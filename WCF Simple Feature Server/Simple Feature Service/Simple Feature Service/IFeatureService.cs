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

using GIS.Datasources.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GIS.Services
{
    /// <summary>
    /// Represents a feature service accessing simple features.
    /// </summary>
    [ServiceContract]
    public interface IFeatureService
    {
        /// <summary>
        /// All layers registered with this feature service.
        /// </summary>
        /// <returns>A list of all layers.</returns>
        [OperationContract]
        ICollection<FeatureLayer> QueryLayers();

        /// <summary>
        /// Queries features of the specified feature layer.
        /// </summary>
        /// <param name="featureLayer">The features layer which should be queried.</param>
        /// <returns>A list of all features of the specified layer.</returns>
        [OperationContract]
        ICollection<Feature> QueryFeatures(FeatureLayer featureLayer);
    }
}
