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

        //checking user
        public int CheckUse(User us)
        {
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("ChkUsr", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@User", us.Username);
            cmd.Parameters.AddWithValue("@Pass", us.Paasword);
            con.Open();
            IDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
                return (1);

            con.Close();
            return (0);
        }


        //adding doctor
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
            cmd.Parameters.AddWithValue("@tim", doc.Timings);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }


        //adding patients
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


        //scheduling appointments
        public int Schedulec(Schedule sc)
        {

            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("GetAppmnt", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Patid", sc.PatientId);
            cmd.Parameters.AddWithValue("@spec", sc.Specializations);
            cmd.Parameters.AddWithValue("@doctor", sc.DoctorName);
            cmd.Parameters.AddWithValue("@vd", sc.VisitDate);
            cmd.Parameters.AddWithValue("@at", sc.AppointmentTime);

            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        //view appointments
        public List<Schedule> Viewappointment()
        {
            List<Schedule> listschedule = new List<Schedule>();
            using (SqlConnection con = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("GetAppmnts", con))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        listschedule.Add(new Schedule()
                        {
                            AppointmentId = int.Parse(reader["AppointmentId"].ToString()),
                            PatientId = int.Parse(reader["PatientID"].ToString()),
                            Specializations = reader["Specializations"].ToString(),
                            DoctorName = reader["DoctorName"].ToString(),
                            VisitDate = reader["VisitDate"].ToString(),
                            AppointmentTime = reader["AppointmentTime"].ToString()
                        });
                    }

                }
            }
            return listschedule;
        }
        
        //deletedata
        public int Deletedat(int id)
        {
            int result;
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("Delsch", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        //viewdoctor
        public List<Doctor> Viewdoctor()
        {
            List<Doctor> listDoctor = new List<Doctor>();
            using (SqlConnection con = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("GetDoctor", con))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        listDoctor.Add(new Doctor()
                        {
                            Doctorid = int.Parse(reader["Doctorid"].ToString()),
                            Firstname = reader["Firstname"].ToString(),
                            Lastname = reader["Lastname"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            Specialization = reader["Specialization"].ToString(),
                            Visitinghours = reader["Visitinghours"].ToString(),
                            Timings=reader["Timings"].ToString()
                        });
                    }
                }
            }
            return listDoctor;
        }
        public int DeleteDoc(int id)
        {
            int result;
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("Deletedocter", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@did", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }

}


