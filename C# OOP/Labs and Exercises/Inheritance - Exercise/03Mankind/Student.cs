namespace _03Mankind
{
    using System;
    using System.Linq;
    using System.Text;

    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName,lastName)
        {
            this.FacultyNumber = facultyNumber;
        }
        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }

            private set
            {
                if(value.Length<5 || value.Length>10 || value.All(x=>char.IsLetterOrDigit(x))==false)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            StringBuilder studentResult = new StringBuilder();
            studentResult.Append(base.ToString());
            studentResult.Append($"Faculty number: {this.FacultyNumber}");

            return studentResult.ToString();
        }
    }
}
