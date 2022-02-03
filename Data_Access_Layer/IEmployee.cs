using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;






namespace Data_Access_Layer
{
    public interface IEmployee
    {        
        Task<List<EmployeeEntity>> GetAllEmployee();
       
    }
}