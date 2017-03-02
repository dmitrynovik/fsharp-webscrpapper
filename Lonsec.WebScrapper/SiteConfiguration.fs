namespace Lonsec.WebScrapper

type Classification = {
    name: string;
    weight: float;
}

type SiteConfiguration = {  
    url: string; 
    categories: seq<Classification>;
    outPath: string;
    newslinkSelector: string -> bool; 
    articleRootSelector: string;
}

