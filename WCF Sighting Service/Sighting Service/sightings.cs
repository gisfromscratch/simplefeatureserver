//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sighting.Services
{
    using System;
    using System.Collections.Generic;
    
    public partial class sightings
    {
        public int OID { get; set; }
        public System.Data.Entity.Spatial.DbGeometry Shape { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> DeviceId { get; set; }
    
        public virtual devices devices { get; set; }
    }
}
