using System.Windows;

namespace Wpf10.NewMessageBoxButtons;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button1_Click(object sender, RoutedEventArgs e)
    {
        ShowMessageBox("'OK' buttons", MessageBoxButton.OK);
    }

    private void Button2_Click(object sender, RoutedEventArgs e)
    {
        ShowMessageBox("'OKCancel' buttons", MessageBoxButton.OKCancel);
    }

    private void Button3_Click(object sender, RoutedEventArgs e)
    {
        ShowMessageBox("'AbortRetryIgnore' buttons", MessageBoxButton.AbortRetryIgnore);
    }

    private void Button4_Click(object sender, RoutedEventArgs e)
    {
        ShowMessageBox("'YesNoCancel' buttons", MessageBoxButton.YesNoCancel);
    }

    private void Button5_Click(object sender, RoutedEventArgs e)
    {
        ShowMessageBox("'YesNo' buttons", MessageBoxButton.YesNo);
    }

    private void Button6_Click(object sender, RoutedEventArgs e)
    {
        ShowMessageBox("'RetryCancel' buttons", MessageBoxButton.RetryCancel);
    }

    private void Button7_Click(object sender, RoutedEventArgs e)
    {
        ShowMessageBox("'CancelTryContinue' buttons", MessageBoxButton.CancelTryContinue);
    }

    private void ShowMessageBox(string description, MessageBoxButton buttons)
    {
        var result = MessageBox.Show(description, "MessageBox buttons", buttons);
        resultTextBlock.Text = $"MessageBoxResult: {result}";
    }
}