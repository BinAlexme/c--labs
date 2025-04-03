using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace paint
{
    class Rectangle : Figure
    {
        public Rectangle(Point pointOne, Point pointTwo) : base(pointOne, pointTwo) { }

        public Rectangle(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2) { }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);

            Point normPointOne = new Point(pointOne.x, pointOne.y);
            Point normPointTwo = new Point(pointTwo.x, pointTwo.y);

            Normalization(ref normPointOne, ref normPointTwo);

            System.Drawing.Rectangle rectangle = System.Drawing.Rectangle.FromLTRB(normPointOne.x, normPointOne.y, normPointTwo.x, normPointTwo.y);

            g.DrawRectangle(pen, rectangle);
        }

        public override void DrawHash(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            Point normPointOne = new Point(pointOne.x, pointOne.y);
            Point normPointTwo = new Point(pointTwo.x, pointTwo.y);

            Normalization(ref normPointOne, ref normPointTwo);

            System.Drawing.Rectangle rectangle = System.Drawing.Rectangle.FromLTRB(normPointOne.x, normPointOne.y, normPointTwo.x, normPointTwo.y);

            g.DrawRectangle(pen, rectangle);
        }

        public override void Hide(Graphics g)
        {
            Pen eraser = new Pen(Color.White, 3);

            Point normPointOne = new Point(pointOne.x, pointOne.y);
            Point normPointTwo = new Point(pointTwo.x, pointTwo.y);

            Normalization(ref normPointOne, ref normPointTwo);

            System.Drawing.Rectangle rectangle = System.Drawing.Rectangle.FromLTRB(normPointOne.x, normPointOne.y, normPointTwo.x, normPointTwo.y);

            g.DrawRectangle(eraser, rectangle);
        }

    }
}
