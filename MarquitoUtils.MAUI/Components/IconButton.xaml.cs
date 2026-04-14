using MarquitoUtils.MAUI.Common.Enums;

namespace MarquitoUtils.MAUI.Components;

public partial class IconButton : Component
{
    public static readonly BindableProperty IconProperty = CreateProperty<Icon, IconComponent>(nameof(Icon));

    public Icon Icon
    {
        get => this.GetValue<Icon>(IconProperty);
        set => this.SetValue(IconProperty, value);
    }

    public static readonly BindableProperty IconValueProperty = CreateProperty<string, IconComponent>(nameof(IconValue));

    public string IconValue
    {
        get => this.GetValue<string>(IconValueProperty);
        private set => this.SetValue(IconValueProperty, value);
    }

    public static readonly BindableProperty IconColorProperty = CreateProperty<Color, IconComponent>(nameof(IconColor));

    public Color IconColor
    {
        get { return (Color)GetValue(IconColorProperty); }
        set { SetValue(IconColorProperty, value); }
    }

    public static readonly BindableProperty FontSizeProperty = CreateProperty<double, IconComponent>(nameof(FontSize));

    [System.ComponentModel.TypeConverter(typeof(FontSizeConverter))]
    public double FontSize
    {
        get { return (double)GetValue(FontSizeProperty); }
        set { SetValue(FontSizeProperty, value); }
    }

    /// <summary>
    /// Occurs when the button is clicked/tapped.
    /// </summary>
    public event EventHandler Clicked;

    public IconButton()
    {
        InitializeComponent();
    }

    protected override void OnComponentLoaded(object? sender, EventArgs e)
    {
        this.IconValue = this.Icon.GetIconUniCodeCharacter();
    }

    private void IconButton_Clicked(object sender, EventArgs e)
    {
        this.Clicked?.Invoke(this, e);
    }
}