using GreenThumb.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThumb.Database
{
    internal class GreenThumbDbContext : DbContext
    {
        public GreenThumbDbContext()
        {

        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<GardenModel> Garden { get; set; }
        public DbSet<PlantModel> Plants { get; set; }
        public DbSet<InstructionModel> Instructions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GreenThumbDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlantModel>().HasData(
                new PlantModel()
                {
                    Id = 1,
                    BotanicalName = "Anemone nemorosa",
                    Name = "Vitsippa",
                    Description = "En blomma som blir 10-20 cm hög, med vita blad",
                },
                new PlantModel()
                {
                    Id = 2,
                    BotanicalName = "Helianthus annuus",
                    Name = "Solros",
                    Description = "En blomma som kan bli 3 m hög, med stora gula blad",
                },
                new PlantModel()
                {
                    Id = 3,
                    BotanicalName = "Helicodiceros muscivorus",
                    Name = "Fläckig drakkalla",
                    Description = "En illaluktande planta som sägs likna ändan på ett dött djur",
                });
            modelBuilder.Entity<InstructionModel>().HasData(
                new InstructionModel()
                {
                    Id = 1,
                    Instruction = "Vattna varannan dag",
                    PlantId = 1
                },
                new InstructionModel()
                {
                    Id = 2,
                    Instruction = "Vattna varannan dag",
                    PlantId = 2
                },
                new InstructionModel()
                {
                    Id = 3,
                    Instruction = "Vattna varannan dag",
                    PlantId = 3
                },
                new InstructionModel()
                {
                    Id = 4,
                    Instruction = "Stäng näsan",
                    PlantId = 3
                });
            modelBuilder.Entity<GardenModel>().HasData(
                new GardenModel()
                {
                    UserId = 00001,
                    GardenId = 1,
                    Adress = "Stengatan 12, Malmö"
                },
                new GardenModel()
                {
                    UserId = 00002,
                    GardenId = 2,
                    Adress = "Kärleksgatan 72C, Lund"
                });
            modelBuilder.Entity<UserModel>().HasData(
                new UserModel()
                {
                    UserId = 00002,
                    Username = "Stefan",
                    Password = "STEFANÄRBÄST"
                },
                new UserModel()
                {
                    UserId = 00001,
                    Username = "Emma",
                    Password = "123"
                });
        }
    }
}
