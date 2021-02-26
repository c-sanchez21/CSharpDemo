using System;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NullCoalescing());
            Console.WriteLine(NullCoalescing("Hello World")+"\n");
            AnonymousType();//Show AnonymousType
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

        static void AnonymousType()
        {
            var person = new { FirstName = "Cesar", LastName = "Sanchez" };
            //person.FirstName = "Cesar2"; //Error: Anonymous Types are read-only
            Console.WriteLine(String.Format("AnonymousType of Person: FirstName={0} LastName={1}", person.FirstName, person.LastName));
        }
    }
}
