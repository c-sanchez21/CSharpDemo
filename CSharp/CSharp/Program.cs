using System;

namespace CSharp
{
    //Author: Cesar Sanchez
    //Project demonstrating various features of C#
    class Program
    {
        #region Variables
        static Random RandomGen = new Random();
        #endregion
        static void Main(string[] args)
        {
            //Demonstrate Various C# features. 
            Console.WriteLine(NullCoalescing());
            Console.WriteLine(NullCoalescing("Hello World")+"\n");
            AnonymousTypes();
            DynamicTypes();
            NullableValueTypes();
            ExtensionMethods();
            ImplicitExplicitTest();
        }

        #region C# 8.0
        static string NullCoalescing(string x = null)
        {
            //The null-coalescing operator ?? returns the value of its left-hand operand if it isn't null;
            //otherwise, it evaluates the right-hand operand and returns its result. 
            //The ?? operator doesn't evaluate its right-hand operand if the left-hand operand evaluates to non-null.
            string s = x ?? "X was a Null String";
            return s;
        }
        //TODO: Add additional C# 8.0 features. 
        #endregion

        static void NullableValueTypes()
        {
            int val = RandomGen.Next(0, 1000);
            int? x = (val > 500) ? val : null;//Target-Typed Conditional Expression [New in C# 9.0]
            //For a conditional expression c? e1 : e2, when
            //1. there is no common type for e1 and e2, or
            //2. for which a common type exists but one of the expressions e1 or e2 has no implicit conversion to that type

            Console.WriteLine("Nullable Type = {0}\n",(x.HasValue ? x.ToString() : "Null"));
        }

        static void AnonymousTypes()
        {
            var person = new { FirstName = "Cesar", LastName = "Sanchez" };
            //person.FirstName = "Cesar2"; //Error: Anonymous Types are read-only
            Console.WriteLine(String.Format("AnonymousType of Person: FirstName={0} LastName={1} \n", person.FirstName, person.LastName));
        }

        static void DynamicTypes()
        {
            dynamic val = new { FirstName = "Cesar", LastName = "Sanchez" };
            Console.WriteLine("Dynamic Value of Person: {0}", val);
            val = RandomGen.Next(0, 1000); //Dynamic types can change value and type at runtime. 
            Console.WriteLine("Dynamic Value changed to random Int32: {0}  \n", val);
        }

        static void ExtensionMethods()
        {
            string s = "Welcome to extension methods";
            int wordCount = s.WordCount();
            Console.WriteLine("{0} = {1} words.\n", s, wordCount);
        }

        public struct Person
        {
            public static implicit operator string(Person p) => p.FirstName;
            public static implicit operator int(Person p) => p.Age;
            public static explicit operator Person(string s) => new Person(s);

            public string FirstName;
            public int Age;
            public Person(string fName)
            {
                FirstName = fName;
                Age = RandomGen.Next(18, 100);
            }
        }

        public static void ImplicitExplicitTest()
        {
            string name = "Jane";
            int age = RandomGen.Next(100);

            Person p = (Person)name; //Explicit Conversion
            p.Age = age; 
            string s = p; //Implicit conversion to string
            int x = p; //Implicit conversion to int
            Console.WriteLine("Implicit & Explicit Operator Test: Name = {0}, Age = {1}", s, x);
        }
    }
    /// <summary>
    /// Class for demonstrating Extension Methods
    /// </summary>
    public static class Extensions
    {
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
