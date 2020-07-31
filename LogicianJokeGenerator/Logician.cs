namespace LogicianJokeGenerator
{
    public sealed class Logician
    {
        private readonly bool _wantBeer;

        public Logician(bool wantBeer)
        {
            _wantBeer = wantBeer;
        }

        public Answer DoYouWantBeer(bool anyAnswerNo, bool allAnswersYes)
        {
            if (!_wantBeer || anyAnswerNo)
            {
                return Answer.No;
            }

            return allAnswersYes ? Answer.Yes : Answer.DontKnow;
        }
    }
}