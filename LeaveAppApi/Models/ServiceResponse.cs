using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAppApi.Models
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;
    }

    public class standardResonse
    {
        public string STATUS;
        public dynamic DATA;
        public dynamic DATA2;
        public string DESCRIPTION;
    }
}
