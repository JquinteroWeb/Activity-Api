using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using VehiculosAPI.Entidades;

namespace VehiculosAPI.Models
{
    public class Users:IdentityUser
    {
        public string Documento { get; set; }
        public  string Direccion { get; set; }

        public string movil { get; set; }

        public int TipoDocumentoId { get; set; }
        

        public ICollection<Activities> activity { get; set; }
    }
}
