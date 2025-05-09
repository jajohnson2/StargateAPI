using Microsoft.EntityFrameworkCore;
using System.Data;

namespace StargateAPI.Business.Data
{
    public class StargateContext : DbContext
    {
        public IDbConnection Connection => Database.GetDbConnection();
        public DbSet<Person> People { get; set; }
        public DbSet<AstronautDetail> AstronautDetails { get; set; }
        public DbSet<AstronautDuty> AstronautDuties { get; set; }

        public StargateContext(DbContextOptions<StargateContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StargateContext).Assembly);

            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            // Add seed data for Person
            modelBuilder.Entity<Person>()
                .HasData(
                    new Person { Id = 1, Name = "John Doe" },
                    new Person { Id = 2, Name = "Jane Smith" },
                    new Person { Id = 3, Name = "Chris Johnson" },
                    new Person { Id = 4, Name = "Emily Carter" },
                    new Person { Id = 5, Name = "Michael Brown" },
                    new Person { Id = 6, Name = "Sarah Wilson" },
                    new Person { Id = 7, Name = "David Lee" },
                    new Person { Id = 8, Name = "Laura Adams" },
                    new Person { Id = 9, Name = "James Taylor" },
                    new Person { Id = 10, Name = "Anna White" },
                    new Person { Id = 11, Name = "Robert Green" },
                    new Person { Id = 12, Name = "Sophia Hall" },
                    new Person { Id = 13, Name = "Daniel King" },
                    new Person { Id = 14, Name = "Olivia Scott" },
                    new Person { Id = 15, Name = "William Harris" }
                );

            // Add seed data for AstronautDetail
            modelBuilder.Entity<AstronautDetail>()
                .HasData(
                    new AstronautDetail { Id = 1, PersonId = 1, CurrentRank = "Astronaut", CurrentDutyTitle = "Mission Commander", CareerStartDate = new DateTime(2010, 01, 15), CareerEndDate = null },
                    new AstronautDetail { Id = 2, PersonId = 2, CurrentRank = "Astronaut", CurrentDutyTitle = "Science Pilot", CareerStartDate = new DateTime(2012, 05, 20), CareerEndDate = null },
                    new AstronautDetail { Id = 3, PersonId = 3, CurrentRank = "Astronaut Candidate", CurrentDutyTitle = "RETIRED", CareerStartDate = new DateTime(2021, 01, 01), CareerEndDate = new DateTime(2023, 07, 01) },
                    new AstronautDetail { Id = 4, PersonId = 4, CurrentRank = "Astronaut", CurrentDutyTitle = "Mission Specialist", CareerStartDate = new DateTime(2018, 09, 25), CareerEndDate = null },
                    new AstronautDetail { Id = 5, PersonId = 5, CurrentRank = "Astronaut", CurrentDutyTitle = "RETIRED", CareerStartDate = new DateTime(2008, 11, 12), CareerEndDate = new DateTime(2020, 06, 30) },
                    new AstronautDetail { Id = 6, PersonId = 6, CurrentRank = "Astronaut Candidate", CurrentDutyTitle = "Pilot", CareerStartDate = new DateTime(2021, 01, 01), CareerEndDate = null },
                    new AstronautDetail { Id = 7, PersonId = 7, CurrentRank = "Astronaut", CurrentDutyTitle = "RETIRED", CareerStartDate = new DateTime(2013, 04, 15), CareerEndDate = new DateTime(2022, 12, 31) },
                    new AstronautDetail { Id = 8, PersonId = 8, CurrentRank = "Astronaut", CurrentDutyTitle = "Spacecraft Pilot", CareerStartDate = new DateTime(2016, 07, 20), CareerEndDate = null },
                    new AstronautDetail { Id = 9, PersonId = 9, CurrentRank = "Astronaut", CurrentDutyTitle = "RETIRED", CareerStartDate = new DateTime(2009, 02, 10), CareerEndDate = new DateTime(2019, 08, 15) },
                    new AstronautDetail { Id = 10, PersonId = 10, CurrentRank = "Astronaut Candidate", CurrentDutyTitle = "Flight Engineer", CareerStartDate = new DateTime(2020, 10, 05), CareerEndDate = null },
                    new AstronautDetail { Id = 11, PersonId = 11, CurrentRank = "Astronaut", CurrentDutyTitle = "RETIRED", CareerStartDate = new DateTime(2011, 06, 01), CareerEndDate = new DateTime(2021, 03, 31) },
                    new AstronautDetail { Id = 12, PersonId = 12, CurrentRank = "Astronaut", CurrentDutyTitle = "Mission Specialist", CareerStartDate = new DateTime(2014, 08, 15), CareerEndDate = null },
                    new AstronautDetail { Id = 13, PersonId = 13, CurrentRank = "Science Pilot", CareerStartDate = new DateTime(2017, 12, 01), CareerEndDate = null },
                    new AstronautDetail { Id = 14, PersonId = 14, CurrentRank = "Astronaut Candidate", CurrentDutyTitle = "Pilot", CareerStartDate = new DateTime(2022, 03, 10), CareerEndDate = null },
                    new AstronautDetail { Id = 15, PersonId = 15, CurrentRank = "Astronaut", CurrentDutyTitle = "RETIRED", CareerStartDate = new DateTime(2007, 05, 25), CareerEndDate = new DateTime(2018, 09, 30) }
                );

