using System;

namespace LazyLoadDomain.Lazy
{
    public interface IValueHolder<T>
    {
        T GetValue(object parameter);
    }

    public class ValueHolder<T> : IValueHolder<T>
    {
        public ValueHolder(Func<object, T> getVal)
        {
            getValue = getVal;
        }


        private readonly Func<object, T> getValue;
        private T value;
        // Lazy Initialization + Value Holder pattern;
        // inject it into entity (Customer this time);
        // initialize it in CustomerRepository
        public T GetValue(object parameter)
            => value ??= getValue(parameter);
    }
}
