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
         Matrix44<double> id4 = Matrix44<double>.Identity(1.0);
         Console.WriteLine(m44);
         Matrix44<double> d = m44.Inverse(1.0);
         Console.WriteLine("\n" + d*m44); 
         Console.WriteLine(m44 * id4 == m44); //True
         Console.WriteLine(id4 * m44 == m44); //True

         //Declare a 3x3 matrix
         Matrix33<double> m33 = new Matrix33<double>(6, -7, 10, 0, 3, -1, 0, 5, 2);

         Matrix33<double> m33Inv = m33.Inverse(1.0);
         Matrix33<double> c = m33 * m33Inv;

         Console.WriteLine("\n" + c); //True
         
         Console.WriteLine(c == Matrix33<double>.Identity(1.0)); //True
         Console.WriteLine(m44); //True

         Console.ReadKey();
      }
   }
}
