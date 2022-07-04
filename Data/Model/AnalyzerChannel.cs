using System;
using System.Collections.Generic;

#nullable disable

namespace TestWebApplication.Data.Model
{
    public partial class AnalyzerChannel
    {
        public int Id { get; set; }
        public int? Idanalyzer { get; set; }
        public int? Idchannel { get; set; }

        public virtual Analyzer IdanalyzerNavigation { get; set; }
        public virtual Channel IdchannelNavigation { get; set; }
    }
}
