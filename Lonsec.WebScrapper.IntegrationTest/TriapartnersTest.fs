namespace Lonsec.WebScrapper.IntegrationTest

open System.IO
open NUnit.Framework
open Lonsec.WebScrapper

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
            
