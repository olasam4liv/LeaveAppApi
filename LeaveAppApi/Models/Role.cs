using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LeaveAppApi.Context.Model
{
   
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Role
    {
        SuperAdmin,
        Admin,
        Underwriter,
        Broker,
        DirectCustomer
    }
    public class Role_
    {


    }
}
