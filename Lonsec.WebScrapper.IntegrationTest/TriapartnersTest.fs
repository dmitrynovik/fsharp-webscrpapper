namespace WebScrapper.FSharp.IntegrationTest

open System.IO
open NUnit.Framework
open WebScrapper.FSharp

[<TestFixture>]
type TriapartnersTest() = 
    inherit TestBase(
        new SiteConfiguration(
            "http://www.triapartners.com/trialogue.php",
            Path.GetTempPath() + "scrappy\\",
            (fun(url:string) -> true),
            [|".trialogue-details"|])
        )

    [<Test>]
    override this.downloadAll() = base.downloadAll()
            
