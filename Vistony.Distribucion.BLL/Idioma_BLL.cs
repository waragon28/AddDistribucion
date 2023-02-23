using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vistony.Distribucion.DAL;

namespace Vistony.Distribucion.BLL
{
    public class Idioma_BLL
    {
        Idiomas_DAL idiomas_DAL = new Idiomas_DAL();
        public void GetPackIdiomafrmConsolidation(string Idioma,SAPbouiCOM.Form oForm,
          StaticText StaticText10,
          StaticText StaticText11, StaticText StaticText12,
          CheckBox CheckBox2, CheckBox CheckBox3, StaticText StaticText13,
          Button Button5, Button Button4, Button Button3,
          StaticText StaticText8, StaticText StaticText9)
        {
            idiomas_DAL.GetPackIdiomafrmConsolidation(Idioma, oForm, StaticText10, StaticText11, StaticText12,
                CheckBox2, CheckBox3, StaticText13, Button5, Button4, Button3 ,StaticText8, StaticText9);
        }
        public void FormatoGridConsolidado(Grid Grid1, string Idioma)
        {
            idiomas_DAL.FormatoGridConsolidado(Grid1, Idioma);
        }
        public void FormatoGridIdioma(Grid Grid1, string Idioma)
        {
            idiomas_DAL.FormatoGridIdioma(Grid1, Idioma);
        }
        
        public void GetPackIdiomafrmAsignationConsolidation(string Idioma,Form oForm, StaticText StaticText0,
            StaticText StaticText1,Button Button0, Button Button1)
        {
            idiomas_DAL.GetPackIdiomafrmAsignationConsolidation(Idioma, oForm, StaticText0, StaticText1,
                Button0, Button1);
        }

        public void FormatoGridProgramationHandbook(Grid Grid0,string Idioma)
        {
            idiomas_DAL.FormatoGridProgramationHandbook(Grid0, Idioma);
        }
        public void FormatoGridIdiomaProgramManual(Grid Grid0, string Idioma)
        {
            idiomas_DAL.FormatoGridIdiomaProgramManual(Grid0, Idioma);
        }
        public void GetPackIdiomafrmProgramationHandbook(Form oForm,string Idioma,StaticText StaticText0,StaticText StaticText1,
           StaticText StaticText2,StaticText StaticText7,CheckBox CheckBox0,Button Button1,
           Button Button2,Button Button3,StaticText StaticText8,StaticText StaticText9)
        {
            idiomas_DAL.GetPackIdiomafrmProgramationHandbook(oForm,Idioma, StaticText0,StaticText1,
            StaticText2,StaticText7,CheckBox0,Button1,Button2,Button3, StaticText8, StaticText9);
        }
        public void GetPackIdiomafrmAsignationProgramationManual(string Idioma, Form oForm,
          StaticText StaticText0,StaticText StaticText1,StaticText StaticText2,
          StaticText StaticText3, StaticText StaticText4,StaticText StaticText5)
        {
            idiomas_DAL.GetPackIdiomafrmAsignationProgramationManual(Idioma, oForm, StaticText0, StaticText1, StaticText2,
            StaticText3, StaticText4, StaticText5);
        }

    }
}
