using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.Tools;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace $safeprojectname$.ViewModel
{
    // base main page view model
    public class MainViewModel : ViewModelBase
    {
// view bools
        public bool IsPaneOpen { get; private set; }

// commands
        public RelayCommand<Page> ViewLoadedCommand { get; private set; }       
        public RelayCommand<Frame> PaneContentFrameLoadedCommand { get; private set; }
        public RelayCommand<SizeChangedEventArgs> PageSizeChangedCommand { get; private set; }
        public RelayCommand OpenClosePaneButtonTappedCommand { get; private set; }
        public RelayCommand<ManipulationStartedRoutedEventArgs> SplitViewManipulationStartedCommand { get; private set; }
        public RelayCommand<ManipulationDeltaRoutedEventArgs> SplitViewManipulationDeltaCommand { get; private set; }
        public RelayCommand<ManipulationCompletedRoutedEventArgs> SplitViewManipulationCompletedCommand { get; private set; }

// privates
        private GesturesDetector _detector { get; set; }

// constructors
        public MainViewModel()
        {
            ViewLoadedCommand = new RelayCommand<Page>(ViewLoaded);
            PaneContentFrameLoadedCommand = new RelayCommand<Frame>(PaneContentFrameLoaded);
            PageSizeChangedCommand = new RelayCommand<SizeChangedEventArgs>(PageSizeChanged);
            OpenClosePaneButtonTappedCommand = new RelayCommand(OpenClosePaneButtonTapped);
            SplitViewManipulationStartedCommand = new RelayCommand<ManipulationStartedRoutedEventArgs>(SplitViewManipulationStarted);
            SplitViewManipulationDeltaCommand = new RelayCommand<ManipulationDeltaRoutedEventArgs>(SplitViewManipulationDelta);
            SplitViewManipulationCompletedCommand = new RelayCommand<ManipulationCompletedRoutedEventArgs>(SplitViewManipulationCompleted);

            _detector = new GesturesDetector();
            RaisePropertyChanged("HidePane");
        }

// methods       
        void ViewLoaded(Page page)
        {
        } 
        
        void PaneContentFrameLoaded(Frame frame)
        {
            App.PaneContentFrame = frame;
            // TODO: navigate to any page except MainPage!
            // App.PaneContentFrame.Navigate(typeof('Page Class'));
        }

        void PageSizeChanged(SizeChangedEventArgs args)
        {
        }

        void OpenClosePaneButtonTapped()
        {
            if (IsPaneOpen)
            {
                IsPaneOpen = false;
            }
            else
            {
                IsPaneOpen = true;
            }
            RaisePropertyChanged("IsPaneOpen");
        }

        void SplitViewManipulationStarted(ManipulationStartedRoutedEventArgs args)
        {
            _detector.GestureStarted(args.Position);
        }

        void SplitViewManipulationDelta(ManipulationDeltaRoutedEventArgs args)
        {
            HnadleDetectingResult(_detector.GestureInProgress(args.Position));
        }

        void SplitViewManipulationCompleted(ManipulationCompletedRoutedEventArgs args)
        {
            HnadleDetectingResult(_detector.GestureEnded(args.Position));
        }

        void HnadleDetectingResult(int result)
        {
            switch (result)
            {
                case -1:
                    IsPaneOpen = false;
                    break;
                case 1:
                    IsPaneOpen = true;
                    break;
                default:
                    break;
            }
            RaisePropertyChanged("IsPaneOpen");
        }
    }
}
