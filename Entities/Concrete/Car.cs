using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string? ModelYear { get; set; }
        public double DailyPrice { get; set; }
        public string Description { get; set; } 
    }
}
