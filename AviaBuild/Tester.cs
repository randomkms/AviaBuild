//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AviaBuild
{
    using System;
    using System.Collections.ObjectModel;
    
    public partial class Tester
    {
        public int IdTester { get; set; }
        public string TesterName { get; set; }
        public int TestLabId { get; set; }
    
        public virtual TestLab TestLab { get; set; }
    }
}