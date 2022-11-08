using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace VehiculosAPI.DTOs
{
    public class CredencialesUsuario : IdentityUser
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

    }
}
