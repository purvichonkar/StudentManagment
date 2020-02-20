using Student_Management_System.DAL;
using Student_Management_System.DTO;
using System;
using System.Data;

namespace Student_Management_System.BLL
{
    public class StudentBLL : IStudentBLL
    {
        private static DataTable dt = new DataTable();
        private static StudentDAL _studentData = new StudentDAL();
        StudentDTO studentDetail = new StudentDTO();

        private readonly IStudentDAL _istudentdal;
        public StudentBLL(IStudentDAL istudentdal)
        {
            _istudentdal = istudentdal;
            _studentData.EstablishConnection();
        }
      
        public void GetStudentData()
        {

            
           // Console.WriteLine("Student Name");
           // studentDetail.Studentname = Console.ReadLine();
         //   Console.WriteLine("Student Age");
           // studentDetail.Age = Convert.ToInt32(Console.ReadLine());
         //   Console.WriteLine("Student Address");
           // studentDetail.Address = Console.ReadLine();
         //   Console.WriteLine("Student Phoneno");
           // studentDetail.Phoneno =int.Parse(Console.ReadLine());
                        
            
            studentDetail.Studentname = "abc";
            studentDetail.Age = 21;
            studentDetail.Address = "xyz";
            studentDetail.Phoneno = 9874563;

            _studentData.SaveStudentDetails(studentDetail);

        }
        public void ShowStudentDetails()
        {

            dt = _studentData.ShowStudentDetails();
            Console.WriteLine("STUDENTID STUDENTNAME \tAGE \tADDRESS\t\tPHONENO");
            Console.WriteLine("_____________________________________________________");
            _studentData.ShowStudentDetails();
            //foreach(DataColumn columnName in dt.Columns)
            //{
             //   Console.WriteLine( columnName.ColumnName+"\t");
           // }
            foreach(DataRow row in dt.Rows)
            {
                Console.WriteLine(row["Id"]+ "\t"+row["Studentname"] + "\t\t" + row["Age"] + " \t" + row["Address"] + "\t \t" + row["Phoneno"]);
            }
        }
        public void UpdateStudentDetails()
        {
            //int Id;
            ////Console.WriteLine("Student Id");
            //Id = 2;//int.Parse(Console.ReadLine());


            studentDetail.Studentname = "abc";
            studentDetail.Age = 21;
            studentDetail.Address = "xyz";
            studentDetail.Phoneno = 9874563;
            _studentData.UpdateStudentdetails(2);
            
            
        }
        public void DeleteStudentDetails()
        {
            int Id=2;
           // Console.WriteLine("Enter Student ID");
           // Id = int.Parse(Console.ReadLine());

            _studentData.DeleteStudentDetails(Id);

        }
        public void StudentParticularRecord()
        {
            int studentId;
            Console.WriteLine("Enter Student Id:");
            studentId = int.Parse(Console.ReadLine());
            dt = _studentData.StudentParticularRecordFetch(studentId);
            foreach(DataRow row in dt.Rows)
            {
                Console.WriteLine("STUDENTID STUDENTNAME \tAGE \tADDRESS\t\tPHONENO");
                Console.WriteLine("_____________________________________________________");
                Console.WriteLine(row["Id"]+"\t\t"+row["Studentname"]+"\t"+row["Age"]+"\t"+row["Address"]+ "\t\t"+ row["Phoneno"] );
            }

        }

    }
}
