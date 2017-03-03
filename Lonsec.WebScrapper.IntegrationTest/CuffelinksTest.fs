namespace Lonsec.WebScrapper.IntegrationTest

open System.IO
open NUnit.Framework

[<TestFixture>]
type CuffelinksTest() = 
    inherit TestBase(
        {
            url = "https://cuffelinks.com.au";
            newslinkSelector = fun(url:string) -> true;
            articleRootSelectors = [|"article"|];
            outPath = Path.GetTempPath() + "scrappy\\cuffelinks.com.au\\";
            categories = [];
        })

        [<Test>]
        override this.downloadAll() = base.downloadAll()
            
