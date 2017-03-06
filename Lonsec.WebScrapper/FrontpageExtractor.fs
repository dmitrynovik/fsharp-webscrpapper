namespace Lonsec.WebScrapper

open System
open System.Diagnostics
open System.Threading.Tasks
open FSharp.Data

type FrontpageExtractor(siteConfig: SiteConfiguration) = 

    let scrappy = new DocumentScrapper()

    member this.extractAll() =

        let documentLinks = scrappy.loadLinks(siteConfig.url, siteConfig.newslinkSelector)
        let writer = new DocumentWriter(scrappy, siteConfig.outPath)

        // TODO: how do we remove elements like .pagecount - ?
        Parallel.ForEach (documentLinks, fun (linkText, href) ->
            try
                Console.ForegroundColor <- ConsoleColor.White
                let doc = scrappy.load href
                let rootContent = siteConfig.articleRootSelectors 
                                    |> Seq.map(fun selector -> doc.CssSelect(selector)) 
                                    |> Seq.concat 
                                    |> Seq.tryHead

                if rootContent.IsSome then
                    writer.writeDocument(siteConfig, linkText, rootContent.Value)
                else
                    Trace.TraceWarning (String.Format("could not scrap {0}", href))
            with
            | err -> 
                Console.ForegroundColor <- ConsoleColor.Red
                Trace.TraceError (err.ToString())
        ) |> ignore


