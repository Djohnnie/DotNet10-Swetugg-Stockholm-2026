namespace WinForms10.AsyncForms;

public partial class Form1 : Form
{
    private int _counter = 0;

    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var modal = new ModalForm();
        modal.ShowDialog(this);
        MessageBox.Show("Modal closed");
    }

    private async void button2_Click(object sender, EventArgs e)
    {
        var modal = new ModalForm();
        await modal.ShowDialogAsync(this);
        MessageBox.Show("Modal closed");
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        _counter++;

        Invoke(() =>
        {
            label1.Text = $"Counter: {_counter}";
        });
    }
}