using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.ImmutableList
{
    using System.Reflection;

    class ImmutableListEx
    {
        static void Main(string[] args)
        {
            Type immutableList = typeof(ImmutableList);
            FieldInfo[] fields = immutableList.GetFields();
            if (fields.Length < 1)
            {
                throw new Exception();
            }
            else
            {
                Console.WriteLine(fields.Length);
            }

            MethodInfo[] methods = immutableList.GetMethods();
            bool containsMethod = methods.Any(m => m.ReturnType.Name.Equals("ImmutableList"));
            if (!containsMethod)
            {
                throw new Exception();
            }
            else
            {
                Console.WriteLine(methods[0].ReturnType.Name);
            }

        }
    }

    public class ImmutableList
    {
        public List<int> integers;

        public ImmutableList()
        {
            this.integers = new List<int>();
        }

        public ImmutableList GetList()
        {
            ImmutableList newList = new ImmutableList();
            newList.integers = this.integers;
            return newList;
        }
    }
}
