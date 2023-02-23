using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Forxap.Framework.ServiceLayer
{
   public   class Base
    {
       
        private string _baseUri = string.Empty;
        private string _urlServiceLayer = ConfigurationSettings.AppSettings["UrlServiceLayer"];
        private string _companyName = ConfigurationSettings.AppSettings["CompanyName"];
        private string _userName = ConfigurationSettings.AppSettings["UserName"];
        private string _userPassword = ConfigurationSettings.AppSettings["UserPassword"];


        private string _login = string.Empty;
        private string _contentType = string.Empty;
        private string _routedId = string.Empty ;
        private string _noContent = string.Empty;
        private string _b1Session = string.Empty;
        private string _node0 = string.Empty;
 
   
       public string BaseUri
        {
            get { return _baseUri ; }
            set { _baseUri = SLResources.BASEURI; }
        }



       
        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                _companyName = ConfigurationSettings.AppSettings["CompanyName"];

            }
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = ConfigurationSettings.AppSettings["UserName"];

            }
        }


        public string UserPassword
        {
            get { return _userPassword; }
            set
            {
                _userPassword = ConfigurationSettings.AppSettings["UserPassword"];

            }
        }


        public string UrlServiceLayer
        {
            get { return _urlServiceLayer;}
            set
            {
                _urlServiceLayer = ConfigurationSettings.AppSettings["UrlServiceLayer"];


            }
        }

        


        public string Login
        {
            get { return _login;}
            set { _login = SLResources.LOGIN; }
        }


       
	    public string  ContentType
	    {
		    get { return _contentType;}
            set { _contentType = SLResources.CONTENTTYPE; }
	    }
	
    

	    public string B1Session
	    {
		    get { return _b1Session;}
            set { _b1Session = SLResources.B1SESSION; }
	    }
	
        
   
   


        public string RoutedId
        {
            get { return _routedId; }
            set { _routedId = SLResources.ROUTEID; }
        }
        
        

	    public string Node0
	    {
		    get { return _node0;}
            set { _node0 = SLResources.NOBE0; }
	    }
	
    

	    public string NoContent
	    {
		    get { return _noContent;}
            set { _noContent = SLResources.NOCONTENT; }
	    }



        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public bool ActionSuccess { get; set; }        

        public AddonType AddonClient { get; set; }

        public static SAPbouiCOM.Application oApplication { get; set; }
        public static SAPbobsCOM.Company bobsCompany { get; set; }


    }// fin de la clase


    public enum AddonType
    {
        SAP,
        API,
        WinForm
 
    }

}// fin del namespace



