using Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;


namespace Data_Access_Layer.Repository
{
    public class Db
    {
        readonly SqlConnection _connection;

        private IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();

        }

        public Db()
        {
            var configuration = GetConfiguration();
            _connection = new SqlConnection(configuration.GetSection("Data")
                .GetSection("ConnectionString").Value);
        }

        public async Task<string> EmployeeOpt(EmployeeEntity employee)
        {
            string msg = string.Empty;
            //var result = new OkResult();
           // await Task.Run(() =>
            //{
            

                try
                {
                    SqlCommand command = new SqlCommand("Sp_Employee", _connection);
                    command.CommandType = CommandType.StoredProcedure;                    
                    command.Parameters.AddWithValue("@ID", employee.ID);
                    command.Parameters.AddWithValue("@CompanyId", employee.CompanyId);
                    command.Parameters.AddWithValue("@CreatedOn", employee.CreatedOn);
                    command.Parameters.AddWithValue("@DeletedOn", employee.DeletedOn);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@Fax", employee.Fax);
                    command.Parameters.AddWithValue("@TestName", employee.TestName);
                    command.Parameters.AddWithValue("@Lastlogin", employee.LastLogin);
                    command.Parameters.AddWithValue("@Password1", employee.Password);
                    command.Parameters.AddWithValue("@PortalId", employee.PortalId);
                    command.Parameters.AddWithValue("@RoleId", employee.RoleId);
                    command.Parameters.AddWithValue("@StatusId", employee.StatusId);
                    command.Parameters.AddWithValue("@Telephone", employee.Telephone);
                    command.Parameters.AddWithValue("@UpdatedOn", employee.UpdatedOn);
                    command.Parameters.AddWithValue("@Username", employee.Username);
                    command.Parameters.AddWithValue("@type", employee.type);                
                    await _connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    await _connection.CloseAsync();
                    msg = "SUCCESS";
                    

                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                    
                }
                finally
                {
                    if (_connection.State == ConnectionState.Open)
                    {
                        _connection.Close();
                    }
                }
                // });
                //result.ExecuteResultAsync();
                return msg;
        }
        //Get the Record
        //public async Task<DataSet> EmployeeGet(EmployeeEntity employee, out string msg)
        public async Task<DataSet> EmployeeGet(EmployeeEntity employee)
        {
            string msg = string.Empty;
            DataSet dataSet = new DataSet();
            try
            {

                SqlCommand command = new SqlCommand("Sp_Employee", _connection);                
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", employee.ID);
                command.Parameters.AddWithValue("@CompanyId", employee.CompanyId);
                command.Parameters.AddWithValue("@CreatedOn", employee.CreatedOn);
                command.Parameters.AddWithValue("@DeletedOn", employee.DeletedOn);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@Fax", employee.Fax);
                command.Parameters.AddWithValue("@TestName", employee.TestName);
                command.Parameters.AddWithValue("@Lastlogin", employee.LastLogin);
                command.Parameters.AddWithValue("@Password1", employee.Password);
                command.Parameters.AddWithValue("@PortalId", employee.PortalId);
                command.Parameters.AddWithValue("@RoleId", employee.RoleId);
                command.Parameters.AddWithValue("@StatusId", employee.StatusId);
                command.Parameters.AddWithValue("@Telephone", employee.Telephone);
                command.Parameters.AddWithValue("@UpdatedOn", employee.UpdatedOn);
                command.Parameters.AddWithValue("@Username", employee.Username);
                command.Parameters.AddWithValue("@type", employee.type);

               
                //IAsyncResult result = command.BeginExecuteNonQuery();
                //await _connection.OpenAsync();
                //var result = command.ExecuteReaderAsync();
                //await _connection.CloseAsync();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                await Task.Run(() => dataAdapter.Fill(dataSet));
               
                //msg = "SUCCESS";

                //I set this 'cause I didn't know how to become EmployeeGet Method async 
                ///TODO: I HAVE TO CHANGE THIS -- Test if conection always gonna be close!
                //if (_connection.State == ConnectionState.Open)
                //    await _connection.CloseAsync();


            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return dataSet;
        }
    }


}
