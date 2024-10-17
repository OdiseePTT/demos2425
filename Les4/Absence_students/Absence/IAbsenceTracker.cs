
namespace Absence
{
    public interface IAbsenceTracker
    {
        void AddStudentAsAbsentToDay(Student s, DateOnly date);
        void AddStudentAsAbsentToToday(Student s);
        void AddStudentAsExcusedToDay(Student s, DateOnly date);
        void AddStudentAsExcusedToToday(Student s);
        void AddStudentAsPresentToDay(Student s, DateOnly date);
        void AddStudentAsPresentToToday(Student s);
        AbsenceCheck? GetAbsenceCheckOnDate(DateOnly date);
        List<AbsenceCheck> GetAbsenceChecks();
        void RemoveAbsenceCheck(DateOnly date);
        void RemoveAbsentStudentFromDay(Student s, DateOnly date);
        void RemoveExcusedStudentFromDay(Student s, DateOnly date);
        void RemovePresentStudentFromDay(Student s, DateOnly date);
    }
}