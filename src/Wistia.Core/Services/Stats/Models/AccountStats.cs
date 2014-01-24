using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wistia.Core.Services.Stats.Models
{
    public class AccountStats
    {
        public int load_count { get; set; }
        public int play_count { get; set; }
        public double hours_watched { get; set; }
    }
}
