using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TelefonDefteri.Models.Entities
{
    [Table("Kategoriler")]
    public class Kategori
    {
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
       
    }
}