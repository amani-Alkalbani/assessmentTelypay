using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace assessmentTelypay.Models
{
    public class TelypayDB:DbContext
    {

        public TelypayDB() : base("constr") { }

        public DbSet<User> Users { get; set; }
    }
}