using ReactiveUI;

namespace AchtGewinnt.Models
{
    public abstract class ModelBase : ReactiveObject
    {
        public int Id { get; set; }
    }
}
