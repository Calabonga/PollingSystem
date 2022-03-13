using System.Diagnostics;

namespace Calabonga.PollingSystem.Entities
{
    [DebuggerDisplay("{QuestionText}")]
    public class Poll
    {
        public Poll(string questionText, List<PollAnswer> answers)
        {
            QuestionText = questionText;
            Answers = answers;
        }

        public string QuestionText { get; }

        public List<PollAnswer>? Answers { get; }

        /// <summary>
        /// Make a vote
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void VoteTo(int id, int value = 1)
        {
            var item = Answers?.SingleOrDefault(x => x.Id == id);
            if (item == null)
            {
                return;
            }

            item.Votes += value;

            var totalVotes = Answers?.Sum(x => x.Votes) ?? 0;
            Answers?.ForEach(x => x.SetPercents(totalVotes));
        }
    }
}
