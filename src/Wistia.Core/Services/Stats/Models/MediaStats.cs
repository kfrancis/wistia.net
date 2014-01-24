using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wistia.Core.Services.Stats.Models
{
    public class MediaStats
    {
        public DateTime date { get; set; }
        public int load_count { get; set; }
        public int play_count { get; set; }
        public double play_rate { get; set; }
        public double hours_watched { get; set; }
        public double engagement { get; set; }
        public int visitors { get; set; }
    }
}
