using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drilling.Infrastructure.Entities
{
    public class DrillBlock
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime UpdateTime { get; set; }

        public DrillBlock(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            UpdateTime = DateTime.Now;
        }

        public DrillBlock(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public DrillBlock(Guid id, string name, DateTime updateTime)
        {
            Id = id;
            Name = name;
            UpdateTime = updateTime;
        }
    }
}
