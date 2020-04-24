using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLinear;
using System.Numerics;

namespace Example_complex_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var i = Complex.ImaginaryOne;

            //Declare a 4x4 matrix
            Matrix44<Complex> m44 = new Matrix44<Complex>(1, 1, 1, 1, 1, i, -1, -i, 1, -i, 1, -1, 1, -i, -1, i);

            //Declare an identity matrix
            Matrix44<Complex> id = Matrix44<Complex>.Identity(1.0);

            Console.WriteLine(id * m44 == m44);//true

            Console.ReadKey();
        }
    }
}
