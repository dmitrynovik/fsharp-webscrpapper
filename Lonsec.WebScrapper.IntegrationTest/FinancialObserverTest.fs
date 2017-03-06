namespace Lonsec.WebScrapper.IntegrationTest

open System.IO
open NUnit.Framework
open Lonsec.WebScrapper

[<TestFixture>]
type FinancialObserverTest() = 
    inherit TestBase(
        new SiteConfiguration(
                            "http://www.financialobserver.com.au/news",
                            Path.GetTempPath() + "scrappy\\",
                            (fun(url:string) -> url.Contains("/articles/")),
                            [|".articleDetail"|])
                    )
    [<Test>]
    [<Ignore("This HTML does not scrap well.")>]
    override this.downloadAll() = base.downloadAll()
            
