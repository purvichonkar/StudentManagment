using System;
using Xunit;
using Moq;
using Student_Management_System.DAL;
using Student_Management_System.BLL;
using Student_Management_System.DTO;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Check_UpdateStudentDetails()
        {
            //arrange
            int id = 2;
            var Studdal = new Mock<IStudentDAL>();
            Studdal.Setup(x => x.UpdateStudentdetails(2));
            //Studdal.Setup(x=>x.UpdateStudentdetails(id));
            StudentBLL sBll = new StudentBLL(Studdal.Object);
            //act
            sBll.UpdateStudentDetails();
            //Assert
            Studdal.VerifyAll();
        }
        [Fact]
        public void Check_DeleteStudentData()
        {
            //Arrange
            int id = 7;
            var studdal = new Mock<IStudentDAL>();
            studdal.Setup(x => x.DeleteStudentDetails(id));
            StudentBLL studentBLL = new StudentBLL(studdal.Object);
            //Act
            studentBLL.DeleteStudentDetails();
            studdal.VerifyAll();
            //Assert
        }

        [Fact]
        public void Check_insert_studentdata()
        {
            //Arrange
            var Studdal = new Mock<IStudentDAL>();
            Studdal.Setup(x => x.SaveStudentDetails(studdto));
            StudentBLL studentbll = new StudentBLL(Studdal.Object);
            
            //Act
            studentbll.GetStudentData();

            //Assert
             Studdal.VerifyAll();
        }
       StudentDTO studdto = new StudentDTO
        {

            Id = 11,
            Studentname = "poorvi",
            Age = 21,
            Address = "valsad",
            Phoneno = 987456
        };
    }
}
