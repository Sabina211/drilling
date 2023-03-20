using Drilling.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Drilling.Models
{
    public class HoleForm
    {
        [Required(ErrorMessage = "Необходимо заполнить поле Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле DrillBlock")]
        public Guid DrillBlockId { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле Depth")]
        [DoubleAttrubute("Depth")]
        public string Depth { get; set; }

        public HoleForm(string name, Guid drillBlockId, string depth)
        {
            Name = name;
            DrillBlockId = drillBlockId;
            Depth = depth;
        }
    }
}
