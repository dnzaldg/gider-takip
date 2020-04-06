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
    [Table("Offices")]
    public class Office : MyEntityBase
    {
        [DisplayName("Ofis Adı"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string OfficeName { get; set; }

        
        [DisplayName("E-mail")]
        [StringLength(50, ErrorMessage = "{0} alanı en fazla {1} karakter uzunluğunda olmalıdır!")]
        [Required(ErrorMessage = "{0} alanı gereklidir!")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                         @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                         ErrorMessage = "Email adresi geçersiz!")]
        public string FirmaEmail { get; set; }

       


        [Display(Name = "Firma Numarası")]
        [Required(ErrorMessage = "Telefon alanı gereklidir!")]
        [MaxLength(10, ErrorMessage = "{0} alanı en fazla {1} karakter olmalıdır.")]
        [MinLength(10, ErrorMessage = "{0} alanı en az {1} karakter olmalıdır.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "{0} alanı geçersiz!")]
        public string FirmaPhone { get; set; }



        [DisplayName("Websitesi"), StringLength(50), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string Website { get; set; }



        [DisplayName("Adres"), StringLength(300)]
        public string Address { get; set; }

        public  List<People> Peoples { get; set; }
        public Office()
        {
            Peoples = new List<People>();
        }
       




    }
}
