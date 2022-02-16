using System;

namespace Entity
{
    public class EmployeeEntity
    {
        public EmployeeEntity(int id)
        {
            ID = id;
        }
        public int ID { get; set; } = 0;
        public string CompanyId { get; set; } = "";
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime DeletedOn { get; set; } = DateTime.Now;
        public string Email { get; set; } = "";
        public string Fax { get; set; } = "";
        public string TestName { get; set; } = "";
        public DateTime LastLogin { get; set; } = DateTime.Now;
        public string Password { get; set; } = "";
        public string PortalId { get; set; } = "";
        public string RoleId { get; set; } = "";
        public string StatusId { get; set; } = "";
        public string Telephone { get; set; } = "";
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public string Username { get; set; } = "";
        public string type { get; set; } = "";
    }
}