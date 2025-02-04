namespace Loupedeck.BasicOSCPlugin
{
    using System;

    // This class contains the plugin-level logic of the Loupedeck plugin.

    public class BasicOSCPlugin : Plugin
    {
        // Gets a value indicating whether this is an API-only plugin.
        public override Boolean UsesApplicationApiOnly => true;

        // Gets a value indicating whether this is a Universal plugin or an Application plugin.
        public override Boolean HasNoApplication => true;

        // Initializes a new instance of the plugin class.
        public BasicOSCPlugin()
        {
            // Initialize the plugin log.
            PluginLog.Init(this.Log);

            // Initialize the plugin resources.
            PluginResources.Init(this.Assembly);

            if (this.TryGetPluginSetting("OscIp", out var ip))
            {
                this.OscIp = ip;
            }

            if (this.TryGetPluginSetting("OscPort", out var portStr) && Int32.TryParse(portStr, out var port))
            {
                this.OscPort = port;
            }
        }

        // This method is called when the plugin is loaded.
        public override void Load()
        {
            this.SetPluginSetting("OscIp", this.OscIp);
            this.SetPluginSetting("OscPort", this.OscPort.ToString());
        }

        // This method is called when the plugin is unloaded.
        public override void Unload()
        {
        }

        public String OscIp { get; } = "127.0.0.1";
        public Int32 OscPort { get; } = 1280;
    }
}
