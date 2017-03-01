namespace Lonsec.WebScrapper

open FSharp.Data

type FrontpageExtractor(url: string, articleRootSelector: string, 
                        newslinkSelector: string -> bool, outPath: string) = 

    let scrappy = new GenericWebScrapper()

    member this.extractAll() =

        let documentLinks = scrappy.loadLinks(url, newslinkSelector)
        let writer = new DocumentWriter(scrappy, outPath)

        // TODO: how do we remove elements like .pagecount - ?
        documentLinks |> Seq.iter (fun (linkText, href) ->
            let doc = scrappy.load href
            let rootContent = doc.CssSelect(articleRootSelector) |> Seq.tryHead
            if rootContent.IsSome then
                writer.scrapDocumentFromLink(linkText, href)
        )


