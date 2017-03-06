namespace Lonsec.WebScrapper.Runner

open System.IO
open Lonsec.WebScrapper

module SiteList =
    
    let root = Path.GetTempPath() + "scrappy\\";
    type config = SiteConfiguration

    let all = [|

        new config("http://morningstar.com.au", root, 
                    (fun(url:string) -> url.Contains("/article/")), 
                    [|".storyPageHolder"|]);

        new config("http://morningstar.com.au/funds", root, 
                    (fun(url:string) -> url.Contains("/article/")), 
                    [|".storyPageHolder"|], 
                    ["funds"]);

        new config("http://moneymanagement.com.au/news", root, 
                    (fun(url:string) -> url.Contains("/news/")), 
                    [|".cm-article-body"; ".News"|]);

        new config("http://moneymanagement.com.au/funds-management", root, 
                    (fun(url:string) -> url.Contains("/news/")),
                    [|".cm-article-body"; ".News"|], 
                    ["funds"]);

        new config("http://moneymanagement.com.au/financial-planning", root, 
                    (fun(url:string) -> url.Contains("/news/")),
                    [|".cm-article-body"; ".News"|], 
                    ["financial-planning"]);

        new config("http://moneymanagement.com.au/superannuation", root, 
                    (fun(url:string) -> url.Contains("/news/")),
                    [|".cm-article-body"; ".News"|], 
                    ["superannuation"]);

        new config("http://moneymanagement.com.au/people-products", root, 
                    (fun(url:string) -> url.Contains("/news/")),
                    [|".cm-article-body"; ".News"|], 
                    ["people"; "products"]);

        new config("http://moneymanagement.com.au/all-news", root, 
                    (fun(url:string) -> url.Contains("/news/")), 
                    [|"article"|]);

        new config("http://moneymanagement.com.au/markets", root, 
                    (fun(url:string) -> url.Contains("/news/")), 
                    [|"article"|],
                    ["markets"]);

        new config("http://moneymanagement.com.au/regulation", root, 
                    (fun(url:string) -> url.Contains("/news/")), 
                    [|"article"|],
                    ["regulation"]);

        new config("http://moneymanagement.com.au/appointments", root, 
                    (fun(url:string) -> url.Contains("/news/")), 
                    [|"article"|],
                    ["people"]);

        new config("http://moneymanagement.com.au/appointments", root, 
                    (fun(url:string) -> url.Contains("/news/")), 
                    [|"article"|],
                    ["people"]);

        new config("http://moneymanagement.com.au/superannuation", root, 
                    (fun(url:string) -> url.Contains("/news/")), 
                    [|"article"|],
                    ["superannuation"]);

        new config("http://moneymanagement.com.au/mergers-acquisitions", root, 
                    (fun(url:string) -> url.Contains("/news/")), 
                    [|"article"|],
                    ["mergers-acquisitions"]);

        new config("https://cuffelinks.com.au", root, 
                    (fun(url:string) -> true), 
                    [|"article"|]);

        new config("http://www.triapartners.com/trialogue.php", root, 
                    (fun(url:string) -> true), 
                    [|".trialogue-details"|]);
    |]


