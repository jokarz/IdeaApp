using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace IdeaApi.Models
{
    public class IdeaContext : DbContext
    {

        public IdeaContext(DbContextOptions<IdeaContext> options)
            : base(options)
        {
        }

        public DbSet<Idea> Ideas { get; set; }

        public static void SeedInitialDb(IServiceProvider serviceProvider)
        {
            using (var context = new IdeaContext(
                serviceProvider.GetRequiredService<DbContextOptions<IdeaContext>>()))
            {
                if (context.Ideas.Any())
                {
                    return;
                }

                context.Ideas.AddRange(
                    new Idea
                    {
                        Name = "Creating a human management system with robots",
                        Description = "Won't it be good if robots could manage our life?",
                        Status = -1
                    },
                    new Idea
                    {
                        Name = "Flying skateboard",
                        Description = "It would be awesome. Back to the future anybody?",
                        Status = 0
                    },
                    new Idea
                    {
                        Name = "Creating food in pill form",
                        Description = "Imagine being able to consume a pill that is a replacement for a whole meal!",
                        Status = 1
                    }
               );
                context.SaveChanges();
            }

        }


    }
}