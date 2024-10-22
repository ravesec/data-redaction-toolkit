using System;
using Avalonia.Controls;
using Avalonia.Input;

namespace drtk_gui.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void InputElement_OnKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key != Key.Space && e.Key != Key.Enter)
            return;

        if (sender is TextBox textBox)
        {
            var text = textBox.Text?.TrimEnd();
            if (text != null)
            {
                var words = text.Split(' ');

                if (words.Length > 0)
                {
                    var lastWord = words[^1];
                    Console.WriteLine(lastWord); // Print the last word
                    textBox.Text = string.Join(' ', words[..^1]); // Remove the last word
                }
            }
        }
        e.Handled = true; // Mark the event as handled
    }
}