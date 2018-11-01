using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIACinema.Data.Entities;

namespace VIACinema.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MovieContext context)
        {
            context.Database.EnsureCreated();

            if(context.Movies.Any())
            {
                return;
            }

            var movies = new Movie[]
            {
                new Movie{ Name = "Jason Bourne", Category = "Action", ImageURL = "~/images/JasonBourne.jpg",
                    MovieLength = "2:30", Price = 10, Rating = 66,
                    Description = "It's been 10 years since Jason Bourne (Matt Damon) walked away from the agency that trained him to become a deadly weapon. Hoping to draw him out of the shadows, CIA director Robert Dewey assigns hacker and counterinsurgency expert Heather Lee to find him. Lee suspects that former operative Nicky Parsons is also looking for him. As she begins tracking the duo, Bourne finds himself back in action battling a sinister network that utilizes terror and technology to maintain unchecked power.",
                    DirectorName = "Paul Greengrass"},
                new Movie{ Name = "Prisoners", Category = "Crime/Thriller", ImageURL = "~/images/Prisoners.jpg",
                    MovieLength = "2:33", Price = 10, Rating = 81,
                    Description = "Keller Dover (Hugh Jackman) faces a parent's worst nightmare when his 6-year-old daughter, Anna, and her friend go missing. The only lead is an old motorhome that had been parked on their street. The head of the investigation, Detective Loki (Jake Gyllenhaal), arrests the driver (Paul Dano), but a lack of evidence forces Loki to release his only suspect. Dover, knowing that his daughter's life is at stake, decides that he has no choice but to take matters into his own hands.",
                    DirectorName = "Denis Villeneuve"},
                new Movie{ Name = "Kill Bill: Volume 1", Category = "Crime/Thriller", ImageURL = "~/images/KillBill1.jpg",
                    MovieLength = "1:52", Price = 10, Rating = 81,
                    Description = "A former assassin, known simply as The Bride (Uma Thurman), wakes from a coma four years after her jealous ex-lover Bill (David Carradine) attempts to murder her on her wedding day. Fueled by an insatiable desire for revenge, she vows to get even with every person who contributed to the loss of her unborn child, her entire wedding party, and four years of her life. After devising a hit list, The Bride sets off on her quest, enduring unspeakable injury and unscrupulous enemies.",
                    DirectorName = "Quentin Tarantino"}
            };

            foreach(Movie m in movies)
            {
                context.Add(m);
            }
            context.SaveChanges();

           /* var tickets = new Ticket[]
            {
                new Ticket{Id = 1, Movie = movies[0], TicketPrice = 10},
                new Ticket{Id = 2, Movie = movies[1], TicketPrice = 10},
                new Ticket{Id = 3, Movie = movies[2], TicketPrice = 10}
            };

            foreach (Ticket t in tickets)
            {
                context.Add(t);
            }
            context.SaveChanges();

            var orders = new Order[]
            {
                new Order{Id = 1, OrderDate = new DateTime(2018, 5, 20),
                Quantity = 1, Tickets = tickets
                },
                new Order{Id = 2, OrderDate = new DateTime(2018, 5, 23),
                Quantity = 2, Tickets = tickets
                },
                new Order{Id = 3, OrderDate = new DateTime(2018, 5, 26),
                Quantity = 1, Tickets = tickets
                }
            };

            foreach (Order o in orders)
            {
                context.Add(o);
            }
            context.SaveChanges();*/
        }
    }
}
