using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forxap.Framework.Utils
{
    public class Paths : Base
    {

        /// <summary>
        ///  retorna la ruta donde se deben importar/exportar los documentos en excel
        /// </summary>
        /// <returns></returns>
        public static string GetExcelDocsPath()
        {
            return oCompany.ExcelDocsPath;
        }


        /// <summary>
        ///  retorna la ruta donde se deben importar/exportar las imagenes
        /// </summary>
        /// <returns></returns>
        public static string GetBitMapPath()
        {
            return oCompany.BitMapPath;
        }



        /// <summary>
        ///  retorna la ruta donde se deben importar/exportar los archivos atachados
        /// </summary>
        /// <returns></returns>
        public static string GetAttachMentPath()
        {
            return oCompany.AttachMentPath;
        }


        /// <summary>
        /// retorna la ruta donde se deben importar o exportar archivos word
        /// </summary>
        /// <returns></returns>
        public static string GetWordDocsPath()
        {
            return oCompany.WordDocsPath;
            

           

        }

    }// fin de la clase

}// fin del namespace
