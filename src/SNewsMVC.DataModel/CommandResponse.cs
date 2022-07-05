using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNewsMVC.DataModel
{
    public class CommandResponse
    {

        public bool Success
        {
            get
            {
                bool isSuccess = String.IsNullOrEmpty(ErrorMessage);
                return isSuccess;
            }
        }
        public string ErrorMessage { get; set; }
    }

    public class CommandResponse<T> : CommandResponse
    {
        public T Data { get; set; }
    }
}
