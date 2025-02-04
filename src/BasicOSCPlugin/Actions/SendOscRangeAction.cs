using System.Text.Json;

using Loupedeck;
using Loupedeck.BasicOSCPlugin;

public class SendOscRangeAction : PluginDynamicAdjustment
{
    private Single _currentValue = 0.0f;

    public SendOscRangeAction()
        : base("Send OSC Range Message", "Sends OSC values within a range", "OSC", false) 
            => this.MakeProfileAction("text;OSC Settings:");

    protected override void ApplyAdjustment(String actionParameter, Int32 ticks)
    {
        var settings = JsonSerializer.Deserialize<OscRangeSettings>(actionParameter);
        this._currentValue = Math.Clamp(this._currentValue + ticks * 0.05f, settings.Min, settings.Max);
        OscClient.SendOscMessage(settings.IpAddress, settings.Port, settings.Address, this._currentValue);
        this.AdjustmentValueChanged();
    }
}