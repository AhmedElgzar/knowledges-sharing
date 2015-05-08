using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RxNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var drawStart = Observable.FromEventPattern<MouseEventArgs>(canvas, "MouseDown");
            var move = Observable.FromEventPattern<MouseEventArgs>(canvas, "MouseMove");
            var drawEnd = Observable.FromEventPattern<MouseEventArgs>(canvas, "MouseUp");

            int x = 0, y = 0;
            var drawStream = drawStart.SelectMany(e =>
            {
                x = e.EventArgs.Location.X;
                y = e.EventArgs.Location.Y;
                return move.TakeUntil(drawEnd);
            });

            drawStream.Subscribe(evt =>
            {
                var newX = evt.EventArgs.Location.X;
                var newY = evt.EventArgs.Location.Y;

                var color = new Pen(Color.Black);
                Graphics g = canvas.CreateGraphics();
                g.DrawLine(color, new Point(x, y), new Point(newX, newY));

                x = newX;
                y = newY;
            });
        }
    }
}
