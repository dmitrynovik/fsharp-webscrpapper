namespace Lonsec.WebScrapper

open System.IO
open System.Text

type IO =
    static member removeInvalidCharsFromFileName(filename: string) = 
        let badChars = Path.GetInvalidFileNameChars() |> Seq.toList
        let mutable buf = new StringBuilder(filename.Length)
        for c in filename do
            if not (List.contains c badChars) then buf <- buf.Append c
        buf.ToString()


