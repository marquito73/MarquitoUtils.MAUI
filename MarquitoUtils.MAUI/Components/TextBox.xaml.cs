namespace MarquitoUtils.MAUI.Components;

/// <summary>
/// Text box component
/// </summary>
public partial class TextBox : Component
{
    #region Label

    public static readonly BindableProperty LabelProperty = CreateProperty<string, TextBox>(nameof(Label), default(string));
    /// <summary>
    /// Label of the text box
    /// </summary>
    public string Label
    {
        get => this.GetValue<string>(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    #endregion Label

    #region Value

    public event EventHandler<TextChangedEventArgs> ValueChanged;

    protected virtual void OnTextChanged(string oldValue, string newValue)
    {
        this.ValueChanged?.Invoke(this, new TextChangedEventArgs(oldValue, newValue));
    }

    public static readonly BindableProperty ValueProperty = CreateProperty<string, TextBox>(nameof(Value),
        propertyChanged: (bindable, oldValue, newValue) => ((TextBox)bindable).OnTextChanged((string)oldValue, (string)newValue));
    /// <summary>
    /// Value of the text box
    /// </summary>
    public string Value
    {
        get => this.GetValue<string>(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    #endregion Value

    #region Placeholder

    public static readonly BindableProperty PlaceholderProperty = CreateProperty<string, TextBox>(nameof(Placeholder), default(string));
    /// <summary>
    /// Placeholder of the text box
    /// </summary>
    public string Placeholder
    {
        get => this.GetValue<string>(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    #endregion Placeholder

    #region Keyboard

    public static readonly BindableProperty KeyboardProperty = CreateProperty<Keyboard, TextBox>(nameof(Keyboard), Keyboard.Default,
        coerceValue: (o, v) => (Keyboard)v ?? Keyboard.Default);

    /// <summary>
    /// Keyboard type for the text box
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(Microsoft.Maui.Converters.KeyboardTypeConverter))]
    public Keyboard Keyboard
    {
        get => (Keyboard)GetValue(KeyboardProperty);
        set => SetValue(KeyboardProperty, value);
    }

    #endregion Keyboard

    public TextBox()
    {
        InitializeComponent();
    }

    protected override void OnComponentLoaded(object? sender, EventArgs e)
    {
    }
}