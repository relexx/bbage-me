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
      this.components = new System.ComponentModel.Container();
      this.btnDoPaint = new System.Windows.Forms.Button();
      this.plTarget = new System.Windows.Forms.Panel();
      this.btnClear = new System.Windows.Forms.Button();
      this.tbFactor = new System.Windows.Forms.TrackBar();
      this.ttInfo = new System.Windows.Forms.ToolTip(this.components);
      this.btnFindPath = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.tbFactor)).BeginInit();
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
      // btnClear
      // 
      this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClear.Location = new System.Drawing.Point(474, 41);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(75, 23);
      this.btnClear.TabIndex = 0;
      this.btnClear.Text = "Clear";
      this.btnClear.UseVisualStyleBackColor = true;
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // tbFactor
      // 
      this.tbFactor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.tbFactor.Location = new System.Drawing.Point(474, 99);
      this.tbFactor.Maximum = 100;
      this.tbFactor.Minimum = 1;
      this.tbFactor.Name = "tbFactor";
      this.tbFactor.Size = new System.Drawing.Size(75, 42);
      this.tbFactor.SmallChange = 5;
      this.tbFactor.TabIndex = 2;
      this.tbFactor.TickFrequency = 5;
      this.tbFactor.Value = 10;
      this.tbFactor.Scroll += new System.EventHandler(this.tbFactor_Scroll);
      // 
      // btnFindPath
      // 
      this.btnFindPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFindPath.Location = new System.Drawing.Point(474, 70);
      this.btnFindPath.Name = "btnFindPath";
      this.btnFindPath.Size = new System.Drawing.Size(75, 23);
      this.btnFindPath.TabIndex = 0;
      this.btnFindPath.Text = "FindPath";
      this.btnFindPath.UseVisualStyleBackColor = true;
      this.btnFindPath.Click += new System.EventHandler(this.btnFindPath_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(561, 324);
      this.Controls.Add(this.tbFactor);
      this.Controls.Add(this.plTarget);
      this.Controls.Add(this.btnFindPath);
      this.Controls.Add(this.btnClear);
      this.Controls.Add(this.btnDoPaint);
      this.Name = "MainForm";
      this.Text = "Form1";
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
      this.Load += new System.EventHandler(this.MainForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.tbFactor)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnDoPaint;
    private System.Windows.Forms.Panel plTarget;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.TrackBar tbFactor;
    private System.Windows.Forms.ToolTip ttInfo;
    private System.Windows.Forms.Button btnFindPath;
  }
}

