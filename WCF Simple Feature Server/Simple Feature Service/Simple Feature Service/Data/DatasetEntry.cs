using GIS.Datasources.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GIS.Services.Data
{
    /// <summary>
    /// A dataset entry having an ID and a name.
    /// </summary>
    [DataContract]
    public class DatasetEntry
    {
        [DataMember(Name = @"id")]
        public int Id { get; set; }

        [DataMember(Name = @"name")]
        public string Name { get; set; }
    }
}