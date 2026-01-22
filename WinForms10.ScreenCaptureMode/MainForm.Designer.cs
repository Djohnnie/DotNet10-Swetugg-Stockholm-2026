namespace WinForms10.ScreenCaptureMode;

partial class MainForm
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
        button1 = new Button();
        textBox1 = new TextBox();
        textBox2 = new TextBox();
        radioButton1 = new RadioButton();
        radioButton2 = new RadioButton();
        radioButton3 = new RadioButton();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new Point(288, 166);
        button1.Name = "button1";
        button1.Size = new Size(112, 34);
        button1.TabIndex = 0;
        button1.Text = "Do stuff!";
        button1.UseVisualStyleBackColor = true;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(65, 49);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(335, 31);
        textBox1.TabIndex = 1;
        textBox1.Text = "Johnny";
        // 
        // textBox2
        // 
        textBox2.Location = new Point(65, 86);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(335, 31);
        textBox2.TabIndex = 2;
        textBox2.Text = "Hooyberghs";
        // 
        // radioButton1
        // 
        radioButton1.AutoSize = true;
        radioButton1.Checked = true;
        radioButton1.Location = new Point(65, 166);
        radioButton1.Name = "radioButton1";
        radioButton1.Size = new Size(81, 29);
        radioButton1.TabIndex = 3;
        radioButton1.TabStop = true;
        radioButton1.Text = "Allow";
        radioButton1.UseVisualStyleBackColor = true;
        radioButton1.CheckedChanged += radioButton1_CheckedChanged;
        // 
        // radioButton2
        // 
        radioButton2.AutoSize = true;
        radioButton2.Location = new Point(65, 201);
        radioButton2.Name = "radioButton2";
        radioButton2.Size = new Size(137, 29);
        radioButton2.TabIndex = 4;
        radioButton2.Text = "HideContent";
        radioButton2.UseVisualStyleBackColor = true;
        radioButton2.CheckedChanged += radioButton2_CheckedChanged;
        // 
        // radioButton3
        // 
        radioButton3.AutoSize = true;
        radioButton3.Location = new Point(65, 236);
        radioButton3.Name = "radioButton3";
        radioButton3.Size = new Size(140, 29);
        radioButton3.TabIndex = 5;
        radioButton3.Text = "HideWindow";
        radioButton3.UseVisualStyleBackColor = true;
        radioButton3.CheckedChanged += radioButton3_CheckedChanged;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(801, 450);
        Controls.Add(radioButton3);
        Controls.Add(radioButton2);
        Controls.Add(radioButton1);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(button1);
        Name = "MainForm";
        Text = "MainForm";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button button1;
    private TextBox textBox1;
    private TextBox textBox2;
    private RadioButton radioButton1;
    private RadioButton radioButton2;
    private RadioButton radioButton3;
}