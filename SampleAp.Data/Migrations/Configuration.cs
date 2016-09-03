namespace SampleAp.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SampleAp.Data.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<SampleAp.Data.SampleApContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }

    public class DatabaseInitializer : CreateDatabaseIfNotExists<SampleApContext>
    {
        SampleApContext context = new SampleApContext();

        public DatabaseInitializer()
        {
            Seed(context);
        }

        protected override void Seed(SampleApContext context)
        {
            # region Master Display AS
            context.Displays.AddOrUpdate(
               z => z.DisplayAs,
               new MasterDisplayAs { DisplayAs = "FirstLast" },
               new MasterDisplayAs { DisplayAs = "LastFirst" },
               new MasterDisplayAs { DisplayAs = "Knickname" }

               );
            context.SaveChanges();
            #endregion

            # region Sample Conatacts
            context.Contacts.AddOrUpdate(
                p => p.FirstName,
                 new Contact { FirstName = "Andrew ", LastName = "Peters", MasterDisplayAsId = 1, Knickname = "AndrewP", DateOfBirth = DateTime.Now, PhoneNumber = "+91-1234567980" },
                     new Contact { FirstName = "Brice ", LastName = "Lambson", MasterDisplayAsId = 2, Knickname = "BriceL", DateOfBirth = DateTime.Now.AddMonths(12), PhoneNumber = "+91-1234567980" },
                 new Contact { FirstName = "Rowan ", LastName = "Miller", MasterDisplayAsId = 3, Knickname = "MillerP", DateOfBirth = DateTime.Now.AddMonths(-24), PhoneNumber = "+91-1234567980" }

               );
                context.SaveChanges();
            #endregion
        }
    }
}
