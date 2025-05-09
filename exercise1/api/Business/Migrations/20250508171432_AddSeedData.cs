using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StargateAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CareerStartDate",
                table: "AstronautDetail",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "John Doe" },
                    { 2, "Jane Smith" },
                    { 3, "Chris Johnson" },
                    { 4, "Emily Carter" },
                    { 5, "Michael Brown" },
                    { 6, "Sarah Wilson" },
                    { 7, "David Lee" },
                    { 8, "Laura Adams" },
                    { 9, "James Taylor" },
                    { 10, "Anna White" },
                    { 11, "Robert Green" },
                    { 12, "Sophia Hall" },
                    { 13, "Daniel King" },
                    { 14, "Olivia Scott" },
                    { 15, "William Harris" }
                });

            migrationBuilder.InsertData(
                table: "AstronautDetail",
                columns: new[] { "Id", "PersonId", "CurrentRank", "CurrentDutyTitle", "CareerStartDate", "CareerEndDate" },
                values: new object[,]
                {
                    { 1, 1, "Astronaut", "Mission Commander", new DateTime(2010, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, 2, "Astronaut", "Science Pilot", new DateTime(2012, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, 3, "Astronaut Candidate", "RETIRED", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, "Astronaut", "Mission Specialist", new DateTime(2018, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, 5, "Astronaut", "RETIRED", new DateTime(2008, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 6, "Astronaut Candidate", "Pilot", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 7, 7, "Astronaut", "RETIRED", new DateTime(2013, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 8, "Astronaut", "Spacecraft Pilot", new DateTime(2016, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 9, 9, "Astronaut", "RETIRED", new DateTime(2009, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 10, "Astronaut Candidate", "Flight Engineer", new DateTime(2020, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 11, 11, "Astronaut", "RETIRED", new DateTime(2011, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 12, "Astronaut", "Mission Specialist", new DateTime(2014, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 13, 13, "Science Pilot", "", new DateTime(2017, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }, // Note: Original had "" for CurrentDutyTitle
                    { 14, 14, "Astronaut Candidate", "Pilot", new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 15, 15, "Astronaut", "RETIRED", new DateTime(2007, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AstronautDuty",
                columns: new[] { "Id", "PersonId", "Rank", "DutyTitle", "DutyStartDate", "DutyEndDate" },
                values: new object[,]
                {
                    { 1, 1, "Astronaut Candidate", "Mission Commander for Apollo 11", new DateTime(2010, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, "Astronaut", "Mission Commander for ISS Expedition 42", new DateTime(2015, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, 2, "Astronaut", "Science Pilot for Skylab 4", new DateTime(2012, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, "Astronaut", "Science Pilot for ISS Expedition 50", new DateTime(2018, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, 3, "Astronaut Candidate", "Flight Engineer for Artemis I", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 3, "Astronaut Candidate", "RETIRED", new DateTime(2023, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 7, 4, "Astronaut", "Mission Specialist for STS-61", new DateTime(2018, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 8, 5, "Astronaut", "Payload Commander for STS-93", new DateTime(2008, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 5, "Astronaut", "Payload Commander for ISS Expedition 20", new DateTime(2015, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 5, "Astronaut", "RETIRED", new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 11, 6, "Astronaut Candidate", "Pilot for Artemis II", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 12, 7, "Astronaut", "Science Officer for ISS Expedition 35", new DateTime(2013, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 7, "Astronaut", "Science Officer for ISS Expedition 60", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 7, "Astronaut", "RETIRED", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 15, 8, "Astronaut", "Spacecraft Pilot for STS-88", new DateTime(2016, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 16, 9, "Astronaut", "Mission Commander for STS-107", new DateTime(2009, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 9, "Astronaut", "Mission Commander for ISS Expedition 25", new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 9, "Astronaut", "RETIRED", new DateTime(2019, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 19, 10, "Astronaut Candidate", "Flight Engineer for Artemis III", new DateTime(2020, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 20, 11, "Astronaut", "Payload Specialist for STS-51-L", new DateTime(2011, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 11, "Astronaut", "Payload Specialist for ISS Expedition 45", new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 11, "Astronaut", "RETIRED", new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 23, 12, "Astronaut", "Mission Specialist for STS-125", new DateTime(2014, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 24, 13, "Science Pilot", "Science Pilot for Skylab 3", new DateTime(2017, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }, // Note: Original had "" for DutyTitle, fixed based on likely intent
                    { 25, 14, "Astronaut Candidate", "Pilot for Artemis IV", new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 26, 15, "Astronaut", "Flight Engineer for ISS Expedition 15", new DateTime(2007, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2013, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 15, "Astronaut", "Flight Engineer for ISS Expedition 20", new DateTime(2013, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 15, "Astronaut", "RETIRED", new DateTime(2018, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AstronautDetail",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AstronautDetail",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AstronautDetail",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AstronautDetail",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AstronautDetail",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AstronautDetail",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AstronautDetail",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AstronautDetail",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AstronautDetail",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AstronautDetail",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AstronautDetail",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AstronautDetail",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AstronautDetail",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AstronautDetail",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AstronautDetail",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CareerStartDate",
                table: "AstronautDetail",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");
        }
    }
}
