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

        
        [Required(ErrorMessage = "Email � necess�rio !")]
        [EmailAddress(ErrorMessage = "Email inv�lido!")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Insira uma senha!")]
        [MinLength(8, ErrorMessage ="A senha deve conter no m�nimo 8 caracteres!")]
        public string Password { get; set; }
    }
}