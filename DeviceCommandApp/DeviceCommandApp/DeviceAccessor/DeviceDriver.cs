using System;

namespace DeviceCommandApp.DeviceAccessor
{
    /// <summary>
    /// デバイスドライバ
    /// </summary>
    public class DeviceDriver
    {
        public void WriteRegister(byte addr, byte[] value)
        {
            // ここからHWアクセスする(ダミー)
        }

        public byte[] ReadRegister(byte addr)
        {
            // ここからHWアクセス(ダミー)
            return BitConverter.GetBytes(100);
        }
    }
}
