using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineFoodProject.API.Models;

namespace OnlineFoodProject.API.Controllers
{
    public class SignUpController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                    select CustomerId,Username,Password,EmailId,MobileNo from
                    dbo.SignUp
                    ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["CustomerdbAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);


        }
        public string Post(SignUp sg)
        {
            try
            {
                string query = @"
                    insert into dbo.SignUp values
                    ('" + sg.Username + @"','" + sg.Password + @"','" + sg.EmailId + @"','" + sg.MobileNo + @"')
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["CustomerdbAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Registered Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Registered!!";
            }
        }


        public string Put(SignUp sg)
        {
            try
            {
                string query = @"
                    update dbo.SignUp set Username=
                    '" + sg.Username + @"',Password=
                    '" + sg.Password + @"',EmailId=
                    '" + sg.EmailId + @"',MobileNo=
                    '" + sg.MobileNo + @"'
                    where CustomerId=" + sg.CustomerId + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["CustomerdbAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Update!!";
            }
        }


        public string Delete(int id)
        {
            try
            {
                string query = @"
                    delete from dbo.SignUp 
                    where CustomerId=" + id + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["CustomerdbAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Delete!!";
            }
        }



    }
}
