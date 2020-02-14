using System;
using System.Collections.Generic;
using System.Text;

namespace TrainTracker.Core.Entities
{
    public class Course
    {
        public int CourseID { get; set; }
        public DateTime date { get; set; }

        public String Name { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
