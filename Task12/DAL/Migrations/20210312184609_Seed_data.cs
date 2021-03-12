using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "FullName", "SimpleName" },
                values: new object[,]
                {
                    { 1, "Гомельская область", "Гомель обл" },
                    { 2, "Мозырский район", "Мозырь" },
                    { 3, "Наровлянский район", "Наровля" },
                    { 4, "город Минск", "Минск" }
                });

            migrationBuilder.InsertData(
                table: "ServiceInfo",
                columns: new[] { "Id", "AdditionalCost", "Description", "MainCost", "Name" },
                values: new object[,]
                {
                    { 1, 15.300000000000001, "Консультации, удалённая поддержка. При необходимости выезд к клиенту", 23.5, "Обслуживание КлиентТК" },
                    { 2, 14.199999999999999, "Установкаю, консультации, удалённая поддержка. При необходимости выезд к клиенту.", 19.300000000000001, "Обслуживание ГРС" },
                    { 3, 26.300000000000001, "Обслуживание техники. Ежемесечная проверка с диагностикой на месте эксплуатации.", 32.159999999999997, "Сопровождение вычислительно техники" },
                    { 4, 21.600000000000001, "Удалённое бслуживание техники без выезда на место", 25.859999999999999, "Удалённое сопровождение вычислительно техники" }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Address", "AreaId", "Email", "FullName", "Name", "Smdo" },
                values: new object[,]
                {
                    { 1, "ул Ленина 18", 1, "GomelOblFu@gomel.by", "Областное финансовое упрвление", "Обл ФУ", "Org1235" },
                    { 2, "д. Лесовики 3", 2, "NPZ@npz.by", "Мозырский нефтеперерабатывающий завод", "НПЗ", "Org48693" },
                    { 3, "ул фабричная 1", 3, "Korovka@korovka.by", "ОАО Красный Мозырянин", "Красный мозырянин", null },
                    { 4, "ул Коммунистическая 4", 3, "Narovlya@roo.gomel.by", "Районный отдел образования", "Роо", null },
                    { 5, "ул Заводская 85/4", 4, "Keramin@keramin.by", "ЗАО Керамин", "Керамин", null }
                });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "Id", "EndDate", "Number", "OrganizationId", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "12-123/ВК6", 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "12-1/ГК6", 2, new DateTime(2020, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "33-4/НК-6", 3, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2022, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "4484/ОИ-6", 4, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "MiddleName", "MobilePhone", "OrganizationId", "Phone", "Position" },
                values: new object[,]
                {
                    { 1, "KovalchukAV@gomel.by", "Алёна", "Ковальчук", "Витальевна", null, 1, "80232-23-56-84", "Главный экономист" },
                    { 2, "PesokovVI@npz.by", "Валерий", "Песоков", "Игнатьевич", null, 2, "80236-34-52-68", "Главный специалист" },
                    { 3, null, "Василий", "Фонрос", "Иванович", null, 3, "802355-4-58-22", null },
                    { 4, null, "Анастасия", "Катонова", "Васильвна", null, 4, "802355-4-26-84", "Главный бухгалтер" },
                    { 5, "BulbaII@keramin.by", "Ирина", "Бульба", "Игнатьевна", null, 5, "8017-45-78-32", null }
                });

            migrationBuilder.InsertData(
                table: "ServiceHardwares",
                columns: new[] { "Id", "ContractId", "ServerCount", "ServiceInfoId", "WorkplaceCount" },
                values: new object[,]
                {
                    { 1, 1, 0, 3, 2 },
                    { 2, 2, 0, 4, 5 },
                    { 4, 3, 1, 4, 2 },
                    { 3, 4, 1, 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "ServiceSoftwares",
                columns: new[] { "Id", "AdditionalPlaceCount", "ContractId", "MainPlaceCount", "ServiceInfoId" },
                values: new object[,]
                {
                    { 1, 0, 1, 1, 1 },
                    { 2, 0, 2, 1, 2 },
                    { 3, 1, 3, 1, 1 },
                    { 4, 0, 4, 1, 2 },
                    { 5, 1, 4, 0, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ServiceHardwares",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ServiceHardwares",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ServiceHardwares",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ServiceHardwares",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ServiceSoftwares",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ServiceSoftwares",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ServiceSoftwares",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ServiceSoftwares",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ServiceSoftwares",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ServiceInfo",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ServiceInfo",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ServiceInfo",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ServiceInfo",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
