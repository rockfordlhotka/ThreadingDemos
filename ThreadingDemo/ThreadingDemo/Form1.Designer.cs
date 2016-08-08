namespace ThreadingDemo
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
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
      this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
      this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
      this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
      this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
      this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // textBox1
      // 
      this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.textBox1.Location = new System.Drawing.Point(0, 28);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.textBox1.Size = new System.Drawing.Size(568, 480);
      this.textBox1.TabIndex = 0;
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(568, 25);
      this.toolStrip1.TabIndex = 1;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // toolStripButton1
      // 
      this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
      this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButton1.Name = "toolStripButton1";
      this.toolStripButton1.Size = new System.Drawing.Size(80, 22);
      this.toolStripButton1.Text = "SingleThread";
      this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
      // 
      // toolStripButton2
      // 
      this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
      this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButton2.Name = "toolStripButton2";
      this.toolStripButton2.Size = new System.Drawing.Size(76, 22);
      this.toolStripButton2.Text = "TwoThreads";
      this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
      // 
      // toolStripButton3
      // 
      this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
      this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButton3.Name = "toolStripButton3";
      this.toolStripButton3.Size = new System.Drawing.Size(77, 22);
      this.toolStripButton3.Text = "FourThreads";
      this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
      // 
      // toolStripButton4
      // 
      this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
      this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButton4.Name = "toolStripButton4";
      this.toolStripButton4.Size = new System.Drawing.Size(72, 22);
      this.toolStripButton4.Text = "ThreadPool";
      this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
      // 
      // toolStripButton5
      // 
      this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
      this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButton5.Name = "toolStripButton5";
      this.toolStripButton5.Size = new System.Drawing.Size(75, 22);
      this.toolStripButton5.Text = "Background";
      this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
      // 
      // toolStripButton6
      // 
      this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
      this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButton6.Name = "toolStripButton6";
      this.toolStripButton6.Size = new System.Drawing.Size(31, 22);
      this.toolStripButton6.Text = "TPL";
      this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(568, 508);
      this.Controls.Add(this.toolStrip1);
      this.Controls.Add(this.textBox1);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(6);
      this.Name = "Form1";
      this.Text = "Threading Demo";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton toolStripButton1;
    private System.Windows.Forms.ToolStripButton toolStripButton2;
    private System.Windows.Forms.ToolStripButton toolStripButton3;
    private System.Windows.Forms.ToolStripButton toolStripButton4;
    private System.Windows.Forms.ToolStripButton toolStripButton5;
    private System.Windows.Forms.ToolStripButton toolStripButton6;
  }
}

