using Underanalyzer.Decompiler;

using UndertaleModLib;
using UndertaleModLib.Models;
using UndertaleModLib.Decompiler;

using uzinu.Utils;

namespace uzinu.Commands {
	static class DecompileCommand {
		public static int Run(UndertaleData gmData, string[] args) {
			string scriptName = args[0];

			UndertaleCode code = gmData.Code.ByName(scriptName);
			if (code == null) {
				Log.Error($"Script {scriptName} not found");
				return 3;
			}
			if (code.ParentEntry is not null) {
				Console.WriteLine($"// This is a lambda function within {code.ParentEntry.Name.Content}, decompile that instead.");
				return 0;
			} else try {
				GlobalDecompileContext context = new(gmData);
				string decompiled = new DecompileContext(context, code, gmData.ToolInfo.DecompilerSettings).DecompileToString();
				Console.WriteLine(decompiled);
				return 0;
			} catch (Exception e) {
				Log.Error($"DECOMPILER ERROR! {e}");
				return -1;
			}

		}
	}
}
