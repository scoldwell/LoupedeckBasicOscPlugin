using System.Text.Json;
using System.Text.Json.Serialization;

using Loupedeck;
using Loupedeck.BasicOSCPlugin;

public class SendOscToggleAction : PluginDynamicCommand
{
    private Boolean _state = false;
    private readonly BasicOSCPlugin _plugin;

    public SendOscToggleAction(BasicOSCPlugin plugin)
        : base("Send OSC Message", "Sends an OSC toggle message", "OSC")
    {
        this._plugin = plugin;
        this.AddParameter("settings", "OSC Settings", "OSC");
    }

    protected override void RunCommand(String actionParameter)
    {
        this._state = !this._state;
        var value = this._state ? 1.0f : 0.0f;
        var settings = JsonSerializer.Deserialize<OscToggleSettings>(actionParameter);
        OscClient.SendOscMessage(settings.IpAddress, settings.Port, settings.Address, value);
        this.ActionImageChanged();
    }

    protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        => this._state ? EmbeddedResources.ReadImage("Loupedeck.ToggleOn.png") : EmbeddedResources.ReadImage("Loupedeck.ToggleOff.png");
}