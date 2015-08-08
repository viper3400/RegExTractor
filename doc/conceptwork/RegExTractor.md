# RegExTractor Concept
## Design Key Points

* should be build modular using Ninject
* should use a NUnit as testing framwork
* should use .NET 4.5
 
## RegExTractorShared.dll
Contains all shared code as 

* interfaces
* shared models

## IRegExCrawler
This is maybe the first component which could / should be implemented as a proof of concept of shared models.
By now, there my be a public List<Finding\> IRegExCrawler.Crawl(List<RegExSearchTerm\>, string Content) method.

### Test IRegExCrawler
