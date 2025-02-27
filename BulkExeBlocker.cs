using System.Diagnostics;

namespace BulkExeBlocker
{
	public partial class BulkExeBlocker : Form
	{
		public BulkExeBlocker()
		{
			InitializeComponent();

			rulePrefixPreviewLabel.Text = $"{rulePrefixTextbox.Text}Block Inbound - Program.exe";
		}

		static string SelectFolder()
		{
			using FolderBrowserDialog dialog = new();
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

		int BlockExeFilesInFolder(string folderPath, string rulePrefix = "")
		{
			if (string.IsNullOrEmpty(rulePrefix))
			{
				rulePrefix = "";
			}

			if (!Directory.Exists(folderPath))
			{
				Globals.ReportToUser("Folder does not exist.", true);
				return 1;
			}

			var exeFiles = Directory.GetFiles(folderPath, "*.exe", SearchOption.AllDirectories);

			if (exeFiles.Length == 0)
			{
				Globals.ReportToUser("No EXE files found in the folder.");
				return 2;
			}

			mainProgressBar.Minimum = 0;
			mainProgressBar.Maximum = exeFiles.Length;
			mainProgressBar.Value = 0;

			foreach (string file in exeFiles)
			{
				BlockExeInFirewall(file, rulePrefix);
				mainProgressBar.Value++;
			}

			return 0;
		}

		static void BlockExeInFirewall(string filePath, string rulePrefix)
		{
			string inRuleName = $"{rulePrefix}Block Inbound - {Path.GetFileName(filePath)}";
			string outRuleName = $"{rulePrefix}Block Outbound - {Path.GetFileName(filePath)}";

			// Block inbound
			ExecuteNetshCommand($"advfirewall firewall add rule name=\"{inRuleName}\" dir=in action=block program=\"{filePath}\" enable=yes");

			// Block outbound
			ExecuteNetshCommand($"advfirewall firewall add rule name=\"{outRuleName}\" dir=out action=block program=\"{filePath}\" enable=yes");

			Globals.ReportToConsole($"Blocked EXE: {filePath}");
		}

		static void ExecuteNetshCommand(string arguments)
		{
			ProcessStartInfo processInfo = new("netsh", arguments)
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
					Globals.ReportToUser("Failed to start process.", true);
					return;
				}

				process.WaitForExit();
				string output = process.StandardOutput.ReadToEnd();
				string error = process.StandardError.ReadToEnd();

				if (!string.IsNullOrEmpty(output))
				{
					// No need to show full output in a message box
					// Shot it only on console
					Globals.ReportToConsole(output);
				}

				if (!string.IsNullOrEmpty(error))
				{
					Globals.ReportToUser(error, true);
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
				Globals.ReportToUser("Please select a folder first.");
				return;
			}

			/*
			if (string.IsNullOrEmpty(rulePrefix))
			{
				Globals.ReportToUser("Please enter a rule prefix first.");
				return;
			}
			*/

			if (BlockExeFilesInFolder(folderPath, rulePrefix) == 0)
			{
				Globals.ReportToUser("Process completed successfully.");
			}
		}

		private void DirectoryBrowseButton_Click(object sender, EventArgs e)
		{
			string folderPath = SelectFolder();

			if (string.IsNullOrEmpty(folderPath))
			{

				Globals.ReportToUser("No folder selected.", true);
				return;
			}

			directoryTextbox.Text = folderPath;
		}
	}
}
