using Avalonia.Controls;

namespace CipherChallenge.Views;

public partial class MainWindow : Window
{
    private static double fontSize;
    public static new double FontSize { get => fontSize; }
    public MainWindow()
    {
        fontSize = base.FontSize;
        InitializeComponent();
    }
}