﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtractorSharp.Draw.Brush {
    class Eraser : IBrush {

        public int Radius { set; get; } = 10;

        public Cursor Cursor { set; get; }
        public Point Location { set; get; }

        public Eraser() {
            RefreshCursor();
        }

        public void RefreshCursor() {
            var image = new Bitmap(Radius * 2, Radius * 2);
            using (var g = Graphics.FromImage(image)) {
                g.DrawEllipse(new Pen(Color.Black, 2), new Rectangle(0, 0, Radius * 2, Radius * 2));
            }
            Cursor = new Cursor(image.GetHicon());
        }

        public void Draw(IPaint paint, Point point, decimal scale) {
            point = point.Minus(paint.Location).Divide(scale);
            if (paint.Tag != null) {
                Program.Controller.Do("eraser", paint.Tag, point, Program.Drawer.Color, Radius);
            }
        }
    }
}
