using System.Collections.Generic;
using System.Numerics;

namespace diffEqSolver
{
    public partial class Form1 : Form
    {
        const double accle_g = 9.81;
        Dictionary<int, string> IntegraMethods = new Dictionary<int, string>
        {
            {0, "Eiler" },
            {1, "Hyun" },
            {2, "RK4" },
        };

        
        
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
                Vels= vels;
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

            public static Point operator *(Point a, double c){
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

        Point initialCond = new Point(x:2, y:0);

        List<Point> points = new List<Point>();
        List<double> time = new List<double>();
        int numOfPoints = 0;
        double dT = 0;

        int animationI = 0;

        Point calcSysOut(Point point)
        {
            return new Point(
                ax: 2 * point.X * (-2 * Math.Pow(point.vX, 2) - accle_g) / (4 * Math.Pow(point.X, 2) + 1),
                ay: (2 * Math.Pow(point.vX, 2) + accle_g) / (4 * Math.Pow(point.X, 2) + 1) - accle_g
                );
        }

 
        Random rand = new Random();
        ScottPlot.Plottable.BarPlot animTimeBar;
        double[] animationX = {0};
        double[] animationY = {0};
        double[] animationT = { 0 };
        List<double> poseXGraph = new List<double>();
        List<double> poseYGraph = new List<double>();
        List<double> velXGraph = new List<double>();
        List <double> velYGraph = new List<double>();
        public Form1()
        {
            InitializeComponent();

            xPlot.Plot.Title("X Plot");
            xPlot.Plot.XAxis.Label("Time, c");
            xPlot.Plot.YAxis.Label("Pose, m");

            yPlot.Plot.Title("Y Plot");
            yPlot.Plot.XAxis.Label("Time, c");
            yPlot.Plot.YAxis.Label("Pose, m");

            xyPlot.Plot.Title("XY Pose");
            xyPlot.Plot.XAxis.Label("X, m");
            xyPlot.Plot.YAxis.Label("Y, m");
            xyPlot.Plot.SetAxisLimits(-5, 5, -5, 5);
            xyPlot.Configuration.Zoom = false;
            xyPlot.Configuration.Pan = false;

            timeBar.Plot.YAxis.Line(false);
            timeBar.Plot.YAxis2.Line(false);
            timeBar.Plot.YAxis.Ticks(false);
            timeBar.Plot.SetAxisLimits(xMin: 0, xMax: (double)simEndTime.Value, yMin: 0, yMax:1);
            timeBar.Configuration.Zoom = false;
            timeBar.Configuration.Pan = false;
            timeBar.Plot.XAxis.Label("time, c"); 
            animTimeBar = timeBar.Plot.AddBar(values: new double[] { 0 }, positions: new double[] { 0.5 });
            animTimeBar.BarWidth = 0.5;
            animTimeBar.Orientation = ScottPlot.Orientation.Horizontal;

            foreach (var method in IntegraMethods)
            {
                integraMethod.Items.Add(method.Value);
            }
            integraMethod.Text = IntegraMethods[0];


            //double[] dataX = new double[] { 1, 2, 3, 4, 5 };
            //double[] dataY = new double[] { 1, 4, 9, 16, 25 };

            //xPlot.Plot.AddScatter(dataX, dataY);
            //yPlot.Plot.AddScatter(dataX, dataY);
            plotUpdateTim.Enabled = true;   
        }

        private void xPlotAllCheck_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control c in xPlotParams.Controls)
            {
                CheckBox cb = (CheckBox)c;
                if(cb != null)
                {
                    if(cb.Name != ((CheckBox)sender).Name)
                    {
                        cb.Checked = ((CheckBox)sender).Checked;
                    }
                }
            }
        }

