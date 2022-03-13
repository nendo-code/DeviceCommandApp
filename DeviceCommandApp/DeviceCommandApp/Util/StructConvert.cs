using System;
using System.Runtime.InteropServices;

namespace DeviceCommandApp.Util
{
    public static class StructConvert
    {
        /// <summary>
        /// バイト配列を構造体に変換
        /// </summary>
        public static T ConvertToStructure<T>(byte[] data) where T : struct
        {
            int sz = Marshal.SizeOf(new T());
            IntPtr ptr = Marshal.AllocHGlobal(sz);
            Marshal.Copy(data, 0, ptr, sz);
            var t = (T)Marshal.PtrToStructure(ptr, typeof(T));
            Marshal.FreeHGlobal(ptr);

            return t;
        }

        /// <summary>
        /// 構造体をバイト配列に変換
        /// </summary>
        public static byte[] ConvertToBytes<T>(T strucrure) where T : struct
        {
            int sz = Marshal.SizeOf(strucrure);
            byte[] buf = new byte[sz];

            IntPtr ptr = Marshal.AllocHGlobal(sz);
            Marshal.StructureToPtr(strucrure, ptr, false);
            Marshal.Copy(ptr, buf, 0, sz);
            Marshal.FreeHGlobal(ptr);
            return buf;
        }

    }
}
