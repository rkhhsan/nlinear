using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLinear;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare a 4x4 matrix
            Matrix44<double> m44 = new Matrix44<double>(6, -7, 10, 4, 0, 3, -1, 8, 0, 5, -7, 0, 1, 2, 7, 6);
            //Declare an identity matrix
            Matrix44<double> id = Matrix44<double>.Identity(1.0);

            Console.WriteLine(m44 * id == m44); //True
            Console.WriteLine(id * m44 == m44); //True

            //Declare a 3x3 matrix
            Matrix33<double> m33 = new Matrix33<double>(6, -7, 10, 0, 3, -1, 0, 5, -7);

            Matrix33<double> m33Inv = m33.Inverse(1.0);
            Matrix33<double> id2 = m33 * m33Inv;

            Console.WriteLine(id2 == Matrix33<double>.Identity(1.0)); //True

            Console.ReadKey();
        }
    }
}
