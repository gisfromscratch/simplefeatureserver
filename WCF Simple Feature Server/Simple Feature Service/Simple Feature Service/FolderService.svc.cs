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
    /// Represents a folder service.
    /// </summary>
    public class FolderService : IFolderService
    {
        public Stream GetDescription()
        {
            var xsltFilepath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, @"App_Data", @"ServiceDescriptionTemplate.xsl");
            //return File.ReadAllText(xsltFilepath);

            var xmlSerializer = new XmlSerializer(typeof(ServerFolder));
            string xmlAsText;
            using (var writer = new StringWriter())
            {
                xmlSerializer.Serialize(writer, new ServerFolder { Name = @"root" });
                xmlAsText = writer.ToString();
            }

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlAsText);

            //using (var memoryStream = new MemoryStream())
            var memoryStream = new MemoryStream();
            {
                var xslTransform = new XslTransform();
                xslTransform.Load(xsltFilepath);
                xslTransform.Transform(xmlDocument, null, memoryStream);

                memoryStream.Position = 0;
                WebOperationContext.Current.OutgoingResponse.ContentType = @"text/html";
            }

            return memoryStream;
            //return xmlDocument.DocumentElement;
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

        public string GetDescription(OutputFormat format)
        {
            var xsltFilepath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, @"App_Data", @"ServiceDescriptionTemplate.xsl");
            return File.ReadAllText(xsltFilepath);
        }
    }
}
