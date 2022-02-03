using System.Collections.Generic;

namespace Data_Access_Layer.Repository
{
    public class FakeData
    {
        public List<string> GetAllEmployee()
        {
            List<string> employeeNames = new List<string>();
            employeeNames.Add("Yohan");
            employeeNames.Add("Martin");
            employeeNames.Add("John");
            employeeNames.Add("Edward");
            return employeeNames;
        }
        
    }
}