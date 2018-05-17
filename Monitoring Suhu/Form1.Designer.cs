namespace Monitoring_Suhu
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.detak = new System.Windows.Forms.Timer(this.components);
            this.zedGraphSuhu = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(12, 263);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 1;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(121, 263);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 23);
            this.btn_stop.TabIndex = 2;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // detak
            // 
            this.detak.Tick += new System.EventHandler(this.detak_Tick);
            // 
            // zedGraphSuhu
            // 
            this.zedGraphSuhu.Location = new System.Drawing.Point(12, 35);
            this.zedGraphSuhu.Name = "zedGraphSuhu";
            this.zedGraphSuhu.ScrollGrace = 0D;
            this.zedGraphSuhu.ScrollMaxX = 0D;
            this.zedGraphSuhu.ScrollMaxY = 0D;
            this.zedGraphSuhu.ScrollMaxY2 = 0D;
            this.zedGraphSuhu.ScrollMinX = 0D;
            this.zedGraphSuhu.ScrollMinY = 0D;
            this.zedGraphSuhu.ScrollMinY2 = 0D;
            this.zedGraphSuhu.Size = new System.Drawing.Size(268, 222);
            this.zedGraphSuhu.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 349);
            this.Controls.Add(this.zedGraphSuhu);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Timer detak;
        private ZedGraph.ZedGraphControl zedGraphSuhu;
    }
}

