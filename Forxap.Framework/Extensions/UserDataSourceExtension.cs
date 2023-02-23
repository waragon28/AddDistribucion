using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbouiCOM;


using System.Globalization;
using System.Reflection; 

namespace Forxap.Framework.Extensions
{
    public static class UserDataSourceExtension
    {

        public static void SetUserDataSource(this IForm oForm, string UserDataSourceName, string value)
        {

            if (UserDataSourceName == null)
                throw new ArgumentNullException("UserDataSources");

            if (string.IsNullOrEmpty(UserDataSourceName))
                throw new ArgumentException("No puede ser nulo o vacio.");

            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("No puede ser nulo o vacio.");



            try
            {
                if (value != null)
                {
                   UserDataSource dataSource = oForm.DataSources.UserDataSources.Item(UserDataSourceName);
                    dataSource.ValueEx = value;


                }
            }
            catch
            {


            }

        } 

    }
}
