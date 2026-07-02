namespace uzinu.Utils {
	static class Log {
		static readonly bool OutputColourEnabled = !Console.IsOutputRedirected
			&& Environment.GetEnvironmentVariable("NO_COLOR") is null 
			&& Environment.GetEnvironmentVariable("NO_COLOUR") is null;

		static readonly bool ErrorColourEnabled = !Console.IsErrorRedirected
			&& Environment.GetEnvironmentVariable("NO_COLOR") is null
			&& Environment.GetEnvironmentVariable("NO_COLOUR") is null;

		static readonly bool DebugOutputEnabled = Environment.GetEnvironmentVariable("DEBUG") is not null;

		public static void Error(string msg) => WriteErr("[E]", "\x1b[31m", msg);
		public static void Warn(string msg) => WriteErr("[W]", "\x1b[33m", msg);
		public static void Info(string msg) => WriteOut("[i]", "\x1b[0m", msg);
		public static void Debug(string msg) { if (DebugOutputEnabled)	WriteOut("[d]", "\x1b[34m", msg); }

		public static void Warn(string msg, bool unused) => Warn(msg); // UTModLib wants to pass isImportant but we ignore it

		static void WriteOut(string level, string ansiColour, string msg) {
			if (OutputColourEnabled)
				Console.WriteLine($"{ansiColour}{level}\x1b[0m {msg}");
			else
				Console.WriteLine($"{level} {msg}");
		}

		static void WriteErr(string level, string ansiColour, string msg) {
			if (ErrorColourEnabled)
				Console.Error.WriteLine($"{ansiColour}{level}\x1b[0m {msg}");
			else
				Console.Error.WriteLine($"{level} {msg}");
		}
	}
}
