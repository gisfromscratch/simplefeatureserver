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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GIS.Datasources.Geometry
{
    /// <summary>
    /// Represents a geometry having a spatial reference (<see cref="SpatialReference"/>).
    /// </summary>
    [DataContract]
    [KnownType(typeof(Point))]
    public abstract class DefaultGeometry
    {
        /// <summary>
        /// The spatial reference of this geometry.
        /// The spatial reference can be <c>null</c>.
        /// </summary>
        [DataMember(Name = @"spatialReference")]
        public SpatialReference SpatialReference { get; set; }
    }
}
