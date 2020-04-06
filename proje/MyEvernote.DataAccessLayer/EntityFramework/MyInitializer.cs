using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyEvernote.Entities;

namespace MyEvernote.DataAccessLayer.EntityFramework
{
    public class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
    //    protected override void Seed(DatabaseContext context)
    //    {
            
    //        // Office ofis = new Office()
    //        //{
    //        //    OfficeName = "Akındizayn",
    //        //    FirmaEmail = "akindayn41@gmail.com",
    //        //    FirmaPhone="5386549874",
    //        //    Website="akindizayn.com",
    //        //    Address="çarıyapı",
    //        //    CreatedOn = DateTime.Now.AddHours(1),
    //        //    ModifiedOn = DateTime.Now.AddMinutes(65),
    //        //    //ModifiedUsername = "denizaladag",
    //        //};
            


    //        // Adding admin user..
    //        People admin = new People()
    //        {
    //            Name = "Deniz",
    //            Surname = "Aladağ",
    //            Email = "denizadalag41@gmail.com",
    //            ActivateGuid = Guid.NewGuid(),
    //            PhoneNumber ="5376597516",
    //            Job = "stajyer",
    //            Office=null,
    //            BirthDay = DateTime.Now,
    //            Address ="yeşilova",
    //            IsActive = true,
    //            IsAdmin = true,
    //            Username = "denizaladag",
    //            ProfileImageFilename = "user_boy.png",
    //            Password = "1",
    //            CreatedOn = DateTime.Now,
    //            ModifiedOn = DateTime.Now.AddMinutes(5),
    //            //ModifiedUsername = "denizaladag"
    //        };

    //        // Adding standart user..
    //        People standartUser = new People()
    //        {
    //            Name = "Atakan",
    //            Surname = "Aladağ",
    //            Email = "atialadag4141@gmail.com",
    //            ActivateGuid = Guid.NewGuid(),
    //            PhoneNumber = "5376597517",
    //            Job = "stajyer2",
    //            BirthDay = DateTime.Now,
    //            Address = "yeşilova",
    //            IsActive = true,
    //            IsAdmin = false,
    //            Username = "atakanaladag",
    //            Password = "654321",
    //            ProfileImageFilename = "user_boy.png",
    //            CreatedOn = DateTime.Now.AddHours(1),
    //            ModifiedOn = DateTime.Now.AddMinutes(65),
    //            //ModifiedUsername = "atakanaladag",
    //            Office=null
    //        };
            
    //        //context.Offices.Add(ofis);
    //        context.Peoples.Add(admin);
    //        context.Peoples.Add(standartUser);
    //        context.SaveChanges();
    //    }
    }
}
