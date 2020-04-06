using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.Entities
{
    [Table("Spends")]
    public class Spend : MyEntityBase
    {
        [DisplayName("Birim Fiyat"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public double Price { get; set; }


        [DisplayName("Ürün"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string Product { get; set; }


        [DisplayName("Adet"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public double Piece { get; set; }

        [DisplayName("Sonuç"),Required(ErrorMessage = "{0} alanı gereklidir.")]
        public double Result { get; set; }


        [DisplayName("Zaman")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Zaman { get; set; }


        [DisplayName("Kategori")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [DisplayName("Personel")]
        public int PeopleId { get; set; }

        public virtual People People { get; set; }



    }
}
