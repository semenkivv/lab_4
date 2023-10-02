using System;

namespace Laba4_V_11
{
    class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber a = new ComplexNumber(1, 2.4, pr: 0);
            ComplexNumber b = new ComplexNumber(-3, 0, pr: 1);
            ComplexNumber c = new ComplexNumber(1.4, -0.2, pr: 1);
            ComplexNumber d = new ComplexNumber(3.23, 0, pr: 0);

            Console.WriteLine("a:\n " + a);
            Console.WriteLine("\nb:\n " + b);
            Console.WriteLine("\nc:\n" + c);
            Console.WriteLine("\nd:\n " + d);
            ComplexNumber x = ((a+b)*c*c)/(b-a);
            Console.WriteLine("\nx=((a+b)*c*c)/(b-a)");
            Console.WriteLine("\nx: " + x);

        }
    }
}
