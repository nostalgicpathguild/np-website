//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace np_website.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class InventoryItem
    {
        public int InventoryItemId { get; set; }
        public string CharacterName { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
        public int Slots { get; set; }
        public bool Active { get; set; }
        public bool Public { get; set; }
        public bool Imported { get; set; }
    }
}