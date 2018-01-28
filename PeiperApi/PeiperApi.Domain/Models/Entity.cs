using System;
using System.ComponentModel.DataAnnotations;

namespace PeiperApi.Domain.Models
{
    public class Entity
    {
        [Key]
        public int id { get; set; }

        public DateTime created { get; set; }

        public DateTime? updated { get; set; }
    }
}
