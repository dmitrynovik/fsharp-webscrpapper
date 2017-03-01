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

    // This example loads relevant links from document:
    let documentLinks = scrappy.loadLinks(url, (fun url -> url.Contains("/article/")))
    //printfn "%A" results

    // TODO: how do we remove elements like .pagecount - ?
    documentLinks |> Seq.iter (fun (text, href) ->
        let doc = scrappy.load href
        let rootContent = doc.CssSelect(".storyPageHolder") |> Seq.tryHead
        if rootContent.IsSome then
            let writer = new DocumentWriter(scrappy, outPath)
            writer.scrapDocumentFromLink(text, href)
    )
    
    printf "Job done."     
    System.Console.Read() |> ignore
    0
