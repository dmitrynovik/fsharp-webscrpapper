namespace Lonsec.WebScrapper

open System
open System.IO
open System.Text
open FSharp.Data

type DocumentWriter(scrappy: DocumentScrapper, outPath: string) = 

    do
        if not (Directory.Exists outPath) then Directory.CreateDirectory(outPath) |> ignore

    let path = if outPath.EndsWith("\\") then outPath else outPath + "\\"

    let removeInvalidCharsFromFileName(filename: string) = 
        let badChars = Path.GetInvalidFileNameChars() |> Seq.toList
        let mutable buf = new StringBuilder(filename.Length)
        for c in filename do
            if not (List.contains c badChars) then buf <- buf.Append c
        buf.ToString()

    member this.writeDocument(config: SiteConfiguration, name: string, doc: HtmlNode) =
        let content = doc.InnerText()
        File.WriteAllText (path + removeInvalidCharsFromFileName(name) + ".txt", content)

    
