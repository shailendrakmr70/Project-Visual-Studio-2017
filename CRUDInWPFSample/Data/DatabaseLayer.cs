using CRUDInWPFSample.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using CRUDInWPFSample.ViewModel;

namespace CRUDInWPFSample.Data
{
    class DatabaseLayer
    {
        public static List<User> GetEmployeeFromDatabase()
        {
            try
            {
                DataTable dt = SqlHelper.ExecuteDataTable(AppConstants.getConnectionString(), CommandType.StoredProcedure, "[dbo].[uspGetUser]");
                var Employee = new List<User>();
                foreach (DataRow row in dt.Rows)
                {
                    var obj = new User()
                    {
                        ID = (string)row["ID"],
                        FirstName = (string)row["FirstName"],
                        LastName = (string)row["LastName"],
                        DOB = (string)row["DOB"],
                        Gender = (string)row["Gender"],
                        Nationality = (string)row["Nationality"],
                        Language = ((string)row["Language"]),
                        Address = (string)row["Address"],
                        Male = (bool)row["Male"],
                        Female = (bool)row["Female"],
                        Hindi = (bool)row["Hindi"],
                        English = (bool)row["English"],
                        French = (bool)row["French"],
                    };
                    Employee.Add(obj);
                }
                return Employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void InsertEmployee(User employee)
        {
            try
            {
                SqlParameter[] MyParams = new SqlParameter[9];

                MyParams[0] = new SqlParameter("@ID", employee.ID);
                MyParams[1] = new SqlParameter("@FirstName", employee.FirstName);
                MyParams[2] = new SqlParameter("@LastName", employee.LastName);
                MyParams[3] = new SqlParameter("@Gender", employee.Gender);
                MyParams[4] = new SqlParameter("@DOB", employee.DOB);
                MyParams[5] = new SqlParameter("@Language", employee.Language);
                MyParams[6] = new SqlParameter("@Nationality", employee.Nationality);
                MyParams[7] = new SqlParameter("@Address", employee.Address);
                MyParams[8] = new SqlParameter("@Mode", "SAVE");
                
                SqlHelper.ExecuteNonQuery(AppConstants.getConnectionString(), CommandType.StoredProcedure, "[dbo].[uspInsertUser]", MyParams);
                MessageBox.Show("Data Saved Successfully.");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        internal static void UpdateEmployee(User employee)
        {
            try
            {
                SqlParameter[] MyParams = new SqlParameter[9];
                MyParams[0] = new SqlParameter("@ID", employee.ID);
                MyParams[1] = new SqlParameter("@FirstName", employee.FirstName);
                MyParams[2] = new SqlParameter("@LastName", employee.LastName);
                MyParams[3] = new SqlParameter("@Gender", employee.Gender);
                MyParams[4] = new SqlParameter("@DOB", employee.DOB);
                MyParams[5] = new SqlParameter("@Language", employee.Language);
                MyParams[6] = new SqlParameter("@Nationality", employee.Nationality);
                MyParams[7] = new SqlParameter("@Address", employee.Address);
                MyParams[8] = new SqlParameter("@Mode", "UPDATE");
                SqlHelper.ExecuteNonQuery(AppConstants.getConnectionString(), CommandType.StoredProcedure, "[dbo].[uspInsertUser]", MyParams);
                MessageBox.Show("Data Updated Successfully.");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        internal static void DeleteEmployee(User employee)
        {
            try
            {
                SqlParameter[] MyParams = new SqlParameter[1];
                MyParams[0] = new SqlParameter("@ID", employee.ID);
                SqlHelper.ExecuteNonQuery(AppConstants.getConnectionString(), CommandType.StoredProcedure, "[dbo].[uspDeletetUser]", MyParams);
                MessageBox.Show("Data Deleted Successfully.");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
        public static List<NationalityCollection> GetNationality()
        {
            try
            {
                DataTable dt = SqlHelper.ExecuteDataTable(AppConstants.getConnectionString(), CommandType.StoredProcedure, "[dbo].[uspGetNationality]");
                var NationalityList = new List<NationalityCollection>();
                foreach (DataRow row in dt.Rows)
                {
                    var obj = new NationalityCollection()
                    {
                        Nationality = (string)row["Nationality"]
                    };
                    NationalityList.Add(obj);
                }
                return NationalityList;
                // return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
