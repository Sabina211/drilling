using Drilling.Infrastructure.Entities;

namespace Drilling.Models
{
    public class HolePointModel
    {
        public Guid Id { get; set; }
        public Hole Hole { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public HolePointModel(Guid id, Hole hole, double x, double y, double z)
        {
            Id = id;
            Hole = hole;
            X = x;
            Y = y;
            Z = z;
        }
    }
}
