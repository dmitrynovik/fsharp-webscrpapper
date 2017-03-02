namespace Lonsec.WebScrapper

open System
open System.IO
open System.Text
open FSharp.Data

type DocumentWriter(scrappy: GenericWebScrapper, outPath: string) = 

    do
        if not (Directory.Exists outPath) then Directory.CreateDirectory(outPath) |> ignore

    let path = if outPath.EndsWith("\\") then outPath else outPath + "\\"

    let removeInvalidCharsFromFileName(filename: string) = 
        let badChars = Path.GetInvalidFileNameChars() |> Seq.toList
        let mutable buf = new StringBuilder(filename.Length)
        for c in filename do
            if not (List.contains c badChars) then buf <- buf.Append c
        buf.ToString()

    member this.scrapDocumentFromLink(text: string, href: string) =
        let doc = scrappy.load href
        let rootContent = doc.CssSelect(".storyPageHolder") |> Seq.tryHead
        if rootContent.IsSome then
            let content = rootContent.Value.InnerText()
            File.WriteAllText (path + removeInvalidCharsFromFileName(text) + ".txt", content)
            //printf "\n\n\n*******\n%s" content

    
