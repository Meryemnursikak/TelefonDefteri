using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TelefonDefteri.Models.Entities
{
    [Table("Kisiler")]
    public class Kisi
    {

        public int KisiId { get; set; }

        [DisplayName("İsim")]
        public string KisiAdi { get; set; }

        [DisplayName("Soyisim")]
        public string Soyadi { get; set; }

        [DisplayName("Telefon Numarası")]
        public string Telefon { get; set; }

        [DisplayName("Kategori Adı")]
        public int KategoriId { get; set; }

        public Kategori Kategoriler { get; set; }

    }
}