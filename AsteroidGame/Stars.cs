using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AsteroidGame
{
    class Stars : VisualObject
    {
        private Size _Form;
        public Stars(Point position, Point direction, Size size, Size form)
        {
            _Position = position;
            _Direction = direction;
            _Size = size;
            _Form = form;
        }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.White, _Position.X, _Position.Y, _Size.Width, _Size.Height);
        }

        public override void Update()
        {
            _Position = new Point(_Position.X + _Direction.X , _Position.Y);
            if (_Position.X < 0)
                _Position = new Point(_Position.X + _Form.Width, _Position.Y);
        }
    }
}
