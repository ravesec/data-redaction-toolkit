using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;

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
            if (text is { Length: > 0 })
            {
                var words = text.Split(' ');

                if (words.Length > 0)
                {
                    var lastWord = words[^1].ToLower();
                    
                    // Check if the word already exists in the stack panel
                    if (!IsWordAlreadyAdded(lastWord))
                    {
                        AddWordToStackPanel(lastWord);
                    }
                    
                    textBox.Text = string.Join(' ', words[..^1]); // Remove the last word
                }
            }
        }
        e.Handled = true; // Mark the event as handled
    }

    private bool IsWordAlreadyAdded(string word)
    {
        foreach (var child in KeywordsPanel.Children)
        {
            if (child is not Border { Child: Grid grid })
                continue;
            
            if (grid.Children[0] is TextBlock textBlock && textBlock.Text == word)
            {
                return true;
            }
        }
        return false;
    }

    private void AddWordToStackPanel(string word)
    {
        // Create grid to hold the keyword label and it's button
        var keywordGrid = new Grid
        {
            Margin = new Thickness(5,0,5,0),
            ColumnDefinitions = new ColumnDefinitions("*, Auto")
        };
        
        // Create a border around the stack panel
        var border = new Border
        {
            BorderThickness = new Thickness(0),
            Background = new SolidColorBrush(Color.Parse("#2c313a")),
            Child = keywordGrid,
            CornerRadius = new CornerRadius(5),
            Margin = new Thickness(5),
        };
        
        // Create a label for the keyword
        var label = new TextBlock
        {
            Text = word,
            VerticalAlignment = VerticalAlignment.Center,
            Margin = new Thickness(0, 0, 0, 0)
        };
        
        // Create the button for removing the keyword
        var removeKeywordButton = new Button
        {
            Content = new TextBlock
            {
                Text = "X",
                Foreground = new SolidColorBrush(Color.Parse("#d65347")),
                TextDecorations = TextDecorations.Underline,
                VerticalAlignment = VerticalAlignment.Center,
            },
            Background = Brushes.Transparent,
            BorderThickness = new Thickness(0),
            HorizontalAlignment = HorizontalAlignment.Right
        };
        removeKeywordButton.Click += (s, e) => KeywordsPanel.Children.Remove(border);
        
        // Add the label and button to the keyword panel
        keywordGrid.Children.Add(label);
        Grid.SetColumn(label, 0);
        
        keywordGrid.Children.Add(removeKeywordButton);
        Grid.SetColumn(removeKeywordButton, 1);
        
        // Add the keyword panel to the main stack panel
        KeywordsPanel.Children.Add(border);
    }
}