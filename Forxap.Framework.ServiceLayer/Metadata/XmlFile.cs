using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Threading.Tasks;

namespace Forxap.Framework.ServiceLayer.Metadata
{
    public class XmlFile
    {

        /// <summary>
        ///  Lee las tablas de usuario desde un archivo xml
        /// </summary>
        /// <param name="xmlFile"></param>
        public static void LoadUserTablesFromXmlFile(string xmlFile)
        {
            XmlDocument xmlDocument = new XmlDocument();
            UserTables userTables = new UserTables();


            // verificar que el archivo exista
            if (File.Exists(xmlFile))
            {
                // si el archivo existe entonces lo intenta leer
                xmlDocument.Load(xmlFile);


                /// cargo el nodo con toda la lista de las tablas
                XmlNodeList nodeListTables = xmlDocument.GetElementsByTagName("UserTables");

                ///obtengo una de las tablas
                XmlNodeList nodeListTable = ((XmlElement)nodeListTables[0]).GetElementsByTagName("UserTablesMD");

                /// recorro los nodos de una tabla
                foreach (XmlElement nodo in nodeListTable)
                {

                    int i = 0;

                    XmlNodeList nTableName = nodo.GetElementsByTagName("TableName");

                    XmlNodeList nTableDescription = nodo.GetElementsByTagName("TableDescription");

                    XmlNodeList nTableType = nodo.GetElementsByTagName("TableType");

                    XmlNodeList nArchivable = nodo.GetElementsByTagName("Archivable");
                    XmlNodeList nArchiveDateField = nodo.GetElementsByTagName("ArchiveDateField");



                    //Errors.Sb1Error sb1Error = userTables.CreateUserTable
                    //    (
                    //    nTableName[i].InnerText.Trim(),
                    //    nTableDescription[i].InnerText.Trim(),
                    //    (SAPbobsCOM.BoUTBTableType)Enum.Parse(typeof(SAPbobsCOM.BoUTBTableType), nTableType[i].InnerText),
                    //    (SAPbobsCOM.BoYesNoEnum)Enum.Parse(typeof(SAPbobsCOM.BoYesNoEnum), nArchivable[i].InnerText),
                    //     nArchiveDateField[i].InnerText.Trim()
                    //    );

                    

                }

            }

            else
            {
               // Forxap.Framework.UI.Messages.ShowError("Error: " + xmlFile + " Archivo no existe");
            }


        }




    }// fin de la clase
}// fin del namespace
