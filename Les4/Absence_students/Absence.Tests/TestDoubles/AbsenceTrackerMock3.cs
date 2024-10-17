
namespace Absence.Tests.TestDoubles
{
    internal class AbsenceTrackerMock3 : IAbsenceTracker
    {
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
            return new List<AbsenceCheck>()
            {
                new AbsenceCheck()
                {
                    Day = new DateOnly(2024,1,2),
                    PresentStudents = new List<Student>()
                    {
                        new Student("2", "Jane", "Doe")
                    },
                    AbsentStudents = new List<Student>()
                    {
                        new Student("3", "Jef", "Doe")
                    },
                    ExcusedStudents = new List<Student>()
                    {
                        new Student("4", "Julie", "Doe")
                    }
                }
            };
        }

        public void RemoveAbsenceCheck(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void RemoveAbsentStudentFromDay(Student s, DateOnly date)
        {
            Assert.Fail();
        }

        public void RemoveExcusedStudentFromDay(Student s, DateOnly date)
        {
            Assert.Fail();
        }

        public void RemovePresentStudentFromDay(Student s, DateOnly date)
        {
            Assert.Fail();
        }
    }
}