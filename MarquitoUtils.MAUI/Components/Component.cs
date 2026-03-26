using System.Diagnostics.CodeAnalysis;
using static Microsoft.Maui.Controls.BindableProperty;

namespace MarquitoUtils.MAUI.Components
{
    public abstract class Component : ContentView, IContentView
    {
        private const DynamicallyAccessedMemberTypes DeclaringTypeMembers = DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.PublicMethods;
        private const DynamicallyAccessedMemberTypes ReturnTypeMembers = DynamicallyAccessedMemberTypes.PublicParameterlessConstructor;
        protected Component()
        {
            this.Loaded += this.OnComponentLoaded;
        }

        /// <summary>
        /// Returns the value that is contained in the given bindable property.
        /// </summary>
        /// <param name="property">The bindable property for which to get the value.</param>
        /// <returns>The value that is contained in the <see cref="BindableProperty" />.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="property"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// <see cref="GetValue(BindableProperty)" /> and <see cref="SetValue(BindableProperty, object)" /> are used to access the values of properties that are implemented by a <see cref="BindableProperty" />.
        /// That is, application developers typically provide an interface for a bound property by defining a <see langword="public" /> property whose <see langword="get" /> accessor casts the result of <see cref="GetValue(BindableProperty)" /> to the appropriate type and returns it, and whose <see langword="set" /> accessor uses <see cref="SetValue(BindableProperty, object)" /> to set the value on the correct property.
        /// Application developers should perform no other steps in the public property that defines the interface of the bound property.
        /// </remarks>
        public T GetValue<T>(BindableProperty property)
        {
            return (T)GetValue(property);
        }

        protected IDispatcherTimer InitTimer(double intervalInSeconds, Action action)
        {
            IDispatcherTimer timer = Application.Current.Dispatcher.CreateTimer();

            timer.Interval = TimeSpan.FromSeconds(intervalInSeconds);
            timer.Tick += (s, e) => action();
            timer.Start();

            return timer;
        }

        /// <summary>
        /// Called when the component is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected abstract void OnComponentLoaded(object? sender, EventArgs e);

        protected static BindableProperty CreateProperty<[DynamicallyAccessedMembers(ReturnTypeMembers)] TReturnType, [DynamicallyAccessedMembers(DeclaringTypeMembers)] TDeclaringType>(string propertyName, object defaultValue = null,
            ValidateValueDelegate validateValue = null, BindingPropertyChangedDelegate propertyChanged = null, BindingPropertyChangingDelegate propertyChanging = null,
            CoerceValueDelegate coerceValue = null, CreateDefaultValueDelegate defaultValueCreator = null)
            where TDeclaringType : Component
        {
            return BindableProperty.Create(propertyName, typeof(TReturnType), typeof(TDeclaringType), defaultValue, BindingMode.TwoWay,
                validateValue, propertyChanged, propertyChanging, coerceValue, defaultValueCreator);
        }
    }
}
