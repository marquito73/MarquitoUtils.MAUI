namespace MarquitoUtils.MAUI.Common.Attributes
{
    /// <summary>
    /// Specifies that a class represents a page identifier for use with page-based frameworks or navigation systems.
    /// </summary>
    /// <remarks>Apply this attribute to a class to mark it as a page identifier. This can be used by
    /// frameworks or libraries to discover and register pages for routing, navigation, or other page-related
    /// operations. This attribute is not inherited and cannot be applied multiple times to the same class.</remarks>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class PageIdentificatorAttribute : Attribute
    {
    }
}
