using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RisLab1;
using System.Data.Entity;
using System.Dynamic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace RisLab1Server
{
    class DbInserter
    {
        public static void InsertToDb(List<DbEntry> dbEntries)
        {
            foreach (var dbEntry in dbEntries)
            {
                InsertAnEntry(dbEntry);
            }
        }

        static void InsertAnEntry(DbEntry dbEntry)
        {
            SmartPhonesModelContainer context = new SmartPhonesModelContainer();
            int specificationId = InsertSpecification(dbEntry, context);
            int locationId = InsertLocation(dbEntry, context);
            int brandId = InsertBrand(dbEntry, context);
            InsertLocationByBrand(locationId, brandId, dbEntry, context);
            InsertSmartPhoneSet(specificationId, brandId, dbEntry, context);
        }

        private static int InsertSpecification(DbEntry dbEntry, SmartPhonesModelContainer context)
        {
            Specification specification = new Specification()
            {
                RAMInGB = dbEntry.RAM
            };
            context.SpecificationSet.Add(specification);
            context.SaveChanges();

            return specification.Id;
        }

        private static int InsertLocation(DbEntry dbEntry, SmartPhonesModelContainer context)
        {
            Location location = new Location()
            {
                Address = dbEntry.Location
            };
            context.LocationSet.Add(location);
            context.SaveChanges();

            return location.Id;
        }

        private static int InsertBrand(DbEntry dbEntry, SmartPhonesModelContainer context)
        {
            Brand brand = new Brand()
            {
                Name = dbEntry.Brand
            };
            context.BrandSet.Add(brand);
            context.SaveChanges();

            return brand.Id;
        }

        private static int InsertLocationByBrand(int locationId, int brandId, DbEntry dbEntry, SmartPhonesModelContainer context)
        {
            LocationsByBrand locationByBrand = new LocationsByBrand()
            {
                LocationId = locationId,
                BrandId = brandId
            };
            context.LocationsByBrandSet.Add(locationByBrand);
            context.SaveChanges();

            return locationByBrand.Id;
        }

        private static int InsertSmartPhoneSet(int specificationId, int brandId, DbEntry dbEntry, SmartPhonesModelContainer context)
        {
            SmartPhone smartphone = new SmartPhone()
            {
                BrandId = brandId,
                SpecificationId = specificationId,
                Model = dbEntry.Model             
            };
            context.SmartPhoneSet.Add(smartphone);
            context.SaveChanges();

            return smartphone.Id;
        }
    }
}
