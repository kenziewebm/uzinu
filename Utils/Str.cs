using UndertaleModLib;
using UndertaleModLib.Models;

namespace uzinu.Utils {
    public static class Str {
        public static string str(UndertaleString s) {
            return s.ToString().Trim('"'); // utmodlib is a piece of shit for this
        }
    }
}