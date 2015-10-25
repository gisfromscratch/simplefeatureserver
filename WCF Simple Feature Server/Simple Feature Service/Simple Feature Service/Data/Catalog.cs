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
using System.Web;

namespace GIS.Services.Data
{
    /// <summary>
    /// Catalog as entry point which is accessible through REST.
    /// </summary>
    [DataContract]
    public class Catalog
    {
        private const string _defaultVersion = @"1.0";

        /// <summary>
        /// Creates a new catalog instance and sets the <see cref="SpecificationVersion"/> to <see cref="_defaultVersion"/>.
        /// </summary>
        public Catalog()
        {
            SpecificationVersion = _defaultVersion;
        }

        /// <summary>
        /// The version of the GeoServices REST specification.
        /// </summary>
        [DataMember(Name = @"specVersion")]
        public string SpecificationVersion { get; set; }

        /// <summary>
        /// The software version of this implementation.
        /// </summary>
        [DataMember(Name = @"currentVersion")]
        public string CurrentVersion { get; set; }

        /// <summary>
        /// The names of folders which can be accessed via REST.
        /// </summary>
        [DataMember(Name = @"folders")]
        public IList<string> Folders { get; set; }

        /// <summary>
        /// The child resources which can be accessed via REST.
        /// </summary>
        [DataMember(Name = @"services")]
        public IDictionary<string, string> Services;
    }
}