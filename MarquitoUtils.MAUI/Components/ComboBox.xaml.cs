

using MarquitoUtils.MAUI.Components.Models;

namespace MarquitoUtils.MAUI.Components;

/// <summary>
/// Combo box component
/// </summary>
public partial class ComboBox : Component
{
    #region Label

    public static readonly BindableProperty LabelProperty = CreateProperty<string, ComboBox>(nameof(Label), default(string));
    /// <summary>
    /// Label of the combo box
    /// </summary>
    public string Label
    {
        get => this.GetValue<string>(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    #endregion Label

    #region Item source

    public static readonly BindableProperty ItemsSourceProperty = CreateProperty<List<ComboItemModel>, ComboBox>(nameof(ItemsSource), default(List<ComboItemModel>));

    /// <summary>
    /// Item source of the combo box
    /// </summary>
    public List<ComboItemModel> ItemsSource
    {
        get => this.GetValue<List<ComboItemModel>>(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    #endregion Item source

    #region Selected item

    public static readonly BindableProperty SelectedItemProperty = CreateProperty<ComboItemModel, ComboBox>(nameof(SelectedItem), default(ComboItemModel));

    /// <summary>
    /// Item source of the combo box
    /// </summary>
    public ComboItemModel SelectedItem
    {
        get => this.GetValue<ComboItemModel>(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }

    #endregion Selected item

    /// <summary>
    /// Combo box component constructor
    /// </summary>
    public ComboBox()
    {
        InitializeComponent();
    }

    protected override void OnComponentLoaded(object? sender, EventArgs e)
    {
    }
}