namespace WinForms10.ScreenCaptureMode;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {
        SetScreenCaptureMode();
    }

    private void radioButton2_CheckedChanged(object sender, EventArgs e)
    {
        SetScreenCaptureMode();
    }

    private void radioButton3_CheckedChanged(object sender, EventArgs e)
    {
        SetScreenCaptureMode();
    }

    private void SetScreenCaptureMode()
    {
        if (radioButton1.Checked)
        {
            FormScreenCaptureMode = System.Windows.Forms.ScreenCaptureMode.Allow;
        }
        else if (radioButton2.Checked)
        {
            FormScreenCaptureMode = System.Windows.Forms.ScreenCaptureMode.HideContent;
        }
        else if (radioButton3.Checked)
        {
            FormScreenCaptureMode = System.Windows.Forms.ScreenCaptureMode.HideWindow;
        }
    }
}