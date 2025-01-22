using Microsoft.EntityFrameworkCore;
using StudentAPI.Data;
using StudentAPI.DTOs;
using StudentAPI.Models;
using StudentAPI.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace StudentAPI.Services
{
    public class StudentService : IStudent
    {
        private readonly DataContext _context;
        public StudentService(DataContext context)
        {
            _context = context;
        }
        public List<StudentResponse> ResponseStudent ()
        {
            List<Student> student1 = _context.Students.ToList();
            List<StudentResponse> studentResult = new List<StudentResponse>();
            StudentResponse studentResponse = new StudentResponse ();
            foreach (var studentItem in student1)
            {
                studentResponse.StudentEmail = studentItem.StudentEmail;
                studentResponse.StudentPhone = studentItem.StudentPhone;
                studentResponse.StudentName = studentItem.StudentName;
                studentResponse.StudentGender = studentItem.StudentGender;
                studentResult.Add(studentResponse);
                studentResponse = new StudentResponse();
            }

            return studentResult;
        }
        public StudentResponse ResponseStudentById(Guid Id)
        {
            Student student = _context.Students.Find(Id);
            if (student == null)
            {
                return null;
            }
            StudentResponse studentResponse = new StudentResponse();
            studentResponse.StudentEmail = student.StudentEmail;
            studentResponse.StudentPhone = student.StudentPhone;
            studentResponse.StudentName = student.StudentName;
            studentResponse.StudentGender = student.StudentGender;
            return studentResponse;

        }

        public Student AddStudent (StudentDTO student)
        {
            Student toAddStudent = new Student()
            {
                Id = Guid.NewGuid(),
                StudentEmail = student.StudentEmail,
                StudentPhone = student.StudentPhone,
                StudentAddress = student.StudentAddress,
                StudentGender = student.StudentGender,
                StudentName = student.StudentName,
            };
            _context.Students.Add(toAddStudent);
            _context.SaveChanges();
            return toAddStudent;
        }

        public Student UpdateStudentHug(StudentDTO student)
        {
            Student uStudent = _context.Students.Where(n => n.StudentName == student.StudentName).FirstOrDefault();
            if (uStudent == null)
            {
                return null;
            }

            uStudent.StudentName = student.StudentName;
            uStudent.StudentEmail = student.StudentEmail;
            uStudent.StudentPhone = student.StudentPhone;
            uStudent.StudentAddress = student.StudentAddress;
            uStudent.StudentGender = student.StudentGender;
            _context.SaveChanges();
            return uStudent;
        }
        public Student DeleteStudent(StudentDTO student)
        {
            Student student1 = _context.Students.Where(n => n.StudentName == student.StudentName).FirstOrDefault();
            if (student1 == null)
            {
                return null;
            }
            _context.Students.Remove(student1);
            _context.SaveChanges();
            return student1;
        }

        public Student DeleteStudentHug(StudentDTO student)
        {
            throw new NotImplementedException();
        }
    }
}
