﻿namespace Lonsec.WebScrapper

open System
open FSharp.Data

type GenericWebScrapper() = 

    let ensureAbsoluteUrl(baseUrl: string, url: string) =
        let uri = new Uri(url, UriKind.RelativeOrAbsolute)
        match uri.IsAbsoluteUri with
            | true -> url
            | false -> (new Uri(new Uri(baseUrl), url)).ToString()

    // Loads HTML document
    member this.load(url: string) = HtmlDocument.Load(url)

    // Loads links from the web document specified by URL and filtered by provided function:
    member this.loadLinks(url: string, urlFilter: string -> bool) =
        this.load(url).Descendants["a"]
            |> Seq.choose (fun x -> 
                x.TryGetAttribute("href") 
                |> Option.filter (fun a -> urlFilter(a.Value()))
                |> Option.map (fun a -> x.InnerText(), ensureAbsoluteUrl(url, a.Value()))
            )
