open System
open System.IO
open System.Text
open FSharp.Data
open Lonsec.WebScrapper

let removeInvalidCharsFromFileName(filename: string) = 
    let badChars = Path.GetInvalidFileNameChars() |> Seq.toList
    let mutable buf = new StringBuilder(filename.Length)
    for c in filename do
        if not (List.contains c badChars) then buf <- buf.Append c
    buf.ToString()


[<EntryPoint>]
let main argv = 

    let scrappy = new GenericWebScrapper()
    let url = "http://morningstar.com.au"
    let outPath = Path.GetTempPath() + "out\\"
    if not (Directory.Exists outPath) then Directory.CreateDirectory(outPath) |> ignore

    // This example loads relevant links from document:
    let documentLinks = scrappy.loadLinks(url, (fun url -> url.Contains("/article/")))
    //printfn "%A" results

    // TODO: how do we remove elements like .pagecount - ?
    documentLinks |> Seq.iter (fun (text, href) ->
        let doc = scrappy.load href
        let rootContent = doc.CssSelect(".storyPageHolder") |> Seq.tryHead
        if rootContent.IsSome then
            let content = rootContent.Value.InnerText()
            File.WriteAllText (outPath + removeInvalidCharsFromFileName(text) + ".txt", content)
            //printf "\n\n\n*******\n%s" content
    )
    
    printf "\nJob done."     
    System.Console.Read() |> ignore
    0
