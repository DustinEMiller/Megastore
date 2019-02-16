namespace Megastore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5488b786-30cc-4a43-bc7d-28fac2002834', N'admin@megastore.com', 0, N'ABjk8dBhTlSnbZ3mOmIUjrHSteiKlitrBGIctPNxdd/kjoYFXMOjsuCt4RovDVta1w==', N'67624c89-5b62-4a1d-a852-7e92254bced5', NULL, 0, 0, NULL, 1, 0, N'admin@megastore.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7010cccb-b4ca-4d82-928f-851c764b4e5d', N'guest@megastore.com', 0, N'AMAUsiXTJOsBNc5WYm6k3+CPWQOnbnh+H/WXtouq6usR54f6wEVtGwKK28EUMfoTSQ==', N'30dbf903-0bf4-482c-852c-3c0ca55181e2', NULL, 0, 0, NULL, 1, 0, N'guest@megastore.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ab292ef3-1477-4a7e-95c7-5799ae1c060e', N'Administrator')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5488b786-30cc-4a43-bc7d-28fac2002834', N'ab292ef3-1477-4a7e-95c7-5799ae1c060e')
");

        }

    public override void Down()
        {
        }
    }
}
