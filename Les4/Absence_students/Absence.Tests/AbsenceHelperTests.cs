using Absence.Tests.TestDoubles;

namespace Absence.Tests
{
    internal class AbsenceHelperTests
    {
        [Test]
        public void GetPresencePercentageForStudent_AlwaysPresent_Returns1()
        {

            // Arrange
            AbsenceHelper sut = new AbsenceHelper(new AbsenceTrackerStub1());
            Student student = new Student("1", "John", "Doe");

            // Act
            double result = sut.GetPresencePercentageForStudent(student);

            // Assert
            Assert.That(result, Is.EqualTo(1));

        }
        [Test]
        public void GetPresencePercentageForStudent_OneTimePresentAnd3TimesEcxuesd_Returns25percentage()
        {

            // Arrange
            AbsenceHelper sut = new AbsenceHelper(new AbsenceTrackerStub1());
            Student student = new Student("3", "Jaak", "Doe");

            // Act
            double result = sut.GetPresencePercentageForStudent(student);

            // Assert
            Assert.That(result, Is.EqualTo(0.25));

        }
        [Test]
        public void GetPresencePercentageForStudent_WithStudent2TimeAbsentAnd2TimesPresenyt_Returns50Percent()
        {

            // Arrange
            AbsenceHelper sut = new AbsenceHelper(new AbsenceTrackerStub1());
            Student student = new Student("2", "Jane", "Doe");

            // Act
            double result = sut.GetPresencePercentageForStudent(student);

            // Assert
            Assert.That(result, Is.EqualTo(0.5));

        }

        [Test]
        public void CreateAbsenceCheck_With1StudentPresent1StudentAbsent1StudentExcused_ReturnsCorrectAbsenceCheck()
        {

            // Arrange
            IAbsenceTracker fakeAbsenceTracker = new AbsenceTrackerFake1();
            AbsenceHelper sut = new AbsenceHelper(fakeAbsenceTracker);
            Student john = new Student("1", "John", "Doe"); // Aanwezig
            Student jane = new Student("2", "Jane", "Doe"); // Verontschuldigd
            Student jaak = new Student("3", "Jaak", "Doe"); // Afwezig
            List<Student> presentStudents = new List<Student>() { john };
            List<Student> excusedStudents = new List<Student>() { jane };
            sut.AddNewStudent(john);
            sut.AddNewStudent(jane);
            sut.AddNewStudent(jaak);

            // Act
            AbsenceCheck result = sut.CreateAbsenceCheck(presentStudents, excusedStudents);

            // Assert
            Assert.That(result.PresentStudents, Is.EquivalentTo(new List<Student>() { john }));
            Assert.That(result.ExcusedStudents, Is.EquivalentTo(new List<Student>() { jane }));
            Assert.That(result.AbsentStudents, Is.EquivalentTo(new List<Student>() { jaak }));
        }

        [Test]
        public void AddStudent_WithNewStudentAnd1AbsenceCheckAvailable_CallsAddStudentAsAbsentToDay()
        {
            // Arrange
            IAbsenceTracker absenceTrackerMock = new AbsenceTrackerMock1();
            AbsenceHelper sut = new AbsenceHelper(absenceTrackerMock);
            Student s = new Student("1", "John", "Doe");

            // Act
            sut.AddNewStudent(s);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void RemoveStudent_WithStudentInList_CallsExpectedMethodes()
        {

            // Arrange
            AbsenceTrackerSpy1 absenceTrackerSpy = new AbsenceTrackerSpy1();
            AbsenceHelper sut = new AbsenceHelper(absenceTrackerSpy);
            Student john = new Student("1", "John", "Doe");

            // Act
            sut.RemoveStudent(john);

            // Assert
            Assert.That(absenceTrackerSpy.RemoveAbsentStudentsCalled, Is.Empty);
            Assert.That(absenceTrackerSpy.RemoveExcusedStudentsCalled, Is.Empty);
            Assert.That(absenceTrackerSpy.RemovePresentStudentsCalled, Is.EquivalentTo(
                new List<(Student, DateOnly)>()
                {
                    (john,new DateOnly(2024,9,23)),
                    (john,new DateOnly(2024,9,24)),
                    (john,new DateOnly(2024,9,25)),
                    (john,new DateOnly(2024,9,26)),
                }));

        }

        [Test]
        public void RemoveStudent_WithStudentInList_CallsExpectedMethodes1()
        {

            // Arrange
            AbsenceTrackerSpy1 absenceTrackerSpy = new AbsenceTrackerSpy1();
            AbsenceHelper sut = new AbsenceHelper(absenceTrackerSpy);
            Student jane = new Student("2", "Jane", "Doe");

            // Act
            sut.RemoveStudent(jane);

            // Assert
            Assert.That(absenceTrackerSpy.RemoveAbsentStudentsCalled, Is.EquivalentTo(
                new List<(Student, DateOnly)>()
                {
                (jane,new DateOnly(2024,9,25)),
                    (jane,new DateOnly(2024,9,26)),
                }));
            Assert.That(absenceTrackerSpy.RemoveExcusedStudentsCalled, Is.Empty);
            Assert.That(absenceTrackerSpy.RemovePresentStudentsCalled, Is.EquivalentTo(
                new List<(Student, DateOnly)>()
                {
                    (jane,new DateOnly(2024,9,23)),
                    (jane,new DateOnly(2024,9,24))

                }));

        }
    }
}
