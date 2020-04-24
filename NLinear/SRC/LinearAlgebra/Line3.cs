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
    public struct Line3<T> : IEquatable<Line3<T>>
        where T : IEquatable<T>
    {
        Vec3<T> pos;
        Vec3<T> dir;

        public Vec3<T> Pos
        {
            get
            {
                return pos;
            }
            set
            {
                pos = value;
            }
        }

        public Vec3<T> Dir
        {
            get
            {
                return dir;
            }
            set
            {
                dir = value;
            }
        }

        void Set(Vec3<T> p0, Vec3<T> p1, T unit)
        {
            pos = p0; dir = p1 - p0;
            dir.Normalize(unit);
        }

        public Line3(Vec3<T> p0, Vec3<T> p1, T unit)
        {
            pos = p0;
            dir = p1 - p0;
            dir.Normalize(unit);
        }

        public Vec3<T> ClosestPointTo(Vec3<T> point)
        {
            return ((point - pos) ^ dir) * dir + pos;
        }

        public Vec3<T> GetPoint(T parameter)
        {
            return pos + dir * parameter;
        }

        public T DistanceTo(Vec3<T> point, T unit)
        {
            return (ClosestPointTo(point) - point).Length(unit);
        }

        public T DistanceTo(Line3<T> line)
        {
            Numeric<T> d = (dir % line.dir) ^ (line.pos - pos);
            return (d >= Numeric<T>.Zero()) ? d : -d;
        }

        public Vec3<T> ClosestPointTo(Line3<T> line, Func<double, T> fromDouble = null, Func<T, double> magnitude = null)
        {
            if (fromDouble == null)
                fromDouble = Numeric<T>.FromDouble;

            if (magnitude == null)
                magnitude = Numeric<T>.ToDouble;

            // Assumes the lines are normalized

            Vec3<T> posLpos = pos - line.pos;
            Numeric<T> c = dir ^ posLpos;
            Numeric<T> a = line.dir ^ dir;
            Numeric<T> f = line.dir ^ posLpos;
            Numeric<T> num = c - a * f;

            Numeric<T> denom = a * a - fromDouble(1.0);

            Numeric<T> absDenom = ((denom >= Numeric<T>.Zero()) ? denom : -denom);

            if (absDenom < fromDouble(1.0))
            {
                Numeric<T> absNum = ((num >= Numeric<T>.Zero()) ? num : -num);

                if (magnitude(absNum) >= magnitude(absDenom) * double.MaxValue)
                    return pos;
            }

            return pos + dir * (num / denom);
        }

        public void Multiply(Matrix44<T> m, T unit)
        {
            this = new Line3<T>(pos * m, (pos + dir) * m, unit);
        }

        #region Equality

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Line3<T>)
            {
                Line3<T> other = (Line3<T>)obj;
                return Equals(ref this, ref other);
            }
            return base.Equals(obj);
        }

        public bool Equals(Line3<T> other)
        {
            return Equals(this, other);
        }

        private static bool Equals(ref Line3<T> v1, ref Line3<T> v2)
        {
            return EqualityComparer<Vec3<T>>.Default.Equals(v1.dir, v2.dir)
                && EqualityComparer<Vec3<T>>.Default.Equals(v1.pos, v2.pos);
        }

        public static bool operator ==(Line3<T> v1, Line3<T> v2)
        {
            return EqualityComparer<Vec3<T>>.Default.Equals(v1.dir, v2.dir)
                && EqualityComparer<Vec3<T>>.Default.Equals(v1.pos, v2.pos);
        }

        public static bool operator !=(Line3<T> v1, Line3<T> v2)
        {
            return !(EqualityComparer<Vec3<T>>.Default.Equals(v1.dir, v2.dir)
                && EqualityComparer<Vec3<T>>.Default.Equals(v1.pos, v2.pos));
        }

        public override int GetHashCode()
        {
            int hashCode = 67;

            hashCode = hashCode * 71 + dir.GetHashCode();
            hashCode = hashCode * 71 + pos.GetHashCode();

            return hashCode;
        }

        #endregion
    }
}
