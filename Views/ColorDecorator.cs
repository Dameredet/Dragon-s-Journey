using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_KCK.Views
{


    public abstract class Component
    {
        public abstract void Decorate(string Message);
    }

    class ColorComponent : Component
    {
        public override void Decorate(string Message)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (Message.Length / 2)) + "}", Message));
        }
    }

    abstract class Decorator : Component
    {
        protected Component _component;

        public Decorator(Component component)
        {
            this._component = component;
        }

        public void SetComponent(Component component)
        {
            this._component = component;
        }
        public override void Decorate(string Message)
        {
            if (this._component != null)
            {
                this._component.Decorate(Message);
            }
        }
    }

    class ColorDecoratorWhite : Decorator
    {
        public ColorDecoratorWhite(Component comp) : base(comp)
        {
        }

        public override void Decorate(string Message)
        {
            Console.ResetColor();
            base.Decorate("        " + Message + "        ");
        }
    }

    class ColorDecoratorRed : Decorator
    {
        public ColorDecoratorRed(Component comp) : base(comp)
        {
        }

        public override void Decorate(string Message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            base.Decorate(Message);
        }
    }

    class TextDecoratorSigns : Decorator
    {
        public TextDecoratorSigns(Component comp) : base(comp)
        {
        }

        public override void Decorate(string Message)
        {
            base.Decorate("> " + Message + " <");
        }
    }

    class TextDecoratorTaunt : Decorator
    {
        public TextDecoratorTaunt(Component comp) : base(comp)
        {
        }

        public override void Decorate(string Message)
        {
            base.Decorate("    >< " + Message + " ><    ");
        }
    }

    class TextDecoratorMean : Decorator
    {
        public TextDecoratorMean(Component comp) : base(comp)
        {
        }

        public override void Decorate(string Message)
        {
            base.Decorate(Message + ", you loser");
        }
    }

    public class Writer
    {
        public void WriteCentered(Component component, string Message)
        {
            component.Decorate(Message);
        }
    }
}
