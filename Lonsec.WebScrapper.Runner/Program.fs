open System
open System.IO
open System.Text
open FSharp.Data
open Lonsec.WebScrapper

[<EntryPoint>]
let main argv = 

    let extractor = new FrontpageExtractor("http://morningstar.com.au", 
                                    ".storyPageHolder", 
                                    (fun(url:string) -> url.Contains("/article/")), 
                                    Path.GetTempPath() + "out\\")
    extractor.extractAll()
    
    printf "Job done."     
    System.Console.Read() |> ignore
    0
