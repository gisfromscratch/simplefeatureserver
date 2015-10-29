using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GIS.Datasources.Geometry
{
    /// <summary>
    /// A two-dimensional envelope.
    /// </summary>
    [DataContract]
    public class Envelope : DefaultGeometry
    {
        [DataMember(Name = @"xmin")]
        public double XMin { get; set; }

        [DataMember(Name = @"ymin")]
        public double YMin { get; set; }

        [DataMember(Name = @"xmax")]
        public double XMax { get; set; }

        [DataMember(Name = @"ymax")]
        public double YMax { get; set; }
    }
}
