namespace _03.Mankind
{
    using System;

    public class Student : Human
    {
        private string fNumber;

        public Student(string firstName, string lastName, string fNumber)
            : base(firstName, lastName)
        {
            this.FNumber = fNumber;
        }


        public override string FirstName
        {
            set
            {
                if (value.Length < 4)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
                }

                base.FirstName = value;
            }
        }

        public string FNumber
        {
            get
            {
                return this.fNumber;
            }

            set
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                else
                {
                    foreach (var character in value)
                    {
                        if (!char.IsLetterOrDigit(character))
                        {
                            throw new ArgumentException("Invalid faculty number!");
                        }
                    }

                    this.fNumber = value;
                }
            }
        }


        public override string ToString()
        {
            return base.ToString() + $"\nFaculty number: {this.fNumber}";
        }
    }

}