using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using PermissionsAttribute.DAL;

namespace PermissionsAttribute.Migrations
{
    [DbContext(typeof(AppIdentityDbContext))]
    [Migration("20200113110000_SeedDefaultData")]
    public class SeedDefaultData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var script = @"INSERT INTO [AspNetUsers] ([Id],[UserName],[NormalizedUserName],[Email],[NormalizedEmail],[EmailConfirmed],[PasswordHash],[SecurityStamp],[ConcurrencyStamp],[PhoneNumber],[PhoneNumberConfirmed],[TwoFactorEnabled],[LockoutEnd],[LockoutEnabled],[AccessFailedCount],[Year]) VALUES (
'3192abd3-44e0-4478-ac89-07a1acbb3f75','admin@mail.com','ADMIN@MAIL.COM','admin@mail.com','ADMIN@MAIL.COM',0,'AQAAAAEAACcQAAAAEGcjBUA5GvK1xDq+xcLckU2X4wkJA4cGHhJBPYEIaplwHOyDQp76mvrxuimtE/CKRQ==','TXWLLRBWEHH5Y774DH3UYKAMH2P47JBM','ed8477e8-11e0-4374-bd38-fe760bc26428',NULL,0,0,NULL,1,0,0);
INSERT INTO [AspNetUsers] ([Id],[UserName],[NormalizedUserName],[Email],[NormalizedEmail],[EmailConfirmed],[PasswordHash],[SecurityStamp],[ConcurrencyStamp],[PhoneNumber],[PhoneNumberConfirmed],[TwoFactorEnabled],[LockoutEnd],[LockoutEnabled],[AccessFailedCount],[Year]) VALUES (
'ccabc5d6-6951-4274-8462-c83a6d36ea22','user@mail.com','USER@MAIL.COM','user@mail.com','USER@MAIL.COM',0,'AQAAAAEAACcQAAAAEM3sZjt9FmVlrVdqhnn1LpjDn9XXVvPDNhgqMQjX5Kiw8AARp2XlxnfGolalDebIiA==','2AUAK7SEHXS6JCZ2PWFHPCPFLIGSSNY7','a5032b57-2db7-4c2e-b262-aac063b79745',NULL,0,0,NULL,1,0,1991);
INSERT INTO [AspNetUserClaims] ([Id],[UserId],[ClaimType],[ClaimValue]) VALUES (
1,'3192abd3-44e0-4478-ac89-07a1acbb3f75','permission','GetById');
INSERT INTO [AspNetUserClaims] ([Id],[UserId],[ClaimType],[ClaimValue]) VALUES (
2,'3192abd3-44e0-4478-ac89-07a1acbb3f75','permission','GetAll');
INSERT INTO [AspNetUserClaims] ([Id],[UserId],[ClaimType],[ClaimValue]) VALUES (
3,'3192abd3-44e0-4478-ac89-07a1acbb3f75','permission','Create');
INSERT INTO [AspNetUserClaims] ([Id],[UserId],[ClaimType],[ClaimValue]) VALUES (
4,'3192abd3-44e0-4478-ac89-07a1acbb3f75','permission','Update');
INSERT INTO [AspNetUserClaims] ([Id],[UserId],[ClaimType],[ClaimValue]) VALUES (
5,'3192abd3-44e0-4478-ac89-07a1acbb3f75','permission','Delete');
INSERT INTO [AspNetUserClaims] ([Id],[UserId],[ClaimType],[ClaimValue]) VALUES (
6,'ccabc5d6-6951-4274-8462-c83a6d36ea22','permission','GetById');
INSERT INTO [AspNetUserClaims] ([Id],[UserId],[ClaimType],[ClaimValue]) VALUES (
7,'ccabc5d6-6951-4274-8462-c83a6d36ea22','permission','GetAll');
INSERT INTO [AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp]) VALUES (
'd4f4ae6b-4073-4fb7-ba6d-a6bd92cec9de','admin','ADMIN','3a7adef5-478c-4993-803b-d385e2343523');
INSERT INTO [AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp]) VALUES (
'e40ceb91-5055-4326-aefd-5197577c85b5','user','USER','457bd1c5-eab6-406b-a389-dc8ea7880266');
INSERT INTO [AspNetUserRoles] ([UserId],[RoleId]) VALUES (
'3192abd3-44e0-4478-ac89-07a1acbb3f75','d4f4ae6b-4073-4fb7-ba6d-a6bd92cec9de');
INSERT INTO [AspNetUserRoles] ([UserId],[RoleId]) VALUES (
'ccabc5d6-6951-4274-8462-c83a6d36ea22','e40ceb91-5055-4326-aefd-5197577c85b5');
";
            migrationBuilder.Sql(script);
        }
    }
}
