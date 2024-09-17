using System;
using System.Text.RegularExpressions;
using System;
using System.IO;
using System.Text;

namespace Perle.com.RazorGen
{
    public class RazorGen
    {
        public readonly List<string> IgnoreList = new()
        {
            "10-100-1000-Ethernet-Extenders.cshtml",
            "10-100-1000-media-converter.cshtml",
            "10-gigabit-media-converters.cshtml",
            "10g-rate-converters.cshtml",
            "ethernet-to-fiber-media-converter.cshtml",
            "poe-media-converters.cshtml",
            "10-100-converter.cshtml",
            "console-server.cshtml",
            "device-server.cshtml",
            "discontinuations.cshtml",
            "ethernet-extenders.cshtml",
            "fast-ethernet-converter.cshtml",
            "fiber-media-converter.cshtml",
            "fiber-to-fiber-media-converter.cshtml",
            "gigabit-media-converter.cshtml",
            "multiport-serial-card.cshtml",
            "Parallel-Card.cshtml",
            "sfp-to-sfp-converters.cshtml",
            "terminal-server.cshtml",
            "uno-1-phase.cshtml",
            "index.cshtml",
            "1-port-injectors.cshtml",
            "serial-to-fiber-media-converter.cshtml",
            "industrial-ethernet-switch.cshtml",
            "industrial-managed-ethernet-switch.cshtml",
            "industrial-poe-switch.cshtml",
            "industrial-unmanaged-ethernet-switch.cshtml",
            "perleview-download.cshtml",
            "10-100-ethernet-extenders.cshtml",
            "10g-optical-transceiver.cshtml",
            "Ethernet-Extender-Chassis-Modules.cshtml",
            "fast-ethernet-fiber-media-converter.cshtml",
            "gigabit-fiber-media-converter.cshtml",
            "industrial-temperature-ethernet-extenders.cshtml",
            "poe-ethernet-extender.cshtml",
            "rs232-to-ethernet.cshtml",
            "rs485-to-ethernet.cshtml",
            "serial-hub.cshtml",
            "serial-ip.cshtml",
            "serial-over-ethernet.cshtml",
            "serial-to-ethernet.cshtml",
            "stand-alone-fiber-media-converter.cshtml",
            "stand-alone-managed-media-converter.cshtml",
            "stand-alone-media-converter.cshtml",
            "din-rail-media-converters.cshtml",
            "sfp-media-converter.cshtml",
            "comprehensive-vs-pro.cshtml",
            "industrial-temperature-media-converters.cshtml"
        };
        public List<string> productPageUrls = new();
        public readonly string OutpuTFileDir = @"C:\Users\MichaelFalconi\Desktop\websites\perlesystems.es\perlesystems.es\Views\Products\allproducts\industrial-power-supply";
        public readonly string InputFileDir = @"C:\Users\MichaelFalconi\Downloads\perlewebsites\perlesystems.es\perlesystems.es\products\industrial-power-supply";
        private List<string> FileNames = new List<string>();      
        private readonly string templateNormalPage = "<main>\n\r    <div class=\"container productPageCard\">\n\r        <partial name=\"../Shared/ProductPages/_productHeader\" model=\"@Model\" />\n\r        <div class=\"container-fluid px-xs-0\">\n\r            <partial name=\"../Shared/ProductPages/_tabs\" model=\"@Model\" />\n\r            <div class=\"tab-content print-only\" id=\"productTabs\">\n\r                \n\r            <partial name=\"../Shared/ProductPages/_tabsContent\"\n\r                     model=\"@Model\" />\n\r            </div>\n\r        </div>    \n\r    </div>\n\r</main>\n\r\n\r<partial name=\"../Shared/ProductPages/_productModal\" />\n\r@section meta {\n\r    <partial name=\"_metaContent\" model=\"Model.MetaData\" />\n\r}\n\r@section css {\n\r    <link rel=\"stylesheet\" href=\"~/css/productPage.css\" asp-append-version=\"true\" preload as=\"style\">\n\r}\n\r\n\r@section scripts {\n\r    <script src=\"~/js/productsCommon.js\" asp-append-version=\"true\" async></script>\n\r    <script src=\"~/dist/partNumbersFilterScript.entry.js\" asp-append-version=\"true\" async></script>\n\r}\n\r";
        private readonly string templateMcrDemoBtn = "<main>\n\r    <div class=\"container productPageCard\">\n\r        <partial name=\"../Shared/ProductPages/_productHeader\" model=\"@Model\" view-data='new ViewDataDictionary(ViewData) { { \"btn\", new Button(\"DemoBtnTxt\", \"/contactus/mcrdemo\", \"fas fa-play\") }}' />\n\r        <div class=\"container-fluid px-xs-0\">\n\r            <partial name=\"../Shared/ProductPages/_tabs\" model=\"@Model\" />\n\r            <div class=\"tab-content print-only\" id=\"productTabs\">\n\r                \n\r            <partial name=\"../Shared/ProductPages/_tabsContent\"\n\r                     model=\"@Model\" />\n\r            </div>\n\r        </div>    \n\r    </div>\n\r</main>\n\r\n\r<partial name=\"../Shared/ProductPages/_productModal\" />\n\r@section meta {\n\r    <partial name=\"_metaContent\" model=\"Model.MetaData\" />\n\r}\n\r@section css {\n\r    <link rel=\"stylesheet\" href=\"~/css/productPage.css\" asp-append-version=\"true\" preload as=\"style\">\n\r}\n\r\n\r@section scripts {\n\r    <script src=\"~/js/productsCommon.js\" asp-append-version=\"true\" async></script>\n\r    <script src=\"~/dist/partNumbersFilterScript.entry.js\" asp-append-version=\"true\" async></script>\n\r}\n\r";
        private readonly string templateIOLANDemoBtn = "<main>\n\r    <div class=\"container productPageCard\">\n\r        <partial name=\"../Shared/ProductPages/_productHeader\" model=\"@Model\" view-data='new ViewDataDictionary(ViewData) { { \"btn\", new Button(\"DemoBtnTxt\", \"/contactus/iolandemo\", \"fas fa-play\") }}' />\n\r        <div class=\"container-fluid px-xs-0\">\n\r            <partial name=\"../Shared/ProductPages/_tabs\" model=\"@Model\" />\n\r            <div class=\"tab-content print-only\" id=\"productTabs\">\n\r                \n\r            <partial name=\"../Shared/ProductPages/_tabsContent\"\n\r                     model=\"@Model\" />\n\r            </div>\n\r        </div>    \n\r    </div>\n\r</main>\n\r\n\r<partial name=\"../Shared/ProductPages/_productModal\" />\n\r@section meta {\n\r    <partial name=\"_metaContent\" model=\"Model.MetaData\" />\n\r}\n\r@section css {\n\r    <link rel=\"stylesheet\" href=\"~/css/productPage.css\" asp-append-version=\"true\" preload as=\"style\">\n\r}\n\r\n\r@section scripts {\n\r    <script src=\"~/js/productsCommon.js\" asp-append-version=\"true\" async></script>\n\r    <script src=\"~/dist/partNumbersFilterScript.entry.js\" asp-append-version=\"true\" async></script>\n\r}\n\r";
        private readonly string templatePowerSupFilterBtn = "<main>\n\r    <div class=\"container productPageCard\">\n\r        <partial name=\"../Shared/ProductPages/_productHeader\" model=\"@Model\" view-data='new ViewDataDictionary(ViewData) { { \"btn\", new Button(\"FilterBtnTxt\", \"/product-selector/power-supply/\", \"fas fa-filter\") }}' />\n\r        <div class=\"container-fluid px-xs-0\">\n\r            <partial name=\"../Shared/ProductPages/_tabs\" model=\"@Model\" />\n\r            <div class=\"tab-content print-only\" id=\"productTabs\">\n\r                \n\r            <partial name=\"../Shared/ProductPages/_tabsContent\"\n\r                     model=\"@Model\" />\n\r            </div>\n\r        </div>    \n\r    </div>\n\r</main>\n\r\n\r<partial name=\"../Shared/ProductPages/_productModal\" />\n\r@section meta {\n\r    <partial name=\"_metaContent\" model=\"Model.MetaData\" />\n\r}\n\r@section css {\n\r    <link rel=\"stylesheet\" href=\"~/css/productPage.css\" asp-append-version=\"true\" preload as=\"style\">\n\r}\n\r\n\r@section scripts {\n\r    <script src=\"~/js/productsCommon.js\" asp-append-version=\"true\" async></script>\n\r    <script src=\"~/dist/partNumbersFilterScript.entry.js\" asp-append-version=\"true\" async></script>\n\r}\n\r";

