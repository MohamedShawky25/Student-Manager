namespace Task3
{
    class StudentManager
    {
        public List<Student> Students { get; private set; } = new();
        public List<Instructor> Instructors { get; private set; } = new();
        public List<Course> Courses { get; private set; } = new();
        public bool AddStudent(string? name, int age)
        {
            if (name == null || age == 0) return false;
            Students.Add(new Student(Guid.NewGuid().ToString().Substring(0, 7), name, age));
            return true;
        }
        public bool AddInstructor(string? name, string? specialization)
        {
            if (name == null || specialization == null) return false;
            Instructors.Add(new(Guid.NewGuid().ToString().Substring(0, 5), name, specialization));
            return true;
        }
        public bool AddCourse(string? title, Instructor instructor)
        {
            if (title == null) return false;
            Courses.Add(new(Guid.NewGuid().ToString().Substring(0, 3), title, instructor));
            return true;
        }
        public int FindInsId(string? id) //return index of Instructor Id or -1 if not found 
        {
            for (int i = 0; i < Instructors.Count; i++)
            {
                if (id == Instructors[i].InstructorId)
                    return i;
            }
            return -1;
        }
        public int FindStdId(string? id)//return index of student Id or -1 if not found
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (id == Students[i].StudentId)
                    return i;
            }
            return -1;
        }
        public int FindCourseId(string? id) //return index of Course Id or -1 if not found
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (id == Courses[i].CourseId)
                    return i;
            }
            return -1;
        }
        public bool Enroll(int cIndex, int stIndex)
        {
            if (cIndex == -1 || stIndex == -1)
                return false;
            Students[stIndex].Courses.Add(Courses[cIndex]);
            return true;
        }
        public bool CheckIfEnroll(int cIndex, int stIndex)
        {
            if (Students[stIndex].Courses.Count == 0) return false;
            for (int i = 0; i < Students[stIndex].Courses.Count; i++)
            {
                if (Students[stIndex].Courses[i].CourseId == Courses[cIndex].CourseId)
                    return true;
            }
            return false;
        }
        public string GetStudents() //print the data of all students
        {
            if (Students.Count == 0)
                return "No Students added";
            else
            {
                string s = string.Empty;
                for (int i = 0; i < Students.Count; i++)
                    s += Students[i].PrintDetails() + "\n  ";
                return s;
            }
        }
        public string GetInstructors() //print the data of all instructors
        {
            if (Instructors.Count == 0)
                return "No Instructors added";
            else
            {
                string s = string.Empty;
                for (int i = 0; i < Instructors.Count; i++)
                    s += Instructors[i].PrintDetails() + "\n  ";
                return s;
            }
        }
        public string GetCourses() //print the data of all courses
        {
            if (Courses.Count == 0)
                return "No Courses added";
            else
            {
                string s = string.Empty;
                for (int i = 0; i < Courses.Count; i++)
                    s += Courses[i].PrintDetails() + "\n  ";
                return s;
            }
        }

        public int FindStdName(string? name) //return index of Student Name or -1 if not found
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (name == Students[i].Name)
                    return i;
            }
            return -1;
        }
        public int FindCourseName(string? title) //return index of Course Name or -1 if not found
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (title == Courses[i].Title)
                    return i;
            }
            return -1;
        }
        public bool DeleteStudent (int stdIndex)
        {
            if (stdIndex==-1 ) return false;
            Students.RemoveAt(stdIndex);
            return true;
        }
    }
}
