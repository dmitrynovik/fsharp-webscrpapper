# fsharp-webscrpapper

A simple web scrapper written in F# which
- goes to a main Web Page containing news or other links
- extracts links as defined by the link pattern function
- goes to every extracted link in parallel and scraps the root document as defined by selector
- dumps the scrapped documents to the output path

