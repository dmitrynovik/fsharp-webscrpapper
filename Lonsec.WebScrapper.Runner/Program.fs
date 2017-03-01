open System
open System.IO
open System.Text
open FSharp.Data
open Lonsec.WebScrapper

[<EntryPoint>]
let main argv = 

    SiteList.all |> Seq.iter (fun siteSettings -> 
        printf "processing %s" siteSettings.url 
        let extractor = new FrontpageExtractor(siteSettings)
        extractor.extractAll()
    )
    
    printf "\n\nJob done."
    System.Console.Read() |> ignore
    0
