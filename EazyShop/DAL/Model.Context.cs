﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EazyShopEntities2 : DbContext
    {
        public EazyShopEntities2()
            : base("name=EazyShopEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Columns> Columns { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Nodes> Nodes { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Products_for_lists> Products_for_lists { get; set; }
        public virtual DbSet<Reserved_lists> Reserved_lists { get; set; }
        public virtual DbSet<Transition> Transition { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
