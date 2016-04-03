using System;
using System.Collections;
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
using System.Windows.Forms;

namespace RSSApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TitleListBox.Items.Count > 0)
            {
                TitleListBox.Items.Clear();
                DescriptionListBox.Items.Clear();
                EpisodeListBox.Items.Clear();
                downloadLinkListBox.Items.Clear();
                urlDisplay.Items.Clear();
            }
            if (EZTVRBtn.IsChecked.Value)
            {
                string url = "https://eztv.ag/ezrss.xml";
                FeedReader fReader = new FeedReader();
                var reader = fReader.reader(url);
                foreach (string title in fReader.TorrentTitle(reader))
                {
                    TitleListBox.Items.Add(title);

                }

                foreach (string date in fReader.TorrentDate(reader))
                {
                    EpisodeListBox.Items.Add(date);
                }
                foreach (string description in fReader.tvDescription(reader))
                {
                    DescriptionListBox.Items.Add(description);
                }
                foreach (var downloadLink in fReader.downloadLink(reader))
                {
                    downloadLinkListBox.Items.Add(downloadLink);
                    downloadLinkListBox.Items.Add(downloadLink);
                }
            }
            else if (YIFYRBtn.IsChecked.Value)
            {
                if (TitleListBox.Items.Count > 0)
                {
                    TitleListBox.Items.Clear();
                    DescriptionListBox.Items.Clear();
                    EpisodeListBox.Items.Clear();
                    downloadLinkListBox.Items.Clear();
                    urlDisplay.Items.Clear();
                }
                string url = "https://yts.ag/rss";
                FeedReader fReader = new FeedReader();
                var reader = fReader.reader(url);
                foreach (string title in fReader.TorrentTitle(reader))
                {
                    TitleListBox.Items.Add(title);
                }

                foreach (string date in fReader.TorrentDate(reader))
                {
                    EpisodeListBox.Items.Add(date);
                }
                foreach (string description in fReader.TorrecntDescription(reader))
                {
                    DescriptionListBox.Items.Add(description);
                }
                foreach (var downloadLink in fReader.downloadLink(reader))
                {
                    downloadLinkListBox.Items.Add(downloadLink);
                    downloadLinkListBox.Items.Add(downloadLink);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

            //foreach (string fileType in fReader.TorrentFileType(url))
            //{
            //    FileTypeListBox.Items.Add(fileType);
            //}



        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (urlDisplay.Items.Count > 0)
            {
                urlDisplay.Items.Clear();
            }
            else
            {

                int downloadLinkIndex = downloadLinkListBox.SelectedIndex;
                FeedReader fReader = new FeedReader();
                List<string> links = new List<string>();
                string url = "";
                if (EZTVRBtn.IsChecked.Value)
                {
                    url = "https://eztv.ag/ezrss.xml";
                }
                else if (YIFYRBtn.IsChecked.Value)
                {
                    url = "https://yts.ag/rss";
                }
                var reader = fReader.reader(url);
                int count = 0;
                foreach (var link in fReader.downloadLink(reader))
                {
                    
                    if (count == downloadLinkIndex)
                    {
                        string downloadLinkUrl = link;
                        urlDisplay.Items.Add(downloadLinkUrl);
                    }
                    count++;

                }
            }

        }

        private void ListBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TitleListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (TitleListBox.SelectedItems.Count > 0)
            //{
            //    int indexSelect = 0;
            //    DescriptionListBox.SelectedIndex(indexSelect);
            //}
        }
    }
}