            // Add seed data for AstronautDuty
            modelBuilder.Entity<AstronautDuty>()
                .HasData(
                    new AstronautDuty { Id = 1, PersonId = 1, Rank = "Astronaut Candidate", DutyTitle = "Mission Commander for Apollo 11", DutyStartDate = new DateTime(2010, 01, 15), DutyEndDate = new DateTime(2015, 06, 30) },
                    new AstronautDuty { Id = 2, PersonId = 1, Rank = "Astronaut", DutyTitle = "Mission Commander for ISS Expedition 42", DutyStartDate = new DateTime(2015, 07, 01), DutyEndDate = null },
                    new AstronautDuty { Id = 3, PersonId = 2, Rank = "Astronaut", DutyTitle = "Science Pilot for Skylab 4", DutyStartDate = new DateTime(2012, 05, 20), DutyEndDate = new DateTime(2018, 03, 15) },
                    new AstronautDuty { Id = 4, PersonId = 2, Rank = "Astronaut", DutyTitle = "Science Pilot for ISS Expedition 50", DutyStartDate = new DateTime(2018, 03, 16), DutyEndDate = null },
                    new AstronautDuty { Id = 5, PersonId = 3, Rank = "Astronaut Candidate", DutyTitle = "Flight Engineer for Artemis I", DutyStartDate = new DateTime(2021, 01, 01), DutyEndDate = new DateTime(2023, 07, 01) },
                    new AstronautDuty { Id = 6, PersonId = 3, Rank = "Astronaut Candidate", DutyTitle = "RETIRED", DutyStartDate = new DateTime(2023, 07, 02), DutyEndDate = null },
                    new AstronautDuty { Id = 7, PersonId = 4, Rank = "Astronaut", DutyTitle = "Mission Specialist for STS-61", DutyStartDate = new DateTime(2018, 09, 25), DutyEndDate = null },
                    new AstronautDuty { Id = 8, PersonId = 5, Rank = "Astronaut", DutyTitle = "Payload Commander for STS-93", DutyStartDate = new DateTime(2008, 11, 12), DutyEndDate = new DateTime(2015, 04, 30) },
                    new AstronautDuty { Id = 9, PersonId = 5, Rank = "Astronaut", DutyTitle = "Payload Commander for ISS Expedition 20", DutyStartDate = new DateTime(2015, 05, 01), DutyEndDate = new DateTime(2020, 06, 30) },
                    new AstronautDuty { Id = 10, PersonId = 5, Rank = "Astronaut", DutyTitle = "RETIRED", DutyStartDate = new DateTime(2020, 07, 01), DutyEndDate = null },
                    new AstronautDuty { Id = 11, PersonId = 6, Rank = "Astronaut Candidate", DutyTitle = "Pilot for Artemis II", DutyStartDate = new DateTime(2021, 01, 01), DutyEndDate = null },
                    new AstronautDuty { Id = 12, PersonId = 7, Rank = "Astronaut", DutyTitle = "Science Officer for ISS Expedition 35", DutyStartDate = new DateTime(2013, 04, 15), DutyEndDate = new DateTime(2018, 12, 31) },
                    new AstronautDuty { Id = 13, PersonId = 7, Rank = "Astronaut", DutyTitle = "Science Officer for ISS Expedition 60", DutyStartDate = new DateTime(2019, 01, 01), DutyEndDate = new DateTime(2022, 12, 31) },
                    new AstronautDuty { Id = 14, PersonId = 7, Rank = "Astronaut", DutyTitle = "RETIRED", DutyStartDate = new DateTime(2023, 01, 01), DutyEndDate = null },
                    new AstronautDuty { Id = 15, PersonId = 8, Rank = "Astronaut", DutyTitle = "Spacecraft Pilot for STS-88", DutyStartDate = new DateTime(2016, 07, 20), DutyEndDate = null },
                    new AstronautDuty { Id = 16, PersonId = 9, Rank = "Astronaut", DutyTitle = "Mission Commander for STS-107", DutyStartDate = new DateTime(2009, 02, 10), DutyEndDate = new DateTime(2014, 12, 31) },
                    new AstronautDuty { Id = 17, PersonId = 9, Rank = "Astronaut", DutyTitle = "Mission Commander for ISS Expedition 25", DutyStartDate = new DateTime(2015, 01, 01), DutyEndDate = new DateTime(2019, 08, 15) },
                    new AstronautDuty { Id = 18, PersonId = 9, Rank = "Astronaut", DutyTitle = "RETIRED", DutyStartDate = new DateTime(2019, 08, 16), DutyEndDate = null },
                    new AstronautDuty { Id = 19, PersonId = 10, Rank = "Astronaut Candidate", DutyTitle = "Flight Engineer for Artemis III", DutyStartDate = new DateTime(2020, 10, 05), DutyEndDate = null },
                    new AstronautDuty { Id = 20, PersonId = 11, Rank = "Astronaut", DutyTitle = "Payload Specialist for STS-51-L", DutyStartDate = new DateTime(2011, 06, 01), DutyEndDate = new DateTime(2016, 12, 31) },
                    new AstronautDuty { Id = 21, PersonId = 11, Rank = "Astronaut", DutyTitle = "Payload Specialist for ISS Expedition 45", DutyStartDate = new DateTime(2017, 01, 01), DutyEndDate = new DateTime(2021, 03, 31) },
                    new AstronautDuty { Id = 22, PersonId = 11, Rank = "Astronaut", DutyTitle = "RETIRED", DutyStartDate = new DateTime(2021, 04, 01), DutyEndDate = null },
                    new AstronautDuty { Id = 23, PersonId = 12, Rank = "Astronaut", DutyTitle = "Mission Specialist for STS-125", DutyStartDate = new DateTime(2014, 08, 15), DutyEndDate = null },
                    new AstronautDuty { Id = 24, PersonId = 13, Rank = "Science Pilot for Skylab 3", DutyStartDate = new DateTime(2017, 12, 01), DutyEndDate = null },
                    new AstronautDuty { Id = 25, PersonId = 14, Rank = "Astronaut Candidate", DutyTitle = "Pilot for Artemis IV", DutyStartDate = new DateTime(2022, 03, 10), DutyEndDate = null },
                    new AstronautDuty { Id = 26, PersonId = 15, Rank = "Astronaut", DutyTitle = "Flight Engineer for ISS Expedition 15", DutyStartDate = new DateTime(2007, 05, 25), DutyEndDate = new DateTime(2013, 09, 30) },
                    new AstronautDuty { Id = 27, PersonId = 15, Rank = "Astronaut", DutyTitle = "Flight Engineer for ISS Expedition 20", DutyStartDate = new DateTime(2013, 10, 01), DutyEndDate = new DateTime(2018, 09, 30) },
                    new AstronautDuty { Id = 28, PersonId = 15, Rank = "Astronaut", DutyTitle = "RETIRED", DutyStartDate = new DateTime(2018, 10, 01), DutyEndDate = null }
                );
        }
    }
}
