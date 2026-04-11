using MarquitoUtils.MAUI.Common.Enums;

namespace MarquitoUtils.MAUI.Components;

public partial class IconComponent : Component
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

    /*public static readonly BindableProperty TextColorProperty =
        BindableProperty.Create(nameof(ITextElement.TextColor), typeof(Color), typeof(ITextElement), null,
                                propertyChanged: OnTextColorPropertyChanged);*/
    public static readonly BindableProperty TextColorProperty = CreateProperty<Color, IconComponent>(nameof(TextColor));

    public Color TextColor
    {
        get { return (Color)GetValue(TextColorProperty); }
        set { SetValue(TextColorProperty, value); }
    }

    public static readonly BindableProperty FontSizeProperty = CreateProperty<double, IconComponent>(nameof(FontSize));

    [System.ComponentModel.TypeConverter(typeof(FontSizeConverter))]
    public double FontSize
    {
        get { return (double)GetValue(FontSizeProperty); }
        set { SetValue(FontSizeProperty, value); }
    }

    public IconComponent()
    {
        InitializeComponent();
    }

    protected override void OnComponentLoaded(object? sender, EventArgs e)
    {
        this.IconValue = this.Icon.GetIconUniCodeCharacter();
    }
}