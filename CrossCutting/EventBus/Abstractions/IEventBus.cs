using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrossCutting.EventBus.Abstractions {
    public interface IEventBus
    {
        Task Publish(object values, Dictionary<string, object> headers = null);
    }
}