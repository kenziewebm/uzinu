using UndertaleModLib;
using uzinu.Utils;

namespace uzinu.Commands {
    static class DumpCommand {
        public static int Run(UndertaleData gmData, string[] args) {

            string blockName;
            
            try {
                Log.Debug($"args0 {args[0]}");
                blockName = args[0];
            } catch (IndexOutOfRangeException) {
                Log.Error("Not enough arguments!");
                return 4;
            };

            return blockName switch {
                "gen8" or "generalinfo" => DumpGen8(gmData, args),
                _ => Unknown(blockName)
            };
        }
        private static int Unknown(string blockName) {
            Log.Error($"Unkown block name: {blockName}");
            return 1;
        }
        public static int DumpGen8(UndertaleData gmData, string[] args) {
            string Gen8 = Blocks.Gen8.DumpData(gmData);
            string? output = null;
            try {
                output = args[1];
            } catch (IndexOutOfRangeException) {};
            if (output is not null) {
                try {
                    File.WriteAllText(output, Gen8);
                } catch (Exception e) {
                    Log.Error($"Failed to write file: {e.Message}");
                    return 5;
                }
            } else {
                Console.WriteLine(Gen8);
            }
            return 0;
        }
    }
}
