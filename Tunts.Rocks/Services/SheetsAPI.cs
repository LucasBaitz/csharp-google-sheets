using Google.Apis.Sheets.v4.Data;
using Google.Apis.Sheets.v4;
using Tunts.Rocks.Helpers;
using Tunts.Rocks.Models;

namespace Tunts.Rocks.Services
{
    public class SheetsAPI
    {
        private readonly SheetsService _sheetsService;
        private readonly GradeProcessor _gradeProcessor;
        private readonly SituationParser _situationParser;
        private readonly string _spreadsheetId;

        public SheetsAPI(SheetsService sheetsService, string spreadsheetId)
        {
            _sheetsService = sheetsService;
            _spreadsheetId = spreadsheetId;
            _gradeProcessor = new();
            _situationParser = new();
        }

        public void ProcessGrades()
        {
            string range = "A2:I";

            SpreadsheetsResource.ValuesResource.GetRequest request =
                _sheetsService.Spreadsheets.Values.Get(_spreadsheetId, range);

            ValueRange response = request.Execute();

            IList<IList<object>> values = response.Values;
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    if (!int.TryParse(row[0].ToString(), out int matricula))
                    {
                        continue;
                    }

                    Student student = RowToStudent(row);

                    EvaluateAndUpdateStudent(student, 60);
                }
            }
            else
            {
                Console.WriteLine("No data found.");
            }
        }

        private Student RowToStudent(IList<object> studentRow)
        {
            int id = Convert.ToInt32(studentRow[0]);
            string name = studentRow[1].ToString();
            int absences = Convert.ToInt32(studentRow[2]);
            double p1 = Convert.ToDouble(studentRow[3]);
            double p2 = Convert.ToDouble(studentRow[4]);
            double p3 = Convert.ToDouble(studentRow[5]);

            Student student = new()
            {
                Id = id,
                Name = name,
                Absences = absences,
                Grades = { p1, p2, p3 }

            };

            return student;
        }

        private void EvaluateAndUpdateStudent(Student student, int totalClasses)
        {
            _gradeProcessor.EvaluateStudent(student, totalClasses);

            UpdateStudentData(student);
        }

        private void UpdateStudentData(Student student)
        {
            var studentSituationString = _situationParser.GetValue(student.Situation);

            List<IList<object>> values = new List<IList<object>>
            {
                new List<object> { studentSituationString, student.GradeForFinalExam }
            };

            string range = $"G{student.Id + 3}:H{student.Id + 3}";

            ValueRange body = new ValueRange
            {
                Values = values
            };

            SpreadsheetsResource.ValuesResource.UpdateRequest updateRequest =
                _sheetsService.Spreadsheets.Values.Update(body, _spreadsheetId, range);
            updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;

            UpdateValuesResponse result = updateRequest.Execute();

            ConsoleEX.WriteLineWithColor($"{result.UpdatedCells} cells updated for student {student}", ConsoleColor.DarkYellow);
        }
    }
}