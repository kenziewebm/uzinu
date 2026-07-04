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
                "font" or "fonts" => ListFonts(gmData),
                "objt" or "objects" => ListObjects(gmData),
                "room" or "rooms" => ListRooms(gmData),
                "tpag" or "texturepages" => ListTexturePages(gmData),
                "txtr" or "embeddedtextures" or "textures" => ListEmbeddedTextures(gmData),
                "audo" or "embeddedaudios" or "audios" => ListEmbeddedAudios(gmData),
                "tgin" or "texturegroupinfo" => ListTextureGroupInformation(gmData),
                "embi" or "embeddedimages" => ListEmbeddedImages(gmData),

                "scpt" or "tmln" or "timelines" => NotImplemented(blockName),
                _ => Unknown(blockName)
            };
        }

        /* TODO: This can all theoretically be merged into 
         * ListBlock() {
         *  var block?; i think
         *   blockName switch {
         *     code => block = gmData.Code,
         *     sprt => block = gmData.Sprites,
         *     ...
         *  }
         *  for (var item in block) console.writeline(item.name)
         *  return 0;
         * }
         * but i only thought of that after i already wrote all of this down.
         * and im too lazy to fix it. also i dont think it makes a difference
         * at runtime actually so whatever */

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

        private static int ListFonts(UndertaleData gmData) {
            foreach(UndertaleFont Font in gmData.Fonts) 
               Console.WriteLine(Font.Name.ToString().Trim('"'));
            return 0;
        }

        private static int ListObjects(UndertaleData gmData) {
            foreach(UndertaleGameObject Object in gmData.GameObjects)
                Console.WriteLine(Object.Name.ToString().Trim('"'));
            return 0;
        }

        private static int ListRooms(UndertaleData gmData) {
            foreach(UndertaleRoom Room in gmData.Rooms)
                Console.WriteLine(Room.Name.ToString().Trim('"'));
            return 0;
        }

        private static int ListTextureGroupInformation(UndertaleData gmData) {
            foreach(UndertaleTextureGroupInfo textureGroupInfo in gmData.TextureGroupInfo)
                Console.WriteLine(textureGroupInfo.Name.ToString().Trim('"'));
            return 0;
        }

        private static int ListEmbeddedImages(UndertaleData gmData) {
            foreach(UndertaleEmbeddedImage embeddedImage in gmData.EmbeddedImages)
                Console.WriteLine(embeddedImage.Name.ToString().Trim('"'));
            return 0;
        }

        private static int ListTexturePages(UndertaleData gmData) {
            var count = gmData.TexturePageItems.Count;
            /* Technically, gmData DOES have a name field here, but its unused in UTDR.
             * Instead of returning "TexturePage0, TexturePage1, etc" just return a count. */
            Console.WriteLine($"{count} texture page items (from 0 to {count-1})"); 
            return 0;
        }

        private static int ListEmbeddedTextures(UndertaleData gmData) {
            /* same as above */
            var count = gmData.EmbeddedTextures.Count;
            Console.WriteLine($"{count} embedded textures (from 0 to {count-1})");
            return 0;
        }

        private static int ListEmbeddedAudios(UndertaleData gmData) {
            /* same as above */
            var count = gmData.EmbeddedAudio.Count;
            Console.WriteLine($"{count} embedded audios (from 0 to {count-1})");
            return 0;
        }

        private static int Unknown(string blockName) {
            Log.Error($"Unknown block name: {blockName}");
            return 1;
        }

        private static int NotImplemented(string blockName) {
            Log.Error($"Block not implemented: {blockName}. This is probably because it's empty in UTDR so I can't test it, or listing items is useless.");
            return 2;
        }
    }
}