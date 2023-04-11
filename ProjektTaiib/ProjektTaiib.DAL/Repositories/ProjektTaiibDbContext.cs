using Microsoft.EntityFrameworkCore;
using ProjektTaiib.DAL.Encje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjektTaiib.DAL.Repositories
{
    public class ProjektTaiibDbContext : DbContext
    {
       // public DbSet<BLL>
        public DbSet<DetailedInformation> DetailedInformation { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProjektTaiibDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasData(
                new Event { Id_event = 1, Event_name = "Wystawa obrazów Beksińskiego", Date = new DateTime(2024, 10, 23, 18, 00, 00), Location = "Warsaw Art Gallery", Description = "Obrazy hehe", Category = "Wystawa" },
                new Event { Id_event = 2, Event_name = "Pokaz sztucznych ogni", Date = new DateTime(2024, 12, 31, 23, 45, 00), Location = "Rynek Katowice", Category = "Pokaz" },
                new Event { Id_event = 3, Event_name = "Maryla Rodowicz - wiecznie mloda tour", Date = new DateTime(2023, 11, 21, 18, 30, 00), Location = "Spodek, Katowice", Category = "Koncert" }
                );

            modelBuilder.Entity<Sponsor>().HasData(
                new Sponsor { Id_sponsor = 1, Sponsor_name = "Tarczyński" },
                new Sponsor { Id_sponsor = 2, Sponsor_name = "Pocztex" }
                );

            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { Id_ticket = 1, Id_event = 1, Price = 200, Type = "Normalny", Premium = false },
                new Ticket { Id_ticket = 2, Id_event = 2, Price = 50, Type = "Ulgowy", Premium = true },
                new Ticket { Id_ticket = 3, Id_event = 3, Price = 50, Type = "Normalny", Premium = true }
                );

            modelBuilder.Entity<User>().HasData(
                new User { Id_user = 1, Email = "jedrek.oskarowski@gmail.com", Moderator = false, Username = "Oskiii", Password = "Haslo123" },
                new User { Id_user = 2, Email = "kowalski@gmail.com", Moderator = true, Username = "modKowal", Password = "Haslo123" }
                );

            modelBuilder.Entity<DetailedInformation>().HasData(
                new DetailedInformation { Id_information = 1, UserId = 1, Name = "Jędrek", Surname = "Oskarowski", Email = "jedrek.oskarowski@gmail.com", Phone = "123123123", Payment = "Blik", Country = "Poland", City = "Katowice", Zip_code = "40-000", Street = "Francuska", House_number = 24, Local_number = 7 },
                new DetailedInformation
                {
                    Id_information = 2,
                    UserId = 2,
                    Name = "Jan",
                    Surname = "Kowalski",
                    Email = "kowalski@gmail.com",
                    Phone = "321321321",
                    Payment = "Blik",
                    Country = "Poland",
                    City = "Katowice",
                    Zip_code = "40-000",
                    Street = "Warszawska",
                    House_number = 2,
                }
                );
        }
    }
}
