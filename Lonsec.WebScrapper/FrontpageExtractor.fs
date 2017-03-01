﻿namespace Lonsec.WebScrapper

open FSharp.Data

type FrontpageExtractor(siteConfig: SiteConfiguration) = 

    let scrappy = new GenericWebScrapper()

    member this.extractAll() =

        let documentLinks = scrappy.loadLinks(siteConfig.url, siteConfig.newslinkSelector)
        let writer = new DocumentWriter(scrappy, siteConfig.outPath)

        // TODO: how do we remove elements like .pagecount - ?
        documentLinks |> Seq.iter (fun (linkText, href) ->
            let doc = scrappy.load href
            let rootContent = doc.CssSelect(siteConfig.articleRootSelector) |> Seq.tryHead
            if rootContent.IsSome then
                writer.scrapDocumentFromLink(linkText, href)
        )

