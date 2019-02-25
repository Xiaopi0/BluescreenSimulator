﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BluescreenSimulator.Views;

namespace BluescreenSimulator.Controls
{
    /// <summary>
    /// Interaction logic for ColorPickerForm.xaml
    /// </summary>
    public partial class ColorPickerForm : UserControl
    {
        public ColorPickerForm()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(
            "Color", typeof(Color), typeof(ColorPickerForm), new FrameworkPropertyMetadata(Colors.Black, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public Color Color
        {
            get { return (Color) GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new ColorChooserWindow(Color)
            {
                Owner = Window.GetWindow(this)
            };
            window.ActionComplete += (o, args) => Dispatcher.Invoke(() => Color = args.Color);
            window.ShowDialog();
        }
    }
}
