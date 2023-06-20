//#define AD_BO
#define AD_PE
//#define AD_MA
//#define AD_ES
//#define AD_CL
//#define AD_PY
//#define AD_EC

using Forxap.Framework.Extensions;
using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vistony.Distribucion.DAL;
using Vistony.Distribucion.DAL.Idiomas;

namespace Vistony.Distribucion.DAL
{
   public  class Idiomas_DAL
    {
        /*============================================================================*/
                     /*===============INICIO CONSOLIDADO  =============== */
        /*============================================================================*/
            public void GetPackIdiomafrmConsolidation(string Idioma,
               Form oForm,StaticText StaticText10, StaticText StaticText11, StaticText StaticText12,
               CheckBox CheckBox2, CheckBox CheckBox3, StaticText StaticText13, Button Button5,
               Button Button4, Button Button3, StaticText StaticText8, StaticText StaticText9)
            {
              if (Idioma== "English (United States)")
              {
                oForm.Title = English_United_States.Consolidación_de_entregas;
                StaticText10.Caption = English_United_States.Fecha_de_Documento;
                StaticText11.Caption = English_United_States.Desde;
                StaticText12.Caption = English_United_States.Hasta;
                CheckBox2.Caption = English_United_States.Consolidado;
                CheckBox3.Caption = English_United_States.Con_Agencia;
                StaticText13.Caption= English_United_States.Busqueda;
                Button5.Caption = English_United_States.Buscar;
                Button4.Caption = English_United_States.Cancelar;
                Button3.Caption = English_United_States.Consolidar;
                StaticText8.Caption = English_United_States.Total_documentos;
                StaticText9.Caption = English_United_States.Total_Peso;
              }
               else if (Idioma == "French")
                {
                    oForm.Title = Frances.Consolidación_de_entregas;
                    StaticText10.Caption = Frances.Fecha_de_Documento;
                    StaticText11.Caption = Frances.Desde;
                    StaticText12.Caption = Frances.Hasta;
                    CheckBox2.Caption = Frances.Consolidado;
                    CheckBox3.Caption = Frances.Con_Agencia;
                    StaticText13.Caption = Frances.Busqueda;
                    Button5.Caption = Frances.Buscar;
                    Button4.Caption = Frances.Cancelar;
                    Button3.Caption = Frances.Consolidar;
                    StaticText8.Caption = Frances.Total_documentos;
                    StaticText9.Caption = Frances.Total_Peso;
                }
                else
                {
#if AD_PE
                oForm.Title = "Consolidación de entregas";
#elif AD_CL
                oForm.Title = "Consolidación de Factura";
#elif AD_EC
                oForm.Title = "Consolidación de entregas";
#else
                oForm.Title = "Consolidación de entregas";
#endif
                StaticText10.Caption = "Fecha de Documento";
                    StaticText11.Caption = "Desde";
                    StaticText12.Caption = "Hasta";
                    CheckBox2.Caption = "Consolidado    ";
                    CheckBox3.Caption = "Con Agencia       ";
                    StaticText13.Caption = "Búsqueda";
                    Button5.Caption = "Buscar ";
                    Button4.Caption = "Cerrar";
                    Button3.Caption = "Consolidar";
                    StaticText8.Caption = "Total documentos seleccionados";
                    StaticText9.Caption = "Total peso doc. seleccionados";
                }
            }
            public void FormatoGridConsolidado(Grid Grid1,string Idioma)
            {
                if (Idioma == "English (United States)")
                {
                        Grid1.DataTable.Columns.Add(English_United_States.Marcar, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
#if AD_PE
                 Grid1.DataTable.Columns.Add(English_United_States.Entrega, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                        Grid1.DataTable.Columns.Add(English_United_States.Fecha_Entrega, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
#elif AD_CL
                Grid1.DataTable.Columns.Add("Invoice", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add("Date Invoice", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
#else
                 Grid1.DataTable.Columns.Add(English_United_States.Entrega, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                        Grid1.DataTable.Columns.Add(English_United_States.Fecha_Entrega, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
#endif
                Grid1.DataTable.Columns.Add(English_United_States.Numero_Legal, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                        Grid1.DataTable.Columns.Add(English_United_States.Codigo_SN, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                        Grid1.DataTable.Columns.Add(English_United_States.Nombre_SN, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                        Grid1.DataTable.Columns.Add(English_United_States.Consolidado, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                        Grid1.DataTable.Columns.Add(English_United_States.Fecha_Consolidacion, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                        Grid1.DataTable.Columns.Add(English_United_States.Hora_Consolidacion, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                        Grid1.DataTable.Columns.Add(English_United_States.Fecha_Requerida, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                        Grid1.DataTable.Columns.Add(English_United_States.Peso_Bruto, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                   
                 }
                else if (Idioma == "French")
                {
                    Grid1.DataTable.Columns.Add(Frances.Marcar, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    Grid1.DataTable.Columns.Add(Frances.Entrega, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    Grid1.DataTable.Columns.Add(Frances.Fecha_Entrega, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                     Grid1.DataTable.Columns.Add(Frances.Numero_Legal, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    Grid1.DataTable.Columns.Add(Frances.Codigo_SN, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    Grid1.DataTable.Columns.Add(Frances.Nombre_SN, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    Grid1.DataTable.Columns.Add(Frances.Consolidado, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    Grid1.DataTable.Columns.Add(Frances.Fecha_Consolidacion, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    Grid1.DataTable.Columns.Add(Frances.Hora_Consolidacion, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    Grid1.DataTable.Columns.Add(Frances.Fecha_Requerida, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    Grid1.DataTable.Columns.Add(Frances.Peso_Bruto, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                }
                else
                {
                    Grid1.DataTable.Columns.Add("Marcar", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
#if AD_PE
                 Grid1.DataTable.Columns.Add("Entrega", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    Grid1.DataTable.Columns.Add("Fecha Entrega", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
#elif AD_CL
                Grid1.DataTable.Columns.Add("Factura", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add("Fecha Factura", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
#else
#endif

                Grid1.DataTable.Columns.Add("Número Legal", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    Grid1.DataTable.Columns.Add("Código SN", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    Grid1.DataTable.Columns.Add("Nombre SN", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    Grid1.DataTable.Columns.Add("Consolidado", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    Grid1.DataTable.Columns.Add("Fecha Consolidación", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    Grid1.DataTable.Columns.Add("Hora Consolidación", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    Grid1.DataTable.Columns.Add("Fecha Requerida", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    Grid1.DataTable.Columns.Add("Peso Bruto", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                
                }

                Grid1.Columns.Item(1).Editable = false;
                Grid1.Columns.Item(2).Editable = false;
                Grid1.Columns.Item(3).Editable = false;
                Grid1.Columns.Item(4).Editable = false;
                Grid1.Columns.Item(5).Editable = false;
                Grid1.Columns.Item(6).Editable = false;
                Grid1.Columns.Item(7).Editable = false;
                Grid1.Columns.Item(8).Editable = false;
                Grid1.Columns.Item(9).Editable = false;
                Grid1.Columns.Item(10).Editable = false;
                Grid1.AutoResizeColumns();
            }
            public void FormatoGridIdioma(Grid Grid1,string Idioma)
            {
                if (Idioma == "English (United States)")
                {
                        Grid1.Columns.Item(0).TitleObject.Caption = English_United_States.Marcar;
                        Grid1.Columns.Item(2).TitleObject.Caption = English_United_States.Entrega;
                        Grid1.Columns.Item(3).TitleObject.Caption = English_United_States.Fecha_de_Documento;
                        Grid1.Columns.Item(4).TitleObject.Caption = English_United_States.Numero_Legal;
                        Grid1.Columns.Item(5).TitleObject.Caption = English_United_States.Fecha_Entrega;
                        Grid1.Columns.Item(6).TitleObject.Caption = English_United_States.Codigo_SN;
                        Grid1.Columns.Item(7).TitleObject.Caption = English_United_States.Nombre_SN;
                        Grid1.Columns.Item(8).TitleObject.Caption = English_United_States.Ubigeo;
                        Grid1.Columns.Item(10).TitleObject.Caption = English_United_States.Consolidado;
                        Grid1.Columns.Item(11).TitleObject.Caption = English_United_States.Fecha_Consolidacion;
                        Grid1.Columns.Item(12).TitleObject.Caption = English_United_States.Hora_Consolidacion;
                        Grid1.Columns.Item(13).TitleObject.Caption = English_United_States.Fecha_Requerida;
                        Grid1.Columns.Item(14).TitleObject.Caption = English_United_States.Peso_Bruto;
                }
                else if (Idioma == "French")
                {
                    Grid1.Columns.Item(0).TitleObject.Caption = Frances.Marcar;
                    Grid1.Columns.Item(2).TitleObject.Caption = Frances.Entrega;
                    Grid1.Columns.Item(3).TitleObject.Caption = Frances.Fecha_de_Documento;
                    Grid1.Columns.Item(4).TitleObject.Caption = Frances.Numero_Legal;
                    Grid1.Columns.Item(5).TitleObject.Caption = Frances.Fecha_Entrega;
                    Grid1.Columns.Item(6).TitleObject.Caption = Frances.Codigo_SN;
                    Grid1.Columns.Item(7).TitleObject.Caption = Frances.Nombre_SN;
                    Grid1.Columns.Item(8).TitleObject.Caption = Frances.Ubigeo;
                    Grid1.Columns.Item(10).TitleObject.Caption = Frances.Consolidado;
                    Grid1.Columns.Item(11).TitleObject.Caption = Frances.Fecha_Consolidacion;
                    Grid1.Columns.Item(12).TitleObject.Caption = Frances.Hora_Consolidacion;
                    Grid1.Columns.Item(13).TitleObject.Caption = Frances.Fecha_Requerida;
                    Grid1.Columns.Item(14).TitleObject.Caption = Frances.Peso_Bruto;
                }
                // ampliio el ancho de la columna
                Grid1.RowHeaders.Width += 15;
                Grid1.ReadOnlyColumns();
                Grid1.Columns.Item(0).Editable = true;
                Grid1.AutoResizeColumns();

            }
            public void GetPackIdiomafrmAsignationConsolidation(string Idioma, Form oForm,
               StaticText StaticText0, StaticText StaticText1, Button Button0, Button Button1)
            {
                if (Idioma == "English (United States)")
                {
                    oForm.Title = English_United_States.Title_Data_Consolide;
                    StaticText0.Caption = English_United_States.Consolidado;
                    StaticText1.Caption = English_United_States.Fecha;
                    Button0.Caption = English_United_States.Consolidar;
                    Button1.Caption = English_United_States.Cancelar;
                }
                else if (Idioma == "French")
                {
                    oForm.Title = Frances.Title_Data_Consolide;
                    StaticText0.Caption = Frances.Consolidado;
                    StaticText1.Caption = Frances.Fecha;
                    Button0.Caption = Frances.Consolidar;
                    Button1.Caption = Frances.Cancelar;
                }
                else
                {
                    oForm.Title = "Datos para Consolidar";
                    StaticText0.Caption = "Consolidado:";
                    StaticText1.Caption = "Fecha:";
                    Button0.Caption = "Consolidar";
                    Button1.Caption = "Cancelar";
                }
            }

        /*============================================================================*/
                        /*===============FIN CONSOLIDADO  =============== */
        /*============================================================================*/


        /*============================================================================*/
                /*===============INICIO PROGRAMACION MANUAL  =============== */
        /*============================================================================*/
        public void GetPackIdiomafrmProgramationHandbook(Form oForm, string Idioma, StaticText StaticText0,
                                        StaticText StaticText1,StaticText StaticText2,StaticText StaticText7,
                                        CheckBox CheckBox0,Button Button1,Button Button2,
                                        Button Button3,StaticText StaticText8,StaticText StaticText9)
        {
            if (Idioma == "English (United States)")
            {
                oForm.Title= English_United_States.Programación_de_despachos_Manual;
                StaticText0.Caption = English_United_States.Busqueda_por_Rango_Fecha;
                StaticText1.Caption = English_United_States.Desde;
                StaticText2.Caption = English_United_States.Hasta;
                StaticText7.Caption = English_United_States.Busqueda;
                CheckBox0.Caption = English_United_States.Con_Agencia;
                Button1.Caption= English_United_States.Buscar;
                Button2.Caption = English_United_States.Cerrar;
                Button3.Caption = English_United_States.Programar;
                StaticText8.Caption = English_United_States.Total_documentos;
                StaticText9.Caption = English_United_States.Total_Peso;
            }
            else if (Idioma == "French")
            {
                oForm.Title = Frances.Programación_de_despachos_Manual;
                StaticText0.Caption = Frances.Busqueda_por_Rango_Fecha;
                StaticText1.Caption = Frances.Desde;
                StaticText2.Caption = Frances.Hasta;
                StaticText7.Caption = Frances.Busqueda;
                CheckBox0.Caption = Frances.Con_Agencia;
                Button1.Caption = Frances.Buscar;
                Button2.Caption = Frances.Cerrar;
                Button3.Caption = Frances.Programar;
                StaticText8.Caption = Frances.Total_documentos;
                StaticText9.Caption = Frances.Total_Peso;
            }
            else
            {
                oForm.Title = Espaniol.Programación_de_despachos_Manual;
                StaticText0.Caption = Espaniol.Busqueda_por_Rango_Fecha;
                StaticText1.Caption = Espaniol.Desde;
                StaticText2.Caption = Espaniol.Hasta;
                StaticText7.Caption = Espaniol.Busqueda;
                CheckBox0.Caption = Espaniol.Con_Agencia;
                Button1.Caption = Espaniol.Buscar;
                Button2.Caption = Espaniol.Cerrar;
                Button3.Caption = Espaniol.Programar;
                StaticText8.Caption = Espaniol.Total_documentos;
                StaticText9.Caption = Espaniol.Total_Peso;
            }
        }
        public void FormatoGridIdiomaProgramManual(Grid Grid0, string Idioma)
        {
            if (Idioma == "English (United States)")
            {
                Grid0.Columns.Item(0).TitleObject.Caption = English_United_States.Marcar;
                Grid0.Columns.Item(1).TitleObject.Caption = English_United_States.Entrega;
                Grid0.Columns.Item(2).TitleObject.Caption = English_United_States.Fecha_Entrega;
                Grid0.Columns.Item(3).TitleObject.Caption = English_United_States.N_Guia_Entrega;
                Grid0.Columns.Item(4).TitleObject.Caption = English_United_States.Codigo_SN;
                Grid0.Columns.Item(5).TitleObject.Caption = English_United_States.Nombre_SN;
                Grid0.Columns.Item(6).TitleObject.Caption = English_United_States.Peso_Bruto;
                Grid0.Columns.Item(7).TitleObject.Caption = English_United_States.Transporte;
                Grid0.Columns.Item(8).TitleObject.Caption = English_United_States.Consolidado;
                Grid0.Columns.Item(9).TitleObject.Caption = English_United_States.Fecha_Consolidacion;
                Grid0.Columns.Item(10).TitleObject.Caption = English_United_States.Ubigeo;
                Grid0.Columns.Item(11).TitleObject.Caption = English_United_States.Direccion;
                Grid0.Columns.Item(12).TitleObject.Caption = English_United_States.Chofer;
                Grid0.Columns.Item(13).TitleObject.Caption = English_United_States.Vehiculo;
                Grid0.Columns.Item(14).TitleObject.Caption = English_United_States.Ayudante;
                Grid0.Columns.Item(15).TitleObject.Caption = English_United_States.Numero_Referencia;
                Grid0.Columns.Item(16).TitleObject.Caption = English_United_States.Numero_Licencia;
                Grid0.Columns.Item(17).TitleObject.Caption = English_United_States.Marca_Vehiculo;
                Grid0.Columns.Item(18).TitleObject.Caption = English_United_States.Vendedor;
                Grid0.Columns.Item(19).TitleObject.Caption = English_United_States.Saldo;
                Grid0.Columns.Item(20).TitleObject.Caption = English_United_States.Termino_Pago;

            }
            else if (Idioma == "French")
            {
                Grid0.Columns.Item(0).TitleObject.Caption = Frances.Marcar;
                Grid0.Columns.Item("Entrega").TitleObject.Caption = Frances.Entrega;
                Grid0.Columns.Item("NumAtCard").TitleObject.Caption = Frances.N_Guia_Entrega;
                Grid0.Columns.Item("CardCode").TitleObject.Caption = Frances.Codigo_SN;
                Grid0.Columns.Item("CardName").TitleObject.Caption = Frances.Nombre_SN;
               Grid0.Columns.Item("Peso").TitleObject.Caption = Frances.Peso_Bruto;
               Grid0.Columns.Item("Transporte").TitleObject.Caption = Frances.Transporte;
               Grid0.Columns.Item("Consolidado").TitleObject.Caption = Frances.Consolidado;
               Grid0.Columns.Item("FechaConsolidado").TitleObject.Caption = Frances.Fecha_Consolidacion;
               Grid0.Columns.Item("Ubigeo").TitleObject.Caption = Frances.Ubigeo;
               Grid0.Columns.Item("Direccion").TitleObject.Caption = Frances.Direccion;
               Grid0.Columns.Item("Chofer").TitleObject.Caption = Frances.Chofer;
               Grid0.Columns.Item("Vehiculo").TitleObject.Caption = Frances.Vehiculo;
               Grid0.Columns.Item("Ayudante").TitleObject.Caption = Frances.Ayudante;
               Grid0.Columns.Item("NroFactura").TitleObject.Caption = Frances.Numero_Referencia;
               Grid0.Columns.Item("Ayudante").TitleObject.Caption = Frances.Numero_Licencia;
               Grid0.Columns.Item("MarcaVehiculo").TitleObject.Caption = Frances.Marca_Vehiculo;
               Grid0.Columns.Item("Vendedor").TitleObject.Caption = Frances.Vendedor;
               Grid0.Columns.Item("Saldo").TitleObject.Caption = Frances.Saldo;
               Grid0.Columns.Item("TerminoPago").TitleObject.Caption = Frances.Termino_Pago;
               Grid0.Columns.Item("DocDueDate").TitleObject.Caption = Frances.Fecha_Entrega;

            }
            else
            {
                Grid0.Columns.Item(0).TitleObject.Caption = Espaniol.Marcar;
                Grid0.Columns.Item("Entrega").TitleObject.Caption = Espaniol.Entrega;
                Grid0.Columns.Item("NumAtCard").TitleObject.Caption = Espaniol.N_Guia_Entrega;
                Grid0.Columns.Item("CardCode").TitleObject.Caption = Espaniol.Codigo_SN;
                Grid0.Columns.Item("CardName").TitleObject.Caption = Espaniol.Nombre_SN;
                Grid0.Columns.Item("Peso").TitleObject.Caption = Espaniol.Peso_Bruto;
                Grid0.Columns.Item("Transporte").TitleObject.Caption = Espaniol.Transporte;
                Grid0.Columns.Item("Consolidado").TitleObject.Caption = Espaniol.Consolidado;
                Grid0.Columns.Item("FechaConsolidado").TitleObject.Caption = Espaniol.Fecha_Consolidacion;
                Grid0.Columns.Item("Ubigeo").TitleObject.Caption = Espaniol.Ubigeo;
                Grid0.Columns.Item("Direccion").TitleObject.Caption = Espaniol.Direccion;
                Grid0.Columns.Item("Chofer").TitleObject.Caption = Espaniol.Chofer;
                Grid0.Columns.Item("Vehiculo").TitleObject.Caption = Espaniol.Vehiculo;
                Grid0.Columns.Item("Ayudante").TitleObject.Caption = Espaniol.Ayudante;
                Grid0.Columns.Item("NroFactura").TitleObject.Caption = Espaniol.Numero_Referencia;
                Grid0.Columns.Item("Ayudante").TitleObject.Caption = Espaniol.Numero_Licencia;
                Grid0.Columns.Item("MarcaVehiculo").TitleObject.Caption = Espaniol.Marca_Vehiculo;
                Grid0.Columns.Item("Vendedor").TitleObject.Caption = Espaniol.Vendedor;
                Grid0.Columns.Item("Saldo").TitleObject.Caption = Espaniol.Saldo;
                Grid0.Columns.Item("TerminoPago").TitleObject.Caption = Espaniol.Termino_Pago;
                Grid0.Columns.Item("DocDueDate").TitleObject.Caption = Espaniol.Fecha_Entrega;

            }
        }
        public void FormatoGridProgramationHandbook(Grid Grid1, string Idioma)
        {
            if (Idioma == "English (United States)")
            {
                Grid1.DataTable.Columns.Add(English_United_States.Marcar, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(English_United_States.Entrega, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(English_United_States.Fecha_Entrega, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(English_United_States.N_Guia_Entrega, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(English_United_States.Codigo_SN, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(English_United_States.Nombre_SN, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(English_United_States.Peso_Bruto, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(English_United_States.Transporte, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(English_United_States.Consolidado, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(English_United_States.Fecha_Consolidacion, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(English_United_States.Ubigeo, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(English_United_States.Direccion, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(English_United_States.Chofer, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(English_United_States.Vehiculo, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(English_United_States.Ayudante, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(English_United_States.Numero_Referencia, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(English_United_States.Numero_Licencia, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(English_United_States.Marca_Vehiculo, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(English_United_States.Vendedor, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(English_United_States.Saldo, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(English_United_States.Termino_Pago, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            }
            else if (Idioma == "French")
            {
                Grid1.DataTable.Columns.Add(Frances.Marcar, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Frances.Entrega, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Frances.Fecha_Entrega, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Frances.N_Guia_Entrega, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Frances.Codigo_SN, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Frances.Nombre_SN, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Frances.Peso_Bruto, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Frances.Transporte, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Frances.Consolidado, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Frances.Fecha_Consolidacion, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Frances.Ubigeo, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Frances.Direccion, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Frances.Chofer, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Frances.Vehiculo, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Frances.Ayudante, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Frances.Numero_Referencia, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Frances.Numero_Licencia, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Frances.Marca_Vehiculo, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Frances.Vendedor, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Frances.Saldo, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Frances.Termino_Pago, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            }
            else
            {
                Grid1.DataTable.Columns.Add(Espaniol.Marcar, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Espaniol.Entrega, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Espaniol.Fecha_Entrega, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Espaniol.N_Guia_Entrega, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Espaniol.Codigo_SN, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Espaniol.Nombre_SN, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Espaniol.Peso_Bruto, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Espaniol.Transporte, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Espaniol.Consolidado, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Espaniol.Fecha_Consolidacion, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Espaniol.Ubigeo, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Espaniol.Direccion, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Espaniol.Chofer, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Espaniol.Vehiculo, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Espaniol.Ayudante, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Espaniol.Numero_Referencia, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Espaniol.Numero_Licencia, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Espaniol.Marca_Vehiculo, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Espaniol.Vendedor, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Espaniol.Saldo, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                Grid1.DataTable.Columns.Add(Espaniol.Termino_Pago, SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            }

            Grid1.ReadOnlyColumns();
            Grid1.Columns.Item(0).Editable = true;
            Grid1.AutoResizeColumns();

        }
        public void GetPackIdiomafrmAsignationProgramationManual
        (string Idioma, Form oForm,
            StaticText StaticText0,
            StaticText StaticText1,
            StaticText StaticText2,
            StaticText StaticText3,
            StaticText StaticText4,
            StaticText StaticText5)
        {
            if (Idioma == "English (United States)")
            {
                oForm.Title = English_United_States.Datos_para_programar;
                StaticText0.Caption = English_United_States.Asignación_de_Fecha_de_despacho;
                StaticText1.Caption = English_United_States.Chofer;
                StaticText2.Caption = English_United_States.Ayudante;
                StaticText3.Caption = English_United_States.Vehiculo;
                StaticText4.Caption = English_United_States.Fecha_de_Programación;
                StaticText5.Caption = English_United_States.Capacidad;
            }
            else if (Idioma == "French")
            {
                oForm.Title = Frances.Datos_para_programar;
                StaticText0.Caption = Frances.Asignación_de_Fecha_de_despacho;
                StaticText1.Caption = Frances.Chofer;
                StaticText2.Caption = Frances.Ayudante;
                StaticText3.Caption = Frances.Vehiculo;
                StaticText4.Caption = Frances.Fecha_de_Programación;
                StaticText5.Caption = Frances.Capacidad;

            }
            else
            {
                oForm.Title = Espaniol.Datos_para_programar;
                StaticText0.Caption = Espaniol.Asignación_de_Fecha_de_despacho;
                StaticText1.Caption = Espaniol.Chofer;
                StaticText2.Caption = Espaniol.Ayudante;
                StaticText3.Caption = Espaniol.Vehiculo;
                StaticText4.Caption = Espaniol.Fecha_de_Programación;
                StaticText5.Caption = Espaniol.Capacidad;

            }
        }
        /*============================================================================*/
        /*===============FIN PROGRAMACION MANUAL  =============== */
        /*============================================================================*/
    }
}
