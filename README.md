<h1 align="center">
<br>
  <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/1/16/Wolfram_Alpha_logo.svg/1000px-Wolfram_Alpha_logo.svg.png"><br>

 Wolfram Alpha .NET
 <br>
</h1>

-----------------
[![NuGet](https://img.shields.io/nuget/v/Wolfram.Alpha.svg)](https://www.nuget.org/packages/Wolfram.Alpha/)
[![NuGet](https://img.shields.io/nuget/dt/Wolfram.Alpha.svg)](https://www.nuget.org/packages/Wolfram.Alpha/) 

## Basic Overview

The introduction of Wolfram|Alpha defined a fundamentally new paradigm for getting knowledge and answers—not by searching the web, but by doing dynamic computations based on a vast collection of built-in data, algorithms and methods.

**Wolfram Alpha .NET** is an open source software library for interacting with the **Wolfram Alpha API** on the .NET platform. 

## Quick Start

Create a WolframAlphaService with your APP ID:

    WolframAlphaService service = new WolframAlphaService("YOUR APP ID");

Create a request to query with WolframAlphaRequest:

    WolframAlphaRequest request = new WolframAlphaRequest
    {
        Input = "YOUR QUERY"
    };

Send the request to WolframAlpha

    WolframAlphaResult result = await service.Compute(request);

WolframAlphaResult is a class that holds the [QueryResult](https://products.wolframalpha.com/api/documentation/#result-queryresult).
<img src="http://community.wolfram.com//c/portal/getImageAttachment?filename=quickwatch.png&userId=1151285" />

Some values may or may not be defined in the result, since it depends on the query and the response given by the Wolfram Alpha Webservice API. For instance, there may be cases in which Wolfram Alpha returns or not Assumptions, Tips, Errors, etc. However, all the properties are defined in the code, and you'll be able to see them when coding (code prediction with Intellisense on Visual Studio)

And if you'd like to print on the console the Pods with text returned, you could do it this way:

    foreach (var pod in result.QueryResult.Pods)
    {
        if(pod.SubPods != null)
        {
            Console.WriteLine(pod.Title);
            foreach (var subpod in pod.SubPods)
            {
                Console.WriteLine("    " + subpod.Plaintext);
            }
        }
    }

Which will print the following in the case of querying "Stephen Wolfram":

<img src="http://community.wolfram.com//c/portal/getImageAttachment?filename=wolframconsole.png&userId=1151285" />

You can filter and do more complex queries by including other properties on the WolframAlphaRequest object such as the Pod Ids , Units (Metric, non metric), formats, your location, etc. Look at [parameter references](https://products.wolframalpha.com/api/documentation/#parameter-reference).

**We use [GitHub issues](https://github.com/xjose97x/WolframAlpha/issues) for
tracking requests and bugs.**

## Implementations
* [Wolfram|Alpha Bot](https://www.facebook.com/wolframalphabot)



## For more information

* [Wolfram Research Website](http://www.wolfram.com/)
* [Wolfram Alpha Website](https://www.wolframalpha.com/)
* [Wolfram Alpha Full Results API Reference](https://products.wolframalpha.com/api/documentation/)
* [Wolfram Alpha Webservice API Reference](http://products.wolframalpha.com/docs/WolframAlpha-API-Reference.pdf?_ga=2.22650683.1895728587.1510530683-479065163.1490235393)

Learn more about the Wolfram community at the [community page of Wolfram](http://community.wolfram.com) for a few ways to participate.

## Contribute

Contributions are always welcome! Fork this repo and submit a Pull Request 

Caught a mistake or want to contribute to the documentation? [Edit this page on Github](https://github.com/xjose97x/WolframAlpha/blob/master/README.md) 

#### License

MIT

---

> GitHub [@xjose97x](https://github.com/xjose97x) &nbsp;&middot;&nbsp;
> Twitter [@xjose97x](https://twitter.com/xjose97x) &nbsp;&middot;&nbsp;
> Linkedin [Jose Escudero](https://www.linkedin.com/in/xjose97x/)
