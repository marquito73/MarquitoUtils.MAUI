namespace MarquitoUtils.MAUI.Components;

/// <summary>
/// Text box component
/// </summary>
public partial class TextBox : Component
{
    #region Label

    public static readonly BindableProperty LabelProperty = BindableProperty.Create(nameof(Label), typeof(string), typeof(TextBox), default(string));
    /// <summary>
    /// Label of the text box
    /// </summary>
    public string Label
    {
        get => this.GetValue<string>(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    public event EventHandler<TextChangedEventArgs> ValueChanged;

    #endregion Label

    #region Value

    protected virtual void OnTextChanged(string oldValue, string newValue)
    {
        ValueChanged?.Invoke(this, new TextChangedEventArgs(oldValue, newValue));
    }

    public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), typeof(string), typeof(TextBox), defaultBindingMode: BindingMode.TwoWay,
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

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(TextBox), default(string));
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

    public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(InputView), Keyboard.Default,
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
}