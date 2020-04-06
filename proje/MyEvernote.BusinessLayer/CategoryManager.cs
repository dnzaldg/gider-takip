using MyEvernote.BusinessLayer.Abstract;
using MyEvernote.BusinessLayer.Results;
using MyEvernote.DataAccessLayer.EntityFramework;
using MyEvernote.Entities;
using MyEvernote.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.BusinessLayer
{
    public class CategoryManager : ManagerBase<Category>
    {
        DatabaseContext databaseContext = new DatabaseContext();

        public new BusinessLayerResult<Category> Insert(Category data)
        {
            Category cat = Find(x => x.CategoryType == data.CategoryType);
            BusinessLayerResult<Category> res = new BusinessLayerResult<Category>();

            res.Result = data;

            if (cat != null)
            {
                if (cat.CategoryType.ToUpper() == data.CategoryType.ToUpper())
                {
                    res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Kategori adı kayıtlı.");
                }

            }
            else
            {

                if (base.Insert(res.Result) == 0)
                {
                    res.AddError(ErrorMessageCode.UserCouldNotInserted, "Kategori eklenemedi.");
                }
            }

            return res;
        }

        public new BusinessLayerResult<Category> Update(Category data)
        {
            Category db_cat = Find(x => x.CategoryType == data.CategoryType);
            BusinessLayerResult<Category> res = new BusinessLayerResult<Category>();
            res.Result = data;

            if (db_cat != null && db_cat.Id != data.Id)
            {
                if (db_cat.CategoryType == data.CategoryType)
                {
                    res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Kategori adı kayıtlı.");
                }

                return res;
            }

            res.Result = Find(x => x.Id == data.Id);
            res.Result.CategoryType = data.CategoryType;


            if (base.Update(res.Result) == 0)
            {
                res.AddError(ErrorMessageCode.UserCouldNotUpdated, "Kategori güncellenemedi.");
            }

            return res;
        }


        //public override int Delete(Category category)
        //{
        //    SpendManager noteManager = new SpendManager();

        //    // Kategori ile ilişkili notların silinmesi gerekiyor.
        //    foreach (Spend note in category.Notes.ToList())
        //    {


        //        noteManager.Delete(note);
        //    }

        //    return base.Delete(category);
        //}
    }
}
