//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Automation.Gui.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class testcas
    {
        public int testcaseid { get; set; }
        public string testcasename { get; set; }
        public int belongstosuite { get; set; }
    
        public virtual testsuite testsuite { get; set; }
    }
}
