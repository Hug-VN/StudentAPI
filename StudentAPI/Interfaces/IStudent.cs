using StudentAPI.DTOs;
using StudentAPI.Models;
namespace StudentAPI.Interfaces
{
    public interface IStudent
    {
        List<StudentResponse> ResponseStudent();
        StudentResponse ResponseStudentById(Guid Id);
        Student AddStudent(StudentDTO student);
        Student UpdateStudentHug(StudentDTO student);
        Student DeleteStudentHug(StudentDTO student);
    }
}
