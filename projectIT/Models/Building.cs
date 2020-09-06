using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projectIT.Models
{
    public class Building
    {
        [Key]
        public int BuildingId { get; set; }
        
        [Required]
        public string BuildingName { get; set; }
        
        
        public int Status { get; set; }//1- teatar, 2-balet
        [Required]
        
        public int NumberOfSeats { get; set; }
        
        public virtual List<Performance> Performances { get; set; }

        public Building()
        {
            Performances = new List<Performance>();
        }

    }
}