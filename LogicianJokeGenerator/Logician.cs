using System.Collections.Generic;
using System.Linq;

namespace LogicianJokeGenerator
{
    public sealed class Logician
    {
        private readonly bool _wantBeer;

        public Logician(bool wantBeer)
        {
            _wantBeer = wantBeer;
        }

        public Answer DoYouWantBeer(IReadOnlyCollection<Answer> squadAnswers, bool isLastAnswer)
        {
            var anyAnswerNo = squadAnswers.Any(a => a == Answer.No);
            if (!_wantBeer || anyAnswerNo)
            {
                return Answer.No;
            }

            var allAnswersYes = isLastAnswer && squadAnswers.All(a => a == Answer.Yes || a == Answer.DontKnow);
            return allAnswersYes ? Answer.Yes : Answer.DontKnow;
        }
    }
}