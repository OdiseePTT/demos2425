using NSubstitute;
using NUnit.Framework.Internal;

namespace Absence.Nsub.Tests
{
    internal class AbsenceHelperTests
    {

        [Test]
        public void GetPresencePercentageForStudent_AlwaysPresent_Returns1()
        {

            // Arrange
            Student s1 = new Student("1", "John", "Doe");
            Student s2 = new Student("2", "Jane", "Doe");
            Student s3 = new Student("3", "Jaak", "Doe");
            List<AbsenceCheck> absenceChecks = new List<AbsenceCheck>()
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
                   Day = new DateOnly(2024, 09,25)
               }};        
           

            IAbsenceTracker absenceTrackerSub = Substitute.For<IAbsenceTracker>();
            absenceTrackerSub.GetAbsenceChecks().Returns(absenceChecks);

            AbsenceHelper sut = new AbsenceHelper(absenceTrackerSub);
            Student student = new Student("1", "John", "Doe");

            // Act
            double result = sut.GetPresencePercentageForStudent(student);

            // Assert
            Assert.That(result, Is.EqualTo(1.0));
        }

        [Test]

        public void CountPercentageOfStudentsOnDay_WithItems_CalculatesCorrectPercentage()
        {
            // Arrange
            DateOnly day1 = DateOnly.FromDateTime(new DateTime(2024, 09, 01));
            DateOnly day2 = DateOnly.FromDateTime(new DateTime(2024, 09, 02));
            Student student1 = new Student("1", "John", "Doe");
            Student student2 = new Student("2", "Jane", "Doe");
            Student student3 = new Student("3", "Jaak", "Doe");
            Student student4 = new Student("4", "Jef", "Doe");


            IAbsenceTracker absenceTrackerSub = Substitute.For<IAbsenceTracker>();
            //absenceTrackerSub.GetAbsenceCheckOnDate(default).ReturnsForAnyArgs(new AbsenceCheck()
            //{
            //    AbsentStudents = new List<Student>() { student1, student2, student3 },
            //    PresentStudents = new List<Student>() { student4 }
            //});
            absenceTrackerSub.GetAbsenceCheckOnDate(Arg.Any<DateOnly>()).Returns(new AbsenceCheck()
            {
                AbsentStudents = new List<Student>() { student1, student2, student3 },
                PresentStudents = new List<Student>() { student4 }
            });
            absenceTrackerSub.GetAbsenceCheckOnDate(day1).Returns(new AbsenceCheck()
            {
                AbsentStudents = new List<Student>() { student1, student2 },
                PresentStudents = new List<Student>() { student3, student4 }
            });

            absenceTrackerSub.GetAbsenceCheckOnDate(day2).Returns(new AbsenceCheck
            {
                PresentStudents = new List<Student>() { student3, student4, student1, student2 }
            });

            AbsenceHelper sut = new AbsenceHelper(absenceTrackerSub);

            // Act
            double result1 = sut.CountPercentageOfPresentStudentsOnDay(day1);
            double result2 = sut.CountPercentageOfPresentStudentsOnDay(day2);
            double result3 = sut.CountPercentageOfPresentStudentsOnDay(new DateOnly(2024, 10, 1));

            // Assert
            Assert.That(result1, Is.EqualTo(0.5));
            Assert.That(result2, Is.EqualTo(1.0));
            Assert.That(result3, Is.EqualTo(0.25));

        }

        [Test]
        public void RemoveStudent_WithStudentInList_CallsExpectedMethodes()
        {

            // Arrange
            IAbsenceTracker absenceTrackerSub = Substitute.For<IAbsenceTracker>();
            AbsenceHelper sut = new AbsenceHelper(absenceTrackerSub);
            Student s1 = new Student("1", "John", "Doe");
            Student s2 = new Student("2", "Jane", "Doe");
            Student s3 = new Student("3", "Jaak", "Doe");
            List<AbsenceCheck> absenceChecks = new List<AbsenceCheck>()
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
            absenceTrackerSub.GetAbsenceChecks().Returns(absenceChecks);

            // Act
            sut.RemoveStudent(s1);


            // Assert
            absenceTrackerSub.Received().RemovePresentStudentFromDay(s1, new DateOnly(2024, 09, 23));
            absenceTrackerSub.Received().RemovePresentStudentFromDay(s1, new DateOnly(2024, 09, 24));
            absenceTrackerSub.Received().RemovePresentStudentFromDay(s1, new DateOnly(2024, 09, 25));
            absenceTrackerSub.Received().RemovePresentStudentFromDay(s1, new DateOnly(2024, 09, 26));
            absenceTrackerSub.DidNotReceive().RemoveAbsentStudentFromDay(s1,Arg.Any<DateOnly>());
            absenceTrackerSub.DidNotReceiveWithAnyArgs().RemoveExcusedStudentFromDay(default, default);

            absenceTrackerSub.Received(4).RemovePresentStudentFromDay(s1, Arg.Any<DateOnly>());
        }

        [Test]
        public void AddNewStudent_WithNewStudent_UpdateExistingAbsenceChecks()
        {
            IAbsenceTracker absenceTrackerSub = Substitute.For<IAbsenceTracker>();
            AbsenceHelper sut = new AbsenceHelper(absenceTrackerSub);
            Student s1 = new Student("0", "John", "Doe");
            absenceTrackerSub.GetAbsenceChecks().Returns(new List<AbsenceCheck>() { new AbsenceCheck() });
            absenceTrackerSub.When(tracker => tracker.AddStudentAsAbsentToDay(s1, Arg.Any<DateOnly>()))
                .Do( _ => Assert.Pass());

            // Act
            sut.AddNewStudent(s1);


            // Assert
            //absenceTrackerSub.Received().AddStudentAsAbsentToDay(s1, Arg.Any<DateOnly>());

            Assert.Fail();
        }

        [Test]
        public void CreateabsenCheck_WithStudents_ReturnsCorrectAbsenceChech()
        {


            // Arrange
            IAbsenceTracker absenceTrackerSub = Substitute.For<IAbsenceTracker>();
            AbsenceCheck absenceCheck = new AbsenceCheck();
            AbsenceHelper sut = new AbsenceHelper(absenceTrackerSub);
            absenceTrackerSub.When(tracker => tracker.AddStudentAsAbsentToToday(Arg.Any<Student>()))
                .Do(info => absenceCheck.AbsentStudents.Add(info.ArgAt<Student>(0)));
            absenceTrackerSub.When(tracker => tracker.AddStudentAsExcusedToToday(Arg.Any<Student>()))
              .Do(info => absenceCheck.ExcusedStudents.Add(info.ArgAt<Student>(0)));
            absenceTrackerSub.When(tracker => tracker.AddStudentAsPresentToToday(Arg.Any<Student>()))
              .Do(info => absenceCheck.PresentStudents.Add(info.ArgAt<Student>(0)));
           
            absenceTrackerSub.GetAbsenceChecks().Returns(new List<AbsenceCheck>());
            absenceTrackerSub.GetAbsenceCheckOnDate(Arg.Any<DateOnly>()).Returns(absenceCheck);

            Student s1 = new Student("1", "John", "Doe");
            Student s2 = new Student("2", "Jane", "Doe");

            sut.AddNewStudent(s1);
            sut.AddNewStudent(s2);


            // Act
            AbsenceCheck result =  sut.CreateAbsenceCheck(new List<Student> { s1 }, new List<Student> { });

            // Assert
            Assert.That(result.PresentStudents, Is.EquivalentTo(new List<Student>() { s1 }));
            Assert.That(result.ExcusedStudents, Is.EquivalentTo(new List<Student>() {  }));
            Assert.That(result.AbsentStudents, Is.EquivalentTo(new List<Student>() { s2 }));

        }

    }
}
