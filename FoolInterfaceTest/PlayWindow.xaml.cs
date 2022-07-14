using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Durak_BL.Controller;

namespace FoolInterfaceTest
{
    public partial class PlayWindow : Window
    {
        private bool isMaximazed = false;
        public PlayWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 2)
            {
                if(isMaximazed)
                {
                    WindowState = WindowState.Normal;
                    Height = 720;
                    Width = 1080;
                    isMaximazed = false;
                }
                else
                {
                    WindowState = WindowState.Maximized;
                    isMaximazed = true;
                }
            }
        }

        private void Rectangle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
