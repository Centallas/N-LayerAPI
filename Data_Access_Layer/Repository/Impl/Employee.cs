using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
    public class Employee : IEmployee
    {

        private readonly Db _db = new Db();
        private string _msg = string.Empty;
        List<EmployeeEntity> listEmployee = new List<EmployeeEntity>();
        public async Task<List<EmployeeEntity>> GetAllEmployee()
        {
            var res = await GetEmployeeList();
            return res;
        }
        private async Task<List<EmployeeEntity>> GetEmployeeList()
        {
            //await GetListData(out var ds, out var listEmployee);
            var tuple = await GetListData();
            DataSet ds = tuple.Item1;

            if (listEmployee.Any())
            {
                listEmployee.Clear();
            }


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
        private async Task<Tuple<DataSet, string>> GetListData()


        {
            EmployeeEntity emp = new EmployeeEntity()
            {
                type = "get"
            };

            var result = await _db.EmployeeGet(emp);

            return result;
        }
        private async Task<Tuple<DataSet, string>> GetEmployeeData(int id)
        {
            EmployeeEntity emp = new EmployeeEntity
            {
                ID = id,
                type = "getid"
            };
            var result = await _db.EmployeeGet(emp);
            //employeeById = new List<EmployeeEntity>();
            return result;
        }
        public async Task<EmployeeEntity> GetEmployeeById(int id)
        {
            return await GetEmployee(id);
        }
        private async Task<EmployeeEntity> GetEmployee(int id)
        {
            //GetEmployeeData(id, out var ds, out var employeeById);
            var employeeById = new List<EmployeeEntity>();
            var tuple = await GetEmployeeData(id);
            DataSet ds = tuple.Item1;
            EmployeeEntity _employee = new EmployeeEntity();

            if (ds.Tables.Count > 0)
            {

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    employeeById.Add(new EmployeeEntity
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
                        Username = dr["UserName"].ToString()


                    });

                }

                _employee = employeeById.ToList().ElementAt(0);
            }

            return _employee;
        }
        public async Task<EmployeeEntity> InsertEmployee(EmployeeEntity emp)
        {
            string msg;
            EmployeeEntity employee = new EmployeeEntity();
            try
            {
                employee = await _db.EmployeeOpt(emp);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return employee;

        }
        public async Task<EmployeeEntity> UpdateEmployee(int id, EmployeeEntity emp)
        {
            string msg;
            EmployeeEntity employee = new EmployeeEntity();
            try
            {
                emp.ID = id;
                employee = await _db.EmployeeOpt(emp);
            }
            catch (Exception ex)
            {

                msg = ex.Message;
            }
            return employee;

        }
        public async Task DeleteEmployee(int id)
        {
            //string msg;
            EmployeeEntity employee = new EmployeeEntity();
            try
            {
                EmployeeEntity emp = new EmployeeEntity
                {
                    ID = id,
                    type = "delete"
                };

                await _db.EmployeeOpt(emp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }

    }
}
