namespace TemplateMethodRefactored.Inheritance
{
    public abstract class TemplateBase
    {
        private bool _importantSetting;
        // Template Method - not virtual - enforce requirements
        // calling Initialize() for example
        public void Do()
        {
            BeforeDoing();
            Initialize();
            AfterDone();
        }
        // optional hook virtual
        public virtual void BeforeDoing()
        { }
        // 'specialization' hook
        public abstract void AfterDone();

        private void Initialize()
        {
            _importantSetting = true;
        }
    }

    public class TemplateChild : TemplateBase
    {
        public override void AfterDone()
        {
            // do specific to Child stuff
        }
    }
}
