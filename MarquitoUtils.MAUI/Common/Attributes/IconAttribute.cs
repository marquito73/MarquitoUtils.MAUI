namespace MarquitoUtils.MAUI.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class IconAttribute : Attribute
    {
        public string IconCode { get; }

        public IconAttribute(string iconCode)
        {
            this.IconCode = iconCode;
        }
    }
}
