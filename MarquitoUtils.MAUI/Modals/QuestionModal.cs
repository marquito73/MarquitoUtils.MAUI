using MarquitoUtils.Main.Translate.Services;

namespace MarquitoUtils.MAUI.Modals
{
    /// <summary>
    /// Abstract class for a question modal, which is a type of modal that asks the user a question and expects a yes/no answer.
    /// </summary>
    public abstract class QuestionModal : DefaultModal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionModal"/> class with the specified translation service.
        /// </summary>
        /// <param name="translateService"></param>
        public QuestionModal(ITranslateService translateService) : base(translateService)
        {
        }

        public async override Task<bool> ShowModal()
        {
            return await Application.Current?.Windows[0]?.Page?.DisplayAlert(this.GetTitle(),
                this.GetDescription(), this.GetConfirmButtonText(), this.GetCancelButtonText());
        }

        /// <summary>
        /// Get the title of the modal
        /// </summary>
        /// <returns>The title of the modal</returns>
        protected abstract string GetTitle();

        /// <summary>
        /// Get the description of the modal
        /// </summary>
        /// <returns>The description of the modal</returns>
        protected abstract string GetDescription();

        /// <summary>
        /// Get the text of the confirm button
        /// </summary>
        /// <returns>The text of the confirm button</returns>
        protected abstract string GetConfirmButtonText();

        /// <summary>
        /// Get the text of the cancel button
        /// </summary>
        /// <returns>The text of the cancel button</returns>
        protected abstract string GetCancelButtonText();
    }
}
