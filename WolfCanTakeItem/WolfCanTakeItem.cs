using BepInEx;
using UnityEngine;
using WolfCanTakeItem.Patch;
using static BepInEx.BepInDependency;

namespace WolfCanTakeItem
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    [BepInProcess("Lycans.exe")]
    //soft dépendance avec WolfWithPotionEffect permettant de garder l'effet des potions lors de la transformation en loup
    [BepInDependency("LloydHawkeye.WolfWithPotionEffect", DependencyFlags.SoftDependency)]

    public class WolfCanTakeItem : BaseUnityPlugin
    {
        // Le GUID du plugin doit être unique au plugin que vous créez
        // Il doit également être lisible car est utilisé dans le nom des fichiers de config
        // Changez le nom d'auteur et le nom du plugin afin que le GUID soit correctement
        // initialisé pour votre mod
        public const string PLUGIN_GUID = $"{PLUGIN_AUTHOR}.{PLUGIN_NAME}";
        public const string PLUGIN_AUTHOR = "LloydHawkeye";
        public const string PLUGIN_NAME = "ThirstyWolf";
        public const string PLUGIN_VERSION = "1.0.0";

        private void Awake()
        {
            // Initialise le logger global du plugin
            Log.Init(Logger);
            PlayerControllerPatch.Patch();
        }
    }
}