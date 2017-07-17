using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using forum.Models;
 
namespace forum.Data
{
    public class ForumContext : IdentityDbContext<Person>
    {
        public ForumContext(DbContextOptions<ForumContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<Thread> Threads { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

            builder.Entity<Person>().ToTable("Person").Property(i => i.Id);
			builder.Entity<Post>().ToTable("Post");
			builder.Entity<Thread>().ToTable("Thread").Property(i => i.PersonID);
		}

        /*public DbSet<Person> People { get; set; }
		public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Thread> Threads { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
            		
			modelBuilder.Entity<Post>().ToTable("Post");
			modelBuilder.Entity<Thread>().ToTable("Thread");
            modelBuilder.Entity<User>().ToTable("User");
			modelBuilder.Entity<Person>().ToTable("Person").HasDiscriminator<string>("Type")
					   .HasValue<Person>(nameof(Person)) 
					   .HasValue<User>(nameof(User));

		}*/
       
    }
}
