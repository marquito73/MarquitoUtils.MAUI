namespace MarquitoUtils.MAUI.Components.Form
{
    /// <summary>
    /// Represents a form component, with a label and an error container
    /// </summary>
    public abstract class FormComponent : Component, IContentView
    {
        #region Error management

        public static readonly BindableProperty ErrorIsDisplayedProperty = CreateProperty<bool, FormComponent>(nameof(ErrorIsDisplayed), default(bool));
        /// <summary>
        /// Error is displayed ?
        /// </summary>
        public bool ErrorIsDisplayed
        {
            get => this.GetValue<bool>(ErrorIsDisplayedProperty);
            set => SetValue(ErrorIsDisplayedProperty, value);
        }

        public static readonly BindableProperty ErrorValueProperty = CreateProperty<string, FormComponent>(nameof(ErrorValue), default(string));
        /// <summary>
        /// Error is displayed ?
        /// </summary>
        public string ErrorValue
        {
            get => this.GetValue<string>(ErrorValueProperty);
            set => SetValue(ErrorValueProperty, value);
        }

        #endregion Error management

        /// <summary>
        /// Display an error message in the form component
        /// </summary>
        /// <param name="message">The error message to display </param>
        public virtual void DisplayError(string message)
        {
            this.ErrorIsDisplayed = true;

            this.ErrorValue = message;
        }

        /// <summary>
        /// Hide the error message in the form component
        /// </summary>
        public virtual void HideError()
        {
            this.ErrorIsDisplayed = false;

            this.ErrorValue = string.Empty;
        }

        /// <summary>
        /// Event triggered when the component value changes, used to attach events on it, and hide error when the user change the value of the component, 
        /// to avoid displaying an error message when the user has already changed the value after an error was displayed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnComponentChange(object? sender, EventArgs e)
        {
            if (this.ErrorIsDisplayed)
            {
                this.HideError();
            }
        }
    }
}
