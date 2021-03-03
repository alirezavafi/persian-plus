using System;

namespace Persian.Plus.Core.DateTime
{
    [Flags]
    public enum EventType
    {
        Holiday = 1,
        NationalEvent = 2,
        InternationalEvent = 4,
        ReligiousEvent = 8,
        HappyEvent = 16,
        SadnessEvent = 32,
        Eyd = 64,
    }
}