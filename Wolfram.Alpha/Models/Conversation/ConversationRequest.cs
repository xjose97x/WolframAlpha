using System.Device.Location;
using Newtonsoft.Json;

namespace Wolfram.Alpha.Models.Conversation
{
    public class ConversationRequest
    {
        public string i { get; set; }
        public GeoCoordinate GeoLocation { get; set; }
        public string Ip { get; set; }
        public string Units { get; set; }
        public string s { get; set; }
        public string conversationid { get; set; }
        public string Host { get; set; }
    }
}
