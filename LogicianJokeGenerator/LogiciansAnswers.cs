using System.Collections.Generic;

namespace LogicianJokeGenerator
{
    public sealed class LogiciansAnswers
    {
        private readonly object _lockObject = new object();
        private readonly IReadOnlyCollection<Logician> _logicians;
        private readonly List<Answer> _answers;

        public LogiciansAnswers(IReadOnlyCollection<Logician> logicians)
        {
            _logicians = logicians;
            _answers = new List<Answer>(logicians.Count);
        }

        public IReadOnlyCollection<Answer> Answers
        {
            get
            {
                lock (_lockObject)
                {
                    if (_answers.Count != _logicians.Count)
                    {
                        AddLogicianAnswers();
                    }

                    return _answers;
                }
            }
        }

        private void AddLogicianAnswers()
        {
            foreach (var logician in _logicians)
            {
                var isLastAnswer = IsLastAnswer();
                var answer = logician.DoYouWantBeer(_answers, isLastAnswer);
                _answers.Add(answer);
            }
        }

        private bool IsLastAnswer()
        {
            return _logicians.Count - 1 == _answers.Count;
        }
    }
}