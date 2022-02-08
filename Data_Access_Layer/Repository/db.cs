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
        ///TODO: It has been changed only for testing --  
        ///A readonly field cannot be assigned to (except in a constructor or a variable initializer)
        ///https://stackoverflow.com/questions/6848441/assign-value-of-readonly-variable-in-private-method-called-only-by-constructors
        //readonly SqlConnection _connection;
        private SqlConnection _connection;

        private IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();

        }

        public Db()
        {
            InitializedConn();
        }

        private void InitializedConn()
        {
            var configuration = GetConfiguration();
            _connection = new SqlConnection(configuration.GetSection("Data")
                .GetSection("ConnectionString").Value);



        }

        public async Task<EmployeeEntity> EmployeeOpt(EmployeeEntity employee)
        {
            string msg = string.Empty;

            try
            {
                InitializedConn();
                using (SqlCommand command = new SqlCommand("Sp_Employee", _connection))
                {
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
                    _connection.Open();

                    await command.ExecuteNonQueryAsync();
                }


                msg = "SUCCESS";


            }
            catch (Exception ex)
            {
                msg = ex.Message;

            }
            return employee;
        }
        //Get the Record       
        public async Task<Tuple<DataSet, string>> EmployeeGet(EmployeeEntity employee)
        {
            string msg = string.Empty;
            DataSet dataSet = new DataSet();
            try
            {
                InitializedConn();
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

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);


                _connection.Open();
                dataAdapter.Fill(dataSet);


                //await Task.Run(() => dataAdapter.Fill(dataSet));

                ///DONE:UNCOMMENT THIS!!
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
                    await _connection.CloseAsync();
                }

            }
            ///TODO: Modify this validation to Reset DataSet
            if ((dataSet.Tables.Count == 1) && (dataSet.Tables[0].Rows.Count == 0))
            {
                //dataSet.Clear();
                dataSet.Reset();

            }

            return new Tuple<DataSet, string>(dataSet, msg);
        }
    }
}
