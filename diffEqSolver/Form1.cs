using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Numerics;

namespace diffEqSolver
{
    public partial class Form1 : Form
    {
        const double accle_g = 9.81;
        int NUM_OF_EXPR = 25;
        int THIN_OUT_COEF = 8;
        double studentCoef = 5.598;
        Dictionary<int, string> IntegraMethods = new Dictionary<int, string>
        {
            {0, "Eiler" },
            {1, "Hyun" },
            {2, "RK4" },
        };

        Random rnd = new Random();
        
        double getRndNum()
        {
            double num = 0;
            for (int i = 0; i < 6; i++)
            {
                num += rnd.NextDouble()*2 - 1;
            }
            return num * (double)noiseAmp.Value / 6;
        }

        Point initialCond = new Point(x:2, y:0);

        List<Point> points = new List<Point>();
        List<double> time = new List<double>();

        List<List<double>> noisyXPose = new List<List<double>>();
        List<List<double>> noisyYPose = new List<List<double>>();

        List<double> meanXPose = new List<double>();
        List<double> meanYPose = new List<double>();

        List<double> confXPose = new List<double>();
        List<double> confYPose = new List<double>();

        int numOfPoints = 0;
        double dT = 0.01;

        int animationI = 0;
        bool newData = false;

        List<double> thinOut(List<double> inData)
        {
            List<double> outData = new List<double>();
            for(int i = 0; i<inData.Count; i+= THIN_OUT_COEF)
            {
                outData.Add(inData[i]);
            }
            return outData;
        }

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
            integraMethod.Text = IntegraMethods[2];

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

            if (newData)
            {
                newData = false;
                xPlot.Plot.Clear();
                yPlot.Plot.Clear();
                redrawGraph();

            }


