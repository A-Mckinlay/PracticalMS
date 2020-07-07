using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using SimpleEventStore;
using SimpleEventStore.InMemory;

namespace Model.MessageStore
{
    public class MessageStore : IMessageStore
    {
        private EventStore _store;

        public MessageStore()
        {
            var storageEngine = new InMemoryStorageEngine();
            this._store = new EventStore(storageEngine);
        }

        public async Task AppendToStream(string streamId, int expectedRevision, EventData data)
        {
            await this._store.AppendToStream(streamId, expectedRevision, data);
        }

        public async Task<IReadOnlyCollection<StorageEvent>> ReadStreamForwards(string streamId, int startPosition, int numberOfEventsToRead)
        {
            return await this._store.ReadStreamForwards(streamId, startPosition, numberOfEventsToRead);
        }

        public async Task<IReadOnlyCollection<StorageEvent>> ReadStreamForwards(string streamId)
        {
            return await this._store.ReadStreamForwards(streamId);
        }
    }
}

