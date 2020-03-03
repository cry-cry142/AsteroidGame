using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class Game
    {
        public static BufferedGraphicsContext __Context;
        public static BufferedGraphics __Buffer;
        public static int Width;
        public static int Height;

        public static void Inicialize(Form form1)
        {
            Width = form1.Width;
            Height = form1.Height;

            __Context = BufferedGraphicsManager.Current;
            Graphics g = form1.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, form1.Width, form1.Height));

            var timer = new Timer { Interval = 100 };
            timer.Tick += OnTimerTick;
        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        private static VisualObject[] __GameObject;
        public static void Load()
        {
            __GameObject = new VisualObject[30];
            for (var i = 0; i < __GameObject.Length; i++)
            {
                __GameObject[i] = new VisualObject(
                    new Point(600, i * 20),
                    new Point(15 - i, 20 - i),
                    new Size(20, 20)
                    );
            }
        }
        public static void Draw()
        {
            var g = __Buffer.Graphics;
            g.Clear(Color.Black);

            //g.DrawRectangle(Pens.White, 10, 10, 60, 100);


            //g.DrawPie(Pens.Red, new Rectangle(X, 100, 200, 300), 0, 360);

            foreach (var visual_object in __GameObject)
            {
                visual_object.Draw(g);
            }


            __Buffer.Render();

        }
        public static void Update()
        {
            foreach (var visual_object in __GameObject)
                visual_object.Update();
        }
    }
}
