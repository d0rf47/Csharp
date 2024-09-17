using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Crawler
{
    class Crawler
    {
        public const string GermanDomain = "https://www.perlesystems.de";
        
        public List<string> ProductPages = new List<string>()
        {
            //"/products/10-100-1000-Ethernet-Extender-Module.shtml",
            //"/products/10-100-1000-Ethernet-Extender.shtml",
            //"/products/10-100-1000-industrial-converters.shtml",
            //"/products/10-100-1000-Industrial-Ethernet-Extender.shtml",
            //"/products/10-100-1000-Industrial-PoE-Ethernet-Extender.shtml",
            //"/products/10-100-1000-Managed-Ethernet-Extender-Module.shtml",
            //"/products/10-100-1000-Managed-Ethernet-Extender.shtml",
            //"/products/10-100-1000-managed-media-converter-module.shtml",
            //"/products/10-100-1000-managed-media-converters.shtml",
            //"/products/10-100-1000-Media-Converter-Module.shtml",
            //"/products/10-100-1000-media-converters.shtml",
            //"/products/10-100-1000-PoE+-Ethernet-Extender.shtml",
            //"/products/10-100-1000-PoE-Ethernet-Extender.shtml",
            //"/products/10-100-1000-poe-industrial-converters.shtml",
            //"/products/10-100-1000-PoE-Media-Converters.shtml",
            ////"/products/10-100-1000-sfp-industrial-converters.shtml",
            ////"/products/10-100-1000-SFP-Managed-Media-Converter-Module.shtml",
            //"/products/10-100-1000-SFP-Managed-Media-Converters.shtml",
            ////"/products/10-100-1000-SFP-Media-Converter-Module.shtml",
            ////"/products/10-100-1000-sfp-media-converters.shtml",
            "/products/10-100-Converters.shtml",
            "/products/10-100-Ethernet-Extender-Module.shtml",
            "/products/10-100-Ethernet-Extender.shtml",
            "/products/10-100-industrial-converters.shtml",
            "/products/10-100-Industrial-Ethernet-Extender.shtml",
            "/products/10-100-Industrial-PoE-Ethernet-Extender.shtml",
            "/products/10-100-Managed-Ethernet-Extender-Module.shtml",
            "/products/10-100-Managed-Ethernet-Extender.shtml",
            "/products/10-100-Managed-Media-Converter-Module.shtml",
            "/products/10-100-managed-media-converters.shtml",
            "/products/10-100-Media-Converter-Module.shtml",
            "/products/10-100-PoE-Ethernet-Extender.shtml",
            "/products/10-100-poe-industrial-converters.shtml",
            "/products/10-100-poe-media-converters.shtml",
            "/products/Console-Server-NEBS.shtml",
            "/products/Electric-Utility-Terminal-Server.shtml",
            "/products/ethernet-extenders/er-s1110-ethernet-repeater.shtml",
            "/products/ethernet-extenders/tc-extender-2001-eth-2s.shtml",
            "/products/Ethernet-IO-Device-Server.shtml",
            "/products/fast-ethernet-fiber-converter-modules.shtml",
            "/products/fast-ethernet-fiber-converter.shtml",
            "/products/Fast-Ethernet-Fiber-Managed-Converter-Module.shtml",
            "/products/fast-ethernet-managed-media-converter-module.shtml",
            "/products/fast-ethernet-managed-media-converters.shtml",
            "/products/Fast-Ethernet-Media-Converter-Module.shtml",
            "/products/Fast-Ethernet-Media-Converters.shtml",
            "/products/gigabit-fiber-converter-modules.shtml",
            "/products/gigabit-fiber-converters.shtml",
            "/products/gigabit-fiber-managed-converter-modules.shtml",
            "/products/gigabit-managed-media-converter-module.shtml",
            "/products/gigabit-managed-media-converters.shtml",
            "/products/Gigabit-Media-Converter-Module.shtml",
            "/products/Gigabit-Media-Converters.shtml",
            "/products/Gigabit-SFP-Managed-Media-Converter-Module.shtml",
            "/products/Gigabit-SFP-Managed-Media-Converters.shtml",
            "/products/Gigabit-SFP-Media-Converter-Module.shtml",
            "/products/Gigabit-SFP-Media-Converters.shtml",
            "/products/industrial-din-rail-power-supplies.shtml",
            "/products/industrial-power-supply/quint-3-phase-xt.shtml",
            "/products/industrial-power-supply/quint-high-input.shtml",
            "/products/industrial-power-supply/quint-ps-12dc-12dc-8-29050078.shtml",
            "/products/industrial-power-supply/quint-ps-12dc-24dc-5-23201318.shtml",
            "/products/industrial-power-supply/quint-ps-1ac-12dc-15-29046088.shtml",
            "/products/industrial-power-supply/quint-ps-1ac-12dc-20-28667218.shtml",
            "/products/industrial-power-supply/quint-ps-1ac-24dc-1.3-pt-29095758.shtml",
            "/products/industrial-power-supply/quint-ps-1ac-24dc-1.3-sc-29045978.shtml",
            "/products/industrial-power-supply/quint-ps-1ac-24dc-10-29046018.shtml",
            "/products/industrial-power-supply/quint-ps-1ac-24dc-2.5-29095768.shtml",
            "/products/industrial-power-supply/quint-ps-1ac-24dc-2.5-sc-29045988.shtml",
            "/products/industrial-power-supply/quint-ps-1ac-24dc-20-29046028.shtml",
            "/products/industrial-power-supply/quint-ps-1ac-24dc-3.5-28667478.shtml",
            "/products/industrial-power-supply/quint-ps-1ac-24dc-3.8-pt-29095778.shtml",
            "/products/industrial-power-supply/quint-ps-1ac-24dc-3.8-sc-29045998.shtml",
            "/products/industrial-power-supply/quint-ps-1ac-24dc-40-28667898.shtml",
            "/products/industrial-power-supply/quint-ps-1ac-24dc-5-29046008.shtml",
            "/products/industrial-power-supply/quint-ps-1ac-48dc-10-29046118.shtml",
            "/products/industrial-power-supply/quint-ps-1ac-48dc-20-28666958.shtml",
            "/products/industrial-power-supply/quint-ps-1ac-48dc-5-29046108.shtml",
            "/products/industrial-power-supply/quint-ps-24dc-12dc-8-23201158.shtml",
            "/products/industrial-power-supply/quint-ps-24dc-24dc-10-23200928.shtml",
            "/products/industrial-power-supply/quint-ps-24dc-24dc-10-co-23205558.shtml",
            "/products/industrial-power-supply/quint-ps-24dc-24dc-20-23201028.shtml",
            "/products/industrial-power-supply/quint-ps-24dc-24dc-20-co-23205688.shtml",
            "/products/industrial-power-supply/quint-ps-24dc-24dc-5-23200348.shtml",
            "/products/industrial-power-supply/quint-ps-24dc-24dc-5-co-23205428.shtml",
            "/products/industrial-power-supply/quint-ps-24dc-48dc-5-23201288.shtml",
            "/products/industrial-power-supply/quint-ps-48dc-24dc-5-23201448.shtml",
            "/products/industrial-power-supply/quint-ps-48dc-48dc-5-29050088.shtml",
            "/products/industrial-power-supply/quint-ps-60-72dc-24dc-10-29050098.shtml",
            "/products/industrial-power-supply/quint-ps-60-72dc-24dc-10-co-29050118.shtml",
            "/products/industrial-power-supply/quint-ps-96-110dc-24dc-10-29050108.shtml",
            "/products/industrial-power-supply/quint-ps-96-110dc-24dc-10-co-29050128.shtml",
            "/products/industrial-power-supply/step-ps-1ac-12dc-1-28685388.shtml",
            "/products/industrial-power-supply/step-ps-1ac-12dc-1.5-28685678.shtml",
            "/products/industrial-power-supply/step-ps-1ac-12dc-1.5-fl-28685548.shtml",
            "/products/industrial-power-supply/step-ps-1ac-12dc-3-28685708.shtml",
            "/products/industrial-power-supply/step-ps-1ac-12dc-5-28685838.shtml",
            "/products/industrial-power-supply/step-ps-1ac-15dc-4-28686198.shtml",
            "/products/industrial-power-supply/step-ps-1ac-24dc-0.5-28685968.shtml",
            "/products/industrial-power-supply/step-ps-1ac-24dc-0.75-28686358.shtml",
            "/products/industrial-power-supply/step-ps-1ac-24dc-0.75-fl-28686228.shtml",
            "/products/industrial-power-supply/step-ps-1ac-24dc-1.75-28686488.shtml",
            "/products/industrial-power-supply/step-ps-1ac-24dc-2.5-28686518.shtml",
            "/products/industrial-power-supply/step-ps-1ac-24dc-3.5-29049458.shtml",
            "/products/industrial-power-supply/step-ps-1ac-24dc-3.8-c2lps-28686778.shtml",
            "/products/industrial-power-supply/step-ps-1ac-24dc-4.2-28686648.shtml",
            "/products/industrial-power-supply/step-ps-1ac-48dc-2-28686808.shtml",
            "/products/industrial-power-supply/step-ps-1ac-5dc-16.5-28685418.shtml",
            "/products/industrial-power-supply/step-ps-1ac-5dc-2-23205138.shtml",
            "/products/industrial-power-supply/step-ps-48ac-24dc-0.5-28687168.shtml",
            "/products/industrial-power-supply/trio-dc-dc-high-input.shtml",
            "/products/industrial-power-supply/trio-ps-2g-1ac-12dc-10-29031588.shtml",
            "/products/industrial-power-supply/trio-ps-2g-1ac-12dc-5-c2lps-29031578.shtml",
            "/products/industrial-power-supply/trio-ps-2g-1ac-24dc-10-29031498.shtml",
            "/products/industrial-power-supply/trio-ps-2g-1ac-24dc-10-b+d-29031458.shtml",
            "/products/industrial-power-supply/trio-ps-2g-1ac-24dc-20-29031518.shtml",
            "/products/industrial-power-supply/trio-ps-2g-1ac-24dc-3-c2lps-29031478.shtml",
            "/products/industrial-power-supply/trio-ps-2g-1ac-24dc-5-29031488.shtml",
            "/products/industrial-power-supply/trio-ps-2g-1ac-24dc-5-b+d-29031448.shtml",
            "/products/industrial-power-supply/trio-ps-2g-1ac-48dc-10-29031608.shtml",
            "/products/industrial-power-supply/trio-ps-2g-1ac-48dc-5-29031598.shtml",
            "/products/industrial-power-supply/uno-2-phase.shtml",
            "/products/industrial-power-supply/uno-dc-dc.shtml",
            "/products/industrial-power-supply/uno-ps-1ac-12dc-100w-29029978.shtml",
            "/products/industrial-power-supply/uno-ps-1ac-12dc-30w-29029988.shtml",
            "/products/industrial-power-supply/uno-ps-1ac-12dc-55w-29029998.shtml",
            "/products/industrial-power-supply/uno-ps-1ac-15dc-100w-29030028.shtml",
            "/products/industrial-power-supply/uno-ps-1ac-15dc-30w-29030008.shtml",
            "/products/industrial-power-supply/uno-ps-1ac-15dc-55w-29030018.shtml",
            "/products/industrial-power-supply/uno-ps-1ac-24dc-100w-29029938.shtml",
            "/products/industrial-power-supply/uno-ps-1ac-24dc-150w-29043768.shtml",
            "/products/industrial-power-supply/uno-ps-1ac-24dc-240w-29043728.shtml",
            "/products/industrial-power-supply/uno-ps-1ac-24dc-30w-29029918.shtml",
            "/products/industrial-power-supply/uno-ps-1ac-24dc-60w-29029928.shtml",
            "/products/industrial-power-supply/uno-ps-1ac-24dc-90w-c2lps-29029948.shtml",
            "/products/industrial-power-supply/uno-ps-1ac-48dc-100w-29029968.shtml",
            "/products/industrial-power-supply/uno-ps-1ac-48dc-60w-29029958.shtml",
            "/products/industrial-power-supply/uno-ps-1ac-5dc-25w-29043748.shtml",
            "/products/industrial-power-supply/uno-ps-1ac-5dc-40w-29043758.shtml",
            "/products/IOLAN+-Terminal-Server.shtml",
            "/products/iolan-dg-device-server.shtml",
            "/products/iolan-dg-tx-device-server.shtml",
            "/products/iolan-ds.shtml",
            "/products/iolan-scg-console-server.shtml",
            "/products/iolan-scgl-console-server.shtml",
            "/products/iolan-scglm-console-server.shtml",
            "/products/iolan-scglw-console-server.shtml",
            "/products/iolan-scglwm-console-server.shtml",
            "/products/iolan-scgm-console-server.shtml",
            "/products/iolan-scgru-console-server.shtml",
            "/products/iolan-scgw-console-server.shtml",
            "/products/iolan-scgwm-console-server-old.shtml",
            "/products/iolan-scgwm-console-server.shtml",
            "/products/iolan-scr1618-console-server.shtml",
            "/products/iolan-scs-terminal-server.shtml",
            "/products/iolan-sdg-device-server.shtml",
            "/products/iolan-sdg-lte-device-server.shtml",
            "/products/iolan-sdg-poe-device-server.shtml",
            "/products/iolan-sdg-tx-device-server.shtml",
            "/products/iolan-sdg-wireless-device-server.shtml",
            "/products/iolan-sds-d.shtml",
            "/products/iolan-sds-rack-terminal-server.shtml",
            "/products/iolan-sdsc-rack-terminal-server.shtml",
            "/products/IOLAN-SDSM-Terminal-Server.shtml",
            "/products/iolan-stg-poe-terminal-server.shtml",
            "/products/iolan-stg-terminal-server.shtml",
            "/products/iolan-sts-d.shtml",
            "/products/IOLAN-STS-Terminal-Server.shtml",
            "/products/Media-Converter-19-Slot-Chassis.shtml",
            "/products/Media-Converter-2-Slot-Chassis.shtml",
            "/products/Media-Converter-Management-Module.shtml",
            "/products/media-converters/10-gigabit-managed-media-converter-modules.shtml",
            "/products/media-converters/10-gigabit-managed-media-converters.shtml",
            "/products/media-converters/10-gigabit-managed-rate-converter-module.shtml",
            "/products/media-converters/10-gigabit-managed-rate-converter.shtml",
            "/products/media-converters/10-gigabit-media-converter-modules.shtml",
            "/products/media-converters/10-gigabit-rate-converter-module.shtml",
            "/products/media-converters/10-gigabit-standalone-media-converters.shtml",
            "/products/media-converters/10-gigabit-standalone-rate-converter.shtml",
            "/products/media-converters/10gbase-t-managed-media-converter-modules.shtml",
            "/products/media-converters/10gbase-t-managed-media-converters.shtml",
            "/products/media-converters/10gbase-t-managed-rate-converter-module.shtml",
            "/products/media-converters/10gbase-t-managed-rate-converter.shtml",
            "/products/media-converters/10gbase-t-media-converter-modules.shtml",
            "/products/media-converters/10gbase-t-rate-converter-module.shtml",
            "/products/media-converters/10gbase-t-standalone-media-converters.shtml",
            "/products/media-converters/10gbase-t-standalone-rate-converter.shtml",
            "/products/media-converters/s-1110hp-hi-poe-media-converters.shtml",
            "/products/media-converters/s-1110hp-sfp-hi-poe-media-converters.shtml",
            "/products/media-converters/s-1110hp-sfp-xt-hi-poe-media-converters.shtml",
            "/products/media-converters/s-1110hp-xt-hi-poe-media-converters.shtml",
            "/products/media-converters/sr-100-din-rail-copper-fiber-converters.shtml",
            "/products/media-converters/sr-100-sfp-din-rail-copper-fiber-converter.shtml",
            "/products/media-converters/sr-100-sfp-xt-din-rail-copper-fiber-converter.shtml",
            "/products/media-converters/sr-1000-din-rail-copper-fiber-converters.shtml",
            "/products/media-converters/sr-1000-sfp-din-rail-copper-fiber-converter.shtml",
            "/products/media-converters/sr-1000-sfp-xt-din-rail-copper-fiber-converter.shtml",
            "/products/media-converters/sr-1000xt-din-rail-copper-fiber-converters.shtml",
            "/products/media-converters/sr-100xt-din-rail-copper-fiber-converters.shtml",
            "/products/media-converters/sr-1110-din-rail-copper-fiber-converters.shtml",
            "/products/media-converters/sr-1110-sfp-din-rail-copper-fiber-converter.shtml",
            "/products/media-converters/sr-1110-sfp-xt-din-rail-copper-fiber-converter.shtml",
            "/products/media-converters/sr-1110xt-din-rail-copper-fiber-converters.shtml",
            "/products/media-converters/srs-1110-sfp-din-rail-copper-fiber-converter.shtml",
            "/products/media-converters/srs-1110f-din-rail-copper-fiber-converters.shtml",
            "/products/media-converters/srs-1110g-din-rail-copper-fiber-converters.shtml",
            "/products/patch-panels/din-rail-pp-rj-f.shtml",
            "/products/patch-panels/din-rail-pp-rj.shtml",
            "/products/pci-express-parallel-card/SPEED1LE1P-Express-1-port-serial-parallel-pci-express-card.shtml",
            "/products/pci-express-serial-port-cards/Speed1LE-express-1-port-serial-card.shtml",
            "/products/pci-serial-port-cards/SPEED1LE-1-port-serial-card.shtml",
            "/products/pci-serial-port-cards/SPEED4LE-4-port-serial-card.shtml",
            "/products/pci-serial-port-cards/SPEED4LEHD-4-port-serial-card.shtml",
            "/products/perleview.shtml",
            "/products/poe-injectors/din-rail-inj-1000.shtml",
            "/products/poe-injectors/din-rail-inj-1100-t.shtml",
            "/products/poe-injectors/din-rail-inj-2100-t.shtml",
            "/products/poe-injectors/pinj30-poe-injector.shtml",
            "/products/Remote-Power-Switch.shtml",
            "/products/routers-gateways/irg5140-cellular-lte-routers.shtml",
            "/products/routers-gateways/irg5410-cellular-lte-routers.shtml",
            "/products/routers-gateways/irg7000-5g-lte-routers.shtml",
            "/products/serial-extenders/psi-modem-shdsl-serial-extender.shtml",
            "/products/serial-extenders/psi-mos-rs232-fo1300e-rs232-to-fiber.shtml",
            "/products/serial-extenders/psi-mos-rs232-fo850e-rs232-to-fiber.shtml",
            "/products/serial-extenders/psi-mos-rs232-fo850t-rs232-to-dual-fiber.shtml",
            "/products/serial-extenders/psi-mos-rs422-fo1300e-rs422-to-fiber.shtml",
            "/products/serial-extenders/psi-mos-rs422-fo850e-rs422-to-fiber.shtml",
            "/products/serial-extenders/psi-mos-rs422-fo850t-rs422-to-dual-fiber.shtml",
            "/products/serial-extenders/psi-mos-rs484w2-fo850t-rs485-to-dual-fiber.shtml",
            "/products/serial-extenders/psi-mos-rs485w2-fo1300e-rs485-to-fiber.shtml",
            "/products/serial-extenders/psi-mos-rs485w2-fo850e-rs485-to-fiber.shtml",
            "/products/serial-extenders/psm-me-rs232-rs485-converter.shtml",
            "/products/serial-extenders/psm-me-rs232-serial-isolator.shtml",
            "/products/serial-extenders/psm-me-rs485-repeater.shtml",
            "/products/serial-parallel-pci-card/SPEED2LE1P-2-port-serial-parallel-pci-card.shtml",
            "/products/sfp-to-sfp-industrial-media-converter.shtml",
            "/products/sfp-to-sfp-managed-media-converter-module.shtml",
            "/products/sfp-to-sfp-managed-media-converter.shtml",
            "/products/sfp-to-sfp-media-converter-module.shtml",
            "/products/sfp-to-sfp-media-converter.shtml",
            "/products/SPEEDLE-Serial-Card.shtml",
            "/products/surge-protectors/dt-lan-cat6-surge-protector.shtml",
            "/products/surge-protectors/dt-tele-shdsl-surge-protector.shtml",
            "/products/switches/5-port-industrial-ethernet-switch.shtml",
            "/products/switches/5-port-industrial-gigabit-ethernet-switch.shtml",
            "/products/switches/5-port-industrial-gigabit-poe-switch.shtml",
            "/products/switches/8-port-industrial-ethernet-switch.shtml",
            "/products/switches/8-port-industrial-poe-switch.shtml",
            "/products/switches/ids-205-industrial-managed-ethernet-switch.shtml",
            "/products/switches/ids-206-industrial-managed-gigabit-switch.shtml",
            "/products/switches/ids-305-industrial-managed-ethernet-switch.shtml",
            "/products/switches/ids-305f-industrial-managed-ethernet-switch.shtml",
            "/products/switches/ids-305g-industrial-managed-gigabit-switch.shtml",
            "/products/switches/ids-306-industrial-managed-gigabit-switch.shtml",
            "/products/switches/ids-409-industrial-managed-ethernet-switch.shtml",
            "/products/switches/ids-409-sfp-industrial-managed-gigabit-switch.shtml",
            "/products/switches/ids-409c-industrial-managed-gigabit-switch.shtml",
            "/products/switches/ids-509-industrial-managed-ethernet-switch.shtml",
            "/products/switches/ids-509-sfp-industrial-managed-gigabit-switch.shtml",
            "/products/switches/ids-509c-industrial-managed-gigabit-switch.shtml",
            "/products/switches/ids-509cpp-industrial-managed-poe-switch.shtml",
            "/products/switches/ids-509f-industrial-managed-ethernet-switch.shtml",
            "/products/switches/ids-509fpp-industrial-managed-poe-switch.shtml",
            "/products/switches/ids-509g-industrial-managed-gigabit-switch.shtml",
            "/products/switches/ids-509gpp-industrial-managed-poe-switch.shtml",
            "/products/switches/ids-509pp-industrial-managed-poe-switch.shtml",
            "/products/switches/ids-710-industrial-managed-ethernet-switch.shtml",
            "/products/switches/ids-710hp-industrial-managed-poe-switch.shtml",
            "/products/UltraPort-Express-Serial-Card.shtml",
            "/products/ultraport-serial-card.shtml",
            "/products/UltraPort-SI-Serial-Card.shtml"
        };
        public void OpenBrowser(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }


    }
}