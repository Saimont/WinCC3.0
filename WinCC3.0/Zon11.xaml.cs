using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WinCC3._0
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage() {
            this.InitializeComponent();
        }

        private void positionClicked(object sender, RoutedEventArgs e) {
            String name = ((Button)sender).Name;
            name = name.Remove(0, 1);
            Popup p = this.FindName("WinCC3_0test") as Popup;
               
            if (!p.IsOpen) {
                var popup = p.Child as PositionClickedPopup;
                var textBlock = popup.FindName("Title");
                ((TextBlock)textBlock).Text = "Pos: " + name;
                p.IsOpen = true;

                var pos = ConveyorTransportSystem.GetInstance().Positions[int.Parse(name)];
                var destinationBox = popup.FindName("destination") as TextBox;
                if (pos.Destination != 0)
                    destinationBox.Text = pos.Destination.ToString();
                else
                    destinationBox.Text = "";
            } else if(p.IsOpen) {
                var popup = p.Child as PositionClickedPopup;
                var textBlock = popup.FindName("Title");
                ((TextBlock)textBlock).Text = "Pos: " + name;
                var pos = ConveyorTransportSystem.GetInstance().Positions[int.Parse(name)];
                var destinationBox = popup.FindName("destination") as TextBox;
                if (pos.Destination != 0)
                    destinationBox.Text = pos.Destination.ToString();
                else
                    destinationBox.Text = "";
            }
        }

        private void zon12_Click(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(Zon12));
        }

        private void zon13_Click(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(Zon13));
        }

        private void zon14_Click(object sender, RoutedEventArgs e) {
            //TODO Navigate to zone 14

        }

        private void zon15_Click(object sender, RoutedEventArgs e) {
            //TODO Navigate to zone 15

        }
    }
}
