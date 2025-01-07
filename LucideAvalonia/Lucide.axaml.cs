using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using LucideAvalonia.Enum;

namespace LucideAvalonia;

public partial class Lucide : UserControl
{
    public Lucide()
    {
        InitializeComponent();
    }

    // Initialize components
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    // Property for setting the icon source
    public static readonly StyledProperty<object?> IconSourceProperty =
        AvaloniaProperty.Register<Lucide, object?>("IconSource");

    public object? IconSource
    {
        get => GetValue(IconSourceProperty);
        set => SetValue(IconSourceProperty, value);
    }

    // Property for setting the icon name
    public static readonly StyledProperty<LucideIconNames> IconProperty =
        AvaloniaProperty.Register<Lucide, LucideIconNames>("Icon");

    public LucideIconNames Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    // Property for setting the icon stroke brush
    public static readonly StyledProperty<IBrush?> StrokeBrushProperty =
        AvaloniaProperty.Register<Lucide, IBrush?>(
            nameof(StrokeBrush),
            defaultBindingMode: BindingMode.TwoWay);

    public IBrush? StrokeBrush
    {
        get => GetValue(StrokeBrushProperty);
        set => SetValue(StrokeBrushProperty, value);
    }

    // Define a dependency property for the stroke thickness
    private static readonly StyledProperty<double> StrokeThicknessProperty =
        AvaloniaProperty.Register<Lucide, double>("StrokeThickness");

    // Property to get or set the stroke thickness
    public double StrokeThickness
    {
        get => GetValue(StrokeThicknessProperty);
        set
        {
            SetValue(StrokeThicknessProperty, value);
            UpdateStrokeThickness();
        }
    }

    // Override the OnPropertyChanged method to handle property changes
    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        // Check which property has changed and call the appropriate update method
        if (change.Property == StrokeBrushProperty)
            UpdateStrokeBrush();
        else if (change.Property == StrokeThicknessProperty)
            UpdateStrokeThickness();
        else if (change.Property == IconProperty)
            UpdateIconSource();
    }

    // Method to update the stroke brush for the icon
    private void UpdateStrokeBrush()
    {
        if (IconSource is not DrawingImage { Drawing: DrawingGroup drawingGroup }) return;

        var strokeBrush = StrokeBrush;
        foreach (var drawing in drawingGroup.Children)
            if (drawing is GeometryDrawing { Pen: Pen pen })
                pen.Brush = strokeBrush;
    }

    // Method to update the stroke thickness for the icon
    private void UpdateStrokeThickness()
    {
        if (IconSource is not DrawingImage { Drawing: DrawingGroup drawingGroup }) return;

        foreach (var drawing in drawingGroup.Children)
            if (drawing is GeometryDrawing { Pen: Pen pen })
                pen.Thickness = StrokeThickness;
    }

    // Method to update the icon source based on the icon name
    private void UpdateIconSource()
    {
        // Retrieve the resource corresponding to the icon name if resources are defined
        var resource = Resources.MergedDictionaries.FirstOrDefault() as ResourceDictionary;
        IconSource = resource?[Icon.ToString()];
    }
}
