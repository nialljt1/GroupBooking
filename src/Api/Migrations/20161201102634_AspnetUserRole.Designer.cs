using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Api;

namespace Api.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20161201102634_AspnetUserRole")]
    partial class AspnetUserRole
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<DateTimeOffset>("LastUpdatedAt");

                    b.Property<string>("LastUpdatedById")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<int>("NumberOfDiners");

                    b.Property<string>("OrganiserForename")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("OrganiserId")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<string>("OrganiserSurname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("OrganiserTelephoneNumber")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("StartingAt");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastUpdatedById");

                    b.HasIndex("OrganiserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Api.Models.Diner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookingId");

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedById");

                    b.Property<string>("Forename")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTimeOffset>("LastUpdatedAt");

                    b.Property<string>("LastUpdatedById");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastUpdatedById");

                    b.ToTable("Diner");
                });

            modelBuilder.Entity("Api.Models.DinerMenuItem", b =>
                {
                    b.Property<int>("DinerId");

                    b.Property<int>("MenuItemId");

                    b.HasKey("DinerId", "MenuItemId");

                    b.HasIndex("MenuItemId");

                    b.ToTable("DinerMenuItems");
                });

            modelBuilder.Entity("Api.Models.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bcc");

                    b.Property<string>("Body");

                    b.Property<string>("Cc");

                    b.Property<DateTimeOffset>("Created");

                    b.Property<string>("From")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("Sent");

                    b.Property<string>("Subject")
                        .IsRequired();

                    b.Property<string>("To")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("Api.Models.Identity.AspNetRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(450);

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Api.Models.Identity.AspNetRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Api.Models.Identity.AspNetUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(450);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("AspNetRoleId");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("AspNetRoleId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Api.Models.Identity.AspNetUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Api.Models.Identity.AspNetUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(450);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(450);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Api.Models.Identity.AspNetUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(450);

                    b.Property<string>("RoleId")
                        .HasMaxLength(450);

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Api.Models.Identity.AspNetUserToken", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(450);

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(450);

                    b.Property<string>("Name")
                        .HasMaxLength(450);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Api.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("Api.Models.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(200);

                    b.Property<int>("DisplayOrder");

                    b.Property<int>("MenuSectionId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("Number");

                    b.HasKey("Id");

                    b.HasIndex("MenuSectionId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("Api.Models.MenuSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DisplayOrder");

                    b.Property<int>("MenuId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("MenuSections");
                });

            modelBuilder.Entity("Api.Models.Booking", b =>
                {
                    b.HasOne("Api.Models.Identity.AspNetUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Api.Models.Identity.AspNetUser", "LastUpdatedBy")
                        .WithMany()
                        .HasForeignKey("LastUpdatedById");

                    b.HasOne("Api.Models.Identity.AspNetUser", "Organiser")
                        .WithMany()
                        .HasForeignKey("OrganiserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Models.Diner", b =>
                {
                    b.HasOne("Api.Models.Booking", "Booking")
                        .WithMany("Diners")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Api.Models.Identity.AspNetUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Api.Models.Identity.AspNetUser", "LastUpdatedBy")
                        .WithMany()
                        .HasForeignKey("LastUpdatedById");
                });

            modelBuilder.Entity("Api.Models.DinerMenuItem", b =>
                {
                    b.HasOne("Api.Models.Diner", "Diner")
                        .WithMany("DinerMenuItems")
                        .HasForeignKey("DinerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Api.Models.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Models.Identity.AspNetRoleClaim", b =>
                {
                    b.HasOne("Api.Models.Identity.AspNetRole", "AspNetRole")
                        .WithMany("AspNetRoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Models.Identity.AspNetUser", b =>
                {
                    b.HasOne("Api.Models.Identity.AspNetRole")
                        .WithMany("AspNetUsers")
                        .HasForeignKey("AspNetRoleId");
                });

            modelBuilder.Entity("Api.Models.Identity.AspNetUserClaim", b =>
                {
                    b.HasOne("Api.Models.Identity.AspNetUser", "AspNetUser")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Models.Identity.AspNetUserLogin", b =>
                {
                    b.HasOne("Api.Models.Identity.AspNetUser", "AspNetUser")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Models.Identity.AspNetUserRole", b =>
                {
                    b.HasOne("Api.Models.Identity.AspNetRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Api.Models.Identity.AspNetUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Models.MenuItem", b =>
                {
                    b.HasOne("Api.Models.MenuSection", "MenuSection")
                        .WithMany("MenuItems")
                        .HasForeignKey("MenuSectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Models.MenuSection", b =>
                {
                    b.HasOne("Api.Models.Menu", "Menu")
                        .WithMany("MenuSections")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
