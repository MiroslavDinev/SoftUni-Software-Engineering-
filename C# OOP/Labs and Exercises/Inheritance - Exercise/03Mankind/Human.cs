namespace _03Mankind
{
    using System;
    using System.Text;

    public class Human
    {
        private const int FirstNameLength = 4;
        private const int LastNameLength = 3;

        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                this.ValidateNamesFirstLetter(value, nameof(this.firstName));

                this.ValidateNameLength(value, FirstNameLength, nameof(this.firstName));

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                this.ValidateNamesFirstLetter(value, nameof(this.lastName));

                this.ValidateNameLength(value, LastNameLength, nameof(this.lastName));

                this.lastName = value;
            }
        }

        private void ValidateNamesFirstLetter(string value,string parameterName)
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: {parameterName}");
            }
        }

        private void ValidateNameLength(string value, int length, string parameterName)
        {
            if (value.Length < length)
            {
                throw new ArgumentException($"Expected length at least {length} symbols! Argument: {parameterName}");
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"First Name: {this.FirstName}");
            result.AppendLine($"Last Name: {this.LastName}");

            return result.ToString();
        }
    }
}
