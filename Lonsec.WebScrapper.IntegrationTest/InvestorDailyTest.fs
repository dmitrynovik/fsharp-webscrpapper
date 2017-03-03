namespace Lonsec.WebScrapper.IntegrationTest

open System.IO
open NUnit.Framework

[<TestFixture>]
type InvestorDailyTest() = 
    inherit TestBase(
        {
            url = "http://www.investordaily.com.au/all-news";
            newslinkSelector = fun(url:string) -> true;
            articleRootSelectors = [|"article"|];
            outPath = Path.GetTempPath() + "scrappy\\Investordaily\\";
            categories = [];
        })

        [<Test>]
        override this.downloadAll() = base.downloadAll()
            
