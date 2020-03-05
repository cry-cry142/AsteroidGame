using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AsteroidGame
{
    class VisualObject
    {
        protected Point _Position;
        protected Point _Direction;
        protected Size _Size;

        public VisualObject()
        {
        }

        public VisualObject(Point position, Point direction, Size size)
        {
            _Position = position;
            _Direction = direction;
            _Size = size;
        }

        public virtual void Draw(Graphics g)
        {
            //g.DrawEllipse(Pens.White, _Position.X, _Position.Y, _Size.Width, _Size.Height);
            g.FillEllipse(Brushes.White, _Position.X, _Position.Y, _Size.Width, _Size.Height);
        }

        public virtual void Update()
        {
            _Position = new Point(_Position.X + _Direction.X, _Position.Y + _Direction.Y);
            if (_Position.X < 0)
                _Direction = new Point(-_Direction.X, _Direction.Y);
            if (_Position.Y < 0)
                _Direction = new Point(_Direction.X, -_Direction.Y);

            if (_Position.X > Game.Width)
                _Direction = new Point(-_Direction.X, _Direction.Y);
            if (_Position.Y > Game.Height)
                _Direction = new Point(_Direction.X, -_Direction.Y);
        }
    }
}
