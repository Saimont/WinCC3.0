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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WinCC3._0 {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PositionClickedPopup : UserControl {
        public PositionClickedPopup() {
            this.InitializeComponent();
        }

        private void onClick(object sender, RoutedEventArgs e) {
            ((Popup)this.Parent).IsOpen = false;
        }

        private void TextBox_OnTextChanging(TextBox sender, TextBoxTextChangingEventArgs args) {
            //Save the position of the selection, to prevent the cursor to jump to the start
            int pos = sender.SelectionStart;
            sender.Text = new String(sender.Text.Where(char.IsDigit).ToArray());
            sender.SelectionStart = pos;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void checkBox_Checked(object sender, RoutedEventArgs e) {
            CheckBox cb = sender as CheckBox;

            cb.IsChecked = true;
            if (cb != checkBoxOne && checkBoxOne != null)
                checkBoxOne.IsChecked = false;
            if (cb != checkBoxTwo && checkBoxTwo != null)
                checkBoxTwo.IsChecked = false;
            if (cb != checkBoxThree && checkBoxThree != null)
                checkBoxThree.IsChecked = false;
        }
    }
}
