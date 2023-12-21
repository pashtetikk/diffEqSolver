using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace diffEqSolver
{
    public struct Vector2d
    {
        public Vector2d(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Vector2d(Vector2d vec)
        {
            X = vec.X;
            Y = vec.Y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        public static Vector2d operator +(Vector2d a, Vector2d b)
        {
            return new Vector2d(a.X + b.X,
                                a.Y + b.Y);
        }

        public static Vector2d operator -(Vector2d a, Vector2d b)
        {
            return new Vector2d(a.X - b.X,
                            a.Y - b.Y);
        }

        public static Vector2d operator *(Vector2d a, double c)
        {
            return new Vector2d(a.X * c,
                            a.Y * c);
        }

        public static Vector2d operator *(double c, Vector2d a)
        {
            return new Vector2d(a.X * c,
                            a.Y * c);
        }

        public static Vector2d operator /(Vector2d a, double c)
        {
            return new Vector2d(a.X / c,
                            a.Y / c);
        }

    }
}
