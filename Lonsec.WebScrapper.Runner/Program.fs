open System
open System.IO
open System.Text
open FSharp.Data
open Lonsec.WebScrapper



[<EntryPoint>]
let main argv = 

    let scrappy = new GenericWebScrapper()
    let url = "http://morningstar.com.au"
    let outPath = Path.GetTempPath() + "out\\"
    let newslinkSelector = fun (url:string) -> url.Contains("/article/")
    let articleRootSelector = ".storyPageHolder"

    let documentLinks = scrappy.loadLinks(url, newslinkSelector)

    // TODO: how do we remove elements like .pagecount - ?
    documentLinks |> Seq.iter (fun (linkText, href) ->
        let doc = scrappy.load href
        let rootContent = doc.CssSelect(articleRootSelector) |> Seq.tryHead
        if rootContent.IsSome then
            let writer = new DocumentWriter(scrappy, outPath)
            writer.scrapDocumentFromLink(linkText, href)
    )
    
    printf "Job done."     
    System.Console.Read() |> ignore
    0
