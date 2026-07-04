using UndertaleModLib;
using UndertaleModLib.Models;

using uzinu.Utils;

namespace uzinu.Commands {
    static class ListCommand {
        public static int Run(UndertaleData gmData, string[] args) {
            string blockName = args[0];

            return blockName switch {
                "code" => ListCode(gmData),
                _ => Unknown(blockName)
            };
        }

        private static int ListCode(UndertaleData gmData) {
            foreach(UndertaleCode Script in gmData.Code)
                Console.WriteLine(Script.Name);
            return 0;
        }

        private static int Unknown(string blockName) {
            Log.Error($"Unknown block name: {blockName}");
            return 1;
        }
    }
}