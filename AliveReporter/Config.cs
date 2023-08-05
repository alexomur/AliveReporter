using System.ComponentModel;
using Exiled.API.Interfaces;

namespace AliveReporter
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("Should CASSIE report about this roles?")]
        public bool ReportDclass { get; set; } = true;
        public bool ReportScientist { get; set; } = true;
        public bool ReportGuard { get; set; } = true;
        public bool ReportNtf { get; set; } = true;
        public bool ReportCi { get; set; } = true;
        public bool ReportScp { get; set; } = true;

        [Description("Time interval between reports in seconds")]
        public float ReportTimer { get; set; } = 300f;

        [Description("CASSIE report at the start of the round")]
        public bool ReportOnStart { get; set; } = true;

        [Description("Text that CASSIE will say")]
        public string CassieText { get; set; } = "Personnel Report . . . <color=red> $AliveCounts$ </color>";
    }
}