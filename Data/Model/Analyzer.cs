using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace TestWebApplication.Data.Model
{
    public partial class Analyzer
    {
        public Analyzer()
        {
            AnalyzerChannels = new HashSet<AnalyzerChannel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? MeasureInterval { get; set; }

        public virtual ICollection<AnalyzerChannel> AnalyzerChannels { get; set; }
    }
}
