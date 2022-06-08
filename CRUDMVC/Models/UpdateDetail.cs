using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUDMVC.Models
{
    public class UpdateDetail
    {
        public void Update(tbl_Student student)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CrudMVC;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE tbl_Student SET Name = @name, Course = @course, Gender = @gender, Address = @address, Email = @email WHERE ID = @id ";

                SqlCommand cmd = new SqlCommand(query, conn);

                //SqlParameter paraID = new SqlParameter();
                //paraID.ParameterName = "@id";
                //paraID.Value = student.ID;
                //cmd.Parameters.Add(paraID);

                //SqlParameter paraName = new SqlParameter();
                //paraName.ParameterName = "@name";
                //paraName.Value = student.Name;
                //cmd.Parameters.Add(paraName);

                //SqlParameter paraCourse = new SqlParameter();
                //paraCourse.ParameterName = "@course";
                //paraCourse.Value = student.Course;
                //cmd.Parameters.Add(paraCourse);

                //SqlParameter paraGender = new SqlParameter();
                //paraGender.ParameterName = "@gender";
                //paraGender.Value = student.Gender;
                //cmd.Parameters.Add(paraGender);

                //SqlParameter paraAddress = new SqlParameter();
                //paraAddress.ParameterName = "@address";
                //paraAddress.Value = student.Address;
                //cmd.Parameters.Add(paraAddress);

                //SqlParameter paraEmail = new SqlParameter();
                //paraEmail.ParameterName = "@email";
                //paraEmail.Value = student.Email;
                //cmd.Parameters.Add(paraEmail);

                cmd.Parameters.AddWithValue("@id", student.ID);
                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@course", student.Course);
                cmd.Parameters.AddWithValue("@gender", student.Gender);
                cmd.Parameters.AddWithValue("@address", student.Address);
                cmd.Parameters.AddWithValue("@email", student.Email);

                conn.Open();
                cmd.ExecuteNonQuery();
                //int i = cmd.ExecuteNonQuery();
                //conn.Close();

                //if (i>0)
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}




            }
        }

        public void DeleteRecord(int id)
        {
            string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CrudMVC;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "DELETE FROM tbl_Student WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DisplayRecord(int id)
        {
            string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CrudMVC;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "SELECT Name, Course, Gender, Address, Email FROM tbl_Student WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}