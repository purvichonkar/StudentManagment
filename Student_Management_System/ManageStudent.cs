using Student_Management_System.BLL;
using Student_Management_System.DAL;
using Student_Management_System.DTO;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Student_Management_System
{
    public class ManageStudent
    {
        private readonly IStudentBLL istudentbll;
        public ManageStudent()//Main class Construcor
        {
            istudentbll = GetStudentData(); 
        }
        private IServiceProvider ResolveDependency()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IStudentDAL, StudentDAL>()
                 .AddTransient<IStudentBLL, StudentBLL>()

                .BuildServiceProvider();
            return serviceProvider;
        }
        private IStudentBLL GetStudentData()
        {
            var serviceProvider = ResolveDependency();
            return serviceProvider.GetService<IStudentBLL>();
        }
        public void StudentDetailsManage()
        {
            Console.WriteLine("Student Information");
            Console.WriteLine("\n__________________");
            Console.Write("1-SELECT ALL.\n2-INSERT.\n3-UPDATE.\n4-DELETE.\n5-SELECT.\n6-Exit.\n");


           // StudentBLL StudentInfo = new StudentBLL();
            int choice;

            do
            {

                //input the number
                Console.Write("\nSelect an option: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:


                        Console.WriteLine("Display All Student Details");
                        Console.WriteLine("_____________________________________________________");
                        istudentbll.ShowStudentDetails();
                        break;
                    case 2:
                        Console.WriteLine("Add Student details");
                        Console.WriteLine("___________________");
                        istudentbll.GetStudentData();
                        break;
                    case 3:
                        Console.WriteLine("Update Data");
                        istudentbll.UpdateStudentDetails();
                        break;
                    case 4:
                        Console.WriteLine("Delete Student Record");
                        istudentbll.DeleteStudentDetails();
                        break;
                    case 5:
                        Console.WriteLine("Display Particular Student Record");
                        istudentbll.StudentParticularRecord();
                        break;
                    case 6:
                        Console.WriteLine("Exit");
                        break;

                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }

               
            } while (choice != 6);
            
        }

       public static void Main(string[] args)
        {
            ManageStudent manage = new ManageStudent();
            manage.StudentDetailsManage();

        }
    }
}
