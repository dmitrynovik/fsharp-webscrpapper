namespace WebScrapper.FSharp

open System
open System.IO
open System.Text
open System.Diagnostics
open FSharp.Data

type DocumentWriter(scrappy: DocumentScrapper, outPath: string) = 

    do
        if not (Directory.Exists outPath) then Directory.CreateDirectory(outPath) |> ignore

    let path = if outPath.EndsWith("\\") then outPath else outPath + "\\"

    member this.writeDocument(config: SiteConfiguration, name: string, doc: HtmlNode) =
        let content = doc.InnerText()
        let filePath = path + IO.removeInvalidCharsFromFileName(name) + ".txt"
        File.WriteAllText (filePath, content)
        Trace.TraceInformation ("Written: {0}", filePath)


    
