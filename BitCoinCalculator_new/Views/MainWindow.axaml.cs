using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Platform;
using Avalonia.Media.Imaging;

namespace BitCoinCalculator_new.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        this.Title = "Bitcoin Calculator";

        var canvas = new Canvas();

        var screen = Screens.Primary;

        var windowX = (screen.WorkingArea.Width) / 3;
        var windowY = (screen.WorkingArea.Height) / 4;

        this.Position = new PixelPoint(windowX, windowY);

        // var backgroundImagePath = "avares://BitCoinCalculator_new/Assets/silly.jpg";
        //
        //
        // Image background = new Image()
        // {
        //     Source = new Bitmap(backgroundImagePath),
        //     Opacity = 10
        // };
        //
        // Canvas.SetLeft(background, 0);
        // Canvas.SetTop(background, 0);
        //
        // canvas.Children.Add(background);
        //
        // this.Content = canvas;
    }
    
    
}