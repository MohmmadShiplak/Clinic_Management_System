using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Clinic_DataAccess
{
    public  class clsLogHandler
    {

        public static void  LogToEventViewer(string errortype,Exception ex)
        {

            string SourceName=ConfigurationManager.AppSettings["ProjectName"];

            if(!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
            }

            string errorMessage = $"{errortype} in {ex.Source}\n\n Exception Message :"
                + $"{ex.Message}\n\n Exception Type : {ex.GetType().Name}\n\n Stack trace :"
                + $"{ex.StackTrace}\n\n Exception Location : {ex.TargetSite}";
           
            EventLog.WriteEntry(SourceName, errorMessage,EventLogEntryType.Error);


        }





    }
}
