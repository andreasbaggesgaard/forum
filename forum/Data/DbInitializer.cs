using forum.Models;
using System;
using System.Linq;


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace forum.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ForumContext context)
        {
            context.Database.EnsureCreated();

            /*context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            var users = new User[]
            {
                new User { Username = "test",   Password = "123", Picture = "http://placehold.it/500x500" },
                new User { Username = "test2", Password = "123", Picture = "http://placehold.it/500x500" },
            };

            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();

            var threads = new Thread[]
            {
                new Thread { Subject = "Cool subject", UserID = users.Single(c => c.ID == 1 ).ID },
                new Thread { Subject = "Another subject", UserID = users.Single(c => c.ID == 2 ).ID }
            };

            foreach (Thread t in threads)
            {
                context.Threads.Add(t);
            }
            context.SaveChanges();

			var posts = new Post[]
			{
				new Post { Text = "Cool story, Bro", 
                    UserID = users.Single(c => c.ID == 1 ).ID, 
                    ThreadID = threads.Single(c => c.ID == 1).ID },
				new Post { Text = "Nice post",
					UserID = users.Single(c => c.ID == 1 ).ID,
					ThreadID = threads.Single(c => c.ID == 1).ID },
				new Post { Text = "Sounds interesting.. Tell me more.",
					UserID = users.Single(c => c.ID == 1 ).ID,
					ThreadID = threads.Single(c => c.ID == 1).ID },
				new Post { Text = "Boooriing..",
					UserID = users.Single(c => c.ID == 2 ).ID,
					ThreadID = threads.Single(c => c.ID == 2).ID },
			};

			foreach (Post p in posts)
			{
				context.Posts.Add(p);
			}
			context.SaveChanges();*/


        }
    }
}