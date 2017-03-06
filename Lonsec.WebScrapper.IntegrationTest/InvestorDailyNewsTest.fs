namespace Lonsec.WebScrapper.IntegrationTest

open System.IO
open NUnit.Framework
open Lonsec.WebScrapper

[<TestFixture>]
type InvestorDailyNewsTest() = 

    inherit TestBase(
        new SiteConfiguration(
            "http://www.investordaily.com.au/all-news",
            Path.GetTempPath() + "scrappy\\",
            (fun(url:string) -> true),
            [|"article"|])
        )

    [<Test>]
    override this.downloadAll() = base.downloadAll()
            
