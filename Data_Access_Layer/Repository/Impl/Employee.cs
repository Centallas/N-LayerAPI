using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
    public class Employee : IEmployee
    {
        //private readonly FakeData _fakeData = new FakeData();
        private readonly Db _db = new Db();
        private string _msg = string.Empty;
        List<EmployeeEntity> listEmployee = new List<EmployeeEntity>();
        public async Task<List<EmployeeEntity>> GetAllEmployee()
        {
            return await GetEmployeeList();
        }
        private async Task<List<EmployeeEntity>> GetEmployeeList()
        {
            //await GetListData(out var ds, out var listEmployee);
            var tuple = await GetListData();
            DataSet ds = tuple.Item1;           

            //await Task.Run(() =>
            //{


            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listEmployee.Add(new EmployeeEntity
                {
                    ID = Convert.ToInt32(dr["ID"]),
                    CompanyId = dr["CompanyId"].ToString(),
                    CreatedOn = (DateTime)dr["CreatedOn"],
                    DeletedOn = (DateTime)dr["DeletedOn"],
                    Email = dr["Email"].ToString(),
                    Fax = dr["Fax"].ToString(),
                    TestName = dr["TestName"].ToString(),
                    LastLogin = (DateTime)dr["LastLogin"],
                    Password = dr["Password1"].ToString(),
                    PortalId = dr["PortalId"].ToString(),
                    RoleId = dr["RoleId"].ToString(),
                    StatusId = dr["StatusId"].ToString(),
                    Telephone = dr["Telephone"].ToString(),
                    UpdatedOn = (DateTime)dr["UpdatedOn"],
                    Username = dr["UserName"].ToString(),
                });
            }
            // });


            return listEmployee;
        }
        private async Task<Tuple<DataSet>> GetListData()
        {
            EmployeeEntity emp = new EmployeeEntity()
            {
                type = "get"
            };

            //List<EmployeeEntity>listEmployee = new List<EmployeeEntity>();
            //ds = _db.EmployeeGet(emp, out _msg);
            DataSet ds = await _db.EmployeeGet(emp);           

            return new Tuple<DataSet>(ds);
        }
}
}
