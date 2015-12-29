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

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace HamburgerMenu
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var coreTitleBar = Windows.ApplicationModel.Core.CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            Window.Current.SetTitleBar(BarGrid);
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            if(MySplitView.IsPaneOpen)
            {
                MySplitView.OpenPaneLength = MySplitView.CompactPaneLength;
            }
            else
            {
                MySplitView.OpenPaneLength = 150;
            }
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void MenuListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var menuListBox = sender as ListBox;
            if(menuListBox != null)
            {
                if(menuListBox.SelectedItem == HomeMenu)
                {
                    ContentFrame.Navigate(typeof(HomePage));
                }
                else if(menuListBox.SelectedItem == FavoriteMenu)
                {
                    ContentFrame.Navigate(typeof(FavoritePage));
                }
            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            if(ContentFrame.CanGoBack)
            {
                ContentFrame.GoBack();
            }
        }
    }
}
