
namespace Crawler
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Crawler crawler = new();

            crawler.ProductPages.ForEach((page) =>
            {
                crawler.OpenBrowser(Crawler.GermanDomain + page);
            });
        }
    }
    
}