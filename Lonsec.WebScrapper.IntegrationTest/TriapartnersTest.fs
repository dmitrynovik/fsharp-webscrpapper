namespace Lonsec.WebScrapper.IntegrationTest

open System.IO
open NUnit.Framework

[<TestFixture>]
type TriapartnersTest() = 
    inherit TestBase(
        {
            url = "http://www.triapartners.com/trialogue.php";
            newslinkSelector = fun(url:string) -> true;
            articleRootSelectors = [|".trialogue-details"|];
            outPath = Path.GetTempPath() + "scrappy\\triapartners.com\\";
            categories = [];
        })

        [<Test>]
        override this.downloadAll() = base.downloadAll()
            
