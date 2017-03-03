open System
open System.Diagnostics
open Lonsec.WebScrapper

[<EntryPoint>]
let main argv = 

    Lonsec.WebScrapper.Runner.SiteList.all |> Seq.iter (fun siteSettings -> 

        printf "processing %s\n" siteSettings.url 

        let extractor = new FrontpageExtractor(siteSettings)
        try
            Console.ForegroundColor <- ConsoleColor.White
            let extracted = extractor.extractAll()
            Console.WriteLine("\textracted: {0}", extracted)
        with
            | err -> 
                Console.ForegroundColor <- ConsoleColor.Red
                Trace.TraceError (err.ToString())
    )
    
    printf "\n\nJob done."
    Console.Read() |> ignore
    0
