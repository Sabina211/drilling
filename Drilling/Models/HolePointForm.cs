using Drilling.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Drilling.Models
{
    public class HolePointForm
    {
        [Required(ErrorMessage = "Необходимо заполнить поле HoleId")]
        public Guid HoleId { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле X")]
        [DoubleAttrubute("X")]
        public string X { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле Y")]
        [DoubleAttrubute("Y")]
        public string Y { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить полеZ")]
        [DoubleAttrubute("Z")]
        public string Z { get; set; }
    }
}
