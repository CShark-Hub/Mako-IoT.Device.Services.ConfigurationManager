using MakoIoT.Device.Services.Mediator;

namespace MakoIoT.Device.Services.ConfigurationManager.Events
{
    /// <summary>
    /// Signals entering or exiting Configuration Mode.
    /// </summary>
    public class ConfigModeToggleEvent : IEvent
    {
        public SwitchMode Mode { get; set; }
    }
}
