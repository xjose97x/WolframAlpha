using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Wolfram.Alpha.Converters;

namespace Wolfram.Alpha.Models
{
    [Serializable]
    public class QueryResult
    {
        /// <summary>
        ///  True or false depending on whether the input could be successfully understood. 
        ///  If false, there will be no pod subelements.
        /// </summary>
        public bool Success { get; set; }
        
        /// <summary>
        /// Error element.
        /// </summary>
        [JsonConverter(typeof(ErrorConverter))]
        public Error Error { get; set; }

        /// <summary>
        /// The version specification of the API on the server that produced this result.
        /// </summary>
        public float Version { get; set; }

        /// <summary>
        /// Categories and types of data represented in the results.
        /// </summary>
        [JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> DataTypes { get; set; }

        /// <summary>
        /// The wall-clock time in seconds required to generate the output.
        /// </summary>
        public float Timing { get; set; }

        /// <summary>
        /// The number of pods that are missing because they timed out.
        /// </summary>
        public string Timedout { get; set; }

        /// <summary>
        /// The time in seconds required by the parsing phase.
        /// </summary>
        public float ParseTiming { get; set; }

        /// <summary>
        ///  Whether the parsing stage timed out (try a longer parsetimeout parameter if true).
        /// </summary>
        public bool ParseTimedout { get; set; }

        /// <summary>
        ///  A URL to use to recalculate the query and get more pods.
        /// </summary>
        public string Recalculate { get; set; }


        public string TimedoutPods { get; set; }
        public string Id { get; set; }
        public string Host { get; set; }
        public int Server { get; set; }
        public string Related { get; set; }
        public List<Pod> Pods { get; set; }
        [JsonConverter(typeof(SingleOrArrayConverter<Assumption>))]
        public List<Assumption> Assumptions { get; set; }
        [JsonConverter(typeof(SingleOrArrayConverter<Source>))]
        public List<Source> Sources { get; set; }
        [JsonConverter(typeof(SingleOrArrayConverter<Tip>))]
        public List<Tip> Tips { get; set; }
        [JsonProperty("languagemsg")]
        public LanguageMessage LanguageMessage { get; set; }
        public FutureTopic FutureTopic { get; set; }

        [JsonProperty("didyoumeans")]
        [JsonConverter(typeof(SingleOrArrayConverter<DidYouMean>))]
        public List<DidYouMean> DidYouMean { get; set; }
    }
}
