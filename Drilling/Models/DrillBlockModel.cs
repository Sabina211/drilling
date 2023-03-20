namespace Drilling.Models
{
    public class DrillBlockModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime UpdateTime { get; set; }

        public DrillBlockModel(Guid id, string name, DateTime updateTime)
        {
            Id = id;
            Name = name;
            UpdateTime = updateTime;
        }
    }
}
