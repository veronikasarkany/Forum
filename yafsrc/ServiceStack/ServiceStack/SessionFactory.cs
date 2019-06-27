﻿using ServiceStack.Caching;
using ServiceStack.Text.Common;
using ServiceStack.Web;

namespace ServiceStack
{
    public class SessionFactory : ISessionFactory
    {
        private readonly ICacheClient cacheClient;

        public SessionFactory(ICacheClient cacheClient)
        {
            this.cacheClient = cacheClient;
        }

        public class SessionCacheClient : ISession
        {
            private readonly ICacheClient cacheClient;
            private readonly string prefixNs;

            public SessionCacheClient(ICacheClient cacheClient, string sessionId)
            {
                this.cacheClient = cacheClient;
                this.prefixNs = "sess:" + sessionId + ":";
            }

            public object this[string key]
            {
                get => cacheClient.Get<object>(this.prefixNs + key);
                set
                {
                    JsWriter.WriteDynamic(() =>
                        cacheClient.Set(this.prefixNs + key, value));
                }
            }

            public void Set<T>(string key, T value)
            {
                var expiry = HostContext.GetPlugin<SessionFeature>()?.SessionBagExpiry;
                if (expiry != null)
                    cacheClient.Set(this.prefixNs + key, value, expiry.Value);
                else
                    cacheClient.Set(this.prefixNs + key, value);
            }

            public T Get<T>(string key)
            {
                return cacheClient.Get<T>(this.prefixNs + key);
            }

            public bool Remove(string key)
            {
                return cacheClient.Remove(this.prefixNs + key);
            }

            public void RemoveAll()
            {
                cacheClient.RemoveByPattern(this.prefixNs + "*");
            }
        }

        public ISession GetOrCreateSession(IRequest httpReq, IResponse httpRes)
        {
            var sessionId = httpReq.GetSessionId()
                ?? httpRes.CreateSessionIds(httpReq);

            return new SessionCacheClient(cacheClient, sessionId);
        }

        public ISession GetOrCreateSession()
        {
            var request = HostContext.GetCurrentRequest();
            return GetOrCreateSession(request, request.Response);
        }

        public ISession CreateSession(string sessionId)
        {
            return new SessionCacheClient(cacheClient, sessionId);
        }
    }
}