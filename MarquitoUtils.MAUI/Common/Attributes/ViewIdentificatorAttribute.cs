namespace MarquitoUtils.MAUI.Common.Attributes
{
    /// <summary>
    /// Specifies that a class represents a view identifier for use with view-based frameworks or navigation systems.
    /// </summary>
    /// <remarks>Apply this attribute to a class to mark it as a view identifier. This can be used by
    /// frameworks or libraries to discover and register views for routing, navigation, or other view-related
    /// operations. This attribute is not inherited and cannot be applied multiple times to the same class.</remarks>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class ViewIdentificatorAttribute : Attribute
    {
    }
}
