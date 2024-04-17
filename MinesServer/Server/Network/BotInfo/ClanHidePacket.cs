﻿using MinesServer.Network.Constraints;

namespace MinesServer.Network.BotInfo
{
    public readonly struct ClanHidePacket : ITopLevelPacket, IDataPart<ClanHidePacket>
    {
        public const string packetName = "cH";

        public string PacketName => packetName;

        public int Length => 1;

        public static ClanHidePacket Decode(ReadOnlySpan<byte> decodeFrom)
        {
            if (!decodeFrom.SequenceEqual([(byte)'_'])) throw new InvalidPayloadException("Invalid payload");
            return new();
        }

        public int Encode(Span<byte> output)
        {
            Span<byte> span = [(byte)'_'];
            span.CopyTo(output);
            return span.Length;
        }
    }
}
