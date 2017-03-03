namespace Lonsec.WebScrapper.Runner

open System.IO
open Lonsec.WebScrapper

module SiteList =
    
    let all = [|
        { 
            url = "http://morningstar.com.au";
            newslinkSelector = (fun(url:string) -> url.Contains("/article/"));
            articleRootSelectors = [|".storyPageHolder"|];
            outPath = Path.GetTempPath() + "scrappy\\morningstar.com.au\\";
            categories = [];
        };
        { 
            url = "http://morningstar.com.au/Funds";
            newslinkSelector = (fun(url:string) -> url.Contains("/article/"));
            articleRootSelectors = [|".storyPageHolder"|];
            outPath = Path.GetTempPath() + "scrappy\\morningstar.com.au\\funds\\";
            categories = [{ name = "Funds"; weight = 1.0 }];
        };
        { 
            url = "http://moneymanagement.com.au/news";
            newslinkSelector = (fun(url:string) -> url.Contains("/news/"));
            articleRootSelectors = [|".cm-article-body"; ".News"|];
            outPath = Path.GetTempPath() + "scrappy\\moneymanagement.com.au\\";
            categories = [];
        };
        { 
            url = "http://moneymanagement.com.au/funds-management";
            newslinkSelector = (fun(url:string) -> url.Contains("/news/"));
            articleRootSelectors = [|".cm-article-body"; ".News"|];
            outPath = Path.GetTempPath() + "scrappy\\moneymanagement.com.au\\funds\\";
            categories = [{ name = "funds"; weight = 1.0 }];
        };
        { 
            url = "http://moneymanagement.com.au/news/financial-planning";
            newslinkSelector = (fun(url:string) -> url.Contains("/news/"));
            articleRootSelectors = [|".cm-article-body"; ".News"|];
            outPath = Path.GetTempPath() + "scrappy\\moneymanagement.com.au\\financial-planning\\";
            categories = [{ name = "financial-planning"; weight = 1.0 }];
        };
        { 
            url = "http://moneymanagement.com.au/news/superannuation";
            newslinkSelector = (fun(url:string) -> url.Contains("/news/"));
            articleRootSelectors = [|".cm-article-body"; ".News"|];
            outPath = Path.GetTempPath() + "scrappy\\moneymanagement.com.au\\superannuation\\";
            categories = [{ name = "superannuation"; weight = 1.0 }];
        };
        { 
            url = "http://moneymanagement.com.au/news/people-products";
            newslinkSelector = (fun(url:string) -> url.Contains("/news/"));
            articleRootSelectors = [|".cm-article-body"; ".News"|];
            outPath = Path.GetTempPath() + "scrappy\\moneymanagement.com.au\\people-products\\";
            categories = [{ name = "people-products"; weight = 1.0 }];
        };
        {
            url = "http://www.investordaily.com.au/all-news";
            newslinkSelector = fun(url:string) -> true;
            articleRootSelectors = [|"article"|];
            outPath = Path.GetTempPath() + "scrappy\\investordaily.com.au\\";
            categories = [];
        };
        {
            url = "http://www.investordaily.com.au/markets";
            newslinkSelector = fun(url:string) -> true;
            articleRootSelectors = [|"article"|];
            outPath = Path.GetTempPath() + "scrappy\\investordaily.com.au\\markets";
            categories = [{name = "markets"; weight = 1.0}];
        };
        {
            url = "http://www.investordaily.com.au/regulation";
            newslinkSelector = fun(url:string) -> true;
            articleRootSelectors = [|"article"|];
            outPath = Path.GetTempPath() + "scrappy\\investordaily.com.au\\regulation";
            categories = [{name = "regulation"; weight = 1.0}];
        };
        {
            url = "http://www.investordaily.com.au/appointments";
            newslinkSelector = fun(url:string) -> true;
            articleRootSelectors = [|"article"|];
            outPath = Path.GetTempPath() + "scrappy\\investordaily.com.au\\appointments";
            categories = [{name = "appointments"; weight = 1.0}];
        };
        {
            url = "http://www.investordaily.com.au/superannuation";
            newslinkSelector = fun(url:string) -> true;
            articleRootSelectors = [|"article"|];
            outPath = Path.GetTempPath() + "scrappy\\investordaily.com.au\\superannuation";
            categories = [{name = "superannuation"; weight = 1.0}];
        };
        {
            url = "http://www.investordaily.com.au/mergers-acquisitions";
            newslinkSelector = fun(url:string) -> true;
            articleRootSelectors = [|"article"|];
            outPath = Path.GetTempPath() + "scrappy\\investordaily.com.au\\mergers-acquisitions";
            categories = [{name = "mergers-acquisitions"; weight = 1.0}];
        };
        {
            url = "https://cuffelinks.com.au";
            newslinkSelector = fun(url:string) -> true;
            articleRootSelectors = [|"article"|];
            outPath = Path.GetTempPath() + "scrappy\\cuffelinks.com.au\\";
            categories = [];
        };
    |]

