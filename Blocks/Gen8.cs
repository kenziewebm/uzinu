using UndertaleModLib;
using UndertaleModLib.Models;
using System.Text.Json;

namespace uzinu.Blocks {
	static class Gen8 {

		static Dictionary<string, bool> DumpFlags<T>(T flags) where T : struct, Enum {
			return Enum.GetNames<T>().ToDictionary(
					name => name,
					name => flags.HasFlag(Enum.Parse<T>(name))
				);
		}

		public static string DumpData(UndertaleData gmData) {

			UndertaleGeneralInfo.InfoFlags flags = gmData.GeneralInfo.Info;
			UndertaleGeneralInfo.FunctionClassification funcs = gmData.GeneralInfo.FunctionClassifications;
			UndertaleOptions.OptionsFlags opts = gmData.Options.Info;

			var output = new {
				disable_gms_debugger = gmData.GeneralInfo.IsDebuggerDisabled,
				bytecode_version = gmData.GeneralInfo.BytecodeVersion,
				filename = gmData.GeneralInfo.FileName,
				config = gmData.GeneralInfo.Config,
				last_object_id = gmData.GeneralInfo.LastObj,
				last_tile_id = gmData.GeneralInfo.LastTile,
				game_id = gmData.GeneralInfo.GameID,
				directplay_guid = gmData.GeneralInfo.DirectPlayGuid,
				name = gmData.GeneralInfo.Name,
				version = $"{gmData.GeneralInfo.Major}.{gmData.GeneralInfo.Minor}.{gmData.GeneralInfo.Release}.{gmData.GeneralInfo.Build}",
				default_window_size = new {
					width = gmData.GeneralInfo.DefaultWindowWidth,
					height = gmData.GeneralInfo.DefaultWindowHeight,
				},
				flags = DumpFlags(gmData.GeneralInfo.Info),
				license_md5 = Convert.ToHexString(gmData.GeneralInfo.LicenseMD5),
				license_crc32 = gmData.GeneralInfo.LicenseCRC32,
				timestamp = gmData.GeneralInfo.Timestamp,
				display_name = gmData.GeneralInfo.DisplayName,
				active_targets = gmData.GeneralInfo.ActiveTargets,
				function_classification = DumpFlags(gmData.GeneralInfo.FunctionClassifications),
				steam_appid = gmData.GeneralInfo.SteamAppID,
				debugger_port = gmData.GeneralInfo.DebuggerPort,
				fps = gmData.GeneralInfo.GMS2FPS,
				allow_statistics = gmData.GeneralInfo.GMS2AllowStatistics,
				game_guid = Convert.ToHexString(gmData.GeneralInfo.GMS2GameGUID),
				options_flags = DumpFlags(gmData.Options.Info),
			};
			return JsonSerializer.Serialize(output, new JsonSerializerOptions { WriteIndented = true });
	}

	public static string DumpMeta(UndertaleData gmData) => DumpData(gmData);
	}
}
