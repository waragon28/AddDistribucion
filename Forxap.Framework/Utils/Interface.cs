using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using Forxap.Framework.Utils;

namespace Forxap.Framework.Utils
{
    public interface IGetList<T>
    {
        List<T> GetList(SAPbobsCOM.Company oCompany, out Sb1Error sb1Error);
    }
    public interface IGetObject <T>
    {
        T GetObject(SAPbobsCOM.Company oCompany, SAPbobsCOM.Recordset oRecordset, string parameter, out Sb1Error sb1Error);
    }
    public interface IRemove
    {
        int Remove();
    }




}
