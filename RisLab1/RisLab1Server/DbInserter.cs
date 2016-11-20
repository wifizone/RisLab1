using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RisLab1;
using System.Data.Entity;
using System.Dynamic;
using System.Net.Sockets;

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
            SmartPhonesEntities context = new SmartPhonesEntities();
            int specificationId = InsertSpecification(dbEntry, context);
            int locationId = InsertLocation(dbEntry, context);
            int brandId = InsertBrand(dbEntry, context);
            InsertSpecificationsByBrand(locationId, brandId, dbEntry, context);
            InsertSmartPhoneSet(specificationId, brandId, dbEntry, context);
        }

        private static int InsertSpecification(DbEntry dbEntry, SmartPhonesEntities context)
        {
            SpecificationSet specification = new SpecificationSet()
            {
                RAMInGB = dbEntry.RAM
            };
            context.SpecificationSet.Add(specification);
            context.SaveChanges();

            return specification.Id;
        }

        private static int InsertLocation(DbEntry dbEntry, SmartPhonesEntities context)
        {
            LocationsSet location = new LocationsSet()
            {
                Address = dbEntry.Location
            };
            context.LocationsSet.Add(location);
            context.SaveChanges();

            return location.Id;
        }

        private static int InsertBrand(DbEntry dbEntry, SmartPhonesEntities context)
        {
            BrandSet brand = new BrandSet()
            {
                Name = dbEntry.Brand
            };
            context.BrandSet.Add(brand);
            context.SaveChanges();

            return brand.Id;
        }

        private static int InsertSpecificationsByBrand(int locationId, int brandId, DbEntry dbEntry, SmartPhonesEntities context)
        {
            LocationsByBrandSet locationByBrand = new LocationsByBrandSet()
            {
                LocationsId = locationId,
                PlantLocationsId = brandId
            };
            context.LocationsByBrandSet.Add(locationByBrand);
            context.SaveChanges();

            return locationByBrand.Id;
        }

        private static int InsertSmartPhoneSet(int specificationsId, int brandId, DbEntry dbEntry, SmartPhonesEntities context)
        {
            SmartPhoneSet smartphone = new SmartPhoneSet()
            {
                BrandId = brandId,
                Model = dbEntry.Model,
                SpecificationsId = specificationsId
            };
            context.SmartPhoneSet.Add(smartphone);
            context.SaveChanges();

            return smartphone.Id;
        }
    }
}
