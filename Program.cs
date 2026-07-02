using System.IO;

using uzinu.Commands;
using uzinu.Utils;

using UndertaleModLib;
using UndertaleModLib.Util;
using UndertaleModLib.Models;
using static UndertaleModLib.UndertaleReader;

namespace uzinu;

class Program {
	static int Main(string[] args) {

		if (args.Length == 0) { PrintUsage(); return 1; }

		string dataFilePath = args[0];
		string verb = args[1];
		string[] rest = args[2..];

		UndertaleData gmData;
		try {
		using FileStream fs = File.OpenRead(dataFilePath);
			gmData = UndertaleIO.Read(fs, Log.Warn, Log.Debug);
		} catch (Exception e) {
			Log.Error($"Failed to load data.win: {e}");
			return 2;
		}

		return verb switch {
			"decomp" or "dec" => DecompileCommand.Run(gmData, rest),
			_ => Unknown(verb)
		};
	}

	static void PrintUsage() {
		Console.WriteLine("uzinu - better cli for utmodlib\n" +
				"usage: ./uz path/to/data.win <verb> [rest of cmdline]\n" +
				"commands:\n" +
				"  list   <block>       - list assets in block (if the assets can't store names, return count)\n" +
				"  decomp <script_name> - decompile script into gml\n" +
				"  disasm <script_name> - disassemble script into vmasm\n" +
				"  find   <string>      - find references to string in decomp\n\n" +
				"  dump   <block> <meta> [asset] [output] - dump asset from block.\n" +
				"    note: omitting asset name dumps entire block into folder.\n" +
				"    note: trying to dump code will decomp by default.\n" +
				"    note: when dumping animated sprites, [output] becomes the folder name.\n\n" +
				"block list:\n"+ 
				"  Gen8 - game metadata\n  Optn - constant map\n  Sond - maps song names to EmbeddedAudio ids\n  Agrp - audio groups\n  Sprt - sprites\n  Bgnd - backgrounds\n" +
				"  Path - paths\n  Scpt - maps script names to code ids\n  Shdr - shaders\n  Font - fonts\n  Tmln - timelines\n  Objt - game object definitions\n  Room - rooms\n" +
				"  Tpag - texture pages\n  Code - actual game code\n  Vari - variable definitions\n  Func - functions\n  Strg - string list\n  Txtr - spritesheet pointers?\n  Audo - embedded audio\n");
	}

	static int Unknown(string verb) {
		Log.Error($"Unknown verb: {verb}");
		return 1;
	}
}
