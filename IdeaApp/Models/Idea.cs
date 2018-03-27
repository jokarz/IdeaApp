using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeaApi.Models
{
    public class Idea
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; } // 0 = pending, -1 = rejected, 1 = accepted
    }
}
