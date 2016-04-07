using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.ServiceModel.Syndication;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace RSSApp
{
    class FeedReader
    {
        List<string> tvdescriptionlist = new List<string>();
        List<string> downloadLinkList = new List<string>();
        List<string> torrentDescriptionList = new List<string>();
        List<string> dateoutput = new List<string>();
        List<string> list = new List<string>();
        List<string> feedItems = new List<string>();


        public SyndicationFeed reader(string url)
        {

            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            return feed;
        }
        
        public List<string> tFileReader(SyndicationFeed feed)
        {

            foreach (SyndicationItem item in feed.Items)
            {

                String title = item.Title.Text;
                if (title != null)
                {
                    string videoTitle = ("Title: " + TitleParser(title));
                    string category =("Category: " + item.Categories[0].Name);
                    string uriLink = ("Uri: " + item.Links[1].Uri);
                    feedItems.Add(videoTitle);
                    feedItems.Add(category);
                    feedItems.Add(uriLink);
                }


            }

            return feedItems;


        }

        public List<string> TorrentTitle(SyndicationFeed feed)
        {


            foreach (var item in feed.Items)
            {
                var title = item.Title.Text;
                if (title != null) list.Add(TitleParser(title));
            }
            return list; 
        }

        public List<string> TorrentDate(SyndicationFeed feed)
        {
            
            
            foreach (var item in feed.Items)
            {
                dateoutput.Add(item.PublishDate.DateTime.Date.ToLongDateString());

            }
            return dateoutput;
        }

        public List<string> TorrecntDescription(SyndicationFeed feed)
        {
            
            foreach (var item in feed.Items)
            {
                torrentDescriptionList.Add(item.Summary.Text);
            }

            return torrentDescriptionList;
        }

        public List<string> tvDescription(SyndicationFeed feed)
        {
            
            foreach (var item in feed.Items)
            {
                tvdescriptionlist.Add(item.Id);
            }
            return tvdescriptionlist;
        }

        public List<string> downloadLink(SyndicationFeed feed)
        {
            
            foreach (var item in feed.Items)
            {
                downloadLinkList.Add(item.Links[1].Uri.ToString());
            }
            return downloadLinkList;
        }

        public string pendingDownloadTorrent(int index, SyndicationFeed feed)
        {
            foreach (var item in feed.Items)
            {
                downloadLinkList.Add(item.Links[1].Uri.ToString());
            }
            string downloadLink = downloadLinkList[index];
            return downloadLink;
        } 







#region string Parser

        public string TitleParser(string title)
        {
            String newtitle = String.Empty;
            for (int i = 0; i < title.Length; i++)
            {
                newtitle = newtitle + title[i];
                if (i > 100)
                {
                    i = title.Length;
                }
            }
            return newtitle;
        }
    }
#endregion
}
