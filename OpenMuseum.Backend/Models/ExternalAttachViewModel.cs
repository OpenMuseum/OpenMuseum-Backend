using TildaNET.Models;

namespace OpenMuseum.Backend.Models
{
    public class ExternalAttachViewModel
    {
        public long Id { get; set; }

        public long? PageId { get; set; }
        public long? OldPageId { get; set; }

        public TildaPage Page { get; set; }

        public ExternalAttachViewModel() { }
    }
}