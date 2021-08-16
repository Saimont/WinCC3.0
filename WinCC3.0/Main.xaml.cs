using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading;

namespace WinCC3._0 {
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App() {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            ApplicationView.PreferredLaunchViewSize = new Size(1920, 1080);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;

            Thread t = new Thread(OurBackend);
            t.Start();
        }


        private void trams(int pos, Byte[] data) {

            int realpos = pos;
            Position posi = new Position();
            pos = pos - 1000;
            int destpospekare = pos << 1;
            Byte[] temp = new Byte[2];
            temp[0] = data[destpospekare + 1 - 200];
            temp[1] = data[destpospekare - 200];
            short destination = BitConverter.ToInt16(temp, 0);

            posi.Destination = destination;
            posi.TrpId = 0;
            posi.Type = 0;
            //ConveyorTransportSystem.GetInstance();
            ConveyorTransportSystem.GetInstance().Positions[realpos] = posi;


            /*btn.Foreground = new SolidColorBrush(Windows.UI.Colors.DarkSlateBlue);
            string posid = btn.Name;
            if (btn.Name[0] != '1')
                continue;
            int pos = System.Convert.ToInt32(posid);
            pos = pos - 1000;
            int destpospekare = pos << 1;
            Byte[] data = new Byte[2];
            data[0] = b[destpospekare + 1 - 200];
            data[1] = b[destpospekare + 1 - 200];
            short destination = BitConverter.ToInt16(data, 0);
            if (destination == 0) {
                btn.Background = new SolidColorBrush(Windows.UI.Colors.White);
            }
            else if (destination == 1326)
                btn.Background = new SolidColorBrush(Windows.UI.Colors.DarkSlateBlue);
            else
                btn.Background = new SolidColorBrush(Windows.UI.Colors.Yellow);*/
        }
        private async void processDB(Byte[] b) {


            trams(1101, b);
            trams(1102, b);
            trams(1103, b);
            trams(1104, b);
            trams(1105, b);
            trams(1106, b);
            trams(1111, b);
            trams(1112, b);
            trams(1113, b);
            trams(1114, b);
            trams(1115, b);
            trams(1116, b);
            trams(1119, b);
            trams(1120, b);
            trams(1121, b);
            trams(1122, b);
            trams(1123, b);
            trams(1124, b);
            
            trams(1201, b);
            trams(1202, b);
            trams(1203, b);
            trams(1211, b);
            trams(1212, b);
            trams(1213, b);
            trams(1214, b);
            trams(1215, b);
            trams(1216, b);
            trams(1217, b);
            trams(1218, b);
            trams(1219, b);
            trams(1220, b);
            trams(1221, b);
            trams(1222, b);
            trams(1223, b);
            trams(1224, b);
            trams(1225, b);
            trams(1226, b);
            trams(1227, b);
            trams(1228, b);
            trams(1229, b);
            trams(1230, b);
            trams(1231, b);
            trams(1232, b);
            trams(1233, b);
            trams(1234, b);
            


            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => {

                var _Frame = Window.Current.Content as Frame;
                Page page = _Frame.Content as Page;
                
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(page); i++) {
                    //Debug.WriteLine("Loop\n");
                    var value = VisualTreeHelper.GetChild(page, i);

                    //Thread.Sleep(1000);
                    if(value is Grid && ((Grid)value).Name.Equals("outer")) {
                        Grid g = value as Grid;
                        for (int j = 0; j < g.Children.Count; j++) {
                            if(g.Children[j] is Grid && ((Grid)g.Children[j]).Name.Equals("buttons")) {
                                Grid bgrid = g.Children[j] as Grid;
                                for(int p = 0; p < bgrid.Children.Count; p++) {
                                    var temp = bgrid.Children.ElementAt(p);
                                    if (temp is Button) {
                                        Button btn = temp as Button;
                                        string posid = btn.Name.Remove(0, 1);
                                        int pos = 0;

                                        pos = System.Convert.ToInt32(posid);

                                        Position posi = ConveyorTransportSystem.GetInstance().Positions[pos];
                                        if (posi.Destination == 0)
                                            btn.Background = new SolidColorBrush(Windows.UI.Colors.LightSlateGray);
                                        else if (posi.Destination == 1326)
                                            btn.Background = new SolidColorBrush(Windows.UI.Colors.DarkBlue);
                                        else
                                            btn.Background = new SolidColorBrush(Windows.UI.Colors.Yellow);
                                    }
                                }
                            }

                        }
                    }
                    if (value is Button) {
                        Button btn = value as Button;
                        string posid = btn.Name;
                        btn.Visibility = Visibility.Collapsed;
                        btn.Scale = System.Numerics.Vector3.Zero;

                    }
                }

            });

            Thread.Sleep(3000);

        }
        private void OurBackend() {
            QueryPLC.GetInstance().Connect();
            while(true) {
                Byte[] data = QueryPLC.GetInstance().FetchDB(20, 0, 0); // Parameters handled by mod
                processDB(data);
            }
        }

        private void UpdatePositionColors() {

        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null) {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated) {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false) {
                if (rootFrame.Content == null) {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Ensure the current window is active
                Window.Current.Activate();
            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e) {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e) {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
