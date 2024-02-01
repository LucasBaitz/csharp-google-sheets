using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tunts.Rocks.Enums;

namespace Tunts.Rocks.Helpers
{
    public class SituationParser
    {
        private Dictionary<Situation, string> _situationDict;
        public SituationParser()
        {
            _situationDict = new Dictionary<Situation, string>()
            {
                { Situation.FailedByGrade, "Reprovado por Nota" },
                { Situation.FailedByAbsence, "Reprovado por Falta" },
                { Situation.FinalExam, "Exame Final" },
                { Situation.Passed, "Aprovado" }
            };
        }

        public string GetValue(Situation situation)
        {
            return _situationDict[situation];
        }
    }
}
