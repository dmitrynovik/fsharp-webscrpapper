open System
open System.IO
open System.Text
open FSharp.Data
open Lonsec.WebScrapper

[<EntryPoint>]
let main argv = 

    let siteSettings = { 
        url = "http://morningstar.com.au";
        articleRootSelector = ".storyPageHolder";
        newslinkSelector = (fun(url:string) -> url.Contains("/article/"));
        outPath = Path.GetTempPath() + "out\\";
    }

    let extractor = new FrontpageExtractor(siteSettings)
    extractor.extractAll()
    
    printf "Job done."     
    System.Console.Read() |> ignore
    0
