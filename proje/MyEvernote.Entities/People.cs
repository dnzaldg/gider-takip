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
    [Table("Peoples")]
    public class People : MyEntityBase
    {
        [DisplayName("İsim"), 
            StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Name { get; set; }

        [DisplayName("Soyad"), 
            StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Surname { get; set; }

        [Display(Name = "Telefon Numarası")]
        [Required(ErrorMessage = "Telefon alanı gereklidir!")]
        [MaxLength(10, ErrorMessage = "{0} alanı en fazla {1} karakter olmalıdır.")]
        [MinLength(10, ErrorMessage = "{0} alanı en az {1} karakter olmalıdır.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "{0} alanı geçersiz!")]
        public string PhoneNumber { get; set; }

        [DisplayName("Adres"), StringLength(300)]
        public string Address { get; set; }

        [DisplayName("Departman"), Required(ErrorMessage = "{0} alanı gereklidir."), StringLength(50)]
        public string Job { get; set; }

        [DisplayName("Doğum Günü")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]

        public DateTime BirthDay { get; set; }

        [DisplayName("Kullanıcı Adı"), 
            Required(ErrorMessage = "{0} alanı gereklidir."), 
            StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Username { get; set; }

        [DisplayName("E-Posta"), 
            Required(ErrorMessage = "{0} alanı gereklidir."), 
            StringLength(70, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Email { get; set; }

        [DisplayName("Şifre"), 
            Required(ErrorMessage = "{0} alanı gereklidir."), 
            StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Password { get; set; }

        [StringLength(30), ScaffoldColumn(false)]
        public string ProfileImageFilename { get; set; }

        [DisplayName("Aktif")]
        public bool IsActive { get; set; }

        [DisplayName("Yönetici")]
        public bool IsAdmin { get; set; }

        [Required, ScaffoldColumn(false)]
        public Guid ActivateGuid { get; set; }

        [DisplayName("Ofis")]
        public int OfficeId { get; set; }

        public  Office Office { get; set; }
        
        public virtual List<Spend> Spends { get; set; }

        public People()
        {
            Spends = new List<Spend>();
        }


    }
}
