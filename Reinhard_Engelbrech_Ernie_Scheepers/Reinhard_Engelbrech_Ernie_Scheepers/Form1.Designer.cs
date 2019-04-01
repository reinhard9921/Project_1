namespace Reinhard_Engelbrech_Ernie_Scheepers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnStart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnF16 = new System.Windows.Forms.Button();
            this.btn747 = new System.Windows.Forms.Button();
            this.btnBomber = new System.Windows.Forms.Button();
            this.pbStealthBomber = new System.Windows.Forms.PictureBox();
            this.pbF16 = new System.Windows.Forms.PictureBox();
            this.pb747 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStealthBomber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbF16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb747)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(1193, 518);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(181, 66);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start Simulation";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1098, 595);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(194, 33);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(65, 62);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // btnF16
            // 
            this.btnF16.Location = new System.Drawing.Point(1193, 386);
            this.btnF16.Name = "btnF16";
            this.btnF16.Size = new System.Drawing.Size(75, 23);
            this.btnF16.TabIndex = 3;
            this.btnF16.Text = "F16";
            this.btnF16.UseVisualStyleBackColor = true;
            this.btnF16.Click += new System.EventHandler(this.btnF16_Click);
            // 
            // btn747
            // 
            this.btn747.Location = new System.Drawing.Point(1193, 434);
            this.btn747.Name = "btn747";
            this.btn747.Size = new System.Drawing.Size(75, 23);
            this.btn747.TabIndex = 4;
            this.btn747.Text = "747";
            this.btn747.UseVisualStyleBackColor = true;
            this.btn747.Click += new System.EventHandler(this.btn747_Click);
            // 
            // btnBomber
            // 
            this.btnBomber.Location = new System.Drawing.Point(1193, 476);
            this.btnBomber.Name = "btnBomber";
            this.btnBomber.Size = new System.Drawing.Size(75, 23);
            this.btnBomber.TabIndex = 5;
            this.btnBomber.Text = "Bomber";
            this.btnBomber.UseVisualStyleBackColor = true;
            this.btnBomber.Click += new System.EventHandler(this.btnBomber_Click);
            // 
            // pbStealthBomber
            // 
            this.pbStealthBomber.BackColor = System.Drawing.Color.White;
            this.pbStealthBomber.Image = ((System.Drawing.Image)(resources.GetObject("pbStealthBomber.Image")));
            this.pbStealthBomber.Location = new System.Drawing.Point(1009, 492);
            this.pbStealthBomber.Name = "pbStealthBomber";
            this.pbStealthBomber.Size = new System.Drawing.Size(105, 75);
            this.pbStealthBomber.TabIndex = 6;
            this.pbStealthBomber.TabStop = false;
            this.pbStealthBomber.Click += new System.EventHandler(this.pbStealthBomber_Click);
            // 
            // pbF16
            // 
            this.pbF16.BackColor = System.Drawing.Color.White;
            this.pbF16.Image = ((System.Drawing.Image)(resources.GetObject("pbF16.Image")));
            this.pbF16.Location = new System.Drawing.Point(1009, 492);
            this.pbF16.Name = "pbF16";
            this.pbF16.Size = new System.Drawing.Size(105, 75);
            this.pbF16.TabIndex = 7;
            this.pbF16.TabStop = false;
            // 
            // pb747
            // 
            this.pb747.BackColor = System.Drawing.Color.White;
            this.pb747.Image = ((System.Drawing.Image)(resources.GetObject("pb747.Image")));
            this.pb747.Location = new System.Drawing.Point(1009, 492);
            this.pb747.Name = "pb747";
            this.pb747.Size = new System.Drawing.Size(105, 75);
            this.pb747.TabIndex = 8;
            this.pb747.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 590);
            this.Controls.Add(this.pb747);
            this.Controls.Add(this.pbF16);
            this.Controls.Add(this.pbStealthBomber);
            this.Controls.Add(this.btnBomber);
            this.Controls.Add(this.btn747);
            this.Controls.Add(this.btnF16);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnStart);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStealthBomber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbF16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb747)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnF16;
        private System.Windows.Forms.Button btn747;
        private System.Windows.Forms.Button btnBomber;
        private System.Windows.Forms.PictureBox pbStealthBomber;
        private System.Windows.Forms.PictureBox pbF16;
        private System.Windows.Forms.PictureBox pb747;
    }
}

