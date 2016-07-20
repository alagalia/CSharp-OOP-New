using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Mankind
{
    class Mankind
    {
        static void Main()
        {
            try
            {
                string[] studentToken = Console.ReadLine().Split();
                string[] workerToken = Console.ReadLine().Split();

                Student s = new Student(studentToken[0], studentToken[1], studentToken[2]);
                Worker w = new Worker(workerToken[0], workerToken[1], decimal.Parse(workerToken[2]), decimal.Parse(workerToken[3]));

                Console.WriteLine(s);
                Console.WriteLine();
                Console.WriteLine(w);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }



}
