using DeviceCommandApp.CommandCommunication;
using DeviceCommandApp.DeviceAccessor;
using DeviceCommandApp.Model;
using DeviceCommandApp.ViewModel;

namespace DeviceCommandApp.CommandController
{
    /// <summary>
    /// コマンド受信コントローラ
    /// </summary>
    public class CommandControl
    {
        private static CommandControl _Instace = null;
        public static CommandControl Instance
        {
            get
            {
                if (_Instace == null)
                {
                    _Instace = new CommandControl();
                }
                return _Instace;
            }
        }

        public Form1 MainForm { get; set; }
        private MotorCounter motor = new MotorCounter();
        private MainFormViewModel mainFormViewModel = new MainFormViewModel();

        /// <summary>
        /// モーターコマンド受信
        /// </summary>
        /// <param name="command"></param>
        public void ReceiveMotorCommand(MotorCommand command)
        {
            DevicePort.Instance.MoveMotor(command.Move_mm);
            motor.AddCounter(command.Move_mm);
            mainFormViewModel.MotorValue = motor.Counter.ToString() + "mm";
            MainForm.Update(mainFormViewModel);
        }

        /// <summary>
        /// センサーコマンド受信
        /// </summary>
        /// <param name="command"></param>
        public void ReceiveSensorCommand(ReadSensorCommand command)
        {
            var val = DevicePort.Instance.GetSensorValue();
            mainFormViewModel.SensorValue = val.ToString() + "point";
            MainForm.Update(mainFormViewModel);
        }
    }
}
