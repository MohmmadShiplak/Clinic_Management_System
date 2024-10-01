using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_DataAccess
{
    public  class clsErrorLog
    {

        private Action<string,Exception> _LogAction;

        public clsErrorLog(Action<string,Exception>LogAction)
        {
            _LogAction = LogAction; 
        }
        

        public void LogError(string ErrorType,Exception ex)
        {
            _LogAction?.Invoke(ErrorType, ex);
        }






    }
}
