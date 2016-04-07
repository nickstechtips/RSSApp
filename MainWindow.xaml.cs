using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
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
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace RSSApp
{ 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string ytsurl = "https://yts.ag/rss";
        public string eztvurl = "https://eztv.ag/ezrss.xml";
        
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TitleListBox.SelectedItems.Count > 0)
            {
                TitleListBox.SelectedIndex = -1;
            }

                TitleListBox.Items.Clear();
                DescriptionListBox.Items.Clear();
                EpisodeListBox.Items.Clear();
                downloadLinkListBox.Items.Clear();
                
            
            if (EZTVRBtn.IsChecked.Value)
            {
                
                FeedReader fReader = new FeedReader();
                var reader = fReader.reader(eztvurl);
                foreach (string title in fReader.TorrentTitle(reader))
                {
                    TitleListBox.Items.Add(title);

                }

            }
            else if (YIFYRBtn.IsChecked.Value)
            {
               

                
                FeedReader fReader = new FeedReader();
                var reader = fReader.reader(ytsurl);
                foreach (string title in fReader.TorrentTitle(reader))
                {
                    TitleListBox.Items.Add(title);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

            


        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            int downloadLinkIndextitle = TitleListBox.SelectedIndex;


                FeedReader fReader = new FeedReader();
                var reader = fReader.reader(eztvurl);
                urlDisplay.Items.Add(fReader.pendingDownloadTorrent(downloadLinkIndextitle, reader));                
            
            
         }

        

        private void ListBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TitleListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FeedReader fReader = new FeedReader();
            string url = "";
            if (EZTVRBtn.IsChecked.Value)
            {
                url = eztvurl;

            }
            else if (YIFYRBtn.IsChecked.Value)
            {
                url = ytsurl;

            }

            var reader = fReader.reader(url);
            if (TitleListBox.SelectedIndex > 0)
            {


                EpisodeListBox.Items.Add(fReader.TorrentDate(reader)[TitleListBox.SelectedIndex]);
                if (url == eztvurl)
                {
                    DescriptionListBox.Items.Add(fReader.tvDescription(reader)[TitleListBox.SelectedIndex]);
                }
                else
                {
                    DescriptionListBox.Items.Add(fReader.TorrecntDescription(reader)[TitleListBox.SelectedIndex]);
                }
                downloadLinkListBox.Items.Add(fReader.downloadLink(reader)[TitleListBox.SelectedIndex]);
            }
        }
        

        private void CustomRBtn_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ClearAllBtn_Click(object sender, RoutedEventArgs e)
        {
            urlDisplay.Items.Clear();
        }

        private void clearSelectedBtn_Click(object sender, RoutedEventArgs e)
        {
            int linkIndex = urlDisplay.SelectedIndex;

            if (linkIndex >= 0)
            {
                urlDisplay.Items.RemoveAt(linkIndex);
            }
        }

        private void YIFYRBtn_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void downloadBtn_Click(object sender, RoutedEventArgs e)
        {
            List<string> downloadLinks = new List<string>();
            List<string> currentLinks = new List<string>();
            int currentCount = DLLBox.Items.Count;
            foreach (string item in urlDisplay.Items)
            {
                
                downloadLinks.Add(item);
            }

            foreach (string link in downloadLinks)
            {
                if (downloadLinks.Count >= currentCount && currentCount != 0)
                {

                        for (int i = 0; i < downloadLinks.Count; i++)
                        {
                            
                    
                        if (DLLBox.Items[i].ToString() != link)
                        {
                            DLLBox.Items.Add(link);
                            currentLinks.Add(link);
                        }
                    }
                }
                else
                {
                    DLLBox.Items.Add(link);
                    currentLinks.Add(link);
                }


            }
        }
    }
}
