using System;
using forum.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace forum.Models.ViewModels
{
    public class ThreadsViewModel
    {

        public IEnumerable<Thread> Threads { get; set; }

        public Thread Thread { get; set; }

        public IEnumerable<Post> Posts { get; set; }

        public Post Post { get; set; }

		public IEnumerable<Person> People { get; set; }

        public Person Person { get; set; }

        public IFormFile Picture { get; set; }

    }
}
