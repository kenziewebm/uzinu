using UndertaleModLib;
using UndertaleModLib.Models;

using uzinu.Utils;

namespace uzinu.Commands {
    static class ListCommand {
        public static int Run(UndertaleData gmData, string[] args) {
            string blockName = args[0];

            return blockName switch {
                /* Technically there is a seperate Scpt block but all it does is provide
                 * aliases/"pretty names" for stuff in code block. the decomp verb
                 * takes actual script names as they appear in code block anyways */
                "code" or "scripts" => ListCode(gmData),
                "sprt" or "sprites" => ListSprites(gmData),
                "sond" or "sounds" => ListSounds(gmData),
                "agrp" or "audiogroups" => ListAudioGroups(gmData),
                /* UTModTool calls them "tilesets" while the actual gmdata chunk is called
                 * Bgnd so i accept both */
                "bgnd" or "backgrounds" or "tilesets" => ListBackgrounds(gmData),
                "path" or "paths" => ListPaths(gmData),
                "shdr" or "shaders" => ListShaders(gmData),
                _ => Unknown(blockName)
            };
        }

        private static int ListCode(UndertaleData gmData) {
            foreach(UndertaleCode Script in gmData.Code)
                Console.WriteLine(Script.Name.ToString().Trim('"'));
            return 0;
        }
        
        private static int ListSprites(UndertaleData gmData) {
            foreach(UndertaleSprite Sprite in gmData.Sprites)
                Console.WriteLine(Sprite.Name.ToString().Trim('"'));
            return 0;
        }

        private static int ListSounds(UndertaleData gmData) {
            foreach(UndertaleSound Sound in gmData.Sounds)
                Console.WriteLine(Sound.Name.ToString().Trim('"'));
            return 0;
        }

        private static int ListAudioGroups(UndertaleData gmData) {
            foreach(UndertaleAudioGroup AudioGroup in gmData.AudioGroups)
                Console.WriteLine(AudioGroup.Name.ToString().Trim('"'));
            return 0;
        }

        private static int ListBackgrounds(UndertaleData gmData) {
            foreach(UndertaleBackground Background in gmData.Backgrounds)
                Console.WriteLine(Background.Name.ToString().Trim('"'));
            return 0;
        }

        private static int ListPaths(UndertaleData gmData) {
            foreach(UndertalePath Path in gmData.Paths)
                Console.WriteLine(Path.Name.ToString().Trim('"'));
            return 0;
        }

        private static int ListShaders(UndertaleData gmData) {
            foreach(UndertaleShader Shader in gmData.Shaders)
                Console.WriteLine(Shader.Name.ToString().Trim('"'));
            return 0;
        }

        private static int Unknown(string blockName) {
            Log.Error($"Unknown block name: {blockName}");
            return 1;
        }
    }
}