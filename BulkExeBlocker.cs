using System.Diagnostics;

namespace CSharpFormsTest
{
	public partial class BulkExeBlocker : Form
	{
		public BulkExeBlocker()
		{
			InitializeComponent();

			rulePrefixPreviewLabel.Text = $"{rulePrefixTextbox.Text}Block Inbound - Program.exe";
		}

		static void ReportToUser(string message, bool isError = false)
		{
			// Check if console app
			//if (Console.GetCursorPosition() == (0, 0))
			//{
				MessageBox.Show(message, "Bulk Exe Blocker", MessageBoxButtons.OK, isError ? MessageBoxIcon.Error : MessageBoxIcon.Information);
			//}
			//else
			//{
				Console.WriteLine(isError ? "ERROR: " : "" + message);
			//}
		}

		static string SelectFolder()
		{
			using FolderBrowserDialog dialog = new FolderBrowserDialog();
			DialogResult result = dialog.ShowDialog();
			if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
			{
				return dialog.SelectedPath;
			}
			else
			{
				return "";
			}
		}

		static void BlockExeFilesInFolder(string folderPath, string rulePrefix = "")
		{
			foreach (string file in System.IO.Directory.GetFiles(folderPath, "*.exe", SearchOption.AllDirectories))
			{
				BlockExeInFirewall(file, rulePrefix);
			}
		}

		static void BlockExeInFirewall(string filePath, string rulePrefix)
		{
			string inRuleName = $"{rulePrefix}Block Inbound - {Path.GetFileName(filePath)}";
			string outRuleName = $"{rulePrefix}Block Outbound - {Path.GetFileName(filePath)}";

			// Block inbound
			ExecuteNetshCommand($"advfirewall firewall add rule name=\"{inRuleName}\" dir=in action=block program=\"{filePath}\" enable=yes");

			// Block outbound
			ExecuteNetshCommand($"advfirewall firewall add rule name=\"{outRuleName}\" dir=out action=block program=\"{filePath}\" enable=yes");

			ReportToUser($"Blocked {filePath}");
		}

		static void ExecuteNetshCommand(string arguments)
		{
			ProcessStartInfo processInfo = new ProcessStartInfo("netsh", arguments)
			{
				CreateNoWindow = true,
				UseShellExecute = false,
				RedirectStandardOutput = true,
				RedirectStandardError = true
			};

			using (Process? process = Process.Start(processInfo))
			{
				if (process == null)
				{
					ReportToUser("Failed to start process.", true);
					return;
				}

				process.WaitForExit();
				string output = process.StandardOutput.ReadToEnd();
				string error = process.StandardError.ReadToEnd();

				if (!string.IsNullOrEmpty(output))
				{
					// No need to show full output in a message box
					// Shot it only on console
					Console.WriteLine(output);
				}

				if (!string.IsNullOrEmpty(error))
				{
					ReportToUser(error, true);
				}
			}
		}

		private void RulePrefixTextbox_OnTextChanged(object sender, EventArgs e)
		{
			rulePrefixPreviewLabel.Text = $"{rulePrefixTextbox.Text}Block Inbound - Program.exe";
		}

		private void RunScriptButton_Click(object sender, EventArgs e)
		{
			string folderPath = directoryTextbox.Text;
			string rulePrefix = rulePrefixTextbox.Text;

			if (string.IsNullOrEmpty(folderPath))
			{
				ReportToUser("Please select a folder first.");
				return;
			}

			/*
			if (string.IsNullOrEmpty(rulePrefix))
			{
				ReportToUser("Please enter a rule prefix first.");
				return;
			}
			*/

			BlockExeFilesInFolder(folderPath, rulePrefix);

			ReportToUser("Done!");
		}

		private void DirectoryBrowseButton_Click(object sender, EventArgs e)
		{
			string folderPath = SelectFolder();

			if (string.IsNullOrEmpty(folderPath))
			{

				ReportToUser("No folder selected.", true);
				return;
			}

			directoryTextbox.Text = folderPath;
		}
	}
}
