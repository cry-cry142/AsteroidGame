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
            Width = form1.ClientSize.Width;
            Height = form1.ClientSize.Height;

            __Context = BufferedGraphicsManager.Current;
            Graphics g = form1.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            var timer = new Timer { Interval = 10 };
            timer.Tick += OnTimerTick;
            timer.Start();
        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        private static VisualObject[] __GameObject;
        public static void Load()
        {
            __GameObject = new Stars[100];

            Random rnd = new Random();
            
            for (var i = 0; i < __GameObject.Length; i++)
            {
                int star = rnd.Next(2, 4);
                int speed = rnd.Next(-8, -1);
                int width = rnd.Next(0, Width);
                int height = rnd.Next(0, Height);
                __GameObject[i] = new Stars(
                    new Point(width, height),
                    new Point(speed, 0),
                    new Size(star, star),
                    new Size(Width, Height)
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
