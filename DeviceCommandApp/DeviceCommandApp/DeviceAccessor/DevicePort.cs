using System;

namespace DeviceCommandApp.DeviceAccessor
{
    /// <summary>
    /// デバイスアクセスクラス
    /// </summary>
    public class DevicePort
    {
        private const byte MotorAddr = 0x01;// モーターのレジスタのアドレス
        private const byte SensorAddr = 0x02;// センサーのレジスタのアドレス

        private DeviceDriver driver = new DeviceDriver();
        private static DevicePort _Instace = null;
        public static DevicePort Instance
        {
            get
            {
                if (_Instace == null)
                {
                    _Instace = new DevicePort();
                }
                return _Instace;
            }
        }

        /// <summary>
        /// モーターを動かす
        /// </summary>
        public void MoveMotor(int move_distance_mm)
        {
            driver.WriteRegister(MotorAddr, BitConverter.GetBytes(move_distance_mm));
        }

        /// <summary>
        /// センサーの値を取得する
        /// </summary>
        public int GetSensorValue()
        {
            return BitConverter.ToInt32(driver.ReadRegister(SensorAddr));
        }
    }
}
