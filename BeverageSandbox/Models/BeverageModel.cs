using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace BeverageSandbox.Models
{

    public class Brand
    {
        [Key]
        public int BrandID { get; set; }
        [Required]
        public string Name { get; set; }
        
        public virtual ICollection<Beer> Beers { get; set; }
    }

    public class Beer
    {
        [Key]
        public int BeerID { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal ABV { get; set; }

        public virtual Brand Brand { get; set; }
    }

    //public class Hop
    //{
    //    [Key]
    //    public int HopsID { get; set; }
    //    [Required]
    //    public string Name { get; set; }
    //    public int AlphaAcid { get; set; }
    //}

    public class BeverageContext : DbContext
    {
        // constructor which will define which connection string to use (defined in web.config)
        public BeverageContext()
            : base("BeverageConnection")
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Beer> Beers { get; set; }
        //public DbSet<Hop> Hops { get; set; }
    }

}