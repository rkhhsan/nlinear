using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLinear;

namespace Example_3d_vector
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare two unit vectors e1, e2
            Vec3<float> e1 = new Vec3<float>(1, 2, 3);
            Vec3<float> e2 = new Vec3<float>(2, 3, -4);

            Vec3<float> e3 = e1.Cross(e2);

            Console.WriteLine(e3);

            Console.ReadKey();
        }
    }
}
