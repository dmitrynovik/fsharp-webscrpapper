open FSharp.Data
open Lonsec.WebScrapper

[<EntryPoint>]
let main argv = 

    let scrappy = new GenericScrapper()
    let url = "http://morningstar.com.au"

    // This example loads relevant links from document:
    let results = scrappy.loadLinks(url, (fun url -> url.Contains("/article/")))
    //printfn "%A" results

    results |> Seq.iter (fun (text, href) ->
        let doc = scrappy.load href
        let rootContent = doc.CssSelect(".storyPageHolder") |> Seq.tryHead
        if rootContent.IsSome then
            printf "\n\n\n*******\n%s" (rootContent.Value.InnerText())
    )
        
    System.Console.Read() |> ignore
    0
