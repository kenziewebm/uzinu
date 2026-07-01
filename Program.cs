using System.IO;

using Underanalyzer.Decompiler;

using UndertaleModLib;
using UndertaleModLib.Util;
using UndertaleModLib.Models;
using UndertaleModLib.Decompiler;
using static UndertaleModLib.UndertaleReader;

class Program {

static int Main(string[] args) {

	UndertaleData? gmData;

	if (args.Length < 2) {
		Console.WriteLine("uzinu: gimmie a data.win on arg1 and a script name on arg2 dipshit");
		return 1;
	}

	Console.WriteLine($"Loading '{args[0]}'...");
	try {
		using FileStream fs = File.OpenRead(args[0]);
		gmData = UndertaleIO.Read(fs, WarningHandler, ShutUp);
	} catch (Exception e) {
		Console.Error.WriteLine(e);
		return 2;
	}

	UndertaleCode code = gmData.Code.ByName(args[1]);
	if (code == null) {
		Console.Error.WriteLine($"[F] theres no code entry called {args[1]}");
		return 3;
	}
	if (code.ParentEntry is not null) {
		Console.WriteLine($"// This is a lambda function within {code.ParentEntry.Name.Content}, decompile that instead.");
		return 0;
	} else try {
		GlobalDecompileContext context = new(gmData);
		String decompiled = new Underanalyzer.Decompiler.DecompileContext(context, code, gmData.ToolInfo.DecompilerSettings).DecompileToString();
		Console.WriteLine(decompiled);
		return 0;
	} catch (Exception e) {
		Console.WriteLine($"/* DECOMPILER ERROR! {e.ToString()}" + "\n*/");
		return -1;
	}

}

static void WarningHandler(string warning, bool isImportant) => Console.WriteLine($"[!] {warning}");
static void MessageHandler(string message) => Console.WriteLine($"[i] {message}");
static void ShutUp(string Message) {}

}
