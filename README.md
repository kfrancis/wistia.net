Wistia .NET API Wrapper
============================

This library is meant to be used with the [Wistia API](http://wistia.com/doc/developers).

You'll need API credentials to interact with the Wistia V1 API, which you can get by generating credentials within your account settings.

Getting Started
---------------

Install the nuget:
    
    Install-Package Wistia.Core

Sample Code
-----------

Check out the [Unit Tests](https://github.com/kfrancis/wistia.net/tree/master/src/Wistia.Core.Tests) for usage examples.

View the account details:

``` c#
var dataClient = new WistiaDataClient(apiKey: "123abc");
var result = dataClient.Account.Get();
```
``` c#
var statsClient = new WistiaStatsClient(apiKey: "123abc");
var result = statsClient.Account.Get();
```

Supported Endpoints
------------

* [Data](http://wistia.com/doc/data-api)
* [Stats](http://wistia.com/doc/stats-api)

Contributing
------------

**What to contribute:**

* Check out the project's [issues page](https://github.com/kfrancis/wistia.net/issues)
* Refactor something that looks messy to you!

**How to contribute:**

* Fork the project.
* Implement your feature on a topic branch.
* Add tests for it.  This is important so we don't break it in a future version unintentionally.
* Commit, do not mess with the nuspec, version, or history.  If you want to have your own version, that's fine but bump version in a commit by itself that we can ignore when we pull.
* Send us a pull request.
 
Copyright
---------

Copyright (c) 2014 Kori Francis, See LICENSE.txt for further details.