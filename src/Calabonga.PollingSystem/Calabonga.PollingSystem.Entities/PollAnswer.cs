using System.Diagnostics;

namespace Calabonga.PollingSystem.Entities;

[DebuggerDisplay("{Title} {Votes} {Percents}")]
public class PollAnswer
{
    public PollAnswer(int id, string title)
    {
        Id = id;
        Title = title;
    }

    public int Id { get; }

    public string Title { get; }

    public int Votes { get; set; }

    public double Percents { get; set; }

    public void SetPercents(int totalVotes)
    {
        if (totalVotes > 0)
        {
            Percents = Votes * 100d / totalVotes;
        }
    }

    public override string ToString()
    {
        return $"* {Title} ({Votes} {Percents:F})";
    }
}