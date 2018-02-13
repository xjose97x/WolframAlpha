using System;

namespace Wolfram.Alpha.Models.Conversation
{
    [Serializable]
    public class ConversationResult
    {
        public string Result { get; set; }
        public string ConversationId { get; set; }
        public string Host { get; set; }
        public string S { get; set; }
        public string Error { get; set; }
    }
}
