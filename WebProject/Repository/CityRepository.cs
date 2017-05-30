using System;
using System.Configuration;
using System.Data.SqlClient;
using WebProject.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace WebProject.Repository
{
    public class CityRepository
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["TestDatabaseConnection"].ToString();
            con = new SqlConnection(constr);

        }
        public List<City> GetAllCitiesByStateId(int stateId)
        {
            connection();
            var cities = new List<City>();
            var command = new SqlCommand("GetAllCitiesByStateId", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@StateId", stateId);
            var data = new SqlDataAdapter(command);
            var datatable = new DataTable();
            con.Open();
            data.Fill(datatable);
            con.Close();

            cities = (from DataRow dr in datatable.Rows

                      select new City()
                      {
                          Id = Convert.ToInt32(dr["Id"]),
                          Name = Convert.ToString(dr["Name"]),
                          StateId = Convert.ToInt32(dr["Id"])
                      }).ToList();
            return cities;
        }
    }
}