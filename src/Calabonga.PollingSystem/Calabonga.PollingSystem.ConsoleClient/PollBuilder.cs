using Calabonga.PollingSystem.Entities;

namespace Calabonga.PollingSystem.ConsoleClient;

public class PollBuilder
{
    private readonly string _questionText;
    private readonly List<PollAnswer> _items = new();

    public PollBuilder(string questionText)
    {
        _questionText = questionText;
    }

    public PollBuilder AddAnswer(int id, string title)
    {
        _items.Add(new PollAnswer(id, title));
        return this;
    }

    public Poll Build()
    {
        return new Poll(_questionText, _items);
    }

    public PollResults GetResults(Poll poll) => new(poll);
}