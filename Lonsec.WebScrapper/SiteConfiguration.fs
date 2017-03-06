namespace Lonsec.WebScrapper

open System
open System.Linq
open System.IO
open System.Runtime.InteropServices

type Topic = Funds | FinancialPlanning | Superannuation | People | Products | Markets | Regulation | MergersAndAcquisitions

type Category(name: Topic, weight: float) =
    static member Of(name: Topic) = Category(name, 1.0)
    static member Of(name: Topic, weight: float) = Category(name, weight)

type ChildPage = { path: string; categories: seq<Category>; }

type SiteConfiguration(url: string, 
                        fsRoot: string, 
                        newslinkSelector: string -> bool, 
                        articleRootSelectors: seq<string>, 
                        [<Optional;DefaultParameterValue(null)>] ?children: List<ChildPage>) =

    member this.url = url
    member this.newslinkSelector = newslinkSelector
    member this.articleRootSelectors = articleRootSelectors

    member this.outPath(): string = 
        let uri = new Uri(url)
        if (fsRoot.Contains(uri.Host)) then
            fsRoot
        else
            let path = IO.removeInvalidCharsFromFileName(uri.Host) + "\\" + IO.removeInvalidCharsFromFileName(uri.LocalPath)
            Path.Combine(fsRoot, path)

    member this.children = match children with
                            | Some(x) -> x |> List.map (
                                                        fun i -> 
                                                                    let path = this.outPath().TrimEnd('\\') + "\\" + i.path.TrimStart('/')
                                                                    
                                                                    new SiteConfiguration(url.TrimEnd('/') + "/" + i.path.TrimStart('/'), 
                                                                        path, 
                                                                        newslinkSelector, 
                                                                        articleRootSelectors)
                                                       )
                            | None -> [] 



