using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using Microsoft.Extensions.Configuration;
using ProjectSource.Models;
namespace ProjectSource.DAL
{
    public class ClinicDAL
    {
        public string cnn = "";


        public ClinicDAL()
        {
            var builder = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cnn = builder.GetSection("ConnectionStrings:Conne").Value;
        }
        public int Doctord(Doctor doc)
        {
            
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("Doctoradd", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fname", doc.Firstname);
            cmd.Parameters.AddWithValue("@lname", doc.Lastname);
            cmd.Parameters.AddWithValue("@gen", doc.Gender);
            cmd.Parameters.AddWithValue("@spec", doc.Specialization);
            cmd.Parameters.AddWithValue("@vis", doc.Visitinghours);
            cmd.Parameters.AddWithValue("@tim", doc.Timing);
            con.Open();
           int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int Patientp(Patient pat)
        {
            int result;
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("Patientadd", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@finame", pat.Firstname);
            cmd.Parameters.AddWithValue("@laname", pat.Lastname);
            cmd.Parameters.AddWithValue("@gend", pat.Gender);
            cmd.Parameters.AddWithValue("@Dob", pat.Dateofbirth);
            cmd.Parameters.AddWithValue("@age", pat.Age);

            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
