
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitap1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Triangle t = new Triangle();
            t.BaseTriangle = 1;
            Console.WriteLine("New Base Triangle" + t.BaseTriangle);
        }
    }
    abstract class Figure
    {
        public abstract double Area();
    }
    class Triangle : Figure
    {
        public double baseTriangle;

        public double BaseTriangle
        {
            get { return baseTriangle; }
            set
            {
                if (value > 0)
                {
                    baseTriangle = value;
                    Console.WriteLine("Base Triangle has been set to" + value);
                }
                else
                {
                    Console.WriteLine("Base Triangle cant  be less or equal  0");
                }
            }
        }


        public double heightTriangle;

        public double HeightTriangle
        {
            get { return heightTriangle; }
            set
            {
                if (value > 0)
                {
                    baseTriangle = value;
                    Console.WriteLine("Height Triangle has been set to" + value);
                }
                else
                {
                    Console.WriteLine("Height Triangle cant  be less or equal  0");
                }
            }
        }
        public override double Area()
        {
            return (baseTriangle * heightTriangle) / 2;
        }
    }
    class Circle : Figure

    {
        public double radius;

        public override double Area()
        {
            return (this.radius * this.radius) * 3;
        }
    }
}
/*
 * abstraction
 * abstract class A{
 * abstract method X
 * }
 * B:A{
 * bắt buộc override abstract method đó
 * public override...X{
 * }
 */