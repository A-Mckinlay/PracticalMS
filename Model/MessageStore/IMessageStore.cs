using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleEventStore;

namespace Model.MessageStore
{
    public interface IMessageStore
    {
        Task AppendToStream(string streamId, int expectedRevision, EventData data);
        Task<IReadOnlyCollection<StorageEvent>> ReadStreamForwards(string streamId, int startPosition, int numberOfEventsToRead);
        Task<IReadOnlyCollection<StorageEvent>> ReadStreamForwards(string streamId);
    }
}
