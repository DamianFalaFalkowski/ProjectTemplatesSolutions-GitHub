using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using $safeprojectname$.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace $safeprojectname$
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            DataContext = new MainViewModel();
            this.InitializeComponent();
        }       

        private void Frame_Loaded(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).PaneContentFrameLoadedCommand.Execute(sender as Frame);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).ViewLoadedCommand.Execute(sender as Page);
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            (DataContext as MainViewModel).PageSizeChangedCommand.Execute(e);
        }

        private void OpenClosePaneButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            (DataContext as MainViewModel).OpenClosePaneButtonTappedCommand.Execute(null);
        }

        private void SplitView_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            (DataContext as MainViewModel).SplitViewManipulationStartedCommand.Execute(e);
        }

        private void SplitView_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            (DataContext as MainViewModel).SplitViewManipulationDeltaCommand.Execute(e);
        }

        private void SplitView_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            (DataContext as MainViewModel).SplitViewManipulationCompletedCommand.Execute(e);
        }
    }
}
