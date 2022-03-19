using Calabonga.PollingSystem.Entities;

public class PollBuilder
{
    private readonly string _questionText;
    private readonly List<Answer> _items = new();
    
    public PollBuilder(string questionText)
    {
        _questionText = questionText;
    }

    public PollBuilder AddAnswer(Guid id, string title)
    {
        var item = _items.FirstOrDefault(x => x.Id == id);
        if (item is { })
        {
            return this;
        }

        _items.Add(new Answer(id, title));
        return this;
    }

    public Poll Build()
    {
        return new Poll(_questionText, _items);
    }

    public PollResults GetResults(Poll poll) => new(poll);
}