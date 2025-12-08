using MarquitoUtils.Main.Translate.Services;

namespace MarquitoUtils.MAUI.Views;

/// <summary>
/// View for display an error message
/// </summary>
public partial class ErrorView : DefaultView
{
    /// <summary>
    /// The error to display
    /// </summary>
    public Exception Error { get; set; }

    /// <summary>
    /// View for display an error message
    /// </summary>
    /// <param name="serviceProvider">Service provider</param>
    /// <param name="translateService">Service for translates fields</param>
    public ErrorView(IServiceProvider serviceProvider, ITranslateService translateService)
        : base(serviceProvider, translateService)
    {
        InitializeComponent();
    }

    public override void Init()
    {
        this.LblErrorTitle.Text = $"{this.Error.GetType().Name} - {this.Error.Message}";
        this.LblErrorStackTrace.Text = this.Error.StackTrace;
    }

    protected override void ConfigureTranslations()
    {

    }
}