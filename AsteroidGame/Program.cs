﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form form = new Form();
            form.Width = 800;
            form.Height = 600;
            form.MaximumSize = form.Size;
            form.MinimumSize = form.Size;


            form.Show();

            Game.Inicialize(form);
            Game.Load();
            Game.Draw();

            Application.Run(form);

        }
    }
}
