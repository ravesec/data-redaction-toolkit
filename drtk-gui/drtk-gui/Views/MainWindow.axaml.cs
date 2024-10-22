using System;
using System.IO;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Platform.Storage;

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
        UpdateRedactButtonState();
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
        removeKeywordButton.Click += (_, _) => KeywordsPanel.Children.Remove(border);
        
        // Add the label and button to the keyword panel
        keywordGrid.Children.Add(label);
        Grid.SetColumn(label, 0);
        
        keywordGrid.Children.Add(removeKeywordButton);
        Grid.SetColumn(removeKeywordButton, 1);
        
        // Add the keyword panel to the main stack panel
        KeywordsPanel.Children.Add(border);
    }

    private async void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        var storageProvider = StorageProvider;
        
        var result = await storageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Select Files",
            AllowMultiple = true // Allow selecting multiple files
        });

        if (result.Count == 0)
            return;
        
        GetStartedLabel.IsVisible = false;
        FilesPanelScrollViewer.IsVisible = true;

        foreach (var file in result)
        {
            AddFileToStackPanel(file.Path.LocalPath);
        }
        
        UpdateRedactButtonState();
    }

    private readonly string[] _compatibleFileTypes = [".txt"];
    
    private void AddFileToStackPanel(string filePath)
    {
        var fileInfo = new FileInfo(filePath);
        var fileType = fileInfo.Extension.ToLower();
        var isCompatible = _compatibleFileTypes.Contains(fileType);

        var border = new Border
        {
            CornerRadius = new CornerRadius(10),
            BorderBrush = Brushes.Transparent,
            BorderThickness = new Thickness(0),
            Background = new SolidColorBrush(isCompatible ? Color.Parse("#3592c4") : Color.Parse("#ff8503")),
            Margin = new Thickness(5),
        };

        var fileGrid = new Grid
        {
            ColumnDefinitions = new ColumnDefinitions("*, Auto, Auto, Auto"),
            Margin = new Thickness(5)
        };

        if (!isCompatible)
        {
            ToolTip.SetTip(fileGrid, $"Unsupported file type: {fileType}");
        }
        
        // File path
        var filePathTextBlock = new TextBlock
        {
            Text = fileInfo.FullName,
            VerticalAlignment = VerticalAlignment.Center,
            Foreground = new SolidColorBrush(isCompatible ? Color.Parse("#ffffff") : Color.Parse("#000000")),
            Margin = new Thickness(5),
        };
        Grid.SetColumn(filePathTextBlock, 0);
        fileGrid.Children.Add(filePathTextBlock);
        
        // File size (kb)
        var fileSizeTextBlock = new TextBlock
        {
            Text = $"{fileInfo.Length / 1024} KB",
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Left,
            TextAlignment = TextAlignment.Left,
            Foreground = new SolidColorBrush(isCompatible ? Color.Parse("#ffffff") : Color.Parse("#000000")),
            Margin = new Thickness(5)
        };
        Grid.SetColumn(fileSizeTextBlock, 1);
        fileGrid.Children.Add(fileSizeTextBlock);
        
        // File type
        var fileTypeTextBlock = new TextBlock
        {
            Text = fileType,
            VerticalAlignment = VerticalAlignment.Center,
            Foreground = new SolidColorBrush(isCompatible ? Color.Parse("#ffffff") : Color.Parse("#000000")),
            Margin = new Thickness(5)
        };
        Grid.SetColumn(fileTypeTextBlock, 2);
        fileGrid.Children.Add(fileTypeTextBlock);
        
        // Removal button
        var removalButton = new Button
        {
            Content = new TextBlock
            {
                Text = "X",
                Foreground = new SolidColorBrush(isCompatible ? Color.Parse("#ffffff") : Color.Parse("#000000")),
                TextDecorations = TextDecorations.Underline,
                VerticalAlignment = VerticalAlignment.Center,
                FontWeight = FontWeight.Heavy
            },
            Background = Brushes.Transparent,
            BorderThickness = new Thickness(0),
            HorizontalAlignment = HorizontalAlignment.Right
        };
        removalButton.Click += (_, _) => FilesPanel.Children.Remove(border);
        Grid.SetColumn(removalButton, 3);
        fileGrid.Children.Add(removalButton);
        
        border.Child = fileGrid;
        
        // Add fileGrid to the files panel
        FilesPanel.Children.Add(border);
    }

    private void UpdateRedactButtonState()
    {
        var hasSupportedFile = FilesPanel.Children
            .OfType<Border>()
            .Select(border => border.Child as Grid)
            .Any(grid => grid?.Children[2] is TextBlock textBlock && _compatibleFileTypes.Contains(textBlock.Text));
        var hasKeyword = KeywordsPanel.Children.Count > 0;
        var hasCheckedPii = PIIPanel.Children
            .OfType<CheckBox>()
            .Any(checkbox => checkbox.IsChecked == true);
        
        RedactDataButton.IsEnabled = hasSupportedFile && (hasKeyword || hasCheckedPii);
    }

    private void ToggleButton_OnIsCheckedChanged(object? sender, RoutedEventArgs e)
    {
        UpdateRedactButtonState();
    }

    private void FilesPanel_OnLayoutUpdated(object? sender, EventArgs e)
    {
        UpdateRedactButtonState();
        var hasFiles = FilesPanel.Children.OfType<Border>().Any();
        GetStartedLabel.IsVisible = !hasFiles;
    }
}