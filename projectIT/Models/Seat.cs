using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projectIT.Models
{
    public class Seat
    {
        [Key]
        public int SeatId { get; set; }


        
        public Boolean status { get; set; }

        public int PerformanceId { get; set; }
        
        public Performance Performance { get; set; }
        
    }
}