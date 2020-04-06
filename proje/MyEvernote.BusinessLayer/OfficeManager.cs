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
    public class OfficeManager : ManagerBase<Office>
    {

        DatabaseContext databaseContext = new DatabaseContext();
        public new BusinessLayerResult<Office> Insert(Office data)
        {
            Office ofis = Find(x => x.OfficeName == data.OfficeName);
            BusinessLayerResult<Office> res = new BusinessLayerResult<Office>();

            res.Result = data;

            if (ofis != null)
            {
                if (ofis.OfficeName.ToUpper() == data.OfficeName.ToUpper())
                {
                    res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Ofis adı kayıtlı.");
                }

            }
            else
            {

                if (base.Insert(res.Result) == 0)
                {
                    res.AddError(ErrorMessageCode.UserCouldNotInserted, "Ofis eklenemedi.");
                }
            }

            return res;
        }

    }
}
