# ReadMe

## Running the application

The application can be run from within Visual Studio and uses Swagger; so the call can be made using that. Please make the HackerNews.API project the 'Set up Startup Project' option. When the application is running the URL can also be used:

	https://localhost:7259/HackerNews?count=10

i.e. specifying the count in the querystring

Or alternatively, from the powershell command line:

	dotnet build HackerNews.sln
	dotnet run --project=.\HackerNews.API\HackerNews.API.csproj --urls=https://locahost:7259

And then from a new powershel window:

	(Invoke-WebRequest https://localhost:7259/HackerNews?count=10).Content | ConvertFrom-Json

## Assumptions

- Visual Studio 2022 and .net 8 installed
- There will always be best strories available thourgh the API
- To make effecient use of the Hackner News API, the list of best stories and the stories themselves are cached; with the cache expiring after one minute

## Future Improvments

- Better checks and error handling
- Add logging using either Serilog or log4net in order, would help with cache usage and debugging production issues
- More unit tests
- Introduce dependancy injection to better enable unit testing e.g. allow the calls to the Hacker News API to be contained within another class