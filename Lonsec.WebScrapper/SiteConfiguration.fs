namespace Lonsec.WebScrapper

type Classification = {
    name: string;
    weight: float;
}

type SiteConfiguration = {  
    url: string; 
    articleRootSelector: string;
    newslinkSelector: string -> bool; 
    outPath: string;
    categories: seq<Classification>;
}

