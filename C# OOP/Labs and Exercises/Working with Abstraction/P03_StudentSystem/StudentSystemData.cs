namespace P03_StudentSystem
{
    using System;
    using System.Collections.Generic;
    public class StudentSystem
    {
        public StudentSystem()
        {
            this.Repo = new Dictionary<string, Student>();
        }

        public Dictionary<string, Student> Repo { get; private set; }

        public void Add(string name, Student student)
        {
            if(!Repo.ContainsKey(name))
            {
                this.Repo.Add(name, student);
            }
        }

        public Student Get(string name)
        {
            if(!this.Repo.ContainsKey(name))
            {
                return null;
            }

            Student student = this.Repo[name];
            return student;
        }
    }
}
