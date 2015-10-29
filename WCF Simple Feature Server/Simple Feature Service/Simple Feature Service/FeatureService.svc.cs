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

using GIS.Datasources;
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
    /// Represents a simple feature service.
    /// </summary>
    public class FeatureService : IFeatureService
    {
        public ICollection<FeatureLayer> QueryLayers()
        {
            var reader = new SimpleFeatureReader();
            var layers = reader.GetFeatureLayers(@"D:\LocalGit\Repos\simplefeatureserver\data\Points.shp");
            return layers;
        }
        
        public ICollection<Feature> QueryFeatures(FeatureLayer featureLayer)
        {
            var reader = new SimpleFeatureReader();
            var features = reader.QueryFeatureLayer(featureLayer);
            return features;
        }
    }
}
