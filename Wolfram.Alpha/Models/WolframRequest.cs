using System.Collections.Generic;
using System.Device.Location;
using Wolfram.Alpha.Models.Enums;

namespace Wolfram.Alpha.Models
{
    public class WolframRequest
    {
        //Basic Parameters

        /// <summary>
        /// Specifies a pod ID to include in the result
        /// </summary>
        public string Input { get; set; }
        /// <summary>
        /// The desired format for individual result pods
        /// </summary>
        /// <remarks>Default: "plaintext,image"</remarks>
        public List<Format> Formats { get; set; }

        /// <summary>
        /// The desired format for full results
        /// </summary>
        public const string Output = "json";


        //Pod Selection

        /// <summary>
        /// Specifies a pod ID to include in the result
        /// </summary>
        /// <remarks>Default: All pods included</remarks>
        public List<string> IncludePodIds { get; set; }

        /// <summary>
        /// Specifies a pod ID to exclude from the result	
        /// </summary>
        /// <remarks>Default: No pods excluded</remarks>
        public List<string> ExclusePodIds { get; set; }

        /// <summary>
        /// Specifies a pod title to include in the result	
        /// </summary>
        /// <remarks>Default: All pods returned</remarks>
        public List<string> PodTitles { get; set; }

        /// <summary>
        /// Specifies the index(es) of the pod(s) to return	
        /// </summary>
        /// <remarks>Default: All pods returned</remarks>
        public List<int> PodIndex { get; set; }

        /// <summary>
        /// Specifies that only pods produced by the given scanner should be returned
        /// </summary>
        /// <remarks>Default: Pods from all scanners returned</remarks>
        public List<string> Scanners { get; set; }

        //Location

        /// <summary>
        /// Specifies a custom query location based on an IP address
        /// </summary>
        /// <remarks>Default: Use caller's IP address for location</remarks>
        public string IpAddress { get; set; }

        /// <summary>
        /// Specifies a custom query location based on a latitude/longitude pair
        /// </summary>
        /// <remarks>Default: Use caller's IP address for location</remarks>
        public GeoCoordinate GeoCoordinate { get; set; }

        /// <summary>
        /// Specifies a custom query location based on a string
        /// </summary>
        /// <remarks>Default: Use caller's IP address for location</remarks>
        public string Location { get; set; }


        //Size

        /// <summary>
        /// Specify an approximate width limit for text and tables
        /// </summary>
        /// <remarks>Default: Width set at 500 pixels</remarks>
        public int Width { get; set; }

        /// <summary>
        /// Specify an extended maximum width for large objects
        /// </summary>
        /// <remarks>Default: Width set at 500 pixels</remarks>
        public int MaxWidth { get; set; }

        /// <summary>
        /// Specify an approximate width limit for plots and graphics
        /// </summary>
        /// <remarks>Default: Plot width set at 200 pixels</remarks>
        public int PlotWidth { get; set; }

        /// <summary>
        /// Specify magnification of objects within a pod
        /// </summary>
        /// <remarks>Default: Magnification factor of 1.0</remarks>
        public int Magnification { get; set; }


        //Timeouts/Async

        /// <summary>
        /// The number of seconds to allow Wolfram|Alpha to 
        /// compute results in the "scan" stage of processing
        /// </summary>
        /// <remarks>Default: Scan stage times out after 3.0 seconds</remarks>
        public float ScanTimeout { get; set; }

        /// <summary>
        /// The number of seconds to allow Wolfram|Alpha to 
        /// spend in the "format" stage for any one pod
        /// </summary>
        /// <remarks>Default: Individual pods time out after 4.0 seconds</remarks>
        public float PodTimeout { get; set; }

        /// <summary>
        /// The number of seconds to allow Wolfram|Alpha to 
        /// spend in the "format" stage for the entire collection of pods
        /// </summary>
        /// <remarks>Default: Format stage times out after 8.0 seconds</remarks>
        public float FormatTimeout { get; set; }

        /// <summary>
        /// The number of seconds to allow Wolfram|Alpha to 
        /// spend in the "parsing" stage of processing
        /// </summary>
        /// <remarks>Default: Parsing stage times out after 5.0 seconds</remarks>
        public float ParseTimeout { get; set; }

        /// <summary>
        /// The total number of seconds to allow Wolfram|Alpha 
        /// to spend on a query
        /// </summary>
        /// <remarks>Default: Queries time out after 20.0 seconds</remarks>
        public float TotalTimeout { get; set; }

        /// <summary>
        /// Toggles asynchronous mode to allow partial results to 
        /// return before all the pods are computed
        /// </summary>
        /// <remarks>Default: Aynchronous mode disabled ("false")</remarks>
        public bool Async { get; set; }


        //Miscellaneous

        /// <summary>
        /// Whether to allow Wolfram|Alpha to reinterpret queries that 
        /// would otherwise not be understood
        /// </summary>
        /// <remarks>Default: Do not reinterpret queries ("false")</remarks>
        public bool Reinterpret { get; set; }

        /// <summary>
        /// Whether to allow Wolfram|Alpha to try to translate simple 
        /// queries into English
        /// </summary>
        /// <remarks>Default: Do not attempt translation ("false")</remarks>
        public bool Translation { get; set; }

        /// <summary>
        /// Whether to force Wolfram|Alpha to ignore case in queries
        /// </summary>
        /// <remarks>Default: Do not ignore case ("false")</remarks>
        public bool IgnoreCase { get; set; }

        /// <summary>
        /// A special signature that can be applied to guard against misuse of your AppID
        /// </summary>
        /// <remarks>Default: No signature applied</remarks>
        public string Signature { get; set; }

        /// <summary>
        /// Specifies an assumption, such as the meaning of a word or the value of a formula variable
        /// </summary>
        /// <remarks>Default: Assumptions made implicitly by the API</remarks>
        public List<string> Assumptions { get; set; }

        /// <summary>
        /// Specifies a pod state change, which replaces a pod with a modified version, 
        /// such as displaying more digits of a large decimal value
        /// </summary>
        /// <remarks>Default: Pod states generated implicitly by the API</remarks>
        public List<string> PodStates { get; set; }

        /// <summary>
        /// Lets you specify the preferred measurement system, either 
        /// "metric" or "nonmetric" (US customary units)
        /// </summary>
        /// <remarks>Default: Chosen based on caller's IP address</remarks>
        public Unit Unit { get; set; }
    }
}
