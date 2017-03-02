namespace Lonsec.WebScrapper

open System.IO

module SiteList =
    
    let all = [|
        { 
            url = "http://morningstar.com.au";
            newslinkSelector = (fun(url:string) -> url.Contains("/article/"));
            articleRootSelector = ".storyPageHolder";
            outPath = Path.GetTempPath() + "scrappy\\Morningstar\\";
            categories = [];
        };
        { 
            url = "http://morningstar.com.au/Funds";
            newslinkSelector = (fun(url:string) -> url.Contains("/article/"));
            articleRootSelector = ".storyPageHolder";
            outPath = Path.GetTempPath() + "scrappy\\Morningstar\\Funds\\";
            categories = [{ name = "funds"; weight = 1.0 }];
        }
    |]

