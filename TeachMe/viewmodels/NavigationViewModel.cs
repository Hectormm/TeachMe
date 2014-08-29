using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Controls;
using CommonMvvm;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media.Imaging;
using TeachMe.viewmodels;
using TeachMe;
using TeachMe.Views;


namespace TeachMe.viewmodels
{
    public sealed class NavigationViewModel : ObservableObject
    {
        Frame currentFrame;
        Frame currentFrameNav;
        Page currentPage;
        Page currentPageNav;
        int image;
        int otherUser;
        int comment;
        Stack<Page> back;
        Stack<Page> forward;
        String imagePath;
        String icon;
   
        
        static readonly NavigationViewModel instance = new NavigationViewModel();
        private volatile object locker = new object();

        static NavigationViewModel()
        {
            
            /*instance.currentPage = new Botonera();
            instance.currentPage.DataContext = new CategoriaViewModel();*/
            instance.currentPageNav = new NavVerbos();
            //instance.currentPageNav.DataContext = new verbosViewModel();

            TeachMe.viewmodels.NavigationViewModel.instance.currentPage = new pageVerbs();
            TeachMe.viewmodels.NavigationViewModel.instance.currentPage.DataContext = new verbosViewModel();

         
            instance.Back = new Stack<Page>();
            instance.Forward = new Stack<Page>();
            //Instance.Icon = "/PetstoreGen_WPF;images/petstore.png";
         
        }

        private NavigationViewModel() { }

        public static NavigationViewModel Instance
        {
            get
            {
                return instance;
            }
        }

        public Frame CurrentFrame
        {
            get { return currentFrame; }
            set { currentFrame = value; }
        }

        public Frame CurrentFrameNav
        {
            get { return currentFrameNav; }
            set { currentFrameNav = value; }
        }

        public Page CurrentPage
        {
            get { return currentPage; }
            set
            {
                if (currentPage != value)
                {
                    currentPage = value;
                    currentPage.ShowsNavigationUI = false;
                    RaisePropertyChanged("CurrentPage");
                }
            }
        }

        public Page CurrentPageNav
        {
            get { return currentPageNav; }
            set
            {
                if (currentPageNav != value)
                {
                    currentPageNav = value;
                    RaisePropertyChanged("CurrentPageNav");
                }
            }
        }

        public int Image
        {
            get { return image; }
            set
            {
                if (image != value)
                {
                    image = value;
                    RaisePropertyChanged("Image");
                }
            }
        }

        public int OtherUser
        {
            get { return otherUser; }
            set
            {
                if (otherUser != value)
                {
                    otherUser = value;
                    RaisePropertyChanged("OtherUser");
                }
            }
        }

        public int Comment
        {
            get { return comment; }
            set
            {
                if (comment != value)
                {
                    comment = value;
                    RaisePropertyChanged("Comment");
                }
            }
        }

        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                if (imagePath != value)
                {
                    imagePath = value;
                    RaisePropertyChanged("ImagePath");
                }
            }
        }

        public string Icon
        {
            get { return icon; }
            set
            {
                if (icon != value)
                {
                    icon = value;
                    RaisePropertyChanged("Icon");
                }
            }
        }

     
    
        public Stack<Page> Back
        {
            get { return back; }
            set
            {
                if (back != value)
                {
                    back = value;
                    RaisePropertyChanged("Back");
                }
            }
        }

        public Stack<Page> Forward
        {
            get { return forward; }
            set
            {
                if (forward != value)
                {
                    forward = value;
                    RaisePropertyChanged("Forward");
                }
            }
        }

        #region Methods

        public void pushBackStack()
        {
            Instance.Back.Push(Instance.CurrentPage);
        }

        public void pushForwardStack()
        {
            Instance.Forward.Push(Instance.CurrentPage);
        }

        public void popBackStack()
        {
            Instance.CurrentPage = Instance.Back.Pop();
        }

        public void popForwardStack()
        {

            Instance.currentPage = Instance.Forward.Pop();
        }

        

        public void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = Application.Current.MainWindow.Width;
            double windowHeight = Application.Current.MainWindow.Height;
            Application.Current.MainWindow.Left = (screenWidth / 2) - (windowWidth / 2);
            Application.Current.MainWindow.Top = (screenHeight / 2) - (windowHeight / 2);
        }
        #endregion
    }
}
