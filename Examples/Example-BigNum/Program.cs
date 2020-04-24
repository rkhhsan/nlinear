using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLinear;
using System.Numerics;

namespace Example_BigNum
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare two unit vectors e1, e2
            Vec3<BigInteger> e1 = new Vec3<BigInteger>(1, 0, 0);
            Vec3<BigInteger> e2 = new Vec3<BigInteger>(0, 1, 0);

            Vec3<BigInteger> e3 = e1.Cross(e2);

            Console.WriteLine(e3);

            Console.ReadKey();
        }
    }
}
