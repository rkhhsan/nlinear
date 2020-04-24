using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLinear;

namespace Example_Vector
{
   class Program
   {
      static void Main(string[] args)
      {
         //Declare two unit vectors e1, e2
         Vec2<int> v1 = new Vec2<int>(1, 0);
         Vec2<int> v2 = new Vec2<int>(0, 1);


         //Calculate the dot-product :
         int n1 = v1.Dot(v2);
         n1 = v1 ^ v2;

         //Check if proj == 0
         Console.WriteLine(n1 == 0); //True

         //Declare two unit vectors e1, e2
         Vec3<int> e1 = new Vec3<int>(1, 0, 0);
         Vec3<int> e2 = new Vec3<int>(0, 1, 0);

         //Calculate the dot-product :
         int proj = e1 ^ e2;

         //Check if proj == 0
         Console.WriteLine(n1 == 0); //True

         //Calculate the cross product
         Vec3<int> e3 = e1 % e2;

         Vec3<int> e4 = new Vec3<int>(0, 0, 1);

         //Check if e3 == (0, 0, 1)
         Console.WriteLine(e3 == e4); //True

         Console.ReadKey();
      }
   }
}
