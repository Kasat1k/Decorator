using System;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            // Create ConcreteComponent and two Decorators
            CristmasTree chrTree = new CristmasTree();
            ChristmasTreeDecoration chrDecoration = new ChristmasTreeDecoration();
            Garland chrGarland1 = new Garland();
            Garland chrGarland2 = new Garland();

            // Link decorators
            chrDecoration.SetComponent(chrTree);
            chrGarland1.SetComponent(chrDecoration);
            chrGarland2.SetComponent(chrGarland1);
            chrGarland2.Operation();

            // Wait for user
            Console.Read();
        }
    }
    // "Component"
    abstract class Component
    {
        public abstract void Operation();
    }

    // "ConcreteComponent"
    class CristmasTree: Component
    {
        public override void Operation()
        {
            Console.WriteLine("Ялинка");
        }
    }
    // "Decorator"
    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component _component)
        {
            this.component = _component;
        }
        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    // "ConcreteDecoratorA"
    class ChristmasTreeDecoration : Decorator
    {
        private string addedState;

        public override void Operation()
        {
            base.Operation();
            addedState = "Нова новорічна прикраса";
            Console.WriteLine(addedState);
        }
    }

    // "ConcreteDecoratorB" 
    class Garland : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            //Console.WriteLine("Garland.Operation()");
        }
        void AddedBehavior()
        { Console.WriteLine("Новорічна гірляда світиться"); }
    }
}