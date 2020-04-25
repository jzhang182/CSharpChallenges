using System;

namespace AnimalClasses
{
    public interface IFlyable
    {
        void Fly();
    }
    public interface IQuackable
    {
        void Quack();
    }
    public abstract class Animal
    {
        public abstract void Display();
        public abstract override string ToString();
    }

    class Cat : Animal, IQuackable
    {
        private string sound = "Meow.";
        private string look = "I am a cute kitty.";
        public void Quack()
        {
            Console.WriteLine(sound);
        }
        public override void Display()
        {
            Console.WriteLine(look);
        }
        public override string ToString()
        {
            return look + sound;
        }
    }
    class Dog : Animal, IQuackable
    {
        private string sound = "Wurf wurf.";
        private string look = "I am a lovely puppy.";
        public void Quack()
        {
            Console.WriteLine(sound);
        }
        public override void Display()
        {
            Console.WriteLine(look);
        }
        public override string ToString()
        {
            return look + sound;
        }
    }
    class Fox : Animal, IFlyable
    {
        private string look = "I am a swift snowfox.";
        private string flyability = "I can jump high enough into the tree.";
        public override void Display()
        {
            Console.WriteLine(look);
        }
        public void Fly()
        {
            Console.WriteLine(flyability);
        }
        public override string ToString()
        {
            return look + flyability;
        }
    }
    class Bird : Animal, IQuackable, IFlyable
    {
        private string sound = "Chew chew.";
        private string look = "I am a fluffy bird.";
        private string flyability = "I can fly.";
        public void Quack()
        {
            Console.WriteLine(sound);
        }
        public override void Display()
        {
            Console.WriteLine(look);
        }
        public void Fly()
        {
            Console.WriteLine(flyability);
        }
        public override string ToString()
        {
            return look + sound + flyability;
        }
    }

    // class Program
    // {
    //     static void Main()
    //     {
    //         Animal[] myAnimals = { new Cat(), new Dog(), new Bird(), new Fox() };
    //         foreach (Animal currentAnimal in myAnimals)
    //         {
    //             IFlyable flyingAnimal = currentAnimal as IFlyable;
    //             IQuackable quackAnimal = currentAnimal as IQuackable;
    //             if (flyingAnimal != null) { flyingAnimal.Fly(); }
    //             if (!(quackAnimal is null)) { quackAnimal.Quack(); }
    //             // quackAnimal.Quack();
    //             Console.WriteLine(currentAnimal.ToString());
    //             Console.WriteLine("-------------------------");
    //         }
    //     }
    // }
}