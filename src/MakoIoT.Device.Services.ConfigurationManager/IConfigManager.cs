namespace MakoIoT.Device.Services.ConfigurationManager
{
    public interface IConfigManager
    {
        /// <summary>
        /// Processes given operation mode and transitions to next state.
        /// </summary>
        /// <param name="mode">Current operation mode</param>
        /// <returns>True, if normal program logic should be executed; False, if device is in special mode</returns>
        bool ProcessOperationMode(OperationMode mode);
        /// <summary>
        /// Enters device into configuration mode.
        /// </summary>
        void StartConfigMode();
        /// <summary>
        /// Exits device from configuration mode.
        /// </summary>
        void StopConfigMode();
        /// <summary>
        /// Resets all configuration to defaults.
        /// </summary>
        void ResetToDefaults();
    }
}