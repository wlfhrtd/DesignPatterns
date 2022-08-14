using System;
using System.Drawing;
using System.Windows.Forms;

namespace LocationProximity
{
    public class Marker : Label
    {
        private MarkerMediator mediator;

        private Point mouseDownLocation;


        public Marker()
        {
            Text = "{Drag me}";
            TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            MouseDown += OnMouseDown;
            MouseMove += OnMouseMove;
        }


        internal void SetMediator(MarkerMediator m)
        {
            mediator = m;
        }

        private void OnMouseDown(object sender, MouseEventArgs eventArgs)
        {
            if (eventArgs.Button == MouseButtons.Left)
            {
                mouseDownLocation = eventArgs.Location;
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs eventArgs)
        {
            if (eventArgs.Button == MouseButtons.Left)
            {
                Text = Location.ToString();
                Left = eventArgs.X + Left - mouseDownLocation.X;
                Top = eventArgs.Y + Top - mouseDownLocation.Y;

                mediator.Send(Location, this);
            }
        }

        public void ReceiveLocation(Point location)
        {
            double distance = CalcDistance(location);
            if (distance < 100 && BackColor != Color.Red)
            {
                BackColor = Color.Red;
            }
            else if (distance >= 100 && BackColor != Color.Green)
            {
                BackColor = Color.Green;
            }
        }

        private double CalcDistance(Point point)
            => Math.Sqrt(Math.Pow(point.X - Location.X, 2) + Math.Pow(point.Y - Location.Y, 2));
    }
}
