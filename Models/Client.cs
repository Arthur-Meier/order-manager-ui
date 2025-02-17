using System.ComponentModel.DataAnnotations;

namespace OrderManager.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email fornecido não é válido.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter 11 números.")]
        public required string Cpf { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório.")]
        public required string Addres { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [DataType(DataType.Date)]
        [AgeValidation(MinimumAge = 18, ErrorMessage = "O cliente deve ter pelo menos 18 anos.")]
        public DateTime Birthday { get; set; }

        public List<Order> Orders { get; set; } = new();
    }

    public class AgeValidation : ValidationAttribute
    {
        public int MinimumAge { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime birthday)
            {
                var age = DateTime.Today.Year - birthday.Year;
                if (birthday > DateTime.Today.AddYears(-age)) age--;
                if (age >= MinimumAge) return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage);
        }
    }
}
