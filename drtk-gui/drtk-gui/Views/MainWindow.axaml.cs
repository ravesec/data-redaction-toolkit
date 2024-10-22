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
        if (e.Key == Key.Space || e.Key == Key.Enter)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                var text = textBox.Text.TrimEnd();
                var words = text.Split(' ');

                if (words.Length > 0)
                {
                    string lastWord = words[^1];
                    Console.WriteLine(lastWord); // Print the last word
                    textBox.Text = string.Join(' ', words[..^1]); // Remove the last word
                }
            }
            e.Handled = true; // Mark the event as handled
        }
    }
}