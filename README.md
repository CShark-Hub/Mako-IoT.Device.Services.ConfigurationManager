> [!IMPORTANT]
> **This repository has been archived.** Its full history now lives in the
> [`CShark-Hub/Mako-IoT`](https://github.com/CShark-Hub/Mako-IoT) monorepo under `device/services/ConfigurationManager`
> (original `main` tip: tag `legacy/Mako-IoT.Device.Services.ConfigurationManager`).

# Mako-IoT.Device.Services.ConfigurationManager
Provides _configuration mode_ on the device. When entering configuration mode, web server is launched on the device and configuration API is exposed. After finishing config updates the device is rebooted and returns to normal operation mode.

## How to manually sync fork
- Clone repository and navigate into folder
- From command line execute bellow commands
- **git remote add upstream https://github.com/CShark-Hub/Mako-IoT.Base.git**
- **git fetch upstream**
- **git rebase upstream/main**
- If there are any conflicts, resolve them
  - After run **git rebase --continue**
  - Check for conflicts again
- **git push -f origin main**
