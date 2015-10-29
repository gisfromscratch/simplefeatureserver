/*
 * Copyright 2015 Jan Tschada
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using GIS.Datasources.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GIS.Services.Data
{
    /// <summary>
    /// Feature Server which is accessible through REST.
    /// </summary>
    [DataContract]
    public class FeatureServer
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        public FeatureServer()
        {
            CurrentVersion = @"10.4";
            ServiceDescription = string.Empty;
            HasVersionedData = false;
            SupportsDisconnectedEditing = false;
            SupportedQueryFormats = @"JSON";
            MaxRecordCount = 1000;
            Capabilities = @"Query";
            Description = string.Empty;
            Copyright = string.Empty;
            AllowGeometryUpdates = false;
            Layers = new List<DatasetEntry>();
            Tables = new List<DatasetEntry>();
            EnableZDefaults = false;
        }

        [DataMember(Name = @"currentVersion")]
        public string CurrentVersion { get; set; }

        [DataMember(Name = @"serviceDescription")]
        public string ServiceDescription { get; set; }

        [DataMember(Name = @"hasVersionedData")]
        public bool HasVersionedData { get; set; }

        [DataMember(Name = @"supportsDisconnectedEditing")]
        public bool SupportsDisconnectedEditing { get; set; }

        /// <summary>
        /// Comma-separated list of supported query formats.
        /// </summary>
        [DataMember(Name = @"supportedQueryFormats")]
        public string SupportedQueryFormats { get; set; }

        [DataMember(Name = @"maxRecordCount")]
        public long MaxRecordCount { get; set; }

        /// <summary>
        /// Comma-separated list of capabilities/operations.
        /// </summary>
        [DataMember(Name = @"capabilities")]
        public string Capabilities { get; set; }

        [DataMember(Name = @"description")]
        public string Description { get; set; }

        [DataMember(Name = @"copyrightText")]
        public string Copyright { get; set; }

        [DataMember(Name = @"spatialReference")]
        public SpatialReference SpatialReference { get; set;}

        [DataMember(Name = @"initialExtent")]
        public Envelope InitialExtent { get; set; }

        [DataMember(Name = @"fullExtent")]
        public Envelope FullExtent { get; set; }

        [DataMember(Name = @"allowGeometryUpdates")]
        public bool AllowGeometryUpdates { get; set; }

        /// <summary>
        /// The units of the underlying spatial reference.
        /// </summary>
        [DataMember(Name = @"units")]
        public string Units { get; set; }

        [DataMember(Name = @"layers")]
        public IList<DatasetEntry> Layers { get; set; }

        [DataMember(Name = @"tables")]
        public IList<DatasetEntry> Tables { get; set; }

        [DataMember(Name = @"enableZDefaults")]
        public bool EnableZDefaults { get; set; }

        /// <summary>
        /// The url of this feature server.
        /// </summary>
        [DataMember(Name = @"url")]
        public string ServiceUrl { get; set; }
    }
}