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
    public class SpendManager : ManagerBase<Spend>
    {
        public new BusinessLayerResult<Spend> Insert(Spend data)
        {
            Spend spn = Find(x => x.Product == data.Product);
            BusinessLayerResult<Spend> res = new BusinessLayerResult<Spend>();

            res.Result = data;

            if (spn == null)
            {
                if (base.Insert(res.Result) == 0)
                {
                    res.AddError(ErrorMessageCode.UserCouldNotInserted, "Kategori eklenemedi.");
                }

            }
            else
            {
                double sonuc =data.Piece * data.Price;
                res.Result.Result = sonuc;

            }

            return res;
        }


            public new BusinessLayerResult<Spend> Update(Spend data)
            {
                Spend db_spn = Find(x => x.Product == data.Product);
                BusinessLayerResult<Spend> res = new BusinessLayerResult<Spend>();
                res.Result = data;

                if (db_spn != null && db_spn.Id != data.Id)
                {
                    return res;
                }

                res.Result = Find(x => x.Id == data.Id);
                res.Result.Product = data.Product;


                if (base.Update(res.Result) == 0)
                {
                    res.AddError(ErrorMessageCode.UserCouldNotUpdated, "Kategori güncellenemedi.");
                }

                return res;
            }

    }
}
