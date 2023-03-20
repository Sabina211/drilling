using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drilling.Infrastructure.Entities
{
    public class Hole
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DrillBlock DrillBlock { get; set; }
        public double Depth { get; set; }

        public Hole() { }

        public Hole(string name, DrillBlock drillBlock, double depth)
        {
            Name = name;
            DrillBlock = drillBlock;
            Depth = depth;
        }

        public Hole(Guid id, string name, DrillBlock drillBlock, double depth)
        {
            Id = id;
            Name = name;
            DrillBlock = drillBlock;
            Depth = depth;
        }
    }
}
