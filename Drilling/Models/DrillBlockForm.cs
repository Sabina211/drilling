using System.ComponentModel.DataAnnotations;

namespace Drilling.Models
{
    public class DrillBlockForm
    {
        [Required(ErrorMessage = "необходимо заполнить поле Name")]
        public string Name { get; set; }

        public DrillBlockForm(string name)
        {
            Name = name;
        }
    }
}
