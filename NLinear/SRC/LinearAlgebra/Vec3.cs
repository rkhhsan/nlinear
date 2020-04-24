// Copyright (c) 2011 Hamrouni Ghassen. All rights reserved.
//
// Portions of this library are based on Miscellaneous Utility Library by Jon Skeet
// Portions of this library are a port of IlmBase http://www.openexr.com/
//
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLinear
{
   /// <summary>
   /// A 3-dimensional vector/point
   /// </summary>
   /// <typeparam name="T">A numeric type (float, int, ...)</typeparam>
   public struct Vec3<T> : IEquatable<Vec3<T>>
       where T : IEquatable<T>
   {
      /// <summary>
      ///  The vector components.
      /// </summary>
      Numeric<T> x, y, z;

      public T X
      {
         get
         {
            return x;
         }
         set
         {
            x = value;
         }
      }

      public T Y
      {
         get
         {
            return y;
         }
         set
         {
            y = value;
         }
      }

      public T Z
      {
         get
         {
            return z;
         }
         set
         {
            z = value;
         }
      }

      /// <summary>
      ///  Get component at index
      /// </summary>
      /// <param name="index"> Index between 0 and 2 </param>
      /// <returns></returns>
      public T this[int index]
      {
         get
         {
            if (index == 0) return x;
            if (index == 1) return y;

            return z;
         }
      }

      /// <summary>
      /// Constructor x = y = z = a
      /// </summary>
      /// <param name="a"></param>
      public Vec3(T a)
      {
         x = y = z = a;
      }

      /// <summary>
      /// Constructor (x y z) = (a b c)
      /// </summary>
      /// <param name="a"></param>
      public Vec3(T a, T b, T c)
      {
         x = a;
         y = b;
         z = c;
      }

      /// <summary>
      /// The dot product.
      /// </summary>
      /// <param name="v"></param>
      /// <returns></returns>
      public T Dot(Vec3<T> v)
      {
         return x * v.x + y * v.y + z * v.z;
      }

      /// <summary>
      /// The dot product.
      /// </summary>
      /// <param name="v"></param>
      /// <returns></returns>
      public static T operator ^(Vec3<T> c1, Vec3<T> c2)
      {
         return c1.Dot(c2);
      }

      /// <summary>
      /// Cross-product
      /// </summary>
      /// <param name="v"></param>
      /// <returns></returns>
      public Vec3<T> Cross(Vec3<T> v)
      {
         return new Vec3<T>(y * v.z - z * v.y,
                           z * v.x - x * v.z,
                           x * v.y - y * v.x);
      }

      /// <summary>
      /// Cross-product
      /// </summary>
      /// <param name="c1"></param>
      /// <param name="c2"></param>
      /// <returns></returns>
      public static Vec3<T> operator %(Vec3<T> c1, Vec3<T> c2)
      {
         return c1.Cross(c2);
      }

      /// <summary>
      /// Component wise addition
      /// </summary>
      /// <param name="c1"></param>
      /// <param name="c2"></param>
      /// <returns></returns>
      public static Vec3<T> operator +(Vec3<T> c1, Vec3<T> c2)
      {
         Vec3<T> v = new Vec3<T>();

         v.x = c1.x + c2.x;
         v.y = c1.y + c2.y;
         v.z = c1.z + c2.z;

         return v;
      }

      ///<summary>
      /// Component wise subtraction
      /// </summary>
      /// <param name="c1"></param>
      /// <param name="c2"></param>
      /// <returns></returns>
      public static Vec3<T> operator -(Vec3<T> c1, Vec3<T> c2)
      {
         Vec3<T> v = new Vec3<T>();

         v.x = c1.x - c2.x;
         v.y = c1.y - c2.y;
         v.z = c1.z - c2.z;

         return v;
      }

      /// <summary>
      /// Component wise inversion -(x y z) = (-x -y -z)
      /// </summary>
      /// <param name="c1"></param>
      /// <param name="c2"></param>
      /// <returns></returns>
      public static Vec3<T> operator -(Vec3<T> c1)
      {
         Vec3<T> v = new Vec3<T>();

         v.x = -c1.x;
         v.y = -c1.y;
         v.z = -c1.z;

         return v;
      }

      /// <summary>
      /// Component wise inversion -(x y z) = (-x -y -z)
      /// </summary>
      /// <returns></returns>
      public Vec3<T> Negate()
      {
         x = -x;
         y = -y;
         z = -z;

         return this;
      }

      /// <summary>
      /// Component wise multiplication
      /// </summary>
      /// <param name="c1"></param>
      /// <param name="c2"></param>
      /// <returns></returns>
      public static Vec3<T> operator *(Vec3<T> c1, Vec3<T> c2)
      {
         Vec3<T> v = new Vec3<T>();

         v.x = c1.x * c2.x;
         v.y = c1.y * c2.y;
         v.z = c1.z * c2.z;

         return v;
      }

      /// <summary>
      /// Component wise multiplication by a constant
      /// </summary>
      /// <param name="c1"></param>
      /// <param name="c"></param>
      /// <returns></returns>
      public static Vec3<T> operator *(Vec3<T> c1, T c)
      {
         Vec3<T> v = new Vec3<T>();

         v.x = c1.x * c;
         v.y = c1.y * c;
         v.z = c1.z * c;

         return v;
      }

      /// <summary>
      /// Component wise multiplication by a constant
      /// </summary>
      /// <param name="c1"></param>
      /// <param name="c"></param>
      /// <returns></returns>
      public static Vec3<T> operator *(T c, Vec3<T> c1)
      {
         Vec3<T> v = new Vec3<T>();

         v.x = c1.x * c;
         v.y = c1.y * c;
         v.z = c1.z * c;

         return v;
      }

      /// <summary>
      /// Component wise division
      /// </summary>
      /// <param name="c1"></param>
      /// <param name="c"></param>
      /// <returns></returns>
      public static Vec3<T> operator /(Vec3<T> c1, Vec3<T> c2)
      {
         Vec3<T> v = new Vec3<T>();

         v.x = c1.x / c2.x;
         v.y = c1.y / c2.y;
         v.z = c1.z / c2.z;

         return v;
      }

      /// <summary>
      /// Component wise division by a constant
      /// </summary>
      /// <param name="c1"></param>
      /// <param name="c"></param>
      /// <returns></returns>
      public static Vec3<T> operator /(Vec3<T> c1, T c)
      {
         Vec3<T> v = new Vec3<T>();

         v.x = c1.x / c;
         v.y = c1.y / c;
         v.z = c1.z / c;

         return v;
      }

      /// <summary>
      /// Length of the vector
      /// </summary>
      /// <returns></returns>
      public T Length(T unit)
      {
         return GenericMath.Sqrt<T>(x * x + y * y + z * z, unit);
      }

      /// <summary>
      /// Squared length of the vector
      /// </summary>
      /// <returns></returns>
      public T Length2()
      {
         return x * x + y * y + z * z;
      }

      /// <summary>
      /// Normalize the vector (x y z) / Length( (x y z) )
      /// </summary>
      /// <returns></returns>
      public Vec3<T> Normalize(T unit)
      {
         T l = Length(unit);

         Numeric<T> numL = l;

         if (!numL.Equals(Numeric<T>.Zero()))
         {
            x /= l;
            y /= l;
            z /= l;
         }

         return this;
      }

      /// <summary>
      /// get a normalized vector (x y z) / Length( (x y z) )
      /// </summary>
      /// <returns></returns>
      public Vec3<T> Normalized(T unit)
      {
         T l = Length(unit);

         Numeric<T> numL = l;

         if (numL.Equals(Numeric<T>.Zero()))
            return new Vec3<T>(Numeric<T>.Zero());

         return new Vec3<T>(x / l, y / l, z / l);
      }

      #region Equality

      public override bool Equals(object obj)
      {
         if (obj != null && obj is Vec3<T>)
         {
            Vec3<T> other = (Vec3<T>)obj;
            return Equals(ref this, ref other);
         }
         return base.Equals(obj);
      }

      public bool Equals(Vec3<T> other)
      {
         return Equals(this, other);
      }

      public static bool operator ==(Vec3<T> v1, Vec3<T> v2)
      {
         return EqualityComparer<T>.Default.Equals(v1.X, v2.X)
             && EqualityComparer<T>.Default.Equals(v1.Y, v2.Y)
             && EqualityComparer<T>.Default.Equals(v1.Z, v2.Z);
      }

      public static bool operator !=(Vec3<T> v1, Vec3<T> v2)
      {
         return !(EqualityComparer<T>.Default.Equals(v1.X, v2.X)
                 && EqualityComparer<T>.Default.Equals(v1.Y, v2.Y)
                 && EqualityComparer<T>.Default.Equals(v1.Z, v2.Z));
      }

      private static bool Equals(ref Vec3<T> v1, ref Vec3<T> v2)
      {
         return EqualityComparer<T>.Default.Equals(v1.X, v2.X)
             && EqualityComparer<T>.Default.Equals(v1.Y, v2.Y)
             && EqualityComparer<T>.Default.Equals(v1.Z, v2.Z);
      }

      public override int GetHashCode()
      {
         int hashCode = 67;

         hashCode = hashCode * 71 + x.GetHashCode();
         hashCode = hashCode * 71 + y.GetHashCode();
         hashCode = hashCode * 71 + z.GetHashCode();

         return hashCode;
      }

      #endregion

      public override string ToString()
      {
         return String.Format("({0}, {1}, {2})", X, Y, Z);
      }
   }
}
