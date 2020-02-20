using System.Data;
using Student_Management_System.DTO;

namespace Student_Management_System.DAL
{
    public interface IStudentDAL
    {
        void AddConstraint();
        void DataFill();
        void DeleteStudentDetails(int Id);
        void EstablishConnection();
        void SaveStudentDetails(StudentDTO studPropertydto);
        DataTable ShowStudentDetails();
        DataTable StudentParticularRecordFetch(int studentId);
        void UpdateStudentdetails(int Id);
    }
}