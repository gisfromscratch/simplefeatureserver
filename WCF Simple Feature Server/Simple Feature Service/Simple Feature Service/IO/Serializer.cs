using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web;

namespace GIS.Services.IO
{
    /// <summary>
    /// Simple serializer
    /// </summary>
    internal static class Serializer
    {
        internal static Stream ToJson<TInstance>(TInstance instance) where TInstance : class
        {
            var jsonSerializer = new DataContractJsonSerializer(instance.GetType());
            var memoryStream = new MemoryStream();
            jsonSerializer.WriteObject(memoryStream, instance);
            memoryStream.Position = 0;
            return memoryStream; 
        }
    }
}