namespace MarquitoUtils.MAUI.Components;

/// <summary>
/// Color picker component
/// </summary>
public partial class ColorPicker : Component
{
    #region Label

    public static readonly BindableProperty LabelProperty = CreateProperty<string, ColorPicker>(nameof(Label), default(string));
    /// <summary>
    /// Label of the color picker
    /// </summary>
    public string Label
    {
        get => this.GetValue<string>(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    #endregion Label

    #region Background color

    public static readonly BindableProperty PickerBackgroundColorProperty = CreateProperty<Color, ColorPicker>(nameof(PickerBackgroundColor));
    /// <summary>
    /// Background color
    /// </summary>
    public Color PickerBackgroundColor
    {
        get => this.GetValue<Color>(PickerBackgroundColorProperty);
        set => SetValue(PickerBackgroundColorProperty, value);
    }

    #endregion Background color

    #region Selected color

    public static readonly BindableProperty PickerSelectedColorProperty = CreateProperty<Color, ColorPicker>(nameof(PickerSelectedColor));
    /// <summary>
    /// Selected color
    /// </summary>
    public Color PickerSelectedColor
    {
        get => this.GetValue<Color>(PickerSelectedColorProperty);
        set => SetValue(PickerSelectedColorProperty, value);
    }

    #endregion Selected color

    /// <summary>
    /// Initialize color picker component
    /// </summary>
    public ColorPicker()
    {
        InitializeComponent();
    }

    protected override void OnComponentLoaded(object? sender, EventArgs e)
    {
    }
}