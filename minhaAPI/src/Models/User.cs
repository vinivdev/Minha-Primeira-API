using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models
{
    public class User
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerSchema(ReadOnly = true)]
        public long Id { get; set; }

        
        [Required(ErrorMessage = "Email é necessário !")]
        [EmailAddress(ErrorMessage = "Email inválido!")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Insira uma senha!")]
        [MinLength(8, ErrorMessage ="A senha deve conter no mínimo 8 caracteres!")]
        public string Password { get; set; }
    }
}