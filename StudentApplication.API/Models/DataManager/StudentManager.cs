using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentApplication.API.Models.Repository;

namespace StudentApplication.API.Models.DataManager
{
    public class StudentManager : IDataRepository<Student, long>
    {
        ApplicationContext ctx;
        public StudentManager(ApplicationContext c)
        {
            ctx = c;
        }

        public Student Get(long id)
        {
            var student = ctx.Students.FirstOrDefault(b => b.StudentId == id);
            return student;
        }

        public IEnumerable<Student> GetAll()
        {
            var students = ctx.Students.ToList();
            return students;
        }

        public long Add(Student student)
        {
            ctx.Students.Add(student);
            long studentId = ctx.SaveChanges();
            return studentId;
        }

        public long Delete(long id)
        {
            int studentId = 0;
            var student = ctx.Students.FirstOrDefault(b => b.StudentId == id);
            if(student != null)
            {
                ctx.Students.Remove(student);
                ctx.SaveChanges();
            }
            return studentId;
        }

        public long Update(long id, Student item)
        {
            long studentId = 0;
            var student = ctx.Students.Find(id);
            if(student != null)
            {
                student.FirstName = item.FirstName;
                student.LastName = item.LastName;
                student.Gender = item.Gender;
                student.PhoneNumber = item.PhoneNumber;
                student.Email = item.Email;
                student.DateOfBirth = item.DateOfBirth;
                student.DateOfRegistration = item.DateOfRegistration;
                student.Address1 = item.Address1;
                student.Address2 = item.Address2;
                student.City = item.City;
                student.State = item.State;
                student.Zip = item.Zip;
                studentId = ctx.SaveChanges();
            }
            return studentId;
        }
    }
}
