
using Tunts.Rocks.Enums;

namespace Tunts.Rocks.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Absences { get; set; }
        public double GPA { get; set; }
        public double GradeForFinalExam { get; set; }
        public List<double> Grades { get; set; } = new List<double>();
        public Situation Situation;

        public override string ToString()
        {
            return $"{Id} - {Name} - Absences: {Absences} - GPA: {GPA} - Grade for Final Exam: {GradeForFinalExam} - Situation: {Situation}";
        }
    }
}