        public void GenFiles()
        {
            Directory.GetFiles(OutpuTFileDir, "*").ToList().ForEach(entry =>
            {                  
                string url = entry.Substring(entry.LastIndexOf("\\") + 1);                              
                if (!entry.Contains("index") && !entry.Contains("assets") && !entry.Contains("techspecs") && !entry.Contains(".aspx") && !entry.Contains(".xml"))
                {                    
                    string s = entry.Substring(entry.LastIndexOf("\\") + 1);                                    
                    if (!IgnoreList.Contains(s) && File.Exists(@$"{InputFileDir}\{url.Substring(0, url.LastIndexOf(".")).ToLower()}.shtml"))
                    {                        
                        Console.WriteLine(@$"{InputFileDir}\{url.Substring(0, url.LastIndexOf(".")).ToLower()}.shtml");    
                        var oldHtml = File.ReadAllText(@$"{InputFileDir}\{url.Substring(0, url.LastIndexOf(".")).ToLower()}.shtml");            
                        //Console.WriteLine(url);
                        if(oldHtml.Contains("template = datasheet-page"))
                        {
                            if(oldHtml.Contains("/contactus/mcrdemo") || oldHtml.Contains("/contactus/media_converter_demo") || ( oldHtml.Contains("vendor_lookup_table.shtml") && oldHtml.ToLower().Contains("demo") ) )
                                GenProdPage(entry, url, templateMcrDemoBtn);
                            else if(oldHtml.Contains("/contactus/iolandemo") || oldHtml.Contains("/contactus/iolan_demo"))
                                GenProdPage(entry, url, templateIOLANDemoBtn);
                            else if(oldHtml.Contains("/product-selector/power-supply/"))
                                GenProdPage(entry, url, templatePowerSupFilterBtn);
                            else
                                GenProdPage(entry, url, templateNormalPage);
                        }
                        else{
                            Console.WriteLine($"could not write non datasheet page {entry}");
                        }
                    }
                    else{
                        Console.WriteLine($"could not write ignored page {entry}");
                        }
                }else
                {
                    Console.WriteLine($"could not write index page  {entry}");
                }
            });            
        }  

