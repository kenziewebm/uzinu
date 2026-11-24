namespace uzinu.Utils {
    public static class Audio {
        public static string getExt(char magic) {
            return magic switch {
                'O' => "ogg",
                'R' => "wav",
                _ => "unk",
            };
        }
    }
}