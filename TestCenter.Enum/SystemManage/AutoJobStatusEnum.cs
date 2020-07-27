using System.ComponentModel;

namespace TestCenter.Enum.SystemManage
{
    public enum AutoJobStatusEnum
    {
        [Description("运行中")]
        Yes = 1,

        [Description("停止")]
        No = 2
    }
}
