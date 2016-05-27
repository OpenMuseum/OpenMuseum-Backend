using OpenMuseum.Models;

namespace OpenMuseum.Backend.Models
{
    public class ChangeAttachPageViewModel
    {
        public long Id { get; set; }

        public long? PageId { get; set; }
        
        public long? OldPageId { get; set; }

        public Page Page { get; set; }

        public ChangeAttachPageViewModel() { }
    }
}