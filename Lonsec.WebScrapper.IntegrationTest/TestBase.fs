namespace Lonsec.WebScrapper.IntegrationTest

open System.Diagnostics
open Lonsec.WebScrapper

[<AbstractClass>]
type TestBase(siteConfig: SiteConfiguration) =

   let extractor = new FrontpageExtractor(siteConfig)

   abstract member downloadAll: unit -> unit

   default this.downloadAll() = 
                              let count = extractor.extractAll()
                              Trace.TraceInformation ("{0} done, extracted: {1}", siteConfig.url, count)

        


