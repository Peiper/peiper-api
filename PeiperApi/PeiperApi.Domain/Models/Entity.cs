using System;
using System.ComponentModel.DataAnnotations;

namespace PeiperApi.Domain.Models
{
    public class Entity
    {
        public string Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Updated { get; set; }
    }
}
