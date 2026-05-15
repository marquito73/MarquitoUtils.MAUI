namespace MarquitoUtils.MAUI.Components.Form;

/// <summary>
/// Date picker component
/// </summary>
public partial class DatePicker : FormComponent
{
    #region Label

    public static readonly BindableProperty LabelProperty = CreateProperty<string, TextBox>(nameof(Label), default(string));
    /// <summary>
    /// Label of the date picker
    /// </summary>
    public string Label
    {
        get => this.GetValue<string>(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    #endregion Label

    #region Date

    public static readonly BindableProperty DateProperty = CreateProperty<DateTime, DatePicker>(nameof(Date));
    /// <summary>
    /// Value of the date picker
    /// </summary>
    public DateTime Date
    {
        get => this.GetValue<DateTime>(DateProperty);
        set => SetValue(DateProperty, value);
    }

    #endregion Date

    public DatePicker()
    {
        InitializeComponent();
    }

    protected override void OnComponentLoaded(object? sender, EventArgs e)
    {
    }
}