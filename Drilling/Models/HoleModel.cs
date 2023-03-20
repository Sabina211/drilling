namespace Drilling.Infrastructure.Entities
{
    public class HoleModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DrillBlock DrillBlock { get; set; }
        public double Depth { get; set; }

        public HoleModel(Guid id, string name, DrillBlock drillBlock, double depth)
        {
            Id = id;
            Name = name;
            DrillBlock = drillBlock;
            Depth = depth;
        }
    }
}
