namespace Lonsec.WebScrapper.Runner

open System.IO
open Lonsec.WebScrapper

module SiteList =
    
    type config = SiteConfiguration
    let fsRoot = Path.GetTempPath() + "scrappy\\";

    let all = [|

        new config("http://morningstar.com.au", fsRoot, 
                    (fun(url:string) -> url.Contains("/article/")), 
                    [|".storyPageHolder"|],
                    [{ path = "/funds"; categories = [Category.Of(Funds)] };]
                  );

        new config("http://moneymanagement.com.au/news", fsRoot, 
                    (fun(url:string) -> url.Contains("/news/")), 
                    [|".cm-article-body"; ".News"|],
                    [
                        { path = "/funds-management"; categories = [Category.Of(Funds)] };
                        { path = "/financial-planning"; categories = [Category.Of(FinancialPlanning)] };
                        { path = "/superannuation"; categories = [Category.Of(Superannuation)] };
                        { path = "/people-products"; categories = [Category.Of(People, 0.5); Category.Of(Products, 0.5)] };
                    ]
                  );

          new config("http://www.investordaily.com.au", fsRoot,
                        (fun(url:string) -> true),
                        [|"article"|],
                        [
                            { path = "/all-news"; categories = [] };
                            { path = "/markets"; categories = [Category.Of(Markets)] };
                            { path = "/regulation"; categories = [Category.Of(Regulation)] };
                            { path = "/appointments"; categories = [Category.Of(People)] };
                            { path = "/mergers-acquisitions"; categories = [Category.Of(MergersAndAcquisitions)] };
                        ]
                     );

        new config("https://cuffelinks.com.au", fsRoot, 
                    (fun(url:string) -> true), 
                    [|"article"|]);

        new config("http://www.triapartners.com/trialogue.php", fsRoot, 
                    (fun(url:string) -> true), 
                    [|".trialogue-details"|]);
    |]


