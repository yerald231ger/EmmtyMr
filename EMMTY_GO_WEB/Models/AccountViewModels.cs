using System.ComponentModel.DataAnnotations;

namespace EMMTY_GO_WEB.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [RegularExpression("^[a-zA-Z ]*$",ErrorMessage = "El campo 'Nombre(s)', no puedo contener letras o caracteres especiales")]
        [Display(Name = "Nombre(s)")]
        public string Name { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]*$",ErrorMessage = "El campo 'Apellido(s)', no puedo contener letras o caracteres especiales")]
        [Display(Name = "Apellido(s)")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "El campo 'Email', no es una direccion de correo valida")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [EmailAddress(ErrorMessage = "El campo 'Email Secundario', no es una direccion de correo valida")]
        [Display(Name = "Email Alternativo")]
        public string AlterEmail { get; set; }
        
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono/Celular")]
        public string PhoneNomber { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "'Telefono/Celular Alternativo'")]
        public string AlterPhoneNomber { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }
}
