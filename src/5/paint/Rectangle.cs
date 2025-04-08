using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace paint
{
    [Serializable()]
    class Rectangle : Figure
    {
        public Rectangle(int x1, int y1, int x2, int y2, int lineSize, Color lineColor, Color solidColor) : base(x1, y1, x2, y2, lineSize, lineColor, solidColor) { }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(lineColor, lineSize);
            SolidBrush solidBrush = new SolidBrush(solidColor);

            Point normPointOne = new Point(pointOne.x, pointOne.y);
            Point normPointTwo = new Point(pointTwo.x, pointTwo.y);

            Normalization(ref normPointOne, ref normPointTwo);

            System.Drawing.Rectangle rectangle = System.Drawing.Rectangle.FromLTRB(normPointOne.x, normPointOne.y, normPointTwo.x, normPointTwo.y);

            g.FillRectangle(solidBrush, rectangle);
            g.DrawRectangle(pen, rectangle);
            pen.Dispose();
            solidBrush.Dispose();
        }

        public override void DrawHash(Graphics g)
        {
            Pen pen = new Pen(lineColor, lineSize)
            {
                DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
            };

            Point normPointOne = new Point(pointOne.x, pointOne.y);
            Point normPointTwo = new Point(pointTwo.x, pointTwo.y);

            Normalization(ref normPointOne, ref normPointTwo);

            System.Drawing.Rectangle rectangle = System.Drawing.Rectangle.FromLTRB(normPointOne.x, normPointOne.y, normPointTwo.x, normPointTwo.y);

            g.DrawRectangle(pen, rectangle);
            pen.Dispose();
        }

        public override void Hide(Graphics g)
        {
            Pen pen = new Pen(Color.White, lineSize);
            SolidBrush solidBrush = new SolidBrush(Color.White);

            Point normPointOne = new Point(pointOne.x, pointOne.y);
            Point normPointTwo = new Point(pointTwo.x, pointTwo.y);

            Normalization(ref normPointOne, ref normPointTwo);

            System.Drawing.Rectangle rectangle = System.Drawing.Rectangle.FromLTRB(normPointOne.x, normPointOne.y, normPointTwo.x, normPointTwo.y);

            g.FillRectangle(solidBrush, rectangle);
            g.DrawRectangle(pen, rectangle);
            pen.Dispose();
            solidBrush.Dispose();
        }

    }
}
