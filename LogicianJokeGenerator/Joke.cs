using System;
using System.Text;

namespace LogicianJokeGenerator
{
    public sealed class Joke
    {
        private readonly object _lockObject = new object();
        private readonly int _jokeNumber;
        private readonly LogiciansAnswers _logiciansAnswers;
        private string _text = string.Empty;

        public Joke(int jokeNumber, LogiciansAnswers logiciansAnswers)
        {
            if (jokeNumber < 0)
            {
                throw new ArgumentException(nameof(jokeNumber));
            }

            _jokeNumber = jokeNumber;
            _logiciansAnswers = logiciansAnswers;
        }

        public string Text
        {
            get
            {
                lock (_lockObject)
                {
                    if (string.IsNullOrEmpty(_text))
                    {
                        CreateJoke();
                    }

                    return _text;
                }
            }
        }

        private void CreateJoke()
        {
            var joke = new StringBuilder();
            joke.Append("Joke #");
            joke.AppendLine(_jokeNumber.ToString());
            joke.AppendLine("Do u all want a beer?");
            foreach (var answer in _logiciansAnswers.Answers)
            {
                joke.Append(" -");
                joke.AppendLine(answer.ToString());
            }

            _text = joke.ToString();
        }
    }
}