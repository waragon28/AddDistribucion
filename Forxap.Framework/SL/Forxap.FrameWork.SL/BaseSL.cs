using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Forxap.Framework.ServiceLayer;

namespace Forxap.FrameWork
{
    public abstract class BaseSL
    {
       

        private static string _baseUri;
        private static string _absolutUriPrefix;
        private static string _login;
        private static string  _contentType;
        private static string _routedId;
        private static string _noContent;
        private static string _b1Session;
        private static string _node0;


        public static string BaseUri
        {
            get { return ResourceSL.BASEURI; }
            set { _baseUri = ResourceSL.BASEURI; }
        }

        

      
        public static string AbsolutUriPrefix
        {
            get { return ResourceSL.ABSOLUTURIPREFIX; }
            set { _absolutUriPrefix = ResourceSL.ABSOLUTURIPREFIX; }
        }

        


        public static string Login
        {
            get { return ResourceSL.LOGIN; }
            set { _login = ResourceSL.LOGIN; }
        }


       
	public static string  ContentType
	{
        get { return ResourceSL.CONTENTTYPE; }
        set { _contentType = ResourceSL.CONTENTTYPE; }
	}
	
    
	public static string B1Session
	{
        get { return ResourceSL.B1SESSION; }
        set { _b1Session = ResourceSL.B1SESSION; }
	}
	
        
   
   


    public static string RoutedId
    {
        get { return ResourceSL.ROUTEID; }
        set { _routedId = ResourceSL.ROUTEID; }
    }
        
        
	public static string Node0
	{
        get { return ResourceSL.NODE0; }
        set { _node0 = ResourceSL.NODE0; }
	}
	
    

	public static string NoContent
	{
        get { return ResourceSL.NOCONTENT; }
        set { _noContent = ResourceSL.NOCONTENT; }
	}
	    

        

    }// fin de la clase



}// fin del namespace
