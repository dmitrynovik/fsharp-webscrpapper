open System
open System.Diagnostics
open Lonsec.WebScrapper

[<EntryPoint>]
let main argv = 

    Lonsec.WebScrapper.Runner.SiteList.all |> Seq.iter (fun siteSettings -> 
        printf "processing %s\n" siteSettings.url 
        let extractor = new FrontpageExtractor(siteSettings)
        try
            extractor.extractAll()
        with
            | err -> Trace.TraceError (err.ToString())
    )
    
    printf "\n\nJob done."
    System.Console.Read() |> ignore
    0
