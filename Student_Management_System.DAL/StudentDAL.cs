using System;
using System.Data;
using System.Data.SqlClient;
using Student_Management_System.DTO;
using System.Configuration;

namespace Student_Management_System.DAL
{
    public class StudentDAL : IStudentDAL
    {
        private static SqlConnection studentcon;
        private  string connect;

        SqlDataAdapter dataAdapter;
        SqlCommandBuilder command;
        private static DataTable dt;

        public void EstablishConnection()
        {
            //connect = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
             connect = @"Data Source=CS23-PC\SQLEXPRESS;Initial Catalog = StudentInfo; Integrated Security = True";
             studentcon = new SqlConnection(connect);

        }

        //SqlConnection studentcon = new SqlConnection(@"Data Source=CS23-PC\SQLEXPRESS;Initial Catalog=StudentInfo;Integrated Security=True");
        //@"Data Source = CS23 - PC\SQLEXPRESS; Initial Catalog = StudentInfo; Integrated Security = True");
        public void DataFill()
        {
            string query = "select * from Student_table";
            dataAdapter = new SqlDataAdapter(query, studentcon);
            command = new SqlCommandBuilder(dataAdapter);
            dt= new DataTable();
            dataAdapter.Fill(dt);
        }
        public void AddConstraint()
        {
            dt.Constraints.Add("Id", dt.Columns[0], true);
        }
        public DataTable ShowStudentDetails()
        {
            try
            {
                DataFill();
               
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception"+e);
            }
            finally
            {
                studentcon.Close();
            }
       
            return dt;
        }
        public DataTable StudentParticularRecordFetch(int studentId)
        {
            string query = " select * from Student_table where Id=" + studentId;
            dataAdapter = new SqlDataAdapter(query, studentcon);
            dt = new DataTable();
            dataAdapter.Fill(dt);
            
            return dt;
        }
        public void UpdateStudentdetails(int Id)
        {
            DataFill();
            //AddConstraint();29-01-2020
            //if (dt.Rows.Contains(Id))
            //{
            //    DataRow dataRow = dt.Rows.Find(Id);
            //    Console.WriteLine("Record Found");
            //    dataRow.BeginEdit();
            //    Console.WriteLine("Enter Update Address ");
            //    dataRow["Address"] = Console.ReadLine();
            //    Console.WriteLine("Record Update Successfully..");
            //    dataRow.EndEdit();
            //    dataAdapter.Update(dt);
            //   // Console.WriteLine("Record Deleted");


            //}

        }
        public void DeleteStudentDetails(int Id)
        {
            DataFill();
            try
            {
                //Console.WriteLine("Find and Delete");
                AddConstraint();
                if(!dt.Rows.Contains(Id))
                {
                    Console.WriteLine("No Record found");
                }
                else
                {
                    DataRow dataRow = dt.Rows.Find(Id);
                    Console.WriteLine("STUDENTID STUDENTNAME \tAGE \tADDRESS\t\tPHONENO");
                    Console.WriteLine("__________________________________________________________");
                    Console.WriteLine(dataRow[0] + "\t\t"+ dataRow[1] +"\t"+ dataRow[2] +"\t"+ dataRow[3] +"\t"+ dataRow[4]);
                    dataRow.Delete();
                    dataAdapter.Update(dt);
                    Console.WriteLine("\nRecord Delete...");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Exeption"+e);
            }
        }


        public void SaveStudentDetails(StudentDTO studPropertydto)
        {
            //try
            {

                DataFill();
                SqlDataAdapter da = new SqlDataAdapter("select * from Student_table", studentcon);
                SqlCommandBuilder command = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "Student_table");

                DataRow row= ds.Tables["Student_table"].NewRow();
                row["Id"] = studPropertydto.Id;
                row["Studentname"] = studPropertydto.Studentname;
                row["Age"] = studPropertydto.Age;
                row["Address"] = studPropertydto.Address;
                row["Phoneno"] = studPropertydto.Phoneno;
                ds.Tables["Student_table"].Rows.Add(row);

                da.Update(ds.Tables["Student_table"]);
               // Console.WriteLine("Data Successfully Inserted...");

             //   Console.ReadKey();
            }
            //catch (Exception e)
            //{
            //    Console.WriteLine("Exeption" + e);
            //}
           
        }
       
       
    }
    
}
