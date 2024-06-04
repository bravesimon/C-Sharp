using MechanicService.Models;
using Microsoft.EntityFrameworkCore;

namespace MechanicService.Data
{
    // in package manager console:
    // dotnet ef migrations add Initial --startup-project MechanicService --verbose
    // dotnet ef database update --startup-project MechanicService --verbose
    public class ServiceDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public ServiceDbContext(DbContextOptions<ServiceDbContext> options) 
                : base (options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, Country = "Hungary", County = "Pest megye", City = "Gyal", PostalCode = "2360", Road= "Bela utca", HouseNumber = 3, Information = "" },
                new Address { Id = 2, Country = "Hungary", County = "Szabolcs-Szatmár-Bereg megye", City = "Nyiregyhaza", PostalCode = "4400", Road ="Kossuth utca", HouseNumber=42, Information = "B haz saroknal" },
                new Address { Id = 3, Country = "Hungary", County = "Bács-Kiskun megye", City = "Kecskemét ", PostalCode = "6000", Road = "Kövérszőlő utca", HouseNumber=2, Information = "" }
            );

            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, FirstMidName = "Akos", LastName = "Budai", Email = "asd@temp.com", PhoneNumber = "+36201234567", AddressId = 1 },
                new Client { Id = 2, FirstMidName = "Bela", LastName = "Szervat", Email = "asd2@temp.com", PhoneNumber = "+36301234567", AddressId = 2 },
                new Client { Id = 3, FirstMidName = "Ferenc", LastName = "Kiss", Email = "asd3@temp.com", PhoneNumber = "+36701234567", AddressId = 3}
            );

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { Id = 1, BoughtTime = DateTime.Parse("2003-09-01"), IsWarrantyActive = false, Type = VehicleType.Coupe, ClientID=1 },
                new Vehicle { Id = 2, BoughtTime = DateTime.Parse("2023-09-01"), IsWarrantyActive = true, Type = VehicleType.SUV, ClientID = 2 },
                new Vehicle { Id = 3, BoughtTime = DateTime.Parse("2024-05-01"), IsWarrantyActive = true, Type = VehicleType.Salon, ClientID = 3 }
            );
           
            modelBuilder.Entity<Service>().HasData(
                 new Service { Id = 1, Date = DateTime.Parse("2003-11-01"), IsDone = true, Information = "", VehicleId = 1 },
                 new Service { Id = 2, Date = DateTime.Parse("2004-03-01"), IsDone = true, Information = "", VehicleId = 1 },
                 new Service { Id = 3, Date = DateTime.Parse("2004-06-01"), IsDone = true, Information = "", VehicleId = 1 },
                 new Service { Id = 4, Date = DateTime.Parse("2024-06-01"), IsDone = true, Information = "", VehicleId = 2 },
                 new Service { Id = 5, Date = DateTime.Parse("2024-07-21"), IsDone = false, Information = "fek allitas lesz", VehicleId = 3 }
             );
        }
    }
}
