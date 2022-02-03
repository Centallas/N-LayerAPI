using System.Collections.Generic;


namespace Data_Access_Layer
{
    public class RedarborDal 
    {
        //private readonly db _dbop = new db();
        //private string _msg = string.Empty;

        //public async Task<List<EmployeeEntity>> GetAllEmployee()
        //{
        //    return await GetEmployeeList();
        //}

        public List<string> GetAllEmployee()
        {
            List<string> employeeNames = new List<string>();
            employeeNames.Add("Yohan");
            employeeNames.Add("Martin");
            employeeNames.Add("John");
            return employeeNames;

        }


        //public async Task<List<EmployeeEntity>> GetEmployeeById(int id)
        //{
        //    return await GetEmployee(id);
        //}
        //private async Task<List<EmployeeEntity>> GetEmployee(int id)
        //{
        //    GetEmployeeData(id, out var ds, out var employeeById);

        //    await Task.Run(() =>
        //    {
        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            employeeById.Add(new EmployeeEntity
        //            {
        //                ID = Convert.ToInt32(dr["ID"]),
        //                CompanyId = dr["CompanyId"].ToString(),
        //                CreatedOn = (DateTime)dr["CreatedOn"],
        //                DeletedOn = (DateTime)dr["DeletedOn"],
        //                Email = dr["Email"].ToString(),
        //                Fax = dr["Fax"].ToString(),
        //                TestName = dr["TestName"].ToString(),
        //                LastLogin = (DateTime)dr["LastLogin"],
        //                Password = dr["Password1"].ToString(),
        //                PortalId = dr["PortalId"].ToString(),
        //                RoleId = dr["RoleId"].ToString(),
        //                StatusId = dr["StatusId"].ToString(),
        //                Telephone = dr["Telephone"].ToString(),
        //                UpdatedOn = (DateTime)dr["UpdatedOn"],
        //                Username = dr["UserName"].ToString()


        //            });

        //        }
        //    });
        //    return employeeById;
        //} 
        //public async Task<string> InsertEmployee(EmployeeEntity emp)
        //{
        //    string msg;
        //    try
        //    {
        //        msg = await _dbop.EmployeeOpt(emp);
        //    }
        //    catch (Exception ex)
        //    {
        //        msg = ex.Message;
        //    }
        //    return msg;

        //}
        //public async Task<string> UpdateEmployee(int id, EmployeeEntity emp)
        //{
        //    string msg;
        //    try
        //    {
        //        emp.ID = id;
        //        msg = await _dbop.EmployeeOpt(emp);
        //    }
        //    catch (Exception ex)
        //    {

        //        msg = ex.Message;
        //    }
        //    return msg;

        //}
        //public async Task<string> DeleteEmployee(int id)
        //{
        //    string msg;
        //    try
        //    {
        //        EmployeeEntity emp = new EmployeeEntity
        //        {
        //            ID = id,
        //            type = "delete"
        //        };
        //        msg = await _dbop.EmployeeOpt(emp);
        //    }
        //    catch (Exception ex)
        //    {
        //        msg = ex.Message;
        //    }
        //    return msg;

        //}

        //private async Task<List<EmployeeEntity>> GetEmployeeList()
        //{
        //    GetListData(out var ds, out var listEmployee);

        //    await Task.Run(() =>
        //    {


        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            listEmployee.Add(new EmployeeEntity
        //            {
        //                ID = Convert.ToInt32(dr["ID"]),
        //                CompanyId = dr["CompanyId"].ToString(),
        //                CreatedOn = (DateTime)dr["CreatedOn"],
        //                DeletedOn = (DateTime)dr["DeletedOn"],
        //                Email = dr["Email"].ToString(),
        //                Fax = dr["Fax"].ToString(),
        //                TestName = dr["TestName"].ToString(),
        //                LastLogin = (DateTime)dr["LastLogin"],
        //                Password = dr["Password1"].ToString(),
        //                PortalId = dr["PortalId"].ToString(),
        //                RoleId = dr["RoleId"].ToString(),
        //                StatusId = dr["StatusId"].ToString(),
        //                Telephone = dr["Telephone"].ToString(),
        //                UpdatedOn = (DateTime)dr["UpdatedOn"],
        //                Username = dr["UserName"].ToString(),
        //            });
        //        }
        //    });


        //    return listEmployee;
        //}
        //private void GetListData(out DataSet ds, out List<EmployeeEntity> listEmployee)
        //{
        //    EmployeeEntity emp = new EmployeeEntity
        //    {
        //        type = "get"
        //    };
        //    ds = _dbop.EmployeeGet(emp, out _msg);
        //    listEmployee = new List<EmployeeEntity>();
        //}
        //private void GetEmployeeData(int id, out DataSet ds, out List<EmployeeEntity> employeeById)
        //{
        //    EmployeeEntity emp = new EmployeeEntity
        //    {
        //        ID = id,
        //        type = "getid"
        //    };
        //    ds = _dbop.EmployeeGet(emp, out _msg);
        //    employeeById = new List<EmployeeEntity>();
        //}
    }
}