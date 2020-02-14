using System;
using System.Collections.Generic;
using System.Text;

namespace TrainTracker.Core.Entities
{
    public class Enrollment
    {
        public  int ID { get; set; }

        public  Person Person { get; set; }
        public int PersonID { get; set; }

        public Course Course { get; set; }

        public int CourseID { get; set; }
    }

}
