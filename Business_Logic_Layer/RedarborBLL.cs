using System.Collections.Generic;

namespace Business_Logic_Layer
{
    //Business Logic Layer -- BLL
    public class RedarborBLL 
    {
        private readonly Data_Access_Layer.RedarborDal _DAL;

        public RedarborBLL()
        {
            _DAL = new Data_Access_Layer.RedarborDal();
        }

        public List<string> GetAllEmployee() 
        {
            var res = _DAL.GetAllEmployee();
            return res;        
        }

        //public RedarborBLL()
        //{
        //    _DAL = new RedarborDal();
        //}

        //public async Task<List<EmployeeEntity>> GetAllEmployee()
        //{
        //    return await _DAL.GetAllEmployee();
        //}
        //public List<string> GetAllEmployee()
        //{
        //    return await _DAL.GetAllEmployee();
        //}
        //public async Task<List<EmployeeEntity>> GetEmployeeById(int id)
        //{
        //    return await _DAL.GetEmployeeById(id);
        //}

        //public async Task<string> InsertEmployee(EmployeeEntity emp)
        //{
        //    return await _DAL.InsertEmployee(emp);
        //}

        //public async Task<string> UpdateEmployee(int id, EmployeeEntity emp)
        //{
        //    return await _DAL.UpdateEmployee(id, emp);
        //}

        //public async Task<string> DeleteEmployee(int id)
        //{
        //    return await _DAL.DeleteEmployee(id);
        //}


    }
}