        private void yPlotAllCheck_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control c in yPlotParams.Controls)
            {
                CheckBox cb = (CheckBox)c;
                if (cb != null)
                {
                    if (cb.Name != ((CheckBox)sender).Name)
                    {
                        cb.Checked = ((CheckBox)sender).Checked;
                    }
                }
            }
        }

        private void plotUpdateTim_Tick(object sender, EventArgs e)
        {
            if (points.Count > 0)
            {
                animationX[0] = points[animationI].X ;
                animationY[0] = points[animationI].Y ;
                animationT[0] = time[animationI];
                xyPlot.Plot.AddScatter(animationX, animationY, markerSize: 10, color: Color.Magenta);
                animTimeBar.Values = animationT;
                animationI++;
                if (animationI >= points.Count)
                {
                    animationI = 0;
                }                
            }


            //testX[0] = testX[0] + (rand.NextDouble() - 0.5)*0.1;
           // testY[0] = testY[0] + (rand.NextDouble() - 0.5) * 0.1;
            //xyPlot.Plot.AddScatter(testX, testY, markerSize: 10, color: Color.Magenta);
            xPlot.Refresh();
            yPlot.Refresh();
            xyPlot.Refresh();
            timeBar.Refresh();
        }

        private void confRange99_CheckedChanged(object sender, EventArgs e)
        {
            confRange95.Checked = !confRange99.Checked;
        }

        private void confRange95_CheckedChanged(object sender, EventArgs e)
        {
            confRange99.Checked = !confRange95.Checked; 
        }


        private void simulateBtn_Click(object sender, EventArgs e)
        {
            plotUpdateTim.Enabled = false;
            animationI = 0;            
            dT = (double)simTimeStep.Value;
            numOfPoints = (int)((double)simEndTime.Value / (double)simTimeStep.Value);
            time.Clear();            
            points.Clear();
            poseXGraph.Clear();
            poseYGraph.Clear();
            velXGraph.Clear();
            velYGraph.Clear();
            time.Add(0);
            points.Add(initialCond);


            switch (integraMethod.SelectedItem.ToString())
            {
                case "Eiler":
                    calcEiler();
                    break;
                case "Hyun":
                    calcHyun();
                    break;
                case "RK4":
                    calcRK4();
                    break;
                default:
                    break;
            }

            foreach(Point point in points)
            {
                poseXGraph.Add(point.X);
                poseYGraph.Add(point.Y);
                velXGraph.Add(point.vX);
                velYGraph.Add(point.vY);
            }
            plotUpdateTim.Interval = (int)(dT * 2000);
            plotUpdateTim.Enabled = true;

        }

        Vector2d integra (Vector2d prevState, Vector2d curState, double dT) {
            return new Vector2d(prevState + curState * dT);
        }


        /*
        private Point integra(Point prevState, Point curState, double dT)
        {
            Point _tmp = new Point(
                x: curState.vX * dT,
                y: curState.vY * dT,
                vx: 0,
                vy: 0); 
            return new Point(prevState + _tmp);
        }

        private Point integra(Point prevState, aPoint curState, double dT)
        {
            Point _tmp= new Point(
                vx: curState.aX * dT,
                vy: curState.aY * dT,
                x:0,
                y:0
                );
            return new Point(prevState + _tmp);

        }  
        */

        private void calcEiler()
        {
            for(int i = 1; i<numOfPoints; i++)
            {
                Point _tmp = calcSysOut(points[i - 1]);
                _tmp.Vels = points[i - 1].Vels + _tmp.Accels * dT;
                _tmp.Coords = points[i - 1].Coords + _tmp.Vels * dT;
                points.Add( _tmp );
                time.Add(time[i - 1] + dT);
            }
        }

        private void calcHyun()
        {
            for(int i = 1; i < numOfPoints;i++)
            {
                Point prev = points[i - 1];

                Point k1 = points[i-1];
                k1.Accels = calcSysOut(prev).Accels;

                Point k2 = new Point();
                k2.Vels = prev.Vels + k1.Accels * dT;
                k2.Coords = prev.Coords + k1.Vels * dT;
                k2.Accels = calcSysOut(k2).Accels;

                Point res = new Point();
                res.Vels = prev.Vels + (k1.Accels + k2.Accels) * dT * 0.5;
                res.Coords = prev.Coords + (k1.Vels + k2.Vels) * dT * 0.5;

                points.Add(res);

                time.Add(time[i - 1] + dT);
            }
        }

        private void calcRK4()
        {
            for (int i = 1; i < numOfPoints; i++)
            {
                Point prevState = points[i - 1];

                Point k1 = points[i - 1];
                k1.Accels = calcSysOut(k1).Accels;

                Point k2 = new Point();
                k2.Vels = k1.Vels + k1.Accels * 0.5 * dT;
                k2.Coords = k1.Coords + k1.Vels * 0.5 * dT;
                k2.Accels = calcSysOut(k2).Accels;

                Point k3 = new Point();
                k3.Vels = k2.Vels + k2.Accels * 0.5 * dT;
                k3.Coords = k2.Coords + k2.Vels * 0.5 * dT;
                k3.Accels = calcSysOut(k3).Accels;

                Point k4 = new Point();
                k4.Vels = k3.Vels + k3.Accels * dT;
                k4.Coords = k3.Coords + k3.Vels  * dT;
                k4.Accels = calcSysOut(k4).Accels;

                Point res = new Point();
                res.Vels = prevState.Vels + (k1.Accels + 2 * k2.Accels + 2 * k3.Accels + k4.Accels) * dT / 6;
                res.Coords = prevState.Coords + (k1.Vels + 2 * k2.Vels + 2 * k3.Vels + k4.Vels) * dT / 6;

                points.Add(res);
                time.Add(time[i - 1] + dT);
            }
        }



        private void simEndTime_ValueChanged(object sender, EventArgs e)
        {
            timeBar.Plot.SetAxisLimitsX(xMin: 0, xMax: (double)simEndTime.Value);
        }

        private void xPoseCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                xPlot.Plot.AddScatter(time.ToArray(), poseXGraph.ToArray(), markerSize: 0);
            }
            else
            {
                xPlot.Plot.Clear();
            }
        }

        private void yPoseCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                yPlot.Plot.AddScatter(time.ToArray(), poseYGraph.ToArray(), markerSize: 0);
            }
            else
            {
                yPlot.Plot.Clear();
            }
        }


    }
}