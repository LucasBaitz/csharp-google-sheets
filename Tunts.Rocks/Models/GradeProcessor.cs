using Tunts.Rocks.Enums;

namespace Tunts.Rocks.Models
{
    public class GradeProcessor
    {
        public void EvaluateStudent(Student student, int toalClasses)
        {
            student.GPA = GetStudentGPA(student);
            student.Situation = CheckSituation(student, toalClasses);
        }

        private double GetStudentGPA(Student student)
        {
            return Math.Round(student.Grades.Average(), 2);
        }

        private Situation CheckSituation(Student student, int totalClasses)
        {

            double absencePercentage = (double)student.Absences / totalClasses;

            if (absencePercentage > 0.25)
            {
                return Situation.FailedByAbsence;
            }
            else
            {
                if (student.GPA < 5)
                {
                    return Situation.FailedByGrade;
                }
                else if (50.00 <= student.GPA && student.GPA < 70.00)
                {
                    student.GradeForFinalExam = CalculateNAF(student);
                    return Situation.FinalExam;
                }
                else
                {
                    return Situation.Passed;
                }
            }
        }

        private double CalculateNAF(Student student)
        {
            return (int)Math.Ceiling(10 - student.GPA);
        }
    }
}
