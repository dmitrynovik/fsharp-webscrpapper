namespace WebScrapper.FSharp.IntegrationTest

open System.IO
open NUnit.Framework
open WebScrapper.FSharp

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
            
