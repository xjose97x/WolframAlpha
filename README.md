<h1 align="center">
<br>
  <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/1/16/Wolfram_Alpha_logo.svg/1000px-Wolfram_Alpha_logo.svg.png"><br>

 Wolfram Alpha .NET
 <br>
</h1>

-----------------

## Basic Overview

The introduction of Wolfram|Alpha defined a fundamentally new paradigm for getting knowledge and answers—not by searching the web, but by doing dynamic computations based on a vast collection of built-in data, algorithms and methods.

**Wolfram Alpha .NET** is an open source software library for interacting with the **Wolfram Alpha API** on the .NET platform. 

## Quick Start

Create a WolframAlphaService with your APP ID:

    WolframAlphaService service = new WolframAlphaService("YOUR APP ID");

Create a request to query with WolframAlphaRequest:

    WolframAlphaRequest request = new WolframAlphaRequest
    {
        Input = "20 degrees to radians"
    };

Send the request to WolframAlpha

    WolframAlphaResult x = service.Compute(request);


**We use [GitHub issues](https://github.com/xjose97x/WolframAlpha/issues) for
tracking requests and bugs.**

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
