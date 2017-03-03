open System
open System.Diagnostics
open Lonsec.WebScrapper

[<EntryPoint>]
let main argv = 

    Lonsec.WebScrapper.Runner.SiteList.all |> Seq.iter (fun siteSettings -> 

        Console.ForegroundColor <- ConsoleColor.White
        printf "processing %s\n" siteSettings.url 

        let extractor = new FrontpageExtractor(siteSettings)
        try
            let extracted = extractor.extractAll()
            printf "\textracted: %d\n" extracted
        with
            | err -> 
                Console.ForegroundColor <- ConsoleColor.Red
                Trace.TraceError (err.ToString())
    )
    
    printf "\n\nJob done."
    Console.Read() |> ignore
    0
