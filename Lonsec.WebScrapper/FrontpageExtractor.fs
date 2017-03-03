namespace Lonsec.WebScrapper

open System
open System.Diagnostics
open FSharp.Data

type FrontpageExtractor(siteConfig: SiteConfiguration) = 

    let scrappy = new DocumentScrapper()

    member this.extractAll() =

        let documentLinks = scrappy.loadLinks(siteConfig.url, siteConfig.newslinkSelector)
        let writer = new DocumentWriter(scrappy, siteConfig.outPath)
        let mutable count = 0

        // TODO: how do we remove elements like .pagecount - ?
        documentLinks |> Seq.iter (fun (linkText, href) ->
            try
                let doc = scrappy.load href
                let rootContent = siteConfig.articleRootSelectors 
                                    |> Seq.map(fun selector -> doc.CssSelect(selector)) 
                                    |> Seq.concat 
                                    |> Seq.tryHead

                if rootContent.IsSome then
                    writer.writeDocument(siteConfig, linkText, rootContent.Value)
                    count <- count + 1
                else
                    Trace.TraceWarning (String.Format("could not scrap {0}", href))
            with
            | err -> 
                Console.ForegroundColor <- ConsoleColor.Red
                Trace.TraceError (err.ToString())
        )
        count


