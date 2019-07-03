﻿using Ncs.Pool;
using SuperSocket.SocketBase.Protocol;

namespace Ncs.Server
{
    public class NcsRequestInfo : RequestInfo<NcsRequestInfo>
    {
        public static NcsObjectPool<NcsRequestInfo> RequestInfoPool = new NcsObjectPool<NcsRequestInfo>(null);

        public new dynamic Key { get; private set; }

        public new CGD.buffer Body { get; private set; }

        public CGD.buffer Buffer { get; private set; }

        public NcsRequestInfo(byte[] body, byte[] buffer)
        {
            Key = NcsDefine.Option.TypeFunc(new CGD.buffer(buffer, 0, buffer.Length));
            Body = new CGD.buffer(body, 0, body.Length);
            Buffer = new CGD.buffer(buffer, 0, buffer.Length);
        }

        public NcsRequestInfo()
        {
        }

        public NcsRequestInfo SetBuffer(byte[] body, byte[] buffer)
        {
            Key = NcsDefine.Option.TypeFunc(new CGD.buffer(buffer, 0, buffer.Length));
            Body = new CGD.buffer(body, 0, body.Length);
            Buffer = new CGD.buffer(buffer, 0, buffer.Length);

            return this;
        }

        public void Clear()
        {
            Key = null;
            NcsPool.ReturnBuffer(Body.clear());
            NcsPool.ReturnBuffer(Buffer.clear());
        }
    }
}