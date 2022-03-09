using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TelefonDefteri.Models.Entities;

namespace TelefonDefteri.Models.Context
{
    public class MVCRehberContext:DbContext
    {

        public MVCRehberContext() : base("Server=.;Database=RehberDB;Trusted_Connection=true")
        {

        }

        public DbSet<Kisi> Kisiler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }

    }
}