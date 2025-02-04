using System.Text.Json;

using Loupedeck;
using Loupedeck.BasicOSCPlugin;

public class SendOscRangeAction : PluginDynamicAdjustment
{
    private Single _currentValue = 0.5f;
    private readonly BasicOSCPlugin _plugin;

    public SendOscRangeAction(BasicOSCPlugin plugin)
        : base("Send OSC Range Message", "Sends OSC values within a range", "OSC", false)
    {            
        this._plugin = plugin;
        this.AddParameter("address", "OSC Address", "OSC");
    }

    protected override void ApplyAdjustment(String actionParameter, Int32 ticks)
    {
        this._currentValue = Math.Clamp(this._currentValue + ticks * 0.05f, 0.0f, 1.0f);
        var settings = JsonSerializer.Deserialize<OscRangeSettings>(actionParameter);
        OscClient.SendOscMessage(settings.IpAddress, settings.Port, settings.Address, this._currentValue);
        this.AdjustmentValueChanged();
    }
}