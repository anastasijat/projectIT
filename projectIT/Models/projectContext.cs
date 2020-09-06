using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace projectIT.Models
{
    public class projectContext:DbContext
    {
        DbSet<Client> Clients { get; set; }
        
        //DbSet<Seat> Seats{ get; set; }

        //DbSet<Performance> Performances { get; set; }
        public projectContext():base("dbProjectIT")
        { }
        public static projectContext Create()
        {
            return new projectContext();
        }

        public System.Data.Entity.DbSet<projectIT.Models.Building> Buildings { get; set; }

        public System.Data.Entity.DbSet<projectIT.Models.Performance> Performances { get; set; }

        public System.Data.Entity.DbSet<projectIT.Models.Seat> Seats { get; set; }
    }
}