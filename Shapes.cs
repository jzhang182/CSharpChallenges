using System;
namespace Shapes
{
    public interface IName
    {
        string GetName();
    }
    public interface IPerimeter
    {
        string GetPerimeter();
    }

    public abstract class Shape : IName, IPerimeter
    {
        public abstract string GetName();
        public abstract string GetPerimeter();
    }

    public class Circle : Shape, IName, IPerimeter
    {
        protected const double pi = 3.1415927;
        private string name = "Circle";
        protected double radius;
        public double Radius
        {
            set { radius = value; }
            get { return radius; }
        }
        // public Circle(string myName = "Circle", double myRadius = 1.0) : base() { this.radius = myRadius; }
        public override string GetName()
        {
            return name;
        }
        public override string GetPerimeter()
        {
            return (2 * radius * pi).ToString();
        }
    }
    public class Triangle : Shape, IName, IPerimeter
    {
        private string name = "Triangle";
        protected double sideLength1;
        protected double sideLength2;
        protected double sideLength3;
        public double SideLength1
        {
            set { sideLength1 = value; }
            get { return sideLength1; }
        }
        public double SideLength2
        {
            set { sideLength2 = value; }
            get { return sideLength2; }
        }
        public double SideLength3
        {
            set { sideLength3 = value; }
            get { return sideLength3; }
        }
        public override string GetName()
        {
            return name;
        }
        public override string GetPerimeter()
        {
            return (sideLength1 + sideLength2 + sideLength3).ToString();
        }
    }
    public class EquilateralTriangle : Triangle, IName, IPerimeter
    {
        private string name = "EquilateralTriangle";
        protected double sideLength;
        public double SideLength
        {
            set { sideLength = value; }
            get { return sideLength; }
        }
        public override string GetName()
        {
            return name;
        }
        new public string GetPerimeter()
        {
            return (sideLength * 3).ToString();
        }
    }
    class Program
    {
        static void PrintName(IName item)
        {
            Console.WriteLine("Current shape is {0}", item.GetName());
        }
        static void PrintPerimeter(IPerimeter item)
        {
            Console.WriteLine("The perimeter is {0}", item.GetPerimeter());
        }
        // static void Main()
        // {
        //     Shape[] myShapes = { new Circle() { myRadius = 1.5}, new EquilateralTriangle() { mySideLength = 2.0 },
        //     new Triangle() { mySideLength1 = 1.8, mySideLength2 = 1.5, mySideLength3 = 2.5 } };
        //     foreach (Shape myShape in myShapes)
        //     {
        //         PrintName(myShape);
        //         PrintPerimeter(myShape);
        //     }
        // }
    }
}