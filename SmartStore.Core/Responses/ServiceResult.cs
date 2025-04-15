using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Core.Responses
{
    public class ServiceResult
    {
        public bool success { get; }
        public string message { get; }

        public ServiceResult(bool success, string message)
        {
            this.success = success;
            this.message = message;
        }

        public static ServiceResult Success(string message)
            => new ServiceResult(true, message);
        public static ServiceResult Failure(string message)
            => new ServiceResult(false, message);
    }

}
