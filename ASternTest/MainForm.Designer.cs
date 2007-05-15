namespace ASternTest
{
  partial class MainForm
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
      this.btnDoPaint = new System.Windows.Forms.Button();
      this.plTarget = new System.Windows.Forms.Panel();
      this.button1 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnDoPaint
      // 
      this.btnDoPaint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDoPaint.Location = new System.Drawing.Point(474, 12);
      this.btnDoPaint.Name = "btnDoPaint";
      this.btnDoPaint.Size = new System.Drawing.Size(75, 23);
      this.btnDoPaint.TabIndex = 0;
      this.btnDoPaint.Text = "DoPaint";
      this.btnDoPaint.UseVisualStyleBackColor = true;
      this.btnDoPaint.Click += new System.EventHandler(this.btnDoPaint_Click);
      // 
      // plTarget
      // 
      this.plTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.plTarget.Location = new System.Drawing.Point(12, 12);
      this.plTarget.Name = "plTarget";
      this.plTarget.Size = new System.Drawing.Size(456, 300);
      this.plTarget.TabIndex = 1;
      this.plTarget.MouseDown += new System.Windows.Forms.MouseEventHandler(this.plTarget_MouseDown);
      this.plTarget.Paint += new System.Windows.Forms.PaintEventHandler(this.plTarget_Paint);
      // 
      // button1
      // 
      this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.button1.Location = new System.Drawing.Point(474, 41);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 0;
      this.button1.Text = "Clear";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(561, 324);
      this.Controls.Add(this.plTarget);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.btnDoPaint);
      this.Name = "MainForm";
      this.Text = "Form1";
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnDoPaint;
    private System.Windows.Forms.Panel plTarget;
    private System.Windows.Forms.Button button1;
  }
}

