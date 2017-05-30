using System;
using System.Configuration;
using System.Data.SqlClient;
using WebProject.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace WebProject.Repository
{
    public class StateRepository
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["TestDatabaseConnection"].ToString();
            con = new SqlConnection(constr);

        }
        public List<State> GetAllStates()
        {
            connection();
            var states = new List<State>();
            var command = new SqlCommand("GetAllStates ", con);
            command.CommandType = CommandType.StoredProcedure;
            var data = new SqlDataAdapter(command);
            var datatable = new DataTable();
            con.Open();
            data.Fill(datatable);
            con.Close();
                        
            states = (from DataRow dr in datatable.Rows

                       select new State()
                       {
                           Id = Convert.ToInt32(dr["Id"]),
                           Name = Convert.ToString(dr["Name"])                           
                       }).ToList();
            return states;
        }
    }
}