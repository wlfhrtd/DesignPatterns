using TemplateMethodRefactored.Components;
using TemplateMethodRefactored.Models;

namespace TemplateMethodRefactored.Base
{
    public abstract class PanFoodServiceBase<T> where T : PanFood, new()
    {
        protected readonly LoggerAdapter logger;

        protected T item;


        public PanFoodServiceBase(LoggerAdapter log)
        {
            logger = log;
        }

        // Template Method
        // not virtual to enforce flow
        public T Prepare()
        {
            item = new T();

            PrepareCrust();

            AddToppings();

            Cover();

            if (item.RequiresBaking)
            {
                Bake();
            }

            Slice();

            return item;
        }

        protected abstract void PrepareCrust();

        protected abstract void AddToppings();
        // hook
        protected virtual void Bake()
        {
            logger.Log("Bake the item.");
        }

        protected abstract void Slice();
        // hook
        protected virtual void Cover()
        {
            // does nothing by default
        }
    }
}
