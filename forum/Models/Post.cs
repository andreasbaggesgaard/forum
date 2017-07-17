using System;
using forum.Models;
using System.ComponentModel.DataAnnotations;

namespace forum.Models
{
    public class Post
    {
		public int ID { get; set; }
        [Required]
		public string Text { get; set; }
        public string Created { get; set; }
		public int ThreadID { get; set; }
        public string PersonID { get; set;}

        public Thread Thread { get; set; }
        public Person Person { get; set; }
	}
}
