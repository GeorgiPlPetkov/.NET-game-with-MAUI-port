﻿using BattleshipClone.DB;

namespace BattleshipClone
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
