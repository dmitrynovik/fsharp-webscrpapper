namespace Lonsec.WebScrapper.IntegrationTest

open System.IO
open NUnit.Framework

[<TestFixture>]
type InvestorDailyMarketsTest() = 
    inherit TestBase(
        {
            url = "http://www.investordaily.com.au/markets";
            newslinkSelector = fun(url:string) -> true;
            articleRootSelectors = [|"article"|];
            outPath = Path.GetTempPath() + "scrappy\\investordaily.com.au\\Markets";
            categories = [{name = "markets"; weight = 1.0}];
        })

        [<Test>]
        override this.downloadAll() = base.downloadAll()
            
