using Drilling.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Drilling.Models
{
    public class DrillBlockPointForm
    {
        [Required(ErrorMessage = "Необходимо заполнить поле DrillBlockId")]
        public Guid DrillBlockId { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле Sequence")]
        public int Sequence { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле X")]
        [DoubleAttrubute("X")]
        public string X { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле Y")]
        [DoubleAttrubute("Y")]
        public string Y { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле Z")]
        [DoubleAttrubute("Z")]
        public string Z { get; set; }
    }
}
