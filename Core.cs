﻿using System;
using System.Reflection;
using Harmony;
using Newtonsoft.Json;

namespace CharlesB
{
    public class Core
    {
        public const string ModName = "CharlesB";
        public const string ModId   = "com.joelmeador.CharlesB";

        internal static Settings ModSettings = new Settings();
        internal static string ModDirectory;

        public static void Init(string directory, string settingsJSON)
        {
            ModDirectory = directory;
            Logger.Setup();
            try
            {
                ModSettings = JsonConvert.DeserializeObject<Settings>(settingsJSON);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                ModSettings = new Settings();
            }

            HarmonyInstance.DEBUG = ModSettings.debug;
            var harmony = HarmonyInstance.Create(ModId);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}