namespace Lonsec.WebScrapper.IntegrationTest

open System.IO
open NUnit.Framework
open Lonsec.WebScrapper

[<TestFixture>]
type CuffelinksTest() = 
    inherit TestBase(new SiteConfiguration(
                        "https://cuffelinks.com.au",
                        Path.GetTempPath() + "scrappy\\",
                        (fun(url:string) -> true),
                        [|"article"|])
                    )

        [<Test>]
        override this.downloadAll() = base.downloadAll()
            
