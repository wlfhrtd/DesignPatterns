namespace TemplateMethod.Inheritance
{
    public abstract class Base
    {
        private bool importantSetting;

        public virtual void Do()
        {
            Initialize();
        }

        private void Initialize()
        {
            importantSetting = true;
        }
    }

    public class Child : Base
    {
        public override void Do()
        {
            // if forgot to call - important Initialize() won't be called
            // base.Do();
        }
    }
}
