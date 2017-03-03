namespace Lonsec.WebScrapper.Runner

open System.IO
open Lonsec.WebScrapper

module SiteList =
    
    let all = [|
        { 
            url = "http://morningstar.com.au";
            newslinkSelector = (fun(url:string) -> url.Contains("/article/"));
            articleRootSelectors = [|".storyPageHolder"|];
            outPath = Path.GetTempPath() + "scrappy\\Morningstar\\";
            categories = [];
        };
        { 
            url = "http://morningstar.com.au/Funds";
            newslinkSelector = (fun(url:string) -> url.Contains("/article/"));
            articleRootSelectors = [|".storyPageHolder"|];
            outPath = Path.GetTempPath() + "scrappy\\Morningstar\\Funds\\";
            categories = [{ name = "Funds"; weight = 1.0 }];
        };
        { 
            url = "http://moneymanagement.com.au/news";
            newslinkSelector = (fun(url:string) -> url.Contains("/news/"));
            articleRootSelectors = [|".cm-article-body"; ".News"|];
            outPath = Path.GetTempPath() + "scrappy\\Moneymanagement\\";
            categories = [];
        };
        { 
            url = "http://moneymanagement.com.au/funds-management";
            newslinkSelector = (fun(url:string) -> url.Contains("/news/"));
            articleRootSelectors = [|".cm-article-body"; ".News"|];
            outPath = Path.GetTempPath() + "scrappy\\Moneymanagement\\Funds\\";
            categories = [{ name = "Funds"; weight = 1.0 }];
        };
        { 
            url = "http://moneymanagement.com.au/news/financial-planning";
            newslinkSelector = (fun(url:string) -> url.Contains("/news/"));
            articleRootSelectors = [|".cm-article-body"; ".News"|];
            outPath = Path.GetTempPath() + "scrappy\\Moneymanagement\\FinancialPlanning\\";
            categories = [{ name = "FinancialPlanning"; weight = 1.0 }];
        };
        { 
            url = "http://moneymanagement.com.au/news/superannuation";
            newslinkSelector = (fun(url:string) -> url.Contains("/news/"));
            articleRootSelectors = [|".cm-article-body"; ".News"|];
            outPath = Path.GetTempPath() + "scrappy\\Moneymanagement\\Superannuation\\";
            categories = [{ name = "Superannuation"; weight = 1.0 }];
        };
        { 
            url = "http://moneymanagement.com.au/news/people-products";
            newslinkSelector = (fun(url:string) -> url.Contains("/news/"));
            articleRootSelectors = [|".cm-article-body"; ".News"|];
            outPath = Path.GetTempPath() + "scrappy\\Moneymanagement\\PeopleProducts\\";
            categories = [{ name = "PeopleProducts"; weight = 1.0 }];
        };
    |]

