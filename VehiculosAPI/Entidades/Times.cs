﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VehiculosAPI.Entidades
{
    public class Times
    {
        [Key]
        public int TimesId { get; set; }
        public int TimeWork { get; set; }
        public DateTime? Date { get; set; }
        public int ActivitiesId { get; set; }        
        [JsonIgnore]
        public Activities? Activities { get; set; }

    }
}
