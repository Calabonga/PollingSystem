using Calabonga.PollingSystem.Application;

var builder = new PollBuilder("Как вам это видео?")
    .AddAnswer(Guid.Parse("51611623-e72f-0488-4011-be4f13c8e936"), "Нормально")
    .AddAnswer(Guid.Parse("b253b82c-90a1-2183-4053-48f910a49247"), "Не плохо")
    .AddAnswer(Guid.Parse("50f0b6ee-ba6e-f988-4f3b-79c85308ed25"), "Отстой")
    .AddAnswer(Guid.Parse("9ebb2234-75cb-eeb2-4fed-1774318d9ce8"), "Супер")
    .AddAnswer(Guid.Parse("51611623-e72f-0488-4011-be4f13c8e936"), "Очень круто");

var poll = builder.Build();

poll.VoteTo(Guid.Parse("50f0b6ee-ba6e-f988-4f3b-79c85308ed25"));
poll.VoteTo(Guid.Parse("50f0b6ee-ba6e-f988-4f3b-79c85308ed25"));
poll.VoteTo(Guid.Parse("b253b82c-90a1-2183-4053-48f910a49247"));
poll.VoteTo(Guid.Parse("b253b82c-90a1-2183-4053-48f910a49247"));
poll.VoteTo(Guid.Parse("51611623-e72f-0488-4011-be4f13c8e936"));
poll.VoteTo(Guid.Parse("51611623-e72f-0488-4011-be4f13c8e936"));
poll.VoteTo(Guid.Parse("b253b82c-90a1-2183-4053-48f910a49247"));
poll.VoteTo(Guid.Parse("9ebb2234-75cb-eeb2-4fed-1774318d9ce8"));
poll.VoteTo(Guid.Parse("9ebb2234-75cb-eeb2-4fed-1774318d9ce8"));
poll.VoteTo(Guid.Parse("9ebb2234-75cb-eeb2-4fed-1774318d9ce8"));
poll.VoteTo(Guid.Parse("9ebb2234-75cb-eeb2-4fed-1774318d9ce8"), 10);


using (var context = new ApplicationDbContext())
{
    context.Polls.Add(poll);
    context.SaveChanges();
}

using (var context = new ApplicationDbContext())
{
    foreach (var answer in context.Answers)
    {
        Console.WriteLine(answer.Title);
    }
}

var result = builder.GetResults(poll);

Console.WriteLine(result.GetView());