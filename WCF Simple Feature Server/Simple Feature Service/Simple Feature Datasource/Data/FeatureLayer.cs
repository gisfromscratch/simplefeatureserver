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
using System.Text;
using System.Threading.Tasks;

namespace GIS.Datasources.Data
{
    /// <summary>
    /// Represents a layer having features of the same geometry type and spatial reference.
    /// </summary>
    [DataContract]
    public class FeatureLayer
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        public FeatureLayer()
        {
            Id = 0;
            Name = string.Empty;
            DisplayField = string.Empty;
            Description = string.Empty;
            Copyright = string.Empty;
            IsDefaultVisible = true;
            IsDataVersioned = false;
            SupportsRollbackOnFailure = false;
            SupportsStatistics = false;
            SupportsAdvancedQueries = false;
            GeometryType = @"esriGeometryPoint";
            MinScale = 0.0;
            MaxScale = 0.0;
            EffectiveMinScale = 0.0;
            EffectiveMaxScale = 0.0;
            HasM = false;
            HasZ = false;
            EnableZDefaults = false;
            ZDefault = 0.0;
            AllowGeometryUpdates = false;
            HasAttachments = false;
            ObjectIdFieldName = string.Empty;
            GlobalIdFieldName = string.Empty;
            TypeIdFieldName = string.Empty;
        }

        [DataMember(Name = @"id")]
        public int Id { get; set; }

        [DataMember(Name = @"name")]
        public string Name { get; set; }

        [DataMember(Name = @"type")]
        public string Type
        {
            get
            {
                return @"Feature Layer";
            }

            set
            {
                // Ignore any values
            }
        }

        [DataMember(Name = @"displayField")]
        public string DisplayField { get; set; }

        [DataMember(Name = @"description")]
        public string Description { get; set; }

        [DataMember(Name = @"copyrightText")]
        public string Copyright { get; set; }

        [DataMember(Name = @"defaultVisibility")]
        public bool IsDefaultVisible { get; set; }

        [DataMember(Name = @"isDataVersioned")]
        public bool IsDataVersioned { get; set; }

        [DataMember(Name = @"supportsRollbackOnFailureParameter")]
        public bool SupportsRollbackOnFailure { get; set; }

        [DataMember(Name = @"supportsStatistics")]
        public bool SupportsStatistics { get; set; }

        [DataMember(Name = @"supportsAdvancedQueries")]
        public bool SupportsAdvancedQueries { get; set; }

        [DataMember(Name = @"geometryType")]
        public string GeometryType { get; set; }

        [DataMember(Name = @"minScale")]
        public double MinScale { get; set; }

        [DataMember(Name = @"maxScale")]
        public double MaxScale { get; set; }

        [DataMember(Name = @"effectiveMinScale")]
        public double EffectiveMinScale { get; set; }

        [DataMember(Name = @"effectiveMaxScale")]
        public double EffectiveMaxScale { get; set; }

        [DataMember(Name = @"extent")]
        public Envelope Extent { get; set; }

        [DataMember(Name = @"hasM")]
        public bool HasM { get; set; }

        [DataMember(Name = @"hasZ")]
        public bool HasZ { get; set; }

        [DataMember(Name = @"enableZDefaults")]
        public bool EnableZDefaults { get; set; }

        [DataMember(Name = @"zDefault")]
        public double ZDefault { get; set; }

        [DataMember(Name = @"allowGeometryUpdates")]
        public bool AllowGeometryUpdates { get; set; }

        [DataMember(Name = @"HasAttachments")]
        public bool HasAttachments { get; set; }

        [DataMember(Name = @"objectIdField")]
        public string ObjectIdFieldName { get; set; }

        [DataMember(Name = @"globalIdField")]
        public string GlobalIdFieldName { get; set; }

        [DataMember(Name = @"typeIdField")]
        public string TypeIdFieldName { get; set; }

        /// <summary>
        /// The connection string referencing the underlying datasource.
        /// </summary>
        [DataMember(Name = @"connectionString")]
        public string ConnectionString { get; set; }
    }
}
