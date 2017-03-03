namespace Lonsec.WebScrapper.IntegrationTest

open System.IO
open NUnit.Framework

[<TestFixture>]
type InvestorDailyNewsTest() = 
    inherit TestBase(
        {
            url = "http://www.investordaily.com.au/all-news";
            newslinkSelector = fun(url:string) -> true;
            articleRootSelectors = [|"article"|];
            outPath = Path.GetTempPath() + "scrappy\\investordaily.com.au\\";
            categories = [];
        })

        [<Test>]
        override this.downloadAll() = base.downloadAll()
            
