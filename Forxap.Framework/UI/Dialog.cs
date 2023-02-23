using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Forxap.Framework.UI;

namespace Forxap.Framework.UI.Utils
{
    public class DialogUtil
    {
        private string resultString;

        /// <summary>
        /// Dialogo para selecionar pasta
        /// </summary>
        /// <returns>Pasta Selecionada</returns>
        public string FolderBrowserDialog()
        {
            Thread thread = new Thread(ShowFolderBrowserDialog);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            return resultString;
        }

        /// <summary>
        /// Dialogo para seleccionar archivo
        /// </summary>
        /// <returns>Arcuivo Seleccionado</returns>
        public string OpenFileDialog()
        {
            Thread thread = new Thread(ShowOpenFileDialog);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            return resultString;
        }


    



        /// <summary>
        /// Dialogo para grabar archivo
        /// </summary>
        /// <returns>Archivo Seleccionado</returns>
        public string SaveFileDialog(string ext)
        {

            switch (ext)
            {
                case "txt" :
                    {
                        Thread thread = new Thread(ShowSaveFileDialog);
                        thread.SetApartmentState(ApartmentState.STA);
                        thread.Start();
                        thread.Join();
                    }
                    break;

                case "xls":
                    {
                        Thread thread = new Thread(ShowSaveFileDialogXLS );
                        thread.SetApartmentState(ApartmentState.STA);
                        thread.Start();
                        thread.Join();
                    }
                    break;

                case "xlsx":
                    {
                        Thread thread = new Thread(ShowSaveFileDialogXLSX);
                        thread.SetApartmentState(ApartmentState.STA);
                        thread.Start();
                        thread.Join();
                    }
                    break;

                           

                
            }
            


            return resultString;
        }

        private void ShowFolderBrowserDialog()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog(WindowWrapper.GetForegroundWindowWrapper()) == DialogResult.OK)
            {
                resultString = fbd.SelectedPath;
            }
            System.Threading.Thread.CurrentThread.Abort();
        }

        private void ShowOpenFileDialog(string filter, string title)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = filter; //"Archivo de texto|*.txt";
            ofd.Title = title;  //" Abrir Archivo";


            if (ofd.ShowDialog(WindowWrapper.GetForegroundWindowWrapper()) == DialogResult.OK)
            {
                resultString = ofd.FileName;
            }
            System.Threading.Thread.CurrentThread.Abort();
        }

        private void ShowOpenFileDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Archivo de texto|*.txt";
            ofd.Title = " Abrir Archivo";


            if (ofd.ShowDialog(WindowWrapper.GetForegroundWindowWrapper()) == DialogResult.OK)
            {
                resultString = ofd.FileName;
            }
            System.Threading.Thread.CurrentThread.Abort();
        }


        private void ShowOpenFileDialogXLS()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Archivo de Excel|*.xls";
            ofd.Title = " Abrir Archivo";


            if (ofd.ShowDialog(WindowWrapper.GetForegroundWindowWrapper()) == DialogResult.OK)
            {
                resultString = ofd.FileName;
            }
            System.Threading.Thread.CurrentThread.Abort();
        }

        private void ShowSaveFileDialog()
        {
            SaveFileDialog  saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Archivo de texto|*.txt";
            saveFileDialog.Title = " Guardar Archivo";

            if (saveFileDialog.ShowDialog(WindowWrapper.GetForegroundWindowWrapper()) == DialogResult.OK)
            {
                resultString = saveFileDialog.FileName;
            }
            System.Threading.Thread.CurrentThread.Abort();
        }



        private void ShowSaveFileDialogXLS()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Archivo de excel|*.xls";
            saveFileDialog.Title = " Guardar Archivo";

            if (saveFileDialog.ShowDialog(WindowWrapper.GetForegroundWindowWrapper()) == DialogResult.OK)
            {
                resultString = saveFileDialog.FileName;
            }
            System.Threading.Thread.CurrentThread.Abort();
        }

        private void ShowSaveFileDialogXLSX()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Archivo de excel|*.xlsx";
            saveFileDialog.Title = " Guardar Archivo";

            if (saveFileDialog.ShowDialog(WindowWrapper.GetForegroundWindowWrapper()) == DialogResult.OK)
            {
                resultString = saveFileDialog.FileName;
            }
            System.Threading.Thread.CurrentThread.Abort();
        }




    }// fin de la clase
}// fin del namespace