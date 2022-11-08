using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VehiculosAPI.Entidades
{
    public class Activities
    {
        [Key]
        public int ActivitiesId { get; set; }
        public string Description { get; set; }
       
        public string UsersId { get; set; }
        
         

    }
}
