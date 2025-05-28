using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR7
{
    abstract class Figure
    {
        public int X, Y;
        public Color Color;
        public string Text;
        public abstract void Draw(Graphics g);
        public abstract void Move(int dx, int dy);
    }

    class Square : Figure
    {
        public int Size;

        public Square(int x, int y, Color color, string text, int size)
        {
            X = x;
            Y = y;
            Color = color;
            Text = text;
            Size = size;
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color, 2);
            g.DrawRectangle(pen, X, Y, Size, Size);
            g.DrawString(Text, SystemFonts.DefaultFont, Brushes.Black, X + Size / 4, Y + Size / 4);
        }

        public override void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }
    }

    class Rectangle : Figure
    {
        public int Width, Height;

        public Rectangle(int x, int y, Color color, string text, int width, int height)
        {
            X = x;
            Y = y;
            Color = color;
            Text = text;
            Width = width;
            Height = height;
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color, 2);
            g.DrawRectangle(pen, X, Y, Width, Height);
            g.DrawString(Text, SystemFonts.DefaultFont, Brushes.Black, X + Width / 4, Y + Height / 4);
        }

        public override void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }
    }

    class Ellipse : Figure
    {
        public int Width;
        public int Height;

        public Ellipse(int x, int y, Color color, string text, int width, int height)
        {
            X = x;
            Y = y;
            Color = color;
            Text = text;
            Width = width;
            Height = height;
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color, 2);
            g.DrawEllipse(pen, X - Width / 2, Y - Height / 2, Width, Height);
            g.DrawString(Text, SystemFonts.DefaultFont, Brushes.Black, X - Width / 4, Y - Height / 4);
        }

        public override void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }
    }


    class Rhombus : Figure
    {
        public int Size;

        public Rhombus(int x, int y, Color color, string text, int size)
        {
            X = x;
            Y = y;
            Color = color;
            Text = text;
            Size = size;
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color, 2);
            Point[] points = {
            new Point(X, Y - Size / 2),
            new Point(X + Size / 2, Y), 
            new Point(X, Y + Size / 2),
            new Point(X - Size / 2, Y) 
        };
            g.DrawPolygon(pen, points);
            g.DrawString(Text, SystemFonts.DefaultFont, Brushes.Black, X - Size / 4, Y - Size / 4);
        }

        public override void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }
    }

}
