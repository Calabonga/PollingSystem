
using Calabonga.PollingSystem.ConsoleClient;

var builder = new PollBuilder("Как вам это видео?")
    .AddAnswer(1, "Нормально")
    .AddAnswer(2, "Не плохо")
    .AddAnswer(3, "Отстой")
    .AddAnswer(4, "Супер");

var poll = builder.Build();

poll.VoteTo(3);

poll.VoteTo(3);
poll.VoteTo(2);
poll.VoteTo(1);
poll.VoteTo(4);
poll.VoteTo(4);
poll.VoteTo(4);
poll.VoteTo(4);
poll.VoteTo(4);
poll.VoteTo(4, 10);


var result = builder.GetResults(poll);

Console.WriteLine(result.GetView());


//var poll = new Poll("Как вам это видео?")
//{
//    Answers = new List<PollAnswer>
//    {
//        new(1,"Нормально"),
//        new(2,"Не плохо"),
//        new(3,"Отстой"),
//        new(4,"Супер")
//    }
//};

//poll.VoteTo(3);

//poll.VoteTo(3);
//poll.VoteTo(2);
//poll.VoteTo(1);
//poll.VoteTo(4);
//poll.VoteTo(4);
//poll.VoteTo(4);
//poll.VoteTo(4);
//poll.VoteTo(4);
//poll.VoteTo(4, 10);


//Console.WriteLine(poll);