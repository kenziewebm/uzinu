using UndertaleModLib;
using uzinu.Utils;
using uzinu.Blocks;

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
                "sond" or "sound" => DumpSond(gmData, args),
                _ => Unknown(blockName)
            };
        }
        private static int Unknown(string blockName) {
            Log.Error($"Unkown block name: {blockName}");
            return 1;
        }
    
        public static int DumpSond(UndertaleData gmData, string[] args) {
            (byte[] Data, string Name)? Sound = Blocks.Sond.dumpData(gmData, args[1]);
            string? output = null;
            try {
                output = args[2];
            } catch (IndexOutOfRangeException) {};
            try {
                if (Sound is not null) {
                    if (output is not null) {
                        File.WriteAllBytes(output, Sound.Value.Data);
                    } else {
                        File.WriteAllBytes(Sound.Value.Name, Sound.Value.Data);
                    }
                } 
                } catch (Exception e) {
                    Log.Error($"Failed to write file: {e.Message}");
                    return 1;
                }
            return 0;
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
