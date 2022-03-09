using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelefonDefteri.Models.Entities;

namespace TelefonDefteri.Models.KisiModel
{
    public class KisiGuncelleViewModel
    {
        public Kisi kisi { get; set; }
        public List<Kategori> Kategoriler { get; set; }

    }
}