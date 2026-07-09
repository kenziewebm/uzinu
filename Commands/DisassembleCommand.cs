using UndertaleModLib;
using UndertaleModLib.Models;
using UndertaleModLib.Decompiler;

using uzinu.Utils;

namespace uzinu.Commands {
	static class DisassembleCommand {
		public static int Run(UndertaleData gmData, string[] args) {
            string scriptName = args[0];

            UndertaleCode code = gmData.Code.ByName(scriptName);
            if (code == null) {
                Log.Error($"Script {scriptName} not found");
                return 3;
            }
            if (code.ParentEntry is not null) {
				Console.WriteLine($"// This is a lambda function within {code.ParentEntry.Name.Content}, disassemble that instead.");
				return 0;
			} else try {
				string disassembled = code.Disassemble(gmData.Variables, gmData.CodeLocals?.For(code), gmData.CodeLocals is null); 
				Console.WriteLine(disassembled);
				return 0;
			} catch (Exception e) {
				Log.Error($"DISASSEMBLER ERROR! {e}");
				return -1;
			}
        }
    }
}