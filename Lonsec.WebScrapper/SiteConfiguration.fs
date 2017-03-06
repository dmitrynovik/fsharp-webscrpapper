namespace Lonsec.WebScrapper

open System
open System.Linq
open System.IO
open System.Runtime.InteropServices

type Category(name: string, weight: float) =
    static member Of(name: string) = Category(name, 1.0)

type SiteConfiguration(url: string, fsRoot: string, newslinkSelector: string -> bool, articleRootSelectors: seq<string>, categories: seq<Category>) =    

    member this.url = url
    member this.newslinkSelector = newslinkSelector
    member this.articleRootSelectors = articleRootSelectors
    member this.categories = categories

    member this.outPath = 
        let uri = new Uri(url)
        let path = IO.removeInvalidCharsFromFileName(uri.Host) + uri.LocalPath
        Path.Combine(fsRoot, path)

    new(url: string, fsRoot: string, newslinkSelector: string -> bool, articleRootSelectors: seq<string>, [<Optional;DefaultParameterValue(null)>] ?categories: List<string>) =

        let cats = match categories with
                    | Some(c) -> c
                    | None -> []
                
        let count = cats.Count()
        let weightedCats = cats |> Seq.map(fun i -> new Category(i, 1.0 / (float) count))
        SiteConfiguration(url, fsRoot, newslinkSelector, articleRootSelectors, weightedCats)


