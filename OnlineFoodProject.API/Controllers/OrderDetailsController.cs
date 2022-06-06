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
    public class OrderDetailsController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                    select OrderId,Ordername,Orderquantity,Orderprice,DeliveryAddress,Paymentmethod from
                    dbo.OrderDetails
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
        public string Post(OrderDetails od)
        {
            try
            {
                string query = @"
                    insert into dbo.SignUp values
                    ('" + od.Ordername + @"','" + od.Orderquantity + @"','" + od.Orderprice + @"','" + od.DeliveryAddress + @"','" + od.Paymentmethod + @"')
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

                return "Ordered Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Ordered!!";
            }
        }


        public string Put(OrderDetails od)
        {
            try
            {
                string query = @"
                    update dbo.OrderDetails set Ordername=
                    '" + od.Ordername + @"',Orderquantity=
                    '" + od.Orderquantity + @"',Orderprice=
                    '" + od.Orderprice + @"',DeliveryAddress=
                    '" + od.DeliveryAddress + @"',Paymentmethod=
                    '" + od.Paymentmethod + @"'
                    where CustomerId=" + od.OrderId + @"
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
                    delete from dbo.OrderDetails 
                    where OrderId=" + id + @"
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