            //testX[0] = testX[0] + (rand.NextDouble() - 0.5)*0.1;
            //testY[0] = testY[0] + (rand.NextDouble() - 0.5) * 0.1;
            //xyPlot.Plot.AddScatter(testX, testY, markerSize: 10, color: Color.Magenta);
            xPlot.Refresh();
            yPlot.Refresh();
            xyPlot.Refresh();
            timeBar.Refresh();
        }
        private void redrawGraph()
        {
            if (xPoseCheck.Checked)
            {
                xPlot.Plot.AddScatter(time.ToArray(), poseXGraph.ToArray(), markerSize: 0, color: Color.Blue, lineWidth:3);
            }

            if (xVelCheck.Checked)
            {
                xPlot.Plot.AddScatter(time.ToArray(), velXGraph.ToArray(), markerSize: 0, color: Color.Green, lineWidth: 3);
            }

            if (xPoseNoisyCheck.Checked)
            {
                for(int i = 0; i < NUM_OF_EXPR; i++)
                {
                    xPlot.Plot.AddScatter(time.ToArray(), noisyXPose[i].ToArray(), markerSize: 0, lineWidth:0.1f);
                }
            }

            if(xPoseMeanCheck.Checked)
            {
                xPlot.Plot.AddScatter(time.ToArray(), meanXPose.ToArray(), markerSize: 0, lineWidth: 3, color: Color.Black);
            }

            if (xPoseConfCheck.Checked)
            {
                var errXGraph = xPlot.Plot.AddErrorBars(thinOut(time).ToArray(), thinOut(meanXPose).ToArray(), null, 
                                                            thinOut(confXPose).ToArray(), markerSize: 0, color: Color.Green);
                errXGraph.LineWidth = 1.5;
            }



            if (yPoseCheck.Checked)
            {
                yPlot.Plot.AddScatter(time.ToArray(), poseYGraph.ToArray(), markerSize: 0, color: Color.Blue, lineWidth: 3);
            }

            if (yVelCheck.Checked)
            {
                yPlot.Plot.AddScatter(time.ToArray(), velYGraph.ToArray(), markerSize: 0, color: Color.Green, lineWidth: 3);
            }

            if (yPoseNoisyCheck.Checked)
            {
                for (int i = 0; i < NUM_OF_EXPR; i++)
                {
                    yPlot.Plot.AddScatter(time.ToArray(), noisyYPose[i].ToArray(), markerSize: 0, lineWidth: 0.1f);
                }
            }

            if (yPoseMeanCheck.Checked)
            {
                yPlot.Plot.AddScatter(time.ToArray(), meanYPose.ToArray(), markerSize: 0, lineWidth: 3, color: Color.Black);
            }

            if (yPoseConfCheck.Checked)
            {
                var errYGraph = yPlot.Plot.AddErrorBars(thinOut(time).ToArray(), thinOut(meanYPose).ToArray(), null,
                                                            thinOut(confYPose).ToArray(), markerSize: 0, color: Color.Green);
                errYGraph.LineWidth = 1.5;
            }


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
            noisyXPose.Clear();
            noisyYPose.Clear();
            confXPose.Clear();
            confYPose.Clear();
            meanXPose.Clear();
            meanYPose.Clear();


            time.Add(0);
            points.Add(initialCond);

            if (confRange99.Checked)
            {
                studentCoef = 5.598;
            }
            else
            {
                studentCoef = 2.776;
            }


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

            for (int i = 0; i< NUM_OF_EXPR; i++)
            {
                List<double> _poseX = new List<double>();
                List<double> _poseY = new List<double>();

                List<double> noiseX = new List<double>();
                List<double> noiseY = new List<double>();

                noiseX.Add(getRndNum());
                noiseY.Add(getRndNum());

                _poseX.Add(points[0].X + noiseX[0]);
                _poseY.Add(points[0].Y + noiseY[0]);

                for(int j = 1; j<points.Count; j++)
                {
                    noiseX.Add(noiseX[j - 1] + getRndNum());
                    noiseY.Add(noiseY[j - 1] + getRndNum());

                    _poseX.Add(points[j].X + noiseX[j]);
                    _poseY.Add(points[j].Y + noiseY[j]);
                }
                
                noisyXPose.Add(_poseX);
                noisyYPose.Add(_poseY);
            }

            for (int i = 0; i<points.Count; i++)
            {
                double meanX = 0;
                double meanY = 0;
                for (int j = 0; j < NUM_OF_EXPR; j++) 
                {
                    meanX += noisyXPose[j][i];
                    meanY += noisyYPose[j][i];
                }
                meanXPose.Add(meanX / NUM_OF_EXPR);
                meanYPose.Add(meanY / NUM_OF_EXPR);
            }

            for(int i = 0; i<points.Count; i++)
            {
                double squareXErr = 0;
                double squareYErr = 0;

                for(int j = 0; j<NUM_OF_EXPR; j++)
                {
                    squareXErr += Math.Pow(noisyXPose[j][i] - meanXPose[i], 2);
                    squareYErr += Math.Pow(noisyYPose[j][i] - meanYPose[i], 2);
                }

                confXPose.Add(Math.Sqrt(squareXErr/NUM_OF_EXPR) * studentCoef/Math.Sqrt(NUM_OF_EXPR));
                confYPose.Add(Math.Sqrt(squareYErr/NUM_OF_EXPR) * studentCoef / Math.Sqrt(NUM_OF_EXPR));                
            }


            foreach(Point point in points)
            {
                poseXGraph.Add(point.X);
                poseYGraph.Add(point.Y);
                velXGraph.Add(point.vX);
                velYGraph.Add(point.vY);
            }
            plotUpdateTim.Interval = (int)(dT * 2000);
            xPlot.Plot.Clear();
            yPlot.Plot.Clear();
            newData = true;
            plotUpdateTim.Enabled = true;

        }

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
                Point prev = points[i - 1];

                Point k1 = prev;
                k1.Accels = calcSysOut(k1).Accels;

                Point k2 = new Point();
                k2.Vels = prev.Vels + k1.Accels * 0.5 * dT;
                k2.Coords = prev.Coords + k1.Vels * 0.5 * dT;
                k2.Accels = calcSysOut(k2).Accels;

                Point k3 = new Point();
                k3.Vels = prev.Vels + k2.Accels * 0.5 * dT;
                k3.Coords = prev.Coords + k2.Vels * 0.5 * dT;
                k3.Accels = calcSysOut(k3).Accels;

                Point k4 = new Point();
                k4.Vels = prev.Vels + k3.Accels * dT;
                k4.Coords = prev.Coords + k3.Vels  * dT;
                k4.Accels = calcSysOut(k4).Accels;

                Point res = new Point();
                res.Vels = prev.Vels + (k1.Accels + 2 * k2.Accels + 2 * k3.Accels + k4.Accels) * dT / 6;
                res.Coords = prev.Coords + (k1.Vels + 2 * k2.Vels + 2 * k3.Vels + k4.Vels) * dT / 6;

                points.Add(res);
                time.Add(time[i - 1] + dT);
            }
        }


        private void graphCheck_CehackedChanged(object sender, EventArgs e)
        {
            newData = true;
        }
        private void simEndTime_ValueChanged(object sender, EventArgs e)
        {
            timeBar.Plot.SetAxisLimitsX(xMin: 0, xMax: (double)simEndTime.Value);
        }

    }
}