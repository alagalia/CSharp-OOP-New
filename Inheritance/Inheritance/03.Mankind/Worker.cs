namespace _03.Mankind
{
    using System;

    public class Worker : Human
    {
        private decimal weekSalary;

        private decimal workingHoursPerday;

        public Worker(string firstName, string lastName, decimal weekSalary, decimal workingHoursPerday)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkingHoursPerday = workingHoursPerday;
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }

            set
            {
                if (value < 10.0m)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                this.weekSalary = value;
            }
        }

        public decimal WorkingHoursPerday
        {
            get
            {
                return this.workingHoursPerday;
            }

            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                this.workingHoursPerday = value;
            }
        }

        private decimal SalaryPerHour()
        {
            return (this.weekSalary / 5) / this.workingHoursPerday;
        }

        public override string ToString()
        {
            string worker = base.ToString() + "\n" +
                $"Week Salary: {this.weekSalary:F2}\nHours per day: {this.workingHoursPerday:F2}\nSalary per hour: {this.SalaryPerHour():F2}";

            return worker;
        }
    }

}