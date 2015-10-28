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

using GIS.Services.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Hosting;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace GIS.Services
{
    /// <summary>
    /// Represents a catalog service.
    /// </summary>
    public class CatalogService : ICatalogService
    {
        public Stream GetDescription()
        {
            var xsltFilepath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, @"App_Data", @"ServiceDescriptionTemplate.xsl");
            
            // Using the default WCF Data Contract Serializer
            // The XML serializer is not able to serialize instances which implements IDictionary.
            var xmlSerializer = new DataContractSerializer(typeof(Catalog));
            string xmlAsText;
            using (var writer = new StringWriter())
            {
                using (var xmlWriter = new XmlTextWriter(writer))
                {
                    var serviceUrl = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.BaseUri.AbsoluteUri;
                    var catalog = new Catalog();
                    catalog.CurrentVersion = @"10.4";
                    catalog.ServiceUrl = serviceUrl;
                    catalog.Folders.Add(@"root");
                    catalog.Services.Add(@"base", @"FeatureServer");
                    catalog.Services.Add(@"test", @"FeatureServer");
                    xmlSerializer.WriteObject(xmlWriter, catalog);
                    xmlAsText = writer.ToString();
                }
            }

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlAsText);

            var memoryStream = new MemoryStream();
            var xslTransform = new XslTransform();
            xslTransform.Load(xsltFilepath);
            xslTransform.Transform(xmlDocument, null, memoryStream);

            memoryStream.Position = 0;
            WebOperationContext.Current.OutgoingResponse.ContentType = @"text/html";
            return memoryStream;
        }

        public Stream GetStylesheet(string fileName)
        {
            var cssFilePath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, @"App_Data", fileName);
            return File.OpenRead(cssFilePath);
        }

        public IList<FeatureServer> GetFeatureServices()
        {
            var featureServices = new List<FeatureServer>();
            featureServices.Add(new FeatureServer { CurrentVersion = @"10.4", ServiceDescription = string.Empty });
            return featureServices;
        }

        public Stream GetDescription(string format)
        {
            OutputFormat outputFormat;
            if (!Enum.TryParse<OutputFormat>(format, out outputFormat))
            {
                return GetDescription();
            }

            switch (outputFormat)
            {
                case OutputFormat.html:
                    return GetDescription();

                case OutputFormat.json:
                case OutputFormat.pjson:
                    var serviceUrl = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.BaseUri.AbsoluteUri;
                    var catalog = new Catalog();
                    catalog.CurrentVersion = @"10.4";
                    catalog.ServiceUrl = serviceUrl;

                    var jsonSerializer = new DataContractJsonSerializer(typeof(Catalog));
                    var memoryStream = new MemoryStream();
                    jsonSerializer.WriteObject(memoryStream, catalog);
                    memoryStream.Position = 0;
                    return memoryStream;

                default:
                    return GetDescription();
            }
        }
    }
}
