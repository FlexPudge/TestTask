using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace TestWebApplication.Data.Model
{
    public partial class Channel
    {
        public Channel()
        {
            AnalyzerChannels = new HashSet<AnalyzerChannel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string IsHot { get; set; }

        public virtual ICollection<AnalyzerChannel> AnalyzerChannels { get; set; }
    }
}
