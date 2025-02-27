namespace BulkExeBlocker
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();

			Globals.Init(args);
			Application.Run(new BulkExeBlocker());
		}
	}

	static class Globals
	{
		public static bool LoggingEnabled { get; private set; } = false;

		public static void Init(string[] args)
		{
			// Load settings
			// Check for "-debug" argument
			// Check for "-log" argument
			if (args.Contains("-log") || args.Contains("-debug"))
			{
				LoggingEnabled = true;
				// Start the log file
				// Rewrite if already exists
				File.WriteAllLines("BulkExeBlocker.log", new string[] { "BulkExeBlocker started." });
			}
		}

		public static void ReportToUser(string message, bool isError = false)
		{
			MessageBox.Show(message, "Bulk Exe Blocker", MessageBoxButtons.OK, isError ? MessageBoxIcon.Error : MessageBoxIcon.Information);
			
			ReportToConsole(message, isError);
		}

		public static void ReportToConsole(string message, bool isError = false)
		{
			Console.WriteLine(isError ? "ERROR: " : "" + message);

			if (LoggingEnabled)
			{
				File.AppendAllLines("BulkExeBlocker.log", new string[] { $"[{DateTime.Now.ToString()}] | {(isError ? "ERROR: " : "")}{message}" });
			}
		}
	}
}