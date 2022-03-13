using System.Runtime.InteropServices;

namespace DeviceCommandApp.CommandCommunication
{
    public class CommandConstants
    {
        // コマンドヘッダサイズ
        public const int HeaderSize = 2;
    }
    /// <summary>
    /// 今回やりとりするコマンドのヘッダデータ定義 超適当プロトコル
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CommandHeader
    {
        public byte Size { get; set; }// コマンドデータサイズ
        public CommandID CommandID;
    }

    /// <summary>
    /// コマンドID
    /// </summary>
    public enum CommandID : byte
    {
        MotorCommand = 0x01,
        SensorCommand = 0x02
    }

    /// <summary>
    /// モーター動かすコマンド
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MotorCommand
    {
        // 何ミリ動かすか
        public int Move_mm { get; set; }
    }

    /// <summary>
    /// センサー読み取るコマンド
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ReadSensorCommand
    {
        // 中身なし
        public byte Reserved { get; set; }
    }
}
