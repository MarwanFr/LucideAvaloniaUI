using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using LucideAvalonia;
using LucideAvalonia.Enum;

namespace TestApp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        BuildIconGrid();
    }

    private void BuildIconGrid()
    {
        var root = new StackPanel { Margin = new Avalonia.Thickness(24), Spacing = 24 };

        // OLD ICONS — these exist in the original repo
        var oldIcons = new (LucideIconNames icon, string color)[]
        {
            (LucideIconNames.ArrowUp, "#cdd6f4"),
            (LucideIconNames.Heart, "#f38ba8"),
            (LucideIconNames.Star, "#f9e2af"),
            (LucideIconNames.Search, "#cdd6f4"),
            (LucideIconNames.Settings, "#cdd6f4"),
            (LucideIconNames.House, "#cdd6f4"),
            (LucideIconNames.Sun, "#f9e2af"),
            (LucideIconNames.Moon, "#89b4fa"),
            (LucideIconNames.Trash2, "#f38ba8"),
            (LucideIconNames.Youtube, "#f38ba8"),
            (LucideIconNames.Camera, "#cdd6f4"),
            (LucideIconNames.Music, "#a6e3a1"),
            (LucideIconNames.Zap, "#f9e2af"),
            (LucideIconNames.Wifi, "#89b4fa"),
            (LucideIconNames.Globe, "#89dceb"),
            (LucideIconNames.Dice3, "#cdd6f4"),
        };

        // NEW ICONS — only in v0.577.0, will be missing with old library
        var newIcons = new (LucideIconNames icon, string color)[]
        {
            (LucideIconNames.Balloon, "#f38ba8"),
            (LucideIconNames.ChessKing, "#cdd6f4"),
            (LucideIconNames.ChessQueen, "#cba6f7"),
            (LucideIconNames.ChessKnight, "#89b4fa"),
            (LucideIconNames.ChessRook, "#f9e2af"),
            (LucideIconNames.Drone, "#a6e3a1"),
            (LucideIconNames.Helicopter, "#89dceb"),
            (LucideIconNames.Panda, "#cdd6f4"),
            (LucideIconNames.Shrimp, "#fab387"),
            (LucideIconNames.Volleyball, "#f9e2af"),
            (LucideIconNames.Motorbike, "#f38ba8"),
            (LucideIconNames.SolarPanel, "#a6e3a1"),
            (LucideIconNames.Turntable, "#cba6f7"),
            (LucideIconNames.Gpu, "#89b4fa"),
            (LucideIconNames.BowArrow, "#fab387"),
            (LucideIconNames.Rose, "#f38ba8"),
            (LucideIconNames.Scooter, "#89dceb"),
            (LucideIconNames.Spotlight, "#f9e2af"),
            (LucideIconNames.Metronome, "#a6e3a1"),
            (LucideIconNames.Kayak, "#89b4fa"),
        };

        root.Children.Add(MakeHeader("OLD ICONS (should work with both old and new library)", "#a6adc8"));
        root.Children.Add(MakeIconRow(oldIcons));

        root.Children.Add(new Border { Height = 1, Background = new SolidColorBrush(Color.Parse("#313244")) });

        root.Children.Add(MakeHeader("NEW ICONS (v0.577.0 — will be missing with old library)", "#a6e3a1"));
        root.Children.Add(MakeIconRow(newIcons));

        Scroller.Content = root;
    }

    private static TextBlock MakeHeader(string text, string color) =>
        new()
        {
            Text = text,
            Foreground = new SolidColorBrush(Color.Parse(color)),
            FontSize = 16,
            FontWeight = FontWeight.Bold,
        };

    private static WrapPanel MakeIconRow((LucideIconNames icon, string color)[] icons)
    {
        var panel = new WrapPanel();
        foreach (var (icon, color) in icons)
        {
            var lucide = new Lucide
            {
                Icon = icon,
                StrokeBrush = new SolidColorBrush(Color.Parse(color)),
                Width = 32,
                Height = 32,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            var label = new TextBlock
            {
                Text = icon.ToString(),
                Foreground = new SolidColorBrush(Color.Parse("#6c7086")),
                FontSize = 10,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            var stack = new StackPanel
            {
                Margin = new Avalonia.Thickness(8),
                Spacing = 4,
                Width = 90,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            stack.Children.Add(lucide);
            stack.Children.Add(label);
            panel.Children.Add(stack);
        }
        return panel;
    }
}
