using System;
using System.Collections.Generic;
using System.Linq;

namespace LogicianJokeGenerator
{
    public sealed class LogiciansInPub
    {
        private readonly List<Logician> _logicians;
        private readonly List<Answer> _answers;

        public LogiciansInPub(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException(nameof(count));
            }

            _logicians = new List<Logician>(count);
            _answers = new List<Answer>();

            FillLogicians(count);
            CalcAnswers();
        }

        public IReadOnlyCollection<Answer> Answers => _answers;

        private void FillLogicians(int count)
        {
            var random = new Random();
            for (var i = 0; i < count; i++)
            {
                var wantBeer = random.Next(0, 2) != 0;
                var logician = new Logician(wantBeer);
                _logicians.Add(logician);
            }
        }

        private void CalcAnswers()
        {
            foreach (var logician in _logicians)
            {
                var anyAnswerNo = _answers.Any(a => a == Answer.No);
                var allAnswersYes = IsLastAnswer() && _answers.All(a => a == Answer.Yes || a == Answer.DontKnow);
                var answer = logician.DoYouWantBeer(anyAnswerNo, allAnswersYes);
                _answers.Add(answer);
            }
        }

        private bool IsLastAnswer()
        {
            return _logicians.Count - 1 == _answers.Count;
        }
    }
}