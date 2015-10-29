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
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace GIS.Services
{
    /// <summary>
    /// Represents a catalog service describing the available services and allows navigating through those services.
    /// </summary>
    [ServiceContract]
    public interface ICatalogService
    {
        /// <summary>
        /// The description of this and all child services.
        /// </summary>
        /// <returns>The description using HTML format.</returns>
        [OperationContract(Name = @"description")]
        [WebInvoke(Method = @"GET", 
            UriTemplate = @"/")
            //ResponseFormat = WebMessageFormat
            //BodyStyle = WebMessageBodyStyle.Bare)
        ]
        Stream GetDescription();

        /// <summary>
        /// The default CSS stylesheet for rendering the HTML view.
        /// </summary>
        /// <returns>The default CSS stylesheet</returns>
        [OperationContract(Name = @"stylesheet")]
        [WebInvoke(Method = @"GET",
            UriTemplate = @"/static/css/{fileName}")
        ]
        Stream GetStylesheet(string fileName);

        [OperationContract(Name = @"service")]
        [WebInvoke(Method = @"GET", 
            UriTemplate = @"/{serviceName}/FeatureServer")
        ]
        Stream GetFeatureService(string serviceName);

        /// <summary>
        /// The description of this and all child services.
        /// </summary>
        /// <param name="format">The output format.</param>
        /// <returns>The description using the specified output format.</returns>
        [OperationContract(Name = @"descriptionWithFormat")]
        [WebInvoke(Method = @"GET",
            UriTemplate = @"/?f={format}")
        ]
        Stream GetDescription(string format);
    }
}
