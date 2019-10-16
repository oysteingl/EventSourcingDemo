using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Utilities
{
    public static class ObjectExtensions
    {
        public static T Clone<T>(this T @object) => JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(@object));
    }


}