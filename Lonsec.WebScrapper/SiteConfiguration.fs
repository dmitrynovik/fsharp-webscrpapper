namespace Lonsec.WebScrapper

type SiteConfiguration = {  
                            url: string; 
                            articleRootSelector: string;
                            newslinkSelector: string -> bool; 
                            outPath: string 
                         }

