﻿using TemplateMethodRefactored.Base;
using TemplateMethodRefactored.Components;
using TemplateMethodRefactored.Models;

namespace TemplateMethodRefactored
{
    public class ColdVeggiePizzaBakingService : PanFoodServiceBase<ColdVeggiePizza>
    {
        public ColdVeggiePizzaBakingService(LoggerAdapter logger) : base(logger)
        {
        }

        protected override void AddToppings()
        {
            logger.Log("Add cream cheese, peppers, and veggies");

        }

        // there are a few ways to deal with optional behavior like this
        // 1. Override the default and do nothing
        // 2. Add conditional logic to the base template method
        // 3. Implement do-nothing hook method in base template; only override if you need to do something (see Cover)
        //protected override void Bake()
        //{
        //    // override default behavior
        //}

        protected override void PrepareCrust()
        {
            logger.Log("Rolling out dough and press into pan");
        }

        protected override void Slice()
        {
            logger.Log("Slice into squares");
        }
    }
}
