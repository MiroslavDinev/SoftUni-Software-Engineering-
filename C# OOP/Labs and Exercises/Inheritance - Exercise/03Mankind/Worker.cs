namespace _03Mankind
{
    using System;
    using System.Text;

    public class Worker : Human
    {
        private double weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay)
            : base(firstName,lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public double WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            private set
            {
                if(value<=10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            private set
            {
                if(value<1 || value>12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                this.workHoursPerDay = value;
            }
        }

        private double MoneyPerHour()
        {
            return this.WeekSalary / (5 * this.WorkHoursPerDay);
        }

        public override string ToString()
        {
            StringBuilder workerResult = new StringBuilder();
            workerResult.Append(base.ToString());
            workerResult.AppendLine($"Week Salary: {this.WeekSalary:f2}");
            workerResult.AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}");
            workerResult.AppendLine($"Salary per hour: {this.MoneyPerHour():f2}");

            return workerResult.ToString();
        }
    }
}
