using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MarioTravel.Core.BLL.Services.Payment.Service
{
    public sealed class AsyncDuplicateLock
    {
        public sealed class RefCounted<T>
        {
            public RefCounted(T value)
            {
                RefCount = 1;
                Value = value;
            }

            public T Value { get; }
            public int RefCount { get; set; }
        }

        private static readonly Dictionary<string, RefCounted<SemaphoreSlim>> semaphoreSlims =
            new Dictionary<string, RefCounted<SemaphoreSlim>>();

        private static SemaphoreSlim GetOrCreate(string key)
        {
            RefCounted<SemaphoreSlim> item;

            lock (semaphoreSlims)
            {
                if (semaphoreSlims.TryGetValue(key, out item))
                {
                    ++item.RefCount;
                }
                else
                {
                    {
                        item = new RefCounted<SemaphoreSlim>(new SemaphoreSlim(1, 1));
                        semaphoreSlims[key] = item;
                    }
                }
            }

            return item.Value;
        }

        public IDisposable Lock(string key)
        {
            GetOrCreate(key).Wait();
            return new Releaser { Key = key };
        }

        public async Task<IDisposable> LockAsync(string key)
        {
            await GetOrCreate(key).WaitAsync().ConfigureAwait(false);
            return new Releaser { Key = key };
        }

        private sealed class Releaser : IDisposable
        {
            public string Key { private get; set; }

            public void Dispose()
            {
                RefCounted<SemaphoreSlim> item;

                lock (semaphoreSlims)
                {
                    item = semaphoreSlims[Key];
                    --item.RefCount;
                    if (item.RefCount == 0)
                    {
                        semaphoreSlims.Remove(Key);
                    }
                }

                item.Value.Release();
            }
        }
    }
}