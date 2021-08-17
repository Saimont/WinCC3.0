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


        private void ReadPositionFromArray(int pos, Byte[] data) {

            if (data != null) {

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
            } else {
                Position posi = new Position();
                ConveyorTransportSystem.GetInstance().Positions[pos] = posi;
            }


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


            ReadPositionFromArray(1101, b);
            ReadPositionFromArray(1102, b);
            ReadPositionFromArray(1103, b);
            ReadPositionFromArray(1104, b);
            ReadPositionFromArray(1105, b);
            ReadPositionFromArray(1106, b);
            ReadPositionFromArray(1111, b);
            ReadPositionFromArray(1112, b);
            ReadPositionFromArray(1113, b);
            ReadPositionFromArray(1114, b);
            ReadPositionFromArray(1115, b);
            ReadPositionFromArray(1116, b);
            ReadPositionFromArray(1119, b);
            ReadPositionFromArray(1120, b);
            ReadPositionFromArray(1121, b);
            ReadPositionFromArray(1122, b);
            ReadPositionFromArray(1123, b);
            ReadPositionFromArray(1124, b);
            
            ReadPositionFromArray(1201, b);
            ReadPositionFromArray(1202, b);
            ReadPositionFromArray(1203, b);
            ReadPositionFromArray(1211, b);
            ReadPositionFromArray(1212, b);
            ReadPositionFromArray(1213, b);
            ReadPositionFromArray(1214, b);
            ReadPositionFromArray(1215, b);
            ReadPositionFromArray(1216, b);
            ReadPositionFromArray(1217, b);
            ReadPositionFromArray(1218, b);
            ReadPositionFromArray(1219, b);
            ReadPositionFromArray(1220, b);
            ReadPositionFromArray(1221, b);
            ReadPositionFromArray(1222, b);
            ReadPositionFromArray(1223, b);
            ReadPositionFromArray(1224, b);
            ReadPositionFromArray(1225, b);
            ReadPositionFromArray(1226, b);
            ReadPositionFromArray(1227, b);
            ReadPositionFromArray(1228, b);
            ReadPositionFromArray(1229, b);
            ReadPositionFromArray(1230, b);
            ReadPositionFromArray(1231, b);
            ReadPositionFromArray(1232, b);
            ReadPositionFromArray(1233, b);
            ReadPositionFromArray(1234, b);

            ReadPositionFromArray(1301, b);
            ReadPositionFromArray(1302, b);
            ReadPositionFromArray(1303, b);
            ReadPositionFromArray(1304, b);
            ReadPositionFromArray(1304, b);
            ReadPositionFromArray(1305, b);
            ReadPositionFromArray(1306, b);
            ReadPositionFromArray(1307, b);
            ReadPositionFromArray(1308, b);
            ReadPositionFromArray(1309, b);
            ReadPositionFromArray(1311, b);
            ReadPositionFromArray(1312, b);
            ReadPositionFromArray(1313, b);
            ReadPositionFromArray(1314, b);
            ReadPositionFromArray(1315, b);
            ReadPositionFromArray(1316, b);
            ReadPositionFromArray(1320, b);
            ReadPositionFromArray(1321, b);
            ReadPositionFromArray(1322, b);
            ReadPositionFromArray(1323, b);
            ReadPositionFromArray(1324, b);
            ReadPositionFromArray(1325, b);
            ReadPositionFromArray(1326, b);
            ReadPositionFromArray(1327, b);
            ReadPositionFromArray(1328, b);
            ReadPositionFromArray(1329, b);
            ReadPositionFromArray(1330, b);
            ReadPositionFromArray(1331, b);
            ReadPositionFromArray(1340, b);
            ReadPositionFromArray(1341, b);
            ReadPositionFromArray(1342, b);
            ReadPositionFromArray(1343, b);
            ReadPositionFromArray(1344, b);
            ReadPositionFromArray(1351, b);
            ReadPositionFromArray(1352, b);
            ReadPositionFromArray(1353, b);
            ReadPositionFromArray(1354, b);
            ReadPositionFromArray(1360, b);
            ReadPositionFromArray(1361, b);
            ReadPositionFromArray(1362, b);
            ReadPositionFromArray(1363, b);
            ReadPositionFromArray(1364, b);
            ReadPositionFromArray(1365, b);
            ReadPositionFromArray(1370, b);
            ReadPositionFromArray(1371, b);
            ReadPositionFromArray(1372, b);
            ReadPositionFromArray(1373, b);
            ReadPositionFromArray(1374, b);
            ReadPositionFromArray(1375, b);
            ReadPositionFromArray(1376, b);



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
