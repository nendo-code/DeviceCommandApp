using DeviceCommandApp.CommandCommunication;
using DeviceCommandApp.CommandController;
using DeviceCommandApp.ViewModel;
using System;
using System.Windows.Forms;

namespace DeviceCommandApp
{
    public partial class Form1 : Form
    {
        private CommandThread th;
        public Form1()
        {
            InitializeComponent();
            CommandControl.Instance.MainForm = this;
            th = new CommandThread();
        }

        public void Update(MainFormViewModel mainFormViewModel)
        {
            this.Invoke(new Action(
                            () =>
                            {
                                this.MotorValue.Text = mainFormViewModel.MotorValue;
                                this.SensorValue.Text = mainFormViewModel.SensorValue;
                            }));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            th.EndThred();
        }
    }
}
