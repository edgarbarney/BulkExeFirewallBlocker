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

		static string SelectFolder()
		{
			using (FolderBrowserDialog dialog = new FolderBrowserDialog())
			{
				DialogResult result = dialog.ShowDialog();
				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
				{
					return dialog.SelectedPath;
				}
				else
				{
					return null;
				}
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

			Console.WriteLine($"Blocked {filePath}");
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

			using (Process process = Process.Start(processInfo))
			{
				process.WaitForExit();
				string output = process.StandardOutput.ReadToEnd();
				string error = process.StandardError.ReadToEnd();

				if (!string.IsNullOrEmpty(output))
				{
					Console.WriteLine(output);
				}

				if (!string.IsNullOrEmpty(error))
				{
					Console.WriteLine("Error: " + error);
				}
			}
		}

		private void rulePrefixTextbox_OnTextChanged(object sender, EventArgs e)
		{
			rulePrefixPreviewLabel.Text = $"{rulePrefixTextbox.Text}Block Inbound - Program.exe";
		}

		private void runScriptButton_Click(object sender, EventArgs e)
		{
			string folderPath = directoryTextbox.Text;
			string rulePrefix = rulePrefixTextbox.Text;

			if (string.IsNullOrEmpty(folderPath))
			{
				MessageBox.Show("Please select a folder first.");
				return;
			}

			/*
			if (string.IsNullOrEmpty(rulePrefix))
			{
				MessageBox.Show("Please enter a rule prefix first.");
				return;
			}
			*/

			BlockExeFilesInFolder(folderPath, rulePrefix);

			MessageBox.Show("Done!");
		}

		private void directoryBrowseButton_Click(object sender, EventArgs e)
		{
			string folderPath = SelectFolder();

			if (string.IsNullOrEmpty(folderPath))
			{
				Console.WriteLine("No folder selected.");
				return;
			}

			directoryTextbox.Text = folderPath;
		}
	}
}
