using UndertaleModLib;
using UndertaleModLib.Models;

namespace uzinu.Blocks {
    static class Gen8 {
        public static string DumpData(UndertaleData gmData) {

            UndertaleGeneralInfo.InfoFlags flags = gmData.GeneralInfo.Info;
            UndertaleGeneralInfo.FunctionClassification funcs = gmData.GeneralInfo.FunctionClassifications;
            UndertaleOptions.OptionsFlags opts = gmData.Options.Info;


            /* this matches UTModTool GUI names, despite MTModLib names being different */

            /* vim macro for this shit, for future use. start with cursor on unformatted line:
             * $^i""<Esc>nwnwd$i"": {opts.HasFlag(UndertaleOptions.OptionsFlags.<Esc>^nwyw$hhhp$i,<Esc>.ToString().ToLower().Trim('"')j
             * NOTE: variable names need to be treated as one word. so they should be camelCase or WhateverCaseThisIs,
             * NOT this_case because this_case is two words and vim will eat half your variable name */

            /* i would like to preemptively apologize to whoever is reading this */

            return @$"{{
""disable_gms_debugger"": {gmData.GeneralInfo.IsDebuggerDisabled.ToString().ToLower().Trim('"')},
""bytecode_version"": {gmData.GeneralInfo.BytecodeVersion},
""filename"": {gmData.GeneralInfo.FileName},
""config"": {gmData.GeneralInfo.Config},
""last_object_id"": {gmData.GeneralInfo.LastObj},
""last_tile_id"": {gmData.GeneralInfo.LastTile},
""game_id"": {gmData.GeneralInfo.GameID},
""directplay_guid"": ""{gmData.GeneralInfo.DirectPlayGuid}"",
""name"": {gmData.GeneralInfo.Name},
""version"": ""{gmData.GeneralInfo.Major}.{gmData.GeneralInfo.Minor}.{gmData.GeneralInfo.Release}.{gmData.GeneralInfo.Build}"",
""default_window_size"": {{
    ""width"": {gmData.GeneralInfo.DefaultWindowWidth},
    ""height"": {gmData.GeneralInfo.DefaultWindowHeight}
}},
""flags"": {{
    ""fullscreen"": {flags.HasFlag(UndertaleGeneralInfo.InfoFlags.Fullscreen).ToString().ToLower().Trim('"')},
    ""sync_vertex_1"": {flags.HasFlag(UndertaleGeneralInfo.InfoFlags.SyncVertex1).ToString().ToLower().Trim('"')},
    ""sync_vertex_2"": {flags.HasFlag(UndertaleGeneralInfo.InfoFlags.SyncVertex2).ToString().ToLower().Trim('"')},
    ""interpolate"": {flags.HasFlag(UndertaleGeneralInfo.InfoFlags.Interpolate).ToString().ToLower().Trim('"')},
    ""scale"": {flags.HasFlag(UndertaleGeneralInfo.InfoFlags.Scale).ToString().ToLower().Trim('"')},
    ""show_cursor"": {flags.HasFlag(UndertaleGeneralInfo.InfoFlags.ShowCursor).ToString().ToLower().Trim('"')},
    ""sizable"": {flags.HasFlag(UndertaleGeneralInfo.InfoFlags.Sizeable).ToString().ToLower().Trim('"')},
    ""screen_key"": {flags.HasFlag(UndertaleGeneralInfo.InfoFlags.ScreenKey).ToString().ToLower().Trim('"')},
    ""sync_vertex_3"": {flags.HasFlag(UndertaleGeneralInfo.InfoFlags.SyncVertex3).ToString().ToLower().Trim('"')},
    ""studio_version_b1"": {flags.HasFlag(UndertaleGeneralInfo.InfoFlags.StudioVersionB1).ToString().ToLower().Trim('"')},
    ""studio_version_b2"": {flags.HasFlag(UndertaleGeneralInfo.InfoFlags.StudioVersionB2).ToString().ToLower().Trim('"')},
    ""studio_version_b3"": {flags.HasFlag(UndertaleGeneralInfo.InfoFlags.StudioVersionB3).ToString().ToLower().Trim('"')},
    ""studio_version_mask"": {flags.HasFlag(UndertaleGeneralInfo.InfoFlags.StudioVersionMask).ToString().ToLower().Trim('"')},
    ""steam_enabled"": {flags.HasFlag(UndertaleGeneralInfo.InfoFlags.SteamEnabled).ToString().ToLower().Trim('"')},
    ""local_data_enabled"": {flags.HasFlag(UndertaleGeneralInfo.InfoFlags.UseAppDataSaveLocation).ToString().ToLower().Trim('"')},
    ""borderless_window"": {flags.HasFlag(UndertaleGeneralInfo.InfoFlags.BorderlessWindow).ToString().ToLower().Trim('"')},
    ""javascript_mode"": {flags.HasFlag(UndertaleGeneralInfo.InfoFlags.JavaScriptMode).ToString().ToLower().Trim('"')},
    ""license_exclusions"": {flags.HasFlag(UndertaleGeneralInfo.InfoFlags.GameRunFromGMS2IDE).ToString().ToLower().Trim('"')}
}},
""license_md5"": ""{Convert.ToHexString(gmData.GeneralInfo.LicenseMD5)}"",
""license_crc32"": {gmData.GeneralInfo.LicenseCRC32},
""timestamp"": {gmData.GeneralInfo.Timestamp},
""display_name"": {gmData.GeneralInfo.DisplayName},
""active_targets"": {gmData.GeneralInfo.ActiveTargets},
""function_classification"": {{
    ""none"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.None).ToString().ToLower().Trim('"')},
    ""internet"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Internet).ToString().ToLower().Trim('"')}, 
    ""joystick"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Joystick).ToString().ToLower().Trim('"')}, 
    ""gamepad"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Gamepad).ToString().ToLower().Trim('"')},
    ""immersion"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Immersion).ToString().ToLower().Trim('"')},
    ""screengrab"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Screengrab).ToString().ToLower().Trim('"')},
    ""math"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Math).ToString().ToLower().Trim('"')}, 
    ""action"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Action).ToString().ToLower().Trim('"')}, 
    ""matrix_d3d"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.MatrixD3D).ToString().ToLower().Trim('"')}, 
    ""d3d_model"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.D3DModel).ToString().ToLower().Trim('"')}, 
    ""data_structures"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.DataStructures).ToString().ToLower().Trim('"')}, 
    ""file"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.File).ToString().ToLower().Trim('"')}, 
    ""ini"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.INI).ToString().ToLower().Trim('"')}, 
    ""filename"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Filename).ToString().ToLower().Trim('"')}, 
    ""directory"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Directory).ToString().ToLower().Trim('"')}, 
    ""environment"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Environment).ToString().ToLower().Trim('"')}, 
    ""http"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.HTTP).ToString().ToLower().Trim('"')}, 
    ""encoding"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Encoding).ToString().ToLower().Trim('"')}, 
    ""ui_dialog"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.UIDialog).ToString().ToLower().Trim('"')}, 
    ""motion_planning"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.MotionPlanning).ToString().ToLower().Trim('"')}, 
    ""shape_collision"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.ShapeCollision).ToString().ToLower().Trim('"')}, 
    ""instance"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Instance).ToString().ToLower().Trim('"')}, 
    ""room"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Room).ToString().ToLower().Trim('"')}, 
    ""game"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Game).ToString().ToLower().Trim('"')}, 
    ""display"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Display).ToString().ToLower().Trim('"')}, 
    ""device"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Device).ToString().ToLower().Trim('"')}, 
    ""window"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Window).ToString().ToLower().Trim('"')}, 
    ""draw_color"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.DrawColor).ToString().ToLower().Trim('"')}, 
    ""texture"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Texture).ToString().ToLower().Trim('"')}, 
    ""layer"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Layer).ToString().ToLower().Trim('"')}, 
    ""string"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.String).ToString().ToLower().Trim('"')}, 
    ""tiles"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Tiles).ToString().ToLower().Trim('"')}, 
    ""surface"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Surface).ToString().ToLower().Trim('"')}, 
    ""skeleton"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Skeleton).ToString().ToLower().Trim('"')}, 
    ""io"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.IO).ToString().ToLower().Trim('"')}, 
    ""variables"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Variables).ToString().ToLower().Trim('"')}, 
    ""array"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Array).ToString().ToLower().Trim('"')}, 
    ""external_call"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.ExternalCall).ToString().ToLower().Trim('"')}, 
    ""notification"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Notification).ToString().ToLower().Trim('"')}, 
    ""date"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Date).ToString().ToLower().Trim('"')}, 
    ""particle"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Particle).ToString().ToLower().Trim('"')}, 
    ""sprite"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Sprite).ToString().ToLower().Trim('"')}, 
    ""clickable"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Clickable).ToString().ToLower().Trim('"')}, 
    ""legacy_sound"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.LegacySound).ToString().ToLower().Trim('"')}, 
    ""audio"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Audio).ToString().ToLower().Trim('"')}, 
    ""event"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Event).ToString().ToLower().Trim('"')}, 
    ""freetype"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.FreeType).ToString().ToLower().Trim('"')}, 
    ""analytics"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Analytics).ToString().ToLower().Trim('"')}, 
    ""achievement"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Achievement).ToString().ToLower().Trim('"')}, 
    ""cloud_saving"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.CloudSaving).ToString().ToLower().Trim('"')}, 
    ""ads"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Ads).ToString().ToLower().Trim('"')}, 
    ""os"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.OS).ToString().ToLower().Trim('"')}, 
    ""iap"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.IAP).ToString().ToLower().Trim('"')}, 
    ""facebook"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Facebook).ToString().ToLower().Trim('"')}, 
    ""physics"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Physics).ToString().ToLower().Trim('"')}, 
    ""flash_aa"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.FlashAA).ToString().ToLower().Trim('"')}, 
    ""console"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Console).ToString().ToLower().Trim('"')}, 
    ""buffer"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Buffer).ToString().ToLower().Trim('"')}, 
    ""steam"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Steam).ToString().ToLower().Trim('"')}, 
    ""shaders"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.Shaders).ToString().ToLower().Trim('"')}, 
    ""vertex_buffers"": {funcs.HasFlag(UndertaleGeneralInfo.FunctionClassification.VertexBuffers).ToString().ToLower().Trim('"')}
}},
""steam_appid"": {gmData.GeneralInfo.SteamAppID},
""debugger_port"": {gmData.GeneralInfo.DebuggerPort},
""fps"": {gmData.GeneralInfo.GMS2FPS},
""allow_statistics"": {gmData.GeneralInfo.GMS2AllowStatistics.ToString().ToLower().Trim('"')},
""game_guid"": ""{Convert.ToHexString(gmData.GeneralInfo.GMS2GameGUID)}"",
""options_flags"": {{
    ""fullscreen"": {opts.HasFlag(UndertaleOptions.OptionsFlags.FullScreen).ToString().ToLower().Trim('"')},
    ""interpolate_pixels"": {opts.HasFlag(UndertaleOptions.OptionsFlags.InterpolatePixels).ToString().ToLower().Trim('"')}, 
    ""use_new_audio"": {opts.HasFlag(UndertaleOptions.OptionsFlags.UseNewAudio).ToString().ToLower().Trim('"')}, 
    ""no_border"": {opts.HasFlag(UndertaleOptions.OptionsFlags.NoBorder).ToString().ToLower().Trim('"')}, 
    ""show_cursor"": {opts.HasFlag(UndertaleOptions.OptionsFlags.ShowCursor).ToString().ToLower().Trim('"')}, 
    ""sizeable"": {opts.HasFlag(UndertaleOptions.OptionsFlags.Sizeable).ToString().ToLower().Trim('"')}, 
    ""stay_on_top"": {opts.HasFlag(UndertaleOptions.OptionsFlags.StayOnTop).ToString().ToLower().Trim('"')}, 
    ""change_resolution"": {opts.HasFlag(UndertaleOptions.OptionsFlags.ChangeResolution).ToString().ToLower().Trim('"')}, 
    ""no_buttons"": {opts.HasFlag(UndertaleOptions.OptionsFlags.NoButtons).ToString().ToLower().Trim('"')}, 
    ""screen_key"": {opts.HasFlag(UndertaleOptions.OptionsFlags.ScreenKey).ToString().ToLower().Trim('"')}, 
    ""help_key"": {opts.HasFlag(UndertaleOptions.OptionsFlags.HelpKey).ToString().ToLower().Trim('"')}, 
    ""quit_key"": {opts.HasFlag(UndertaleOptions.OptionsFlags.QuitKey).ToString().ToLower().Trim('"')}, 
    ""save_key"": {opts.HasFlag(UndertaleOptions.OptionsFlags.SaveKey).ToString().ToLower().Trim('"')}, 
    ""screen_shot_key"": {opts.HasFlag(UndertaleOptions.OptionsFlags.ScreenShotKey).ToString().ToLower().Trim('"')}, 
    ""close_sec"": {opts.HasFlag(UndertaleOptions.OptionsFlags.CloseSec).ToString().ToLower().Trim('"')}, 
    ""freeze"": {opts.HasFlag(UndertaleOptions.OptionsFlags.Freeze).ToString().ToLower().Trim('"')}, 
    ""show_progress"": {opts.HasFlag(UndertaleOptions.OptionsFlags.ShowProgress).ToString().ToLower().Trim('"')}, 
    ""load_transparent"": {opts.HasFlag(UndertaleOptions.OptionsFlags.LoadTransparent).ToString().ToLower().Trim('"')}, 
    ""scale_progress"": {opts.HasFlag(UndertaleOptions.OptionsFlags.ScaleProgress).ToString().ToLower().Trim('"')}, 
    ""display_errors"": {opts.HasFlag(UndertaleOptions.OptionsFlags.DisplayErrors).ToString().ToLower().Trim('"')}, 
    ""write_errors"": {opts.HasFlag(UndertaleOptions.OptionsFlags.WriteErrors).ToString().ToLower().Trim('"')}, 
    ""abort_errors"": {opts.HasFlag(UndertaleOptions.OptionsFlags.AbortErrors).ToString().ToLower().Trim('"')}, 
    ""variable_errors"": {opts.HasFlag(UndertaleOptions.OptionsFlags.VariableErrors).ToString().ToLower().Trim('"')}, 
    ""creation_eventOrder"": {opts.HasFlag(UndertaleOptions.OptionsFlags.CreationEventOrder).ToString().ToLower().Trim('"')}, 
    ""use_frontTouch"": {opts.HasFlag(UndertaleOptions.OptionsFlags.UseFrontTouch).ToString().ToLower().Trim('"')}, 
    ""use_rearTouch"": {opts.HasFlag(UndertaleOptions.OptionsFlags.UseRearTouch).ToString().ToLower().Trim('"')}, 
    ""use_fastCollision"": {opts.HasFlag(UndertaleOptions.OptionsFlags.UseFastCollision).ToString().ToLower().Trim('"')}, 
    ""fast_collision_compatibility"": {opts.HasFlag(UndertaleOptions.OptionsFlags.FastCollisionCompatibility).ToString().ToLower().Trim('"')}, 
    ""disable_sandbox"": {opts.HasFlag(UndertaleOptions.OptionsFlags.DisableSandbox).ToString().ToLower().Trim('"')}, 
    ""enable_copy_on_write"": {opts.HasFlag(UndertaleOptions.OptionsFlags.EnableCopyOnWrite).ToString().ToLower().Trim('"')}, 
    ""legacy_json_parsing"": {opts.HasFlag(UndertaleOptions.OptionsFlags.LegacyJsonParsing).ToString().ToLower().Trim('"')}, 
    ""legacy_number_conversion"": {opts.HasFlag(UndertaleOptions.OptionsFlags.LegacyNumberConversion).ToString().ToLower().Trim('"')}, 
    ""legacy_other_behavior"": {opts.HasFlag(UndertaleOptions.OptionsFlags.LegacyOtherBehavior).ToString().ToLower().Trim('"')}, 
    ""audio_error_behavior"": {opts.HasFlag(UndertaleOptions.OptionsFlags.AudioErrorBehavior).ToString().ToLower().Trim('"')}, 
    ""allow_instance_change"": {opts.HasFlag(UndertaleOptions.OptionsFlags.AllowInstanceChange).ToString().ToLower().Trim('"')}, 
    ""legacy_primitive_drawing"": {opts.HasFlag(UndertaleOptions.OptionsFlags.LegacyPrimitiveDrawing).ToString().ToLower().Trim('"')}
    }}
}}";
        }

        public static string DumpMeta(UndertaleData gmData) => DumpData(gmData);
    }
}