using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SAPbobsCOM;
using SAPbouiCOM;

namespace Forxap.Framework.Utils
{
    public class Autorization
    {

        public bool validateAuthorization( SAPbobsCOM.Company oCompany, string aUserId, string aFormUID)
        {
            SAPbobsCOM.Recordset oAuth = default(SAPbobsCOM.Recordset);
            oAuth = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string struserid = null;
            //    Return False
            struserid = oCompany.UserName;

            oAuth.DoQuery("select * from UPT1 where 'FormId'='" + aFormUID + "'");


            if ((oAuth.RecordCount <= 0))
            {
                return true;
            }
            else
            {
                string st = null;
                st = oAuth.Fields.Item("PermId").Value.ToString();
                st = "Select * from USR3 where 'PermId'='" + st + "' and 'UserLink'=" + aUserId;
                oAuth.DoQuery(st);
                if (oAuth.RecordCount > 0)
                {
                    if (oAuth.Fields.Item("Permission").Value.ToString() == "N")
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    return true;
                }

            }

            return true;

        }


    }// fin de la clase

}// fin del namespace
