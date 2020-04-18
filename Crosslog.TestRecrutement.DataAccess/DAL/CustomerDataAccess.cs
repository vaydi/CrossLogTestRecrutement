using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Crosslog.TestRecrutement.DataAccess.Dto;

namespace Crosslog.TestRecrutement.DataAccess
{
    public class CustomerDataAccess : ICustomerDataAccess
    {
        private const string SelectCustomers = "ps_s_Customers";
        private const string UpdateCustomers = "ps_u_Customer_by_id";

        public CustomerListEntityDto GetCustomers(DbConnection conn)
        {
            var lstCustomers = new CustomerListEntityDto();

            try
            {
                conn.Open();
                DbCommand command = conn.CreateCommand();
                command.CommandText = SelectCustomers;
                command.CommandType = CommandType.StoredProcedure;

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CustomerEntityDto customer = new CustomerEntityDto
                        {
                            Address = reader["Address"].ToString(),
                            City = reader["City"].ToString(),
                            CustomerId = int.Parse(reader["CustomerId"].ToString()),
                            Email = reader["Email"].ToString(),
                            ZipCode = reader["ZipCode"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            OrderCount = Convert.ToInt32(reader["OrderCount"].ToString()),
                            TotalAmount = Convert.ToDecimal(reader["TotalAmount"].ToString())
                        };

                        string orderNumber = reader["OrderNumber"].ToString();
                        customer.OrderNumber = string.IsNullOrEmpty(orderNumber) ? default(int?) : int.Parse(orderNumber);

                        lstCustomers.Add(customer);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return lstCustomers;
        }

        public bool UpdateCustomer(CustomerEntityDto customer, DbConnection conn)
        {
            try
            {
                conn.Open();
                DbCommand command = conn.CreateCommand();
                command.CommandText = UpdateCustomers;
                command.CommandType = CommandType.StoredProcedure;

                Dictionary<string, string> paramsDbCommand = new Dictionary<string, string>
                {
                    {"@CustomerId", customer.CustomerId.ToString()},
                    {"@LastName", customer.LastName},
                    {"@FirstName", customer.FirstName},
                    {"@Address", customer.Address},
                    {"@ZipCode", customer.ZipCode},
                    {"@City", customer.City},
                    {"@Email", customer.Email},
                    {"@Phone", customer.Phone}
                };

                foreach (var param in paramsDbCommand)
                {
                    AddToDbCommand(ref command, param.Key, param.Value);
                }

                var read = command.ExecuteNonQuery();
                conn.Close();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        /// <summary>
        /// ajouter paramètre entree d'une procédure stockée au Db Command
        /// </summary>
        /// <param name="dbCommand">dbCommand</param>
        /// <param name="fieldName">nom paramètre</param>
        /// <param name="fieldValue">valeur de paramètre</param>
        private static void AddToDbCommand(ref DbCommand dbCommand, string fieldName, string fieldValue)
        {
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = fieldName;
            dbParameter.Value = fieldValue;
            dbCommand.Parameters.Add(dbParameter);
        }
    }
}