namespace Lonsec.WebScrapper.IntegrationTest

open System.IO
open NUnit.Framework

[<TestFixture>]
type InvestorDailyRegulationTest() = 
    inherit TestBase(
        {
            url = "http://www.investordaily.com.au/regulation";
            newslinkSelector = fun(url:string) -> true;
            articleRootSelectors = [|"article"|];
            outPath = Path.GetTempPath() + "scrappy\\investordaily.com.au\\Regulation";
            categories = [{name = "regulation"; weight = 1.0}];
        })

        [<Test>]
        override this.downloadAll() = base.downloadAll()
            
