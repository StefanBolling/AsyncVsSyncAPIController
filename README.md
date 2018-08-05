# AsyncVsSyncAPIController

When it comes to programming, performance is a subject that never gets old. One great way to enhance performance on your API-Controllers is to make them async. But how much will you gain? 

To help you in your never-ending search for performance I have created this simple .net 4.72 project with an async and a sync controller, that reads the content length from a url. To make things really interesting I have also added two load-tests, that evaluates the result from those controllers. 

Since you will be running both the load test and the page on your own machine, I think you need to set it up in you IIS, so here is what you need to do:

1.	Download source-code :)
2.	Create a web-page in your IIS with a binding to http://apicontrollers/
3.	Add the api controller url to your windows host file: 
127.0.0.1		apicontrollers
4.	Compile project and verify that it works by testing these two urls:
* http://apicontrollers/async/getpagecontentlength
* http://apicontrollers/sync/getpagecontentlength
5.	Run load-tests.

You can simply modify the urls to test one of your own real services for example. 

All the code is located in the controllers for simplicity. Notice however, that I used the HttpClient differently on the sync controller compared to the async controller. This is because async context requires it to be handled a bit differently, which Simon Timms demonstrates on: 

https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/

I know it can be hard to keep a long chain of methods async all the way, but if you are in a position where it is possible, why not give it a try?

Happy Coding!

PS. This the load-tests might require VS2017 Enterprise.

PS2. On my machine the sync average page time was 1.36, and the async was 0,39!
