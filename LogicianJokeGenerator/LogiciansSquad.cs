using System;
using System.Collections;
using System.Collections.Generic;

namespace LogicianJokeGenerator
{
    public sealed class LogiciansSquad : IReadOnlyCollection<Logician>
    {
        private readonly object _lockObject = new object();
        private readonly int _count;
        private readonly Func<Logician> _logicianFactory;
        private readonly List<Logician> _logicians;

        public LogiciansSquad(int count, Func<Logician> logicianFactory)
        {
            if (count <= 0)
            {
                throw new ArgumentException(nameof(count));
            }

            _count = count;
            _logicianFactory = logicianFactory;
            _logicians = new List<Logician>(count);
        }

        public IEnumerator<Logician> GetEnumerator()
        {
            lock (_lockObject)
            {
                if (_logicians.Count != _count)
                {
                    AddLogicians();
                }

                return _logicians.GetEnumerator();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count => _count;

        private void AddLogicians()
        {
            for (var i = 0; i < _count; i++)
            {
                _logicians.Add(_logicianFactory());
            }
        }
    }
}