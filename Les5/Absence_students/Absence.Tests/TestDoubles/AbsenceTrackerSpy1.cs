using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Absence.Tests.TestDoubles
{
    internal class AbsenceTrackerSpy1 : IAbsenceTracker
    {

        public List<(Student, DateOnly)> RemoveAbsentStudentsCalled { get; set; } = new List<(Student, DateOnly)>();

        public List<(Student, DateOnly)> RemovePresentStudentsCalled { get; set; } = new List<(Student, DateOnly)>();
        public List<(Student, DateOnly)> RemoveExcusedStudentsCalled { get; set; } = new List<(Student, DateOnly)>();
        public void AddStudentAsAbsentToDay(Student s, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void AddStudentAsAbsentToToday(Student s)
        {
            throw new NotImplementedException();
        }

        public void AddStudentAsExcusedToDay(Student s, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void AddStudentAsExcusedToToday(Student s)
        {
            throw new NotImplementedException();
        }

        public void AddStudentAsPresentToDay(Student s, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void AddStudentAsPresentToToday(Student s)
        {
            throw new NotImplementedException();
        }

        public AbsenceCheck? GetAbsenceCheckOnDate(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public List<AbsenceCheck> GetAbsenceChecks()
        {
            Student s1 = new Student("1", "John", "Doe");
            Student s2 = new Student("2", "Jane", "Doe");
            Student s3 = new Student("3", "Jaak", "Doe");
            return new List<AbsenceCheck>()
           {
               new AbsenceCheck() {
                   PresentStudents = new List<Student>() {s1, s2, s3 },
                   AbsentStudents = new List<Student>(),
                   ExcusedStudents = new List<Student>(),
                   Day = new DateOnly(2024, 09,23)
               },
                 new AbsenceCheck() {
                   PresentStudents = new List<Student>() {s1, s2},
                   AbsentStudents = new List<Student>(),
                   ExcusedStudents = new List<Student>(){s3},
                   Day = new DateOnly(2024, 09,24)
               },
                   new AbsenceCheck() {
                   PresentStudents = new List<Student>() {s1},
                   AbsentStudents = new List<Student>(){s2},
                   ExcusedStudents = new List<Student>() {s3 },
                   Day = new DateOnly(2024, 09,25)
               },
                new AbsenceCheck() {
                   PresentStudents = new List<Student>() {s1},
                   AbsentStudents = new List<Student>(){s2},
                   ExcusedStudents = new List<Student>() {s3 },
                   Day = new DateOnly(2024, 09,26)
               }};
        }

        public void RemoveAbsenceCheck(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void RemoveAbsentStudentFromDay(Student s, DateOnly date)
        {
            RemoveAbsentStudentsCalled.Add((s, date));
        }

        public void RemoveExcusedStudentFromDay(Student s, DateOnly date)
        {
            RemoveExcusedStudentsCalled.Add((s, date));
        }

        public void RemovePresentStudentFromDay(Student s, DateOnly date)
        {
            RemovePresentStudentsCalled.Add((s, date));
        }
    }
}
