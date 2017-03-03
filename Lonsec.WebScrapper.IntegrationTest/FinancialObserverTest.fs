namespace Lonsec.WebScrapper.IntegrationTest

open System.IO
open NUnit.Framework

[<TestFixture>]
type FinancialObserverTest() = 
    inherit TestBase(
        {
            url = "http://www.financialobserver.com.au/news";
            newslinkSelector = fun(url:string) -> url.Contains("/articles/");
            articleRootSelectors = [|".articleDetail"|];
            outPath = Path.GetTempPath() + "scrappy\\Financialobserver\\";
            categories = [];
        })

        [<Test>]
        [<Ignore("This HTML does not scrap well.")>]
        override this.downloadAll() = base.downloadAll()
            
