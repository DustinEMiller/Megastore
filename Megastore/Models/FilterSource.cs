using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Megastore.Models;
using System.Diagnostics;

namespace TwoTap.Models
{

    public interface ITwoTapFilter
    {
        string Name { get; }
        int Count { get; }
    }

    public class TwoTapFilter : ITwoTapFilter
    {
        protected ApplicationDbContext _context;

        public virtual void SaveTwotapItem() { }

        public string Name { get; set; }
        public int Count { get; set; }

        public TwoTapFilter() {
            _context = new ApplicationDbContext();
        }
    }

    public class Category : TwoTapFilter, ITwoTapFilter
    {
        public override void SaveTwotapItem() {

            string[] splitCategories = Name.Replace("~~", "~").Split('~');
            int parentId = 0;

            foreach (var category in splitCategories) {

                var row = _context.Categories.SingleOrDefault(c => c.Name == category);

                if (row == null) {
                    var cat = new Megastore.Models.Category();
                    cat.Name = category;
                    cat.ParentId = parentId;
                    try {
                        _context.Categories.Add(cat);
                        _context.SaveChanges();
                        parentId = cat.Id;
                    }
                    catch (Exception e) {
                        Debug.WriteLine(e.ToString());
                    }
                }
                else {
                    parentId = row.Id;
                }
            }
        }

    }

    public class SiteId : TwoTapFilter, ITwoTapFilter
    {
        public override void SaveTwotapItem() {
            var row = _context.Sites.SingleOrDefault(b => b.SiteId == Name);
            if (row == null) {
                var site = new Megastore.Models.Site();
                site.SiteId = Name;
                try {
                    _context.Sites.Add(site);
                    _context.SaveChanges();
                }
                catch (Exception e) {
                    Debug.WriteLine(e.ToString());
                }
            }
        }
    }

    public class Size : TwoTapFilter, ITwoTapFilter
    {
        public override void SaveTwotapItem() {
            var row = _context.Sizes.SingleOrDefault(b => b.Name == Name);
            if (row == null) {
                var size = new Megastore.Models.Size();
                size.Name = Name;
                try {
                    _context.Sizes.Add(size);
                    _context.SaveChanges();
                }
                catch (Exception e) {
                    Debug.WriteLine(e.ToString());
                }
            }
        }
    }

    public class Promotion : TwoTapFilter, ITwoTapFilter
    {
        public override void SaveTwotapItem() {
            var row = _context.Promotions.SingleOrDefault(b => b.Name == Name);
            if (row == null) {
                var promotion = new Megastore.Models.Promotion();
                promotion.Name = Name;
                try {
                    _context.Promotions.Add(promotion);
                    _context.SaveChanges();
                }
                catch (Exception e) {
                    Debug.WriteLine(e.ToString());
                }
            }
        }
    }

    public class Gender : TwoTapFilter, ITwoTapFilter
    {
        public override void SaveTwotapItem() {
            var row = _context.Genders.SingleOrDefault(b => b.Name == Name);
            if (row == null) {
                var gender = new Megastore.Models.Gender();
                gender.Name = Name;
                try {
                    _context.Genders.Add(gender);
                    _context.SaveChanges();
                }
                catch (Exception e) {
                    Debug.WriteLine(e.ToString());
                }
            }
        }
    }

    public class Brand : TwoTapFilter, ITwoTapFilter
    {
        public override void SaveTwotapItem() {
            var row = _context.Brands.SingleOrDefault(b => b.Name == Name);
            if (row == null) {
                var brand = new Megastore.Models.Brand();
                brand.Name = Name;
                try {
                    _context.Brands.Add(brand);
                    _context.SaveChanges();
                }
                catch (Exception e) {
                    Debug.WriteLine(e.ToString());
                }
            }
        }
    }

    public class FilterSource
    {
        public string message { get; set; }
        public List<Category> categories { get; set; }
        public List<Gender> genders { get; set; }
        public List<Size> sizes { get; set; }
        public List<SiteId> site_ids { get; set; }
        public List<Promotion> promotions { get; set; }
        public List<Brand> brands { get; set; }


        public void PopulateFilters() {
            
            IterateList(categories);
            IterateList(genders);
            IterateList(sizes);
            IterateList(site_ids);
            IterateList(promotions);
            IterateList(brands);
        }

        // There has to be a better way to do this. It's too repetitive
        // I think this whole class and teh saving of items can be done better, but my ignorance is a blocker
        public void IterateList(List<Category> list) {
            foreach (var item in list) {
                item.SaveTwotapItem();
            }
        }

        public void IterateList(List<Brand> list) {
            foreach (var item in list) {
                item.SaveTwotapItem();
            }
        }

        public void IterateList(List<Gender> list) {
            foreach (var item in list) {
                item.SaveTwotapItem();
            }

        }

        public void IterateList(List<Size> list) {
            foreach (var item in list) {
                item.SaveTwotapItem();
            }
        }

        public void IterateList(List<SiteId> list) {
            foreach (var item in list) {
                item.SaveTwotapItem();
            }
        }

        public void IterateList(List<Promotion> list) {
            foreach (var item in list) {
                item.SaveTwotapItem();
            }
        }
    }
}