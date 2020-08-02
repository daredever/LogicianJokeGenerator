using System;
using System.Collections.Generic;

namespace LogicianJokeGenerator
{
    public sealed class JokesGenerator
    {
        private readonly object _lockObject = new object();
        private readonly int _jokesCount;
        private readonly int _logiciansPerJoke;
        private readonly List<Joke> _jokes;

        public JokesGenerator(int jokesCount, int logiciansPerJoke)
        {
            if (jokesCount < 0)
            {
                throw new ArgumentException(nameof(jokesCount));
            }

            if (logiciansPerJoke <= 0)
            {
                throw new ArgumentException(nameof(jokesCount));
            }

            _jokesCount = jokesCount;
            _logiciansPerJoke = logiciansPerJoke;
            _jokes = new List<Joke>(jokesCount);
        }

        public IReadOnlyCollection<Joke> Jokes
        {
            get
            {
                lock (_lockObject)
                {
                    if (_jokes.Count != _jokesCount)
                    {
                        AddJokes();
                    }

                    return _jokes;
                }
            }
        }

        private void AddJokes()
        {
            for (var jokeNumber = 1; jokeNumber <= _jokesCount; jokeNumber++)
            {
                var logiciansSquad = new LogiciansSquad(_logiciansPerJoke, () =>
                {
                    var random = new Random();
                    var wantBeer = random.Next(0, 2) != 0;
                    return new Logician(wantBeer);
                });

                var logiciansAnswers = new LogiciansAnswers(logiciansSquad);
                var joke = new Joke(jokeNumber, logiciansAnswers);
                _jokes.Add(joke);
            }
        }
    }
}