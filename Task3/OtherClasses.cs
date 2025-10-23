namespace Task3
{
    class Instructor(string instructorId, string name, string specialization)
    {
        public string InstructorId { get; init; } = instructorId;
        public string Name { get; init; } = name;
        public string Specialization { get; init; } = specialization;
        public string PrintDetails()
           => $"Name: {Name}, Id: {InstructorId}, specialization: {Specialization}";
    }

    class Course(string courseId, string title, Instructor instructor)
    {
        public string CourseId { get; init; } = courseId;
        public string Title { get; init; } = title;
        public Instructor Instructor { get; init; } = instructor;
        public string PrintDetails()
           => $"Title: {Title}, Id: {CourseId}\n Instructor: {Instructor.PrintDetails()}";

    }
    class Student(string studentId, string name, int age)
    {

        public string StudentId { get; init; } =studentId;
        public string Name { get; init; } = name;
        public int Age { get; init; }=age;
        public List<Course> Courses { get; set; } = new();
        public string GetCourses()
        {
            if (Courses.Count==0)
                return "No Courses Enrolled";
            else
            {
                string s=string.Empty;
                for (int i = 0; i < Courses.Count; i++)
                    s +=Courses[i].PrintDetails() +"\n  ";
                return s;
            }
        }

        public string PrintDetails()
           => $"Student Name: {Name}, Id: {StudentId}, Age: {Age}\n Courses: {GetCourses()}";


    }
}
