using System.ComponentModel.DataAnnotations;
using VehiculosAPI.Entidades;

namespace VehiculosAPI.DTOs
{
    public class ActivitiesDTO
    {

        [Key]
        public int ActivitiesId { get; set; }
        public string Description { get; set; }

        public string UsersId { get; set; }
        
    }
}
