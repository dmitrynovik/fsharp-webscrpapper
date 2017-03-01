namespace Lonsec.WebScrapper

open System.IO

module SiteList =
    
    let all = [
        { 
            url = "http://morningstar.com.au";
            articleRootSelector = ".storyPageHolder";
            newslinkSelector = (fun(url:string) -> url.Contains("/article/"));
            outPath = Path.GetTempPath() + "out\\";
        }
    ]

