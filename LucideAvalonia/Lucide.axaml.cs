using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using LucideAvalonia.Enum;

namespace LucideAvalonia
{
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
        private static readonly StyledProperty<object?> IconSourceProperty = AvaloniaProperty.Register<Lucide, object?>(
            "IconSource");

        public object? IconSource
        {
            get => GetValue(IconSourceProperty);
            set => SetValue(IconSourceProperty, value);
        }

        // Property for setting the icon name
        public static readonly StyledProperty<LucideIconNames> IconProperty = AvaloniaProperty.Register<Lucide, LucideIconNames>(
            "Icon");

        public LucideIconNames Icon
        {
            get => GetValue(IconProperty);
            set
            {
                SetValue(IconProperty, value);
                // If resources are defined, retrieve the resource corresponding to the icon name
                var resource = Resources.MergedDictionaries.FirstOrDefault() as ResourceDictionary;
                IconSource = resource?[Icon.ToString()];
            }
        }

        // Property for setting the icon stroke brush
        public IBrush? StrokeBrush
        {
            get => GetValue(BorderBrushProperty);
            set
            {
                SetValue(BorderBrushProperty, value);
                // Modify the color of all GeometryDrawing in the icon source
                if (IconSource is not DrawingImage { Drawing: DrawingGroup drawingGroup }) return;
                foreach (var drawing in drawingGroup.Children)
                {
                    if (drawing is GeometryDrawing { Pen: Pen pen })
                    {
                        pen.Brush = value;
                    }
                }
            }
        }

        // Property for setting the icon stroke thickness
        public static readonly StyledProperty<double> StrokeThicknessProperty = AvaloniaProperty.Register<Lucide, double>(
            "StrokeThickness");

        public double StrokeThickness
        {
            get => GetValue(StrokeThicknessProperty);
            set
            {
                SetValue(StrokeThicknessProperty, value);
                // Modify the stroke thickness of all GeometryDrawing in the icon source
                if (IconSource is not DrawingImage { Drawing: DrawingGroup drawingGroup }) return;
                foreach (var drawing in drawingGroup.Children)
                {
                    if (drawing is GeometryDrawing { Pen: Pen pen })
                    {
                        pen.Thickness = value;
                    }
                }
            }
        }
    }
}