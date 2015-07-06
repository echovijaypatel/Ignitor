using System;
using System.ComponentModel;

namespace DBHandler.Entities
{
    public class SendQuotesModel
    {
        [DefaultValue(0)]
        public int Id { get; set; }
        [DefaultValue("")]
        public string QuoteText { get; set; }
        [DefaultValue("")]
        public string QouteAuthor { get; set; }
        [DefaultValue(0)]
        public int CategoryId { get; set; }

        [DefaultValue("")]
        public string Category { get; set; }
    }
}
