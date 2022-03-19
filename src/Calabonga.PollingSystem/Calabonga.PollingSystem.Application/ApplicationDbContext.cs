using Calabonga.PollingSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calabonga.PollingSystem.Application
{
    #nullable disable

    public class ApplicationDbContext: DbContext
    {
        public DbSet<Poll> Polls { get; set; }

        public DbSet<Answer> Answers { get; set; }
    }

    #nullable enable
}
