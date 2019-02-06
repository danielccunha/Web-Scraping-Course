using HtmlAgilityPack;

namespace Bots.Instagram.Profile
{
    public class Profile
    {
        public string Username { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public string IosAppName { get; set; }
        public string IosAppId { get; set; }
        public string IosUrl { get; set; }
        public string AndroidAppName { get; set; }
        public string AndroidAppId { get; set; }
        public string AndroidUrl { get; set; }

        public Profile(string username)
        {
            Username = username;
        }

        internal void MapMetas(HtmlNodeCollection metas)
        {
            foreach (HtmlNode node in metas)
            {
                string property = node.GetAttributeValue("property", "");

                if (property == "al:ios:app_name")
                    IosAppName = node.GetAttributeValue("content", "");

                if (property == "al:ios:app_store_id")
                    IosAppId = node.GetAttributeValue("content", "");

                if (property == "al:ios:url")
                    IosUrl = node.GetAttributeValue("content", "");

                if (property == "al:android:app_name")
                    AndroidAppName = node.GetAttributeValue("content", "");

                if (property == "al:android:package")
                    AndroidAppId = node.GetAttributeValue("content", "");

                if (property == "al:android:url")
                    AndroidUrl = node.GetAttributeValue("content", "");

                if (property == "og:type")
                    Type = node.GetAttributeValue("content", "");

                if (property == "og:image")
                    Image = node.GetAttributeValue("content", "");

                if (property == "og:title")
                    Title = node.GetAttributeValue("content", "");

                if (property == "og:description")
                    Description = node.GetAttributeValue("content", "");

                if (property == "og:url")
                    Url = node.GetAttributeValue("content", "");
            }
        }
    }
}
