using System.Diagnostics;
using Calabonga.PollingSystem.Entities.Base;

namespace Calabonga.PollingSystem.Entities
{
    [DebuggerDisplay("{QuestionText}")]
    public class Poll : Identity
    {
        public Poll(string questionText, List<Answer> answers): this(questionText)
        {
            QuestionText = questionText;
            Answers = answers;
        }

        private Poll(string questionText)
        {
            QuestionText = questionText;
        }

        public string QuestionText { get; init; }

        public List<Answer>? Answers { get; }
        
        /// <summary>
        /// Make a vote
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void VoteTo(Guid id, int value = 1)
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
