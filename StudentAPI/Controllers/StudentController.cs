using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;
using StudentAPI.Data;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Services;
using StudentAPI.DTOs;
using StudentAPI.Interfaces;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IStudent _studentRepository;
        public StudentController(DataContext context, IStudent studentRepository)
        {
            _studentRepository = studentRepository;
            _context = context;
        }
        // GET: api/Student
        [HttpGet]
        [Route("All")]
        public List<StudentResponse> GetAllStudents()
        {
            //List<Student> student = await _context.Students.ToListAsync();
            //List<StudentResponse> studentResult = new List<StudentResponse>(); 
            //StudentService studentService = new StudentService();
            //foreach (var studentItem in student)
            //{
            //    StudentResponse studentResponse = studentService.ResponseStudent(studentItem);
            //    studentResult.Add(studentResponse);

            //}
            List<StudentResponse> student = _studentRepository.ResponseStudent();
            return student;

        }

        // GET: api/Category/{studentName}
        //[HttpGet]
        //[Route("{studentName}", Name = "GetStudentByName")]
        //public async Task<ActionResult<StudentResponse>> GetStudentByName(string studentName)
        //{
        //    Student student = await _context.Students.Where(n => n.StudentName == studentName).FirstOrDefaultAsync();
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }
        //    StudentService studentService = new StudentService();
        //    StudentResponse studentResponse = studentService.ResponseStudent(student);
        //    return Ok(studentResponse);
        //}

        // GET: api/Category/{id}
        [HttpGet]
        [Route("{id}", Name = "GetStudentById")]
        public StudentResponse GetStudentById(Guid id)
        {
            //Student student = await _context.Students.Where(n => n.Id == id).FirstOrDefaultAsync();
            //if (student == null)
            //{
            //    return NotFound();
            //}
            //StudentService studentService = new StudentService();
            //StudentResponse studentResponse = studentService.ResponseStudent(student);
            //return Ok(studentResponse);
            StudentResponse studentResult = _studentRepository.ResponseStudentById(id);
            return studentResult;
        }

        // POST: api/Student
        [HttpPost]
        [Route("All", Name = "CreateStudent")]
        public Student CreateStudent(StudentDTO student)
        {
            //category.Id = new int(); // Ensure a new Guid is created for the category
            //_context.StudentDTOs.Add(student);
            //StudentService studentService = new StudentService();
            //Student student1 = studentService.AddStudent(student);
            //_context.Students.Add(student1);
            //await _context.SaveChangesAsync();
            //return CreatedAtAction(nameof(GetStudentById), new { id = student1.Id }, student1);
            Student studentResult = _studentRepository.AddStudent(student);
            return studentResult;
        }

        // PUT: api/Student
        [HttpPut]
        [Route("All", Name = "UpdateStudent")]
        public Student UpdateStudent(StudentDTO student)
        {
            //Student uStudent = await _context.Students.Where(n => n.StudentName == student.StudentName).FirstOrDefaultAsync();
            //if (uStudent == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    StudentService studentService = new StudentService();
            //    Student student1 = studentService.UpdateStudentHug(student, uStudent);
            //    await _context.SaveChangesAsync();
            //    return Ok(student1);
            //}
            Student studentResult = _studentRepository.UpdateStudentHug(student);
            return studentResult;

        }

        // DELETE: api/Student/{id}
        [HttpDelete]
        [Route("All", Name = "DeleteStudent")]
        public Student DeleteStudent(StudentDTO student)
        {
            //    var student = await _context.Students.FindAsync(id);
            //    if (student == null)
            //    {
            //        return NotFound();
            //    }

            //    _context.Students.Remove(student);
            //    await _context.SaveChangesAsync();

            //    return NoContent();
            //}

            //private bool StudentExists(Guid id)
            //{
            //    return _context.Students.Any(e => e.Id == id);
            //}
            Student studentResult = _studentRepository.DeleteStudentHug(student);
            return studentResult;
        }
    }
}
