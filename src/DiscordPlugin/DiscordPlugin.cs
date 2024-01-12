namespace Loupedeck.DiscordPlugin
{
    using System;

    // This class contains the plugin-level logic of the Loupedeck plugin.

    public class DiscordPlugin : Plugin
    {
        // Gets a value indicating whether this is an API-only plugin.
        public override bool UsesApplicationApiOnly => true;

        // Gets a value indicating whether this is a Universal plugin or an Application plugin.
        public override bool HasNoApplication => true;

        // Initializes a new instance of the plugin class.
        public DiscordPlugin()
        {
            // Initialize the plugin log.
            PluginLog.Init(this.Log);

            // Initialize the plugin resources.
            PluginResources.Init(this.Assembly);
        }

        // This method is called when the plugin is loaded during the Loupedeck service start-up.
        public override void Load()
        {
            base.Info.Icon16x16 = PluginResources.ReadImage("Icon16x16.png");
            base.Info.Icon32x32 = PluginResources.ReadImage("Icon32x32.png");
            base.Info.Icon48x48 = PluginResources.ReadImage("Icon48x48.png");
            base.Info.Icon256x256 = PluginResources.ReadImage("Icon256x256.png");
        }

        // This method is called when the plugin is unloaded during the Loupedeck service shutdown.
        public override void Unload()
        {
        }
    }
}
