using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAppApi.Context.Model
{
    public class User
    {
        public Guid UserId { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Department { get; set; }
        public string GradeLevel { get; set; }
        public string NoOfLeaveDays { get; set; }
        public string Password { get; set; }        
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? LastEditDate { get; set; }
        public bool IsActive { get; set; } = true;  
        public string Status { get; set; }       
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
