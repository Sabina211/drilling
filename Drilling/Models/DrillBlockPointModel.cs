using Drilling.Infrastructure.Entities;

namespace Drilling.Models
{
    public class DrillBlockPointModel
    {
        public Guid Id { get; set; }
        public DrillBlock DrillBlock { get; set; }
        public int Sequence { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public DrillBlockPointModel(Guid id, DrillBlock drillBlock, int sequence, double x, double y, double z)
        {
            Id = id;
            DrillBlock = drillBlock;
            Sequence = sequence;
            X = x;
            Y = y;
            Z = z;
        }
    }
}
