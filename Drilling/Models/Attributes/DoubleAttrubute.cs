using System.ComponentModel.DataAnnotations;

namespace Drilling.Models.Attributes
{
    public class DoubleAttrubute : ValidationAttribute
    {
        public string Name { get; set; }
        public DoubleAttrubute(string name)
        {
            Name = name; 
        }

        public override bool IsValid(object? value)
        {
            if (value == null || double.TryParse(value.ToString().Replace(".", ","), out _)) return true;
            ErrorMessage = $"Некорректное значение в поле {Name}. Введите вещественное число";
            return false;
        }
    }
}