        public void GenProdPage( string entry, string url, string template)
        {                                     
            Console.WriteLine(url);                        
            var html = File.ReadAllText(@$"{InputFileDir}\{url.Substring(0, url.LastIndexOf(".")).ToLower()}.shtml");                        
            if(html.Contains("tab-content"))
            {
                Console.WriteLine($"Writing {entry} ");
                html = html.Substring(html.IndexOf("<main"));
                html += template;
                File.WriteAllText(@$"{OutpuTFileDir}\{url.Substring(0, url.LastIndexOf(".")).ToLower()}.cshtml", html, new System.Text.UTF8Encoding(false));
                Console.WriteLine($"Completed {entry} ");
            }
        }

        public void SaveUtf8(string entry, string url)
        {
            url = "quint-3-phase.shtml";
            var html = File.ReadAllText(@$"{OutpuTFileDir}\{url.Substring(0, url.LastIndexOf(".")).ToLower()}.cshtml", Encoding.GetEncoding(28591));          
            File.WriteAllText(@$"{OutpuTFileDir}\{url.Substring(0, url.LastIndexOf(".")).ToLower()}.cshtml", html, new System.Text.UTF8Encoding(false));
        }

        public void GenFilesCaseStudy()
        {
            Directory.GetFiles(OutpuTFileDir, "*").ToList().ForEach(entry =>
            {
                if (!entry.Contains("Index") && !entry.Contains("assets") && !entry.Contains("techspecs") && !entry.Contains(".aspx") && !entry.Contains(".xml"))
                {
                    string s = entry.Substring(entry.LastIndexOf("\\") + 1);
                    if (!IgnoreList.Contains(s))
                    {
                        Console.WriteLine(entry);                        
                        string url = entry.Substring(entry.LastIndexOf("\\") + 1);
                        Console.WriteLine(url);                        
                        var html = File.ReadAllText(@$"{OutpuTFileDir}\{url.Substring(0, url.LastIndexOf(".")).ToLower()}.cshtml");                        
                        if(html.Contains("ProductPageViewModel"))
                        {
                            html = html.Substring(0, html.IndexOf("<main"));
                            html += templateNormalPage;
                            File.WriteAllText(@$"{OutpuTFileDir}\{url.Substring(0, url.LastIndexOf(".")).ToLower()}.cshtml", html);
                        }
                    }
                }
            });            
        }  
    }

    class main{
        static void Main(string[] args)
        {
           RazorGen r=new();
           r.GenFiles();
        }
    }
}