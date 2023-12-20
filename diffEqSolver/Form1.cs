using System.Collections.Generic;

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
            public Point(Point point)
            {
                X= point.X;
                Y= point.Y; 
                vX= point.vX;
                vY= point.vY;
            }
            public Point(double x, double y, double vx, double vy)
            {
                X = x;
                Y = y;
                vX = vx;
                vY = vy;
            }

            public double X { get; set; }
            public double Y { get; set; }
            public double vX { get; set; }
            public double vY { get; set; }
            public static Point operator +(Point a, Point b)
            {
                return new Point(a.X + b.X,
                                a.Y + b.Y,
                                a.vX + b.vX,
                                a.vY + b.vY);
            }

            public static Point operator -(Point a, Point b)
            {
                return new Point(a.X - b.X,
                                a.Y - b.Y,
                                a.vX - b.vX,
                                a.vY - b.vY);
            }

            public static Point operator *(Point a, double c){
                return new Point(a.X *c,
                                a.Y * c,
                                a.vX * c,
                                a.vY * c);
            }

            public static Point operator /(Point a, double c)
            {
                return new Point(a.X / c,
                                a.Y / c,
                                a.vX / c,
                                a.vY / c);
            }

        }

        struct aPoint
        {
            public aPoint(double ax, double ay)
            {
                aX = ax;   
                aY = ay;    
            }
            public double aX { get; set; }
            public double aY { get; set; }

            public static aPoint operator +(aPoint a, aPoint b)
            {
                return new aPoint(a.aX + b.aX,
                                a.aY + b.aY);
            }

            public static Point operator +(Point a, aPoint b)
            {
                return new Point(
                    vx: a.vX + b.aX,
                    vy: a.vY + b.aY,
                    x: a.X,
                    y: a.Y
                );
            }

            public static aPoint operator -(aPoint a, aPoint b)
            {
                return new aPoint(a.aX - b.aX,
                                a.aY - b.aY);
            }

            public static aPoint operator *(aPoint a, double c)
            {
                return new aPoint(a.aX * c,
                                a.aY * c);
            }

            public static aPoint operator /(aPoint a, double c)
            {
                return new aPoint(a.aX / c,
                                a.aY / c);
            }
        }

        Point initialCond = new Point(2, 0, 0, 0);

        List<Point> points = new List<Point>();
        List<double> time = new List<double>();
        int numOfPoints = 0;
        double dT = 0;

        int animationI = 0;

        aPoint calcSysOut(Point point)
        {
            return new aPoint(
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
                if (xPoseCheck.Checked)
                {
                    xPlot.Plot.AddScatter(time.ToArray(), poseXGraph.ToArray(), markerSize:0);
                }
                else
                {
                    xPlot.Plot.Clear();
                }

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
                    break;
                case "RK4":
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

        private void calcEiler()
        {
            for(int i = 1; i<numOfPoints; i++)
            {
                points.Add(new Point(x:0, y: 0, vx: 0, vy: 0));
                aPoint sysOut = calcSysOut(points[i - 1]);
                points[i] = integra(points[i - 1], sysOut, dT);
                points[i] = integra(points[i], points[i], dT);
                time.Add(time[i - 1] + dT);

                /*
                Point _tmp = new Point(
                    vx: points[i - 1].vX + sysOut.aX * dT,
                    vy: points[i - 1].vY + sysOut.aY * dT,
                    x: points[i-1].X + (points[i - 1].vX + sysOut.aX * dT)*dT,
                    y: points[i - 1].Y + (points[i - 1].vY + sysOut.aY * dT) * dT
                    );
                points.Add(_tmp);
                time.Add(time[i - 1] + dT);
                */
                /*
                Point res = points[i - 1] + calcSysOut(points[i - 1] * dT);
                Point _tmp = new Point(
                    vx: 0,
                    vy: 0,
                    x: 0,
                    y: 0
                    );
                */
            }
        }

        private void calcHyun()
        {
            for(int i = 1; i < numOfPoints;i++)
            {
                points.Add(new Point(0,0,0,0));

            }
        }



        private void simEndTime_ValueChanged(object sender, EventArgs e)
        {
            timeBar.Plot.SetAxisLimitsX(xMin: 0, xMax: (double)simEndTime.Value);
        }
    }
}