using System;

namespace DeviceCommandApp.Model
{
    /// <summary>
    /// モーターの累積移動量
    /// </summary>
    public class MotorCounter
    {
        public int Counter { get; private set; } = 0;
        public void AddCounter(int mm)
        {
            Counter += Math.Abs(mm);
        }
    }
}
