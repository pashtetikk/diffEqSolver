namespace diffEqSolver
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.xPlot = new ScottPlot.FormsPlot();
            this.posePlotBox = new System.Windows.Forms.GroupBox();
            this.yPlotParams = new System.Windows.Forms.GroupBox();
            this.yPoseConfCheck = new System.Windows.Forms.CheckBox();
            this.yPoseMeanCheck = new System.Windows.Forms.CheckBox();
            this.yPoseNoisyCheck = new System.Windows.Forms.CheckBox();
            this.yVelCheck = new System.Windows.Forms.CheckBox();
            this.yPoseCheck = new System.Windows.Forms.CheckBox();
            this.yPlotAllCheck = new System.Windows.Forms.CheckBox();
            this.xPlotParams = new System.Windows.Forms.GroupBox();
            this.xPoseConfCheck = new System.Windows.Forms.CheckBox();
            this.xPoseMeanCheck = new System.Windows.Forms.CheckBox();
            this.xPoseNoisyCheck = new System.Windows.Forms.CheckBox();
            this.xVelCheck = new System.Windows.Forms.CheckBox();
            this.xPoseCheck = new System.Windows.Forms.CheckBox();
            this.xPlotAllCheck = new System.Windows.Forms.CheckBox();
            this.yPlot = new ScottPlot.FormsPlot();
            this.xyPlot = new ScottPlot.FormsPlot();
            this.plotUpdateTim = new System.Windows.Forms.Timer(this.components);
            this.timeBar = new ScottPlot.FormsPlot();
            this.Settings = new System.Windows.Forms.GroupBox();
            this.simTimeStep = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.integraMethod = new System.Windows.Forms.ComboBox();
            this.simEndTime = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.confRange95 = new System.Windows.Forms.RadioButton();
            this.confRange99 = new System.Windows.Forms.RadioButton();
            this.noiseAmp = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.simulateBtn = new System.Windows.Forms.Button();
            this.posePlotBox.SuspendLayout();
            this.yPlotParams.SuspendLayout();
            this.xPlotParams.SuspendLayout();
            this.Settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.simTimeStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simEndTime)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noiseAmp)).BeginInit();
            this.SuspendLayout();
            // 
            // xPlot
            // 
            this.xPlot.AutoSize = true;
            this.xPlot.Location = new System.Drawing.Point(10, 30);
            this.xPlot.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.xPlot.Name = "xPlot";
            this.xPlot.Size = new System.Drawing.Size(1119, 500);
            this.xPlot.TabIndex = 0;
            // 
            // posePlotBox
            // 
            this.posePlotBox.Controls.Add(this.yPlotParams);
            this.posePlotBox.Controls.Add(this.xPlotParams);
            this.posePlotBox.Controls.Add(this.yPlot);
            this.posePlotBox.Controls.Add(this.xPlot);
            this.posePlotBox.Location = new System.Drawing.Point(17, 20);
            this.posePlotBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.posePlotBox.Name = "posePlotBox";
            this.posePlotBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.posePlotBox.Size = new System.Drawing.Size(1351, 1025);
            this.posePlotBox.TabIndex = 2;
            this.posePlotBox.TabStop = false;
            // 
            // yPlotParams
            // 
            this.yPlotParams.Controls.Add(this.yPoseConfCheck);
            this.yPlotParams.Controls.Add(this.yPoseMeanCheck);
            this.yPlotParams.Controls.Add(this.yPoseNoisyCheck);
            this.yPlotParams.Controls.Add(this.yVelCheck);
            this.yPlotParams.Controls.Add(this.yPoseCheck);
            this.yPlotParams.Controls.Add(this.yPlotAllCheck);
            this.yPlotParams.Location = new System.Drawing.Point(1123, 538);
            this.yPlotParams.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.yPlotParams.Name = "yPlotParams";
            this.yPlotParams.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.yPlotParams.Size = new System.Drawing.Size(203, 350);
            this.yPlotParams.TabIndex = 3;
            this.yPlotParams.TabStop = false;
            this.yPlotParams.Text = "Отобразить:";
            // 
            // yPoseConfCheck
            // 
            this.yPoseConfCheck.AutoSize = true;
            this.yPoseConfCheck.Location = new System.Drawing.Point(13, 267);
            this.yPoseConfCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.yPoseConfCheck.Name = "yPoseConfCheck";
            this.yPoseConfCheck.Size = new System.Drawing.Size(154, 29);
            this.yPoseConfCheck.TabIndex = 5;
            this.yPoseConfCheck.Text = "Y Pose ConfInt";
            this.yPoseConfCheck.UseVisualStyleBackColor = true;
            // 
            // yPoseMeanCheck
            // 
            this.yPoseMeanCheck.AutoSize = true;
            this.yPoseMeanCheck.Location = new System.Drawing.Point(13, 225);
            this.yPoseMeanCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.yPoseMeanCheck.Name = "yPoseMeanCheck";
            this.yPoseMeanCheck.Size = new System.Drawing.Size(139, 29);
            this.yPoseMeanCheck.TabIndex = 4;
            this.yPoseMeanCheck.Text = "Y Pose Mean";
            this.yPoseMeanCheck.UseVisualStyleBackColor = true;
            // 
            // yPoseNoisyCheck
            // 
            this.yPoseNoisyCheck.AutoSize = true;
            this.yPoseNoisyCheck.Location = new System.Drawing.Point(13, 183);
            this.yPoseNoisyCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.yPoseNoisyCheck.Name = "yPoseNoisyCheck";
            this.yPoseNoisyCheck.Size = new System.Drawing.Size(140, 29);
            this.yPoseNoisyCheck.TabIndex = 3;
            this.yPoseNoisyCheck.Text = "Y Pose Noisy";
            this.yPoseNoisyCheck.UseVisualStyleBackColor = true;
            // 
            // yVelCheck
            // 
            this.yVelCheck.AutoSize = true;
            this.yVelCheck.Location = new System.Drawing.Point(13, 142);
            this.yVelCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.yVelCheck.Name = "yVelCheck";
            this.yVelCheck.Size = new System.Drawing.Size(114, 29);
            this.yVelCheck.TabIndex = 2;
            this.yVelCheck.Text = "Y Velocity";
            this.yVelCheck.UseVisualStyleBackColor = true;
            // 
            // yPoseCheck
            // 
            this.yPoseCheck.AutoSize = true;
            this.yPoseCheck.Location = new System.Drawing.Point(13, 100);
            this.yPoseCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.yPoseCheck.Name = "yPoseCheck";
            this.yPoseCheck.Size = new System.Drawing.Size(90, 29);
            this.yPoseCheck.TabIndex = 1;
            this.yPoseCheck.Text = "Y Pose";
            this.yPoseCheck.UseVisualStyleBackColor = true;
            this.yPoseCheck.CheckedChanged += new System.EventHandler(this.yPoseCheck_CheckedChanged);
            // 
            // yPlotAllCheck
            // 
            this.yPlotAllCheck.AutoSize = true;
            this.yPlotAllCheck.Location = new System.Drawing.Point(13, 37);
            this.yPlotAllCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.yPlotAllCheck.Name = "yPlotAllCheck";
            this.yPlotAllCheck.Size = new System.Drawing.Size(145, 29);
            this.yPlotAllCheck.TabIndex = 0;
            this.yPlotAllCheck.Text = "Показать все";
            this.yPlotAllCheck.UseVisualStyleBackColor = true;
            this.yPlotAllCheck.CheckedChanged += new System.EventHandler(this.yPlotAllCheck_CheckedChanged);
            // 
            // xPlotParams
            // 
            this.xPlotParams.Controls.Add(this.xPoseConfCheck);
            this.xPlotParams.Controls.Add(this.xPoseMeanCheck);
            this.xPlotParams.Controls.Add(this.xPoseNoisyCheck);
            this.xPlotParams.Controls.Add(this.xVelCheck);
            this.xPlotParams.Controls.Add(this.xPoseCheck);
            this.xPlotParams.Controls.Add(this.xPlotAllCheck);
            this.xPlotParams.Location = new System.Drawing.Point(1123, 53);
            this.xPlotParams.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xPlotParams.Name = "xPlotParams";
            this.xPlotParams.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xPlotParams.Size = new System.Drawing.Size(203, 350);
            this.xPlotParams.TabIndex = 2;
            this.xPlotParams.TabStop = false;
            this.xPlotParams.Text = "Отобразить:";
            // 
            // xPoseConfCheck
            // 
            this.xPoseConfCheck.AutoSize = true;
            this.xPoseConfCheck.Location = new System.Drawing.Point(13, 267);
            this.xPoseConfCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xPoseConfCheck.Name = "xPoseConfCheck";
            this.xPoseConfCheck.Size = new System.Drawing.Size(155, 29);
            this.xPoseConfCheck.TabIndex = 5;
            this.xPoseConfCheck.Text = "X Pose ConfInt";
            this.xPoseConfCheck.UseVisualStyleBackColor = true;
            // 
            // xPoseMeanCheck
            // 
            this.xPoseMeanCheck.AutoSize = true;
            this.xPoseMeanCheck.Location = new System.Drawing.Point(13, 225);
            this.xPoseMeanCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xPoseMeanCheck.Name = "xPoseMeanCheck";
            this.xPoseMeanCheck.Size = new System.Drawing.Size(140, 29);
            this.xPoseMeanCheck.TabIndex = 4;
            this.xPoseMeanCheck.Text = "X Pose Mean";
            this.xPoseMeanCheck.UseVisualStyleBackColor = true;
            // 
            // xPoseNoisyCheck
            // 
            this.xPoseNoisyCheck.AutoSize = true;
            this.xPoseNoisyCheck.Location = new System.Drawing.Point(13, 183);
            this.xPoseNoisyCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xPoseNoisyCheck.Name = "xPoseNoisyCheck";
            this.xPoseNoisyCheck.Size = new System.Drawing.Size(141, 29);
            this.xPoseNoisyCheck.TabIndex = 3;
            this.xPoseNoisyCheck.Text = "X Pose Noisy";
            this.xPoseNoisyCheck.UseVisualStyleBackColor = true;
            // 
            // xVelCheck
            // 
            this.xVelCheck.AutoSize = true;
            this.xVelCheck.Location = new System.Drawing.Point(13, 142);
            this.xVelCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xVelCheck.Name = "xVelCheck";
            this.xVelCheck.Size = new System.Drawing.Size(115, 29);
            this.xVelCheck.TabIndex = 2;
            this.xVelCheck.Text = "X Velocity";
            this.xVelCheck.UseVisualStyleBackColor = true;
            // 
            // xPoseCheck
            // 
            this.xPoseCheck.AutoSize = true;
            this.xPoseCheck.Location = new System.Drawing.Point(13, 100);
            this.xPoseCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xPoseCheck.Name = "xPoseCheck";
            this.xPoseCheck.Size = new System.Drawing.Size(91, 29);
            this.xPoseCheck.TabIndex = 1;
            this.xPoseCheck.Text = "X Pose";
            this.xPoseCheck.UseVisualStyleBackColor = true;
            this.xPoseCheck.CheckedChanged += new System.EventHandler(this.xPoseCheck_CheckedChanged);
            // 
            // xPlotAllCheck
            // 
            this.xPlotAllCheck.AutoSize = true;
            this.xPlotAllCheck.Location = new System.Drawing.Point(13, 37);
            this.xPlotAllCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xPlotAllCheck.Name = "xPlotAllCheck";
            this.xPlotAllCheck.Size = new System.Drawing.Size(145, 29);
            this.xPlotAllCheck.TabIndex = 0;
            this.xPlotAllCheck.Text = "Показать все";
            this.xPlotAllCheck.UseVisualStyleBackColor = true;
            this.xPlotAllCheck.CheckedChanged += new System.EventHandler(this.xPlotAllCheck_CheckedChanged);
            // 
            // yPlot
            // 
            this.yPlot.Location = new System.Drawing.Point(10, 515);
            this.yPlot.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.yPlot.Name = "yPlot";
            this.yPlot.Size = new System.Drawing.Size(1119, 500);
            this.yPlot.TabIndex = 1;
            // 
            // xyPlot
            // 
            this.xyPlot.Location = new System.Drawing.Point(1397, 20);
            this.xyPlot.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.xyPlot.Name = "xyPlot";
            this.xyPlot.Size = new System.Drawing.Size(800, 933);
            this.xyPlot.TabIndex = 3;
            // 
            // plotUpdateTim
            // 
            this.plotUpdateTim.Interval = 10;
            this.plotUpdateTim.Tick += new System.EventHandler(this.plotUpdateTim_Tick);
            // 
            // timeBar
            // 
            this.timeBar.Location = new System.Drawing.Point(1440, 917);
            this.timeBar.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.timeBar.Name = "timeBar";
            this.timeBar.Size = new System.Drawing.Size(757, 128);
            this.timeBar.TabIndex = 5;
            // 
            // Settings
            // 
            this.Settings.Controls.Add(this.simTimeStep);
            this.Settings.Controls.Add(this.label3);
            this.Settings.Controls.Add(this.label2);
            this.Settings.Controls.Add(this.integraMethod);
            this.Settings.Controls.Add(this.simEndTime);
            this.Settings.Controls.Add(this.label1);
            this.Settings.Location = new System.Drawing.Point(17, 1093);
            this.Settings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Settings.Name = "Settings";
            this.Settings.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Settings.Size = new System.Drawing.Size(863, 130);
            this.Settings.TabIndex = 7;
            this.Settings.TabStop = false;
            this.Settings.Text = "Simulation Settings";
            // 
            // simTimeStep
            // 
            this.simTimeStep.DecimalPlaces = 4;
            this.simTimeStep.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.simTimeStep.Location = new System.Drawing.Point(413, 53);
            this.simTimeStep.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.simTimeStep.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.simTimeStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.simTimeStep.Name = "simTimeStep";
            this.simTimeStep.Size = new System.Drawing.Size(110, 31);
            this.simTimeStep.TabIndex = 9;
            this.simTimeStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.simTimeStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(276, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Simulation Step";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(541, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Simulation Method";
            // 
            // integraMethod
            // 
            this.integraMethod.FormattingEnabled = true;
            this.integraMethod.Location = new System.Drawing.Point(706, 52);
            this.integraMethod.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.integraMethod.Name = "integraMethod";
            this.integraMethod.Size = new System.Drawing.Size(127, 33);
            this.integraMethod.TabIndex = 8;
            // 
            // simEndTime
            // 
            this.simEndTime.DecimalPlaces = 2;
            this.simEndTime.Location = new System.Drawing.Point(151, 53);
            this.simEndTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.simEndTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.simEndTime.Name = "simEndTime";
            this.simEndTime.Size = new System.Drawing.Size(110, 31);
            this.simEndTime.TabIndex = 7;
            this.simEndTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.simEndTime.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.simEndTime.ValueChanged += new System.EventHandler(this.simEndTime_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(10, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Simulation Time";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.confRange95);
            this.groupBox1.Controls.Add(this.confRange99);
            this.groupBox1.Controls.Add(this.noiseAmp);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(914, 1093);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(454, 130);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Model Settings";
            // 
            // confRange95
            // 
            this.confRange95.AutoSize = true;
            this.confRange95.Location = new System.Drawing.Point(281, 78);
            this.confRange95.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.confRange95.Name = "confRange95";
            this.confRange95.Size = new System.Drawing.Size(72, 29);
            this.confRange95.TabIndex = 13;
            this.confRange95.Text = "95%";
            this.confRange95.UseVisualStyleBackColor = true;
            this.confRange95.CheckedChanged += new System.EventHandler(this.confRange95_CheckedChanged);
            // 
            // confRange99
            // 
            this.confRange99.AutoSize = true;
            this.confRange99.Checked = true;
            this.confRange99.Location = new System.Drawing.Point(281, 37);
            this.confRange99.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.confRange99.Name = "confRange99";
            this.confRange99.Size = new System.Drawing.Size(86, 29);
            this.confRange99.TabIndex = 12;
            this.confRange99.TabStop = true;
            this.confRange99.Text = "99.5%";
            this.confRange99.UseVisualStyleBackColor = true;
            this.confRange99.CheckedChanged += new System.EventHandler(this.confRange99_CheckedChanged);
            // 
            // noiseAmp
            // 
            this.noiseAmp.DecimalPlaces = 4;
            this.noiseAmp.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.noiseAmp.Location = new System.Drawing.Point(111, 52);
            this.noiseAmp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.noiseAmp.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.noiseAmp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.noiseAmp.Name = "noiseAmp";
            this.noiseAmp.Size = new System.Drawing.Size(110, 31);
            this.noiseAmp.TabIndex = 11;
            this.noiseAmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.noiseAmp.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(11, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "NoiseAmp";
            // 
            // simulateBtn
            // 
            this.simulateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.simulateBtn.Location = new System.Drawing.Point(1467, 1107);
            this.simulateBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.simulateBtn.Name = "simulateBtn";
            this.simulateBtn.Size = new System.Drawing.Size(167, 117);
            this.simulateBtn.TabIndex = 9;
            this.simulateBtn.Text = "Simulate";
            this.simulateBtn.UseVisualStyleBackColor = false;
            this.simulateBtn.Click += new System.EventHandler(this.simulateBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2216, 1407);
            this.Controls.Add(this.simulateBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.xyPlot);
            this.Controls.Add(this.timeBar);
            this.Controls.Add(this.posePlotBox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.posePlotBox.ResumeLayout(false);
            this.posePlotBox.PerformLayout();
            this.yPlotParams.ResumeLayout(false);
            this.yPlotParams.PerformLayout();
            this.xPlotParams.ResumeLayout(false);
            this.xPlotParams.PerformLayout();
            this.Settings.ResumeLayout(false);
            this.Settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.simTimeStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simEndTime)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noiseAmp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ScottPlot.FormsPlot xPlot;
        private GroupBox posePlotBox;
        private ScottPlot.FormsPlot yPlot;
        private GroupBox xPlotParams;
        private CheckBox xPlotAllCheck;
        private GroupBox yPlotParams;
        private CheckBox yPoseConfCheck;
        private CheckBox yPoseMeanCheck;
        private CheckBox yPoseNoisyCheck;
        private CheckBox yVelCheck;
        private CheckBox yPoseCheck;
        private CheckBox yPlotAllCheck;
        private CheckBox xPoseConfCheck;
        private CheckBox xPoseMeanCheck;
        private CheckBox xPoseNoisyCheck;
        private CheckBox xVelCheck;
        private CheckBox xPoseCheck;
        private ScottPlot.FormsPlot xyPlot;
        private System.Windows.Forms.Timer plotUpdateTim;
        private ScottPlot.FormsPlot timeBar;
        private GroupBox Settings;
        private ComboBox integraMethod;
        private NumericUpDown simEndTime;
        private Label label1;
        private Label label2;
        private NumericUpDown simTimeStep;
        private Label label3;
        private GroupBox groupBox1;
        private RadioButton confRange95;
        private RadioButton confRange99;
        private NumericUpDown noiseAmp;
        private Label label4;
        private Button simulateBtn;
    }
}