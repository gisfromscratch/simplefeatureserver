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
using GIS.Datasources.Geometry;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OGR = OSGeo.OGR;

namespace GIS.Datasources
{
    /// <summary>
    /// Reads various kinds of datasources containing simple features.
    /// </summary>
    public class SimpleFeatureReader
    {
        private readonly ILog _logger;

        public SimpleFeatureReader()
        {
            _logger = LogManager.GetLogger(GetType());
            OSGeo.OGR.Ogr.RegisterAll();
        }

        /// <summary>
        /// Determines the feature layers of the specified datasource.
        /// </summary>
        /// <param name="filePath">The file path to the datasource.</param>
        /// <returns>The feature layers of the specified datasource.</returns>
        public ICollection<FeatureLayer> GetFeatureLayers(string filePath)
        {
            var layers = new List<FeatureLayer>();
            using (var datasource = OGR.Ogr.Open(filePath, 0))
            {
                var layerCount = datasource.GetRefCount();
                for (var layerIndex = 0; layerIndex < layerCount; layerIndex++)
                {
                    var layer = datasource.GetLayerByIndex(layerIndex);
                    layers.Add(new FeatureLayer { Id = layerIndex, Name = layer.GetName(), ConnectionString = filePath });
                }
            }
            return layers;
        }

        /// <summary>
        /// Query the features of this feature layer.
        /// </summary>
        /// <param name="featureLayer"></param>
        /// <returns></returns>
        public ICollection<Feature> QueryFeatureLayer(FeatureLayer featureLayer)
        {
            if (!File.Exists(featureLayer.ConnectionString))
            {
                throw new ArgumentException("The layers datasource does not exists!");
            }

            var features = new List<Feature>();
            using (var datasource = OGR.Ogr.Open(featureLayer.ConnectionString, 0))
            {
                var layerCount = datasource.GetRefCount();
                if (layerCount < featureLayer.Id)
                {
                    throw new ArgumentException("The layer ID is not valid!");
                }

                using (var layer = datasource.GetLayerByIndex(featureLayer.Id))
                {
                    OGR.Feature ogrFeature;
                    while (null != (ogrFeature = layer.GetNextFeature()))
                    {
                        var feature = new Feature();
                        using (var ogrGeometry = ogrFeature.GetGeometryRef())
                        {
                            var geometryType = ogrGeometry.GetGeometryType();
                            switch (geometryType)
                            {
                                case OGR.wkbGeometryType.wkbPoint:
                                case OGR.wkbGeometryType.wkbPoint25D:
                                    var pointCount = ogrGeometry.GetPointCount();
                                    if (1 == pointCount)
                                    {
                                        if (!ogrGeometry.IsEmpty())
                                        {
                                            feature.Geometry = new Point { X = ogrGeometry.GetX(0), Y = ogrGeometry.GetY(0) };
                                        }
                                    }
                                    else
                                    {
                                        string wkt;
                                        ogrGeometry.ExportToWkt(out wkt);
                                        _logger.WarnFormat(@"Geometry '{0}' does not represent a simple point!", wkt);
                                    }
                                    break;
                            }
                        }
                        features.Add(feature);
                    }
                }
            }
            return features;
        }
    }
}
