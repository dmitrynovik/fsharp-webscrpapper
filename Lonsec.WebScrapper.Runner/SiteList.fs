namespace Lonsec.WebScrapper.Runner

open System.IO
open Lonsec.WebScrapper

module SiteList =
    
    type config = SiteConfiguration
    let fsRoot = Path.GetTempPath() + "scrappy\\";

    let all = [|

        new config("http://morningstar.com.au", fsRoot, 
                    (fun(url:string) -> url.Contains("/article/")), 
                    [|".storyPageHolder"|]);

        new config("http://morningstar.com.au/funds", fsRoot, 
                    (fun(url:string) -> url.Contains("/article/")), 
                    [|".storyPageHolder"|], 
                    [Funds]);

        new config("http://moneymanagement.com.au/news", fsRoot, 
                    (fun(url:string) -> url.Contains("/news/")), 
                    [|".cm-article-body"; ".News"|]);

        new config("http://moneymanagement.com.au/funds-management", fsRoot, 
                    (fun(url:string) -> url.Contains("/news/")),
                    [|".cm-article-body"; ".News"|], 
                    [Funds]);

        new config("http://moneymanagement.com.au/financial-planning", fsRoot, 
                    (fun(url:string) -> url.Contains("/news/")),
                    [|".cm-article-body"; ".News"|], 
                    [FinancialPlanning]);

        new config("http://moneymanagement.com.au/superannuation", fsRoot, 
                    (fun(url:string) -> url.Contains("/news/")),
                    [|".cm-article-body"; ".News"|], 
                    [Superannuation]);

        new config("http://moneymanagement.com.au/people-products", fsRoot, 
                    (fun(url:string) -> url.Contains("/news/")),
                    [|".cm-article-body"; ".News"|], 
                    [People; Products]);

        new config("http://moneymanagement.com.au/all-news", fsRoot, 
                    (fun(url:string) -> url.Contains("/news/")), 
                    [|"article"|]);

        new config("http://moneymanagement.com.au/markets", fsRoot, 
                    (fun(url:string) -> url.Contains("/news/")), 
                    [|"article"|],
                    [Markets]);

        new config("http://moneymanagement.com.au/regulation", fsRoot, 
                    (fun(url:string) -> url.Contains("/news/")), 
                    [|"article"|],
                    [Regulation]);

        new config("http://moneymanagement.com.au/appointments", fsRoot, 
                    (fun(url:string) -> url.Contains("/news/")), 
                    [|"article"|],
                    [People]);

        new config("http://moneymanagement.com.au/superannuation", fsRoot, 
                    (fun(url:string) -> url.Contains("/news/")), 
                    [|"article"|],
                    [Superannuation]);

        new config("http://moneymanagement.com.au/mergers-acquisitions", fsRoot, 
                    (fun(url:string) -> url.Contains("/news/")), 
                    [|"article"|],
                    [MergersAndAcquisitions]);

        new config("https://cuffelinks.com.au", fsRoot, 
                    (fun(url:string) -> true), 
                    [|"article"|]);

        new config("http://www.triapartners.com/trialogue.php", fsRoot, 
                    (fun(url:string) -> true), 
                    [|".trialogue-details"|]);
    |]


