using OpenMuseum.Backend.Models;
using OpenMuseum.Models;

namespace OpenMuseum.Backend.ViewModels
{
    public class BaseLayerAPIViewModel
    {
        public BaseLayerAPIViewModel(BaseLayer layer)
        {
            Id = layer.Id;
            Name = layer.Name;
            Description = layer.Description;
            Url = layer.Url;
            Default = layer.Default;
            Height = layer.Height;
            Width = layer.Width;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public bool Default { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }
}