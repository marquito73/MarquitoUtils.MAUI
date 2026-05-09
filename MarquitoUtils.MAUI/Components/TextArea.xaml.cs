namespace MarquitoUtils.MAUI.Components;

/// <summary>
/// Text area component
/// </summary>
public partial class TextArea : Component
{
    #region Label

    public static readonly BindableProperty LabelProperty = CreateProperty<string, TextArea>(nameof(Label), default(string));
    /// <summary>
    /// Label of the text area
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

    public static readonly BindableProperty ValueProperty = CreateProperty<string, TextArea>(nameof(Value),
        propertyChanged: (bindable, oldValue, newValue) => ((TextArea)bindable).OnTextChanged((string)oldValue, (string)newValue));
    /// <summary>
    /// Value of the text area
    /// </summary>
    public string Value
    {
        get => this.GetValue<string>(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    #endregion Value

    #region Placeholder

    public static readonly BindableProperty PlaceholderProperty = CreateProperty<string, TextArea>(nameof(Placeholder), default(string));
    /// <summary>
    /// Placeholder of the text area
    /// </summary>
    public string Placeholder
    {
        get => this.GetValue<string>(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    #endregion Placeholder

    #region Keyboard

    public static readonly BindableProperty KeyboardProperty = CreateProperty<Keyboard, TextArea>(nameof(Keyboard), Keyboard.Default,
        coerceValue: (o, v) => (Keyboard)v ?? Keyboard.Default);

    /// <summary>
    /// Keyboard type for the text area
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(Microsoft.Maui.Converters.KeyboardTypeConverter))]
    public Keyboard Keyboard
    {
        get => (Keyboard)GetValue(KeyboardProperty);
        set => SetValue(KeyboardProperty, value);
    }

    #endregion Keyboard

    #region Max length

    public static readonly BindableProperty MaxLengthProperty = CreateProperty<int, TextArea>(nameof(MaxLength), default(int));
    /// <summary>
    /// Max length of the text area
    /// </summary>
    public int MaxLength
    {
        get => this.GetValue<int>(MaxLengthProperty);
        set => SetValue(MaxLengthProperty, value);
    }

    #endregion Max length

    #region Height

    public static readonly BindableProperty HeightProperty = CreateProperty<double, TextArea>(nameof(Height), default(double));
    /// <summary>
    /// Max length of the text area
    /// </summary>
    public new double Height
    {
        get => this.GetValue<double>(HeightProperty);
        set => SetValue(HeightProperty, value);
    }

    #endregion Height

    /// <summary>
    /// Text area component constructor
    /// </summary>
    public TextArea()
    {
        InitializeComponent();
    }

    protected override void OnComponentLoaded(object? sender, EventArgs e)
    {
    }
}