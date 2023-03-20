namespace Drilling.Infrastructure.Entities
{
    public class HolePoint
    {
        public Guid Id { get; set; }
        public Hole Hole { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public HolePoint() { }

        public HolePoint(Hole hole, double x, double y, double z)
        {
            Hole = hole;
            X = x;
            Y = y;
            Z = z;
        }
        public HolePoint(Guid id, Hole hole, double x, double y, double z)
        {
            Id = id;
            Hole = hole;
            X = x;
            Y = y;
            Z = z;
        }
    }
}
   