

using MarquitoUtils.MAUI.Components.Models;

namespace MarquitoUtils.MAUI.Components.Form;

/// <summary>
/// Drop down component
/// </summary>
public partial class DropDown : FormComponent
{
    #region Label

    public static readonly BindableProperty LabelProperty = CreateProperty<string, DropDown>(nameof(Label), default(string));
    /// <summary>
    /// Label of the Drop down
    /// </summary>
    public string Label
    {
        get => this.GetValue<string>(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    #endregion Label

    #region Item source

    public static readonly BindableProperty ItemsSourceProperty = CreateProperty<List<DropDownItemModel>, DropDown>(nameof(ItemsSource), default(List<DropDownItemModel>));

    /// <summary>
    /// Item source of the Drop down
    /// </summary>
    public List<DropDownItemModel> ItemsSource
    {
        get => this.GetValue<List<DropDownItemModel>>(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    #endregion Item source

    #region Selected item

    public static readonly BindableProperty SelectedItemProperty = CreateProperty<DropDownItemModel, DropDown>(nameof(SelectedItem), default(DropDownItemModel));

    /// <summary>
    /// Item source of the Drop down
    /// </summary>
    public DropDownItemModel SelectedItem
    {
        get => this.GetValue<DropDownItemModel>(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }

    #endregion Selected item

    /// <summary>
    /// Drop down component constructor
    /// </summary>
    public DropDown()
    {
        InitializeComponent();
    }

    protected override void OnComponentLoaded(object? sender, EventArgs e)
    {
    }
}