using System;
using System.Collections.Generic;

namespace forum.Models
{
    public class Thread
    {
        public int ID { get; set; }

        public string Subject { get; set; }
        public string Text { get; set; }
        public string Picture { get; set; }
        public string Created { get; set; }
        public string PersonID { get; set; }

        public Person Person { get; set; }
    }
}
