using Microsoft.EntityFrameworkCore;
using System;
using WasteRegistry.API.Data.DML;
using Bogus;
using WasteRegistry.API.Token.Model;

namespace WasteRegistry.API.Data.DAL.Data
{
    public class WasteRegistrationContext : DbContext
    {
        public WasteRegistrationContext(DbContextOptions<WasteRegistrationContext> options) : base(options) { }


        public DbSet<WasteRegistryTB> WasteRegistryTB { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            int x = 1;
            var userFaker = new Faker<User>()
                .RuleFor(o => o.FirstName, f => f.Person.FirstName)
                .RuleFor(o => o.LastName, f => f.Person.LastName)
                .RuleFor(o => o.Password, f => f.Person.Random.AlphaNumeric(8))
                .RuleFor(o => o.Username, f => f.Person.UserName)
                .RuleFor(o => o.CreateDate, DateTime.Now)
                .RuleFor(o => o.ModifiedDate, DateTime.Now)
                .RuleFor(o => o.Id, f => x++);

            var mockUsers = userFaker.Generate(2);
            mockUsers.Add(new User { Username = "DummyUser123", Password = "qwerty124", FirstName = "Dummy", LastName = "User", Id = x++ });

            int i = 1;
            var wasteDatefaker = new Faker<WasteRegistryTB>()
                .RuleFor(o => o.Quantity, f => f.Random.Byte())
                .RuleFor(o => o.Month, f => f.Random.Byte(1, 6))
                .RuleFor(o => o.RecipientCompany, f => string.Format("Company{0}", f.Random.Byte(1, 4)))
                .RuleFor(o => o.Store, f => string.Format("Store{0}", f.Random.Byte(1,5)))
                .RuleFor(o => o.WasteKind, f => string.Format("WasteKind{0}", f.Random.Byte(1, 2)))
                .RuleFor(o => o.WasteType, f => string.Format("WasteType{0}", f.Random.Byte(1, 2)))
                .RuleFor(o => o.QuantityUnit, f => string.Format("Unit{0}", f.Random.Byte(1, 2)))
                .RuleFor(o => o.Content, f => f.Lorem.Sentence(7))
                .RuleFor(o => o.WasteDate, f => f.Date.Recent(3).Date)
                .RuleFor(o => o.CreateDate, DateTime.Now)
                .RuleFor(o => o.ModifiedDate, DateTime.Now)
                .RuleFor(o => o.Id, f => i++);

            var mockWastes = wasteDatefaker.Generate(10);

            modelBuilder.Entity<WasteRegistryTB>().HasData(mockWastes);
            modelBuilder.Entity<User>().HasData(mockUsers);

            base.OnModelCreating(modelBuilder);
        }
    }
}
