using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace diffEqSolver
{
    struct Point
    {
        public Point()
        {
            state[0] = new Vector2d(0, 0);
            state[1] = new Vector2d(0, 0);
            state[2] = new Vector2d(0, 0);
        }
        public Point(Point point)
        {
            state = point.state;
        }

        public Point(Vector2d accels, Vector2d vels, Vector2d coords)
        {
            Accels = accels;
            Vels = vels;
            Coords = coords;
        }

        public Point(double x = 0, double y = 0, double vx = 0, double vy = 0, double ax = 0, double ay = 0)
        {
            state[0] = new Vector2d(ax, ay);
            state[1] = new Vector2d(vx, vy);
            state[2] = new Vector2d(x, y);
        }

        /*
        Vector2d[] state = {new Vector2d(0,0),
                            new Vector2d(0,0),
                            new Vector2d(0,0)};
        */
        Vector2d[] state = new Vector2d[3];

        public Vector2d[] State
        {
            get => state;
            set => state = value;
        }

        public Vector2d Accels
        {
            get => state[0]; set => state[0] = value;
        }

        public Vector2d Vels
        {
            get => state[1]; set => state[1] = value;
        }

        public Vector2d Coords
        {
            get => state[2]; set => state[2] = value;
        }

        public double X { get => Coords.X; }
        public double Y { get => Coords.Y; }
        public double vX { get => Vels.X; }
        public double vY { get => Vels.Y; }
        public double aX { get => Accels.X; }
        public double aY { get => Accels.Y; }

        public static Point operator +(Point a, Point b)
        {

            return new Point(accels: a.Accels + b.Accels,
                             vels: a.Vels + b.Vels,
                             coords: a.Coords + b.Coords);
        }

        public static Point operator -(Point a, Point b)
        {
            return new Point(accels: a.Accels - b.Accels,
                             vels: a.Vels - b.Vels,
                             coords: a.Coords - b.Coords);
        }

        public static Point operator *(Point a, double c)
        {
            return new Point(accels: a.Accels * c,
                             vels: a.Vels * c,
                             coords: a.Coords * c);
        }

        public static Point operator /(Point a, double c)
        {
            return new Point(accels: a.Accels / c,
                             vels: a.Vels / c,
                             coords: a.Coords / c);
        }

    }
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
