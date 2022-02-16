using System;

namespace Web_API.DTOs
{
    public class EmployeeDTO
    {
        public EmployeeDTO(int id, string testName)
        {
            ID = id;
            TestName = testName;
        }

        public int ID { get; set; }
        public string CompanyId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime DeletedOn { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string TestName { get; set; }
        public DateTime LastLogin { get; set; }
        public string Password { get; set; } 
        public string PortalId { get; set; } 
        public string RoleId { get; set; }
        public string StatusId { get; set; }
        public string Telephone { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string Username { get; set; }
        public string type { get; set; }
    }
}
