open System
open System.Diagnostics
open Lonsec.WebScrapper

[<EntryPoint>]
let main argv = 
    
    let watch = Stopwatch.StartNew()

    Lonsec.WebScrapper.Runner.SiteList.all |> Seq.iter (fun siteSettings -> 

        Console.ForegroundColor <- ConsoleColor.White
        printf "processing %s\n" siteSettings.url 

        let extractor = new FrontpageExtractor(siteSettings)
        try
            extractor.extractAll() |> ignore
        with
            | err -> 
                Console.ForegroundColor <- ConsoleColor.Red
                Trace.TraceError (err.ToString())
    )
    
    watch.Stop()
    let time = watch.Elapsed.ToString()
    printf "\n\nJob done, elapsed: %s" time  
    Console.Read() |> ignore
    0
