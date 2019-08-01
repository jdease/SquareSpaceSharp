﻿using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class Amount2
    {
        [JsonProperty("value")] public string Value { get; set; }

        [JsonProperty("currency")] public string Currency { get; set; }
    }
}