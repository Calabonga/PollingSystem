using System.Diagnostics;
using Calabonga.PollingSystem.Entities.Base;

namespace Calabonga.PollingSystem.Entities;

[DebuggerDisplay("{Title} {Votes} {Percents}")]
public class Answer: Identity
{
    public Answer(Guid id, string title)
    {
        Id = id;
        Title = title;
    }
    
    public string Title { get; }

    public int Votes { get; set; }

    public double Percents { get; private set; }

    public void SetPercents(int totalVotes)
    {
        if (totalVotes > 0)
        {
            Percents = Votes * 100d / totalVotes;
        }
    }

    public override string ToString()
    {
        return $"* {Title} - {Votes} ({Percents:F}%)";
    }
}