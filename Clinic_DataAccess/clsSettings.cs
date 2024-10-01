
//using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Web.Configuration;

namespace Clinic_DataAccess
{
    public static  class clsSettings
    {

       public static string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
         
         //   "Server=.;database= Clinic Project; User id = sa; Password=sa123456";


       // Server=.;database= Clinic Project; User id = sa; Password=sa123456;



 






    }
}
