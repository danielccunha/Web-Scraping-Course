using HtmlAgilityPack;
using System.Net;

namespace Bots.Instagram.Profile
{
    public static class Instagram
    {
        public static Profile GetProfileByUser(string username)
        {
            Profile profile = new Profile(username);
            string url = $"https://www.instagram.com/{username}/";
            string html = string.Empty;

            using (WebClient client = new WebClient())
                html = client.DownloadString(url);

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            HtmlNodeCollection metas = doc.DocumentNode.SelectNodes("//meta");
            profile.MapMetas(metas);

            return profile;
        }
    }
}
