//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AviaBuildWeb.Models
{
    using System;
    
    public partial class pr11_Result
    {
        public int IdProduct { get; set; }
        public int CehId { get; set; }
        public int TestEquipmentId { get; set; }
        public Nullable<System.DateTime> StartBuild { get; set; }
        public Nullable<System.DateTime> EndBuild { get; set; }
        public Nullable<System.DateTime> StartTest { get; set; }
        public Nullable<System.DateTime> EndTest { get; set; }
        public string Category { get; set; }
        public int IdTestEquipment { get; set; }
        public string TestEquipmentName { get; set; }
        public int TestLabId { get; set; }
        public int IdTestLab { get; set; }
        public string TestLabName { get; set; }
    }
}
