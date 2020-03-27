using Microsoft.Win32;
using System;
using System.Management;
using System.Net.NetworkInformation;

namespace Learun.Util
{
    public class ComputerHelper
    {
        public static string GetComputerInfo()
        {
            string empty = string.Empty;
            return GetCPUInfo() + "|" + GetDiskDrive() + "|" + GetMacAddressByNetworkInformation();
        }

        public static string ValidateTimeLine(DateTime dtStart, DateTime dtEnd)
        {
            DateTime now = DateTime.Now;
            string empty = string.Empty;
            if (now >= dtStart && now <= dtEnd)
            {
                return "DataRight";
            }
            return "DataError";
        }

        private static string GetCPUInfo()
        {
            string empty = string.Empty;
            return GetHardWareInfo("Win32_Processor", "ProcessorId");
        }

        private static string GetDiskDrive()
        {
            string empty = string.Empty;
            return GetHardWareInfo("Win32_DiskDrive", "Model");
        }

        private static string GetMACInfo()
        {
            string empty = string.Empty;
            return GetHardWareInfo("Win32_BaseBoard", "SerialNumber");
        }

        private static string GetHardWareInfo(string typePath, string key)
        {
            try
            {
                ManagementClass managementClass = new ManagementClass(typePath);
                ManagementObjectCollection instances = managementClass.GetInstances();
                PropertyDataCollection properties = managementClass.Properties;
                PropertyDataCollection.PropertyDataEnumerator enumerator = properties.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        PropertyData current = enumerator.Current;
                        if (current.Name == key)
                        {
                            using (ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = instances.GetEnumerator())
                            {
                                if (managementObjectEnumerator.MoveNext())
                                {
                                    ManagementObject managementObject = (ManagementObject)managementObjectEnumerator.Current;
                                    return managementObject.Properties[current.Name].Value.ToString();
                                }
                            }
                        }
                    }
                }
                finally
                {
                    (enumerator as IDisposable)?.Dispose();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return string.Empty;
        }

        private static string GetMacAddressByNetworkInformation()
        {
            string str = "SYSTEM\\CurrentControlSet\\Control\\Network\\{4D36E972-E325-11CE-BFC1-08002BE10318}\\";
            string text = string.Empty;
            try
            {
                NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
                NetworkInterface[] array = allNetworkInterfaces;
                foreach (NetworkInterface networkInterface in array)
                {
                    if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet && networkInterface.GetPhysicalAddress().ToString().Length != 0)
                    {
                        string name = str + networkInterface.Id + "\\Connection";
                        RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(name, false);
                        if (registryKey != null)
                        {
                            string text2 = registryKey.GetValue("PnpInstanceID", "").ToString();
                            int num = Convert.ToInt32(registryKey.GetValue("MediaSubType", 0));
                            if (text2.Length > 3 && text2.Substring(0, 3) == "PCI")
                            {
                                text = networkInterface.GetPhysicalAddress().ToString();
                                for (int j = 1; j < 6; j++)
                                {
                                    text = text.Insert(3 * j - 1, ":");
                                }
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return text;
        }
    }
}
