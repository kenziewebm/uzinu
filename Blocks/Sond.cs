using UndertaleModLib;
using UndertaleModLib.Models;
using System.Collections.Generic;
using System.Linq;
using uzinu.Utils;

namespace uzinu.Blocks {
    public static class Sond {
        public static (byte[], string)? dumpData(UndertaleData gmData, String soundName) {
            UndertaleSound? target = gmData.Sounds.FirstOrDefault(s => Str.str(s.Name) == soundName);
            if (target == null) {
                Log.Error("No such sound was found");
                return null;
            }
            string ext = Audio.getExt((char)target.AudioFile.Data[0]);
            (byte[], string) resp = (target.AudioFile.Data, $"{Str.str(target.Name)}.{ext}");
            return resp;
        }
    }
}