// <auto-generated />
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(EShopContext))]
    [Migration("20221025075615_AddedDescriptionToProduct")]
    partial class AddedDescriptionToProduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataLayer.Entities.Cart", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Cart");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Amount = 2,
                            ProductId = 2,
                            UserId = 1
                        },
                        new
                        {
                            ID = 2,
                            Amount = 3,
                            ProductId = 2,
                            UserId = 2
                        },
                        new
                        {
                            ID = 3,
                            Amount = 1,
                            ProductId = 5,
                            UserId = 1
                        },
                        new
                        {
                            ID = 4,
                            Amount = 8,
                            ProductId = 7,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("Decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SoftDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("TypeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TypeID");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "Description for product 1",
                            ImagePath = "ImagePath1",
                            Price = 1100.75m,
                            ProductName = "GPU1",
                            SoftDelete = false,
                            TypeID = 1
                        },
                        new
                        {
                            ID = 2,
                            Description = "Description for product 2",
                            ImagePath = "ImagePath2",
                            Price = 1234.55m,
                            ProductName = "GPU2",
                            SoftDelete = false,
                            TypeID = 1
                        },
                        new
                        {
                            ID = 3,
                            Description = "Description for product 3",
                            ImagePath = "ImagePath3",
                            Price = 8934.10m,
                            ProductName = "CPU1",
                            SoftDelete = false,
                            TypeID = 2
                        },
                        new
                        {
                            ID = 4,
                            Description = "Description for product 4",
                            ImagePath = "ImagePath4",
                            Price = 9313m,
                            ProductName = "CPU2",
                            SoftDelete = false,
                            TypeID = 2
                        },
                        new
                        {
                            ID = 5,
                            Description = "Description for product 5",
                            ImagePath = "ImagePath5",
                            Price = 110.75m,
                            ProductName = "Keyboard1",
                            SoftDelete = false,
                            TypeID = 3
                        },
                        new
                        {
                            ID = 6,
                            Description = "Description for product 6",
                            ImagePath = "ImagePath6",
                            Price = 500m,
                            ProductName = "Keyboard2",
                            SoftDelete = false,
                            TypeID = 3
                        },
                        new
                        {
                            ID = 7,
                            Description = "Description for product 7",
                            ImagePath = "ImagePath7",
                            Price = 50m,
                            ProductName = "Mouse1",
                            SoftDelete = false,
                            TypeID = 4
                        },
                        new
                        {
                            ID = 8,
                            Description = "Description for product 8",
                            ImagePath = "ImagePath8",
                            Price = 100m,
                            ProductName = "Mouse2",
                            SoftDelete = false,
                            TypeID = 4
                        },
                        new
                        {
                            ID = 9,
                            Description = "Description for product 9",
                            ImagePath = "ImagePath9",
                            Price = 200m,
                            ProductName = "Cooling1",
                            SoftDelete = false,
                            TypeID = 5
                        },
                        new
                        {
                            ID = 10,
                            Description = "Description for product 10",
                            ImagePath = "ImagePath10",
                            Price = 350.50m,
                            ProductName = "Cooling2",
                            SoftDelete = false,
                            TypeID = 5
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.Roles", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            RoleName = "User"
                        },
                        new
                        {
                            ID = 2,
                            RoleName = "Admin"
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.Types", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Type");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            TypeName = "GPU"
                        },
                        new
                        {
                            ID = 2,
                            TypeName = "CPU"
                        },
                        new
                        {
                            ID = 3,
                            TypeName = "Keyboard"
                        },
                        new
                        {
                            ID = 4,
                            TypeName = "Mouse"
                        },
                        new
                        {
                            ID = 5,
                            TypeName = "Cooling"
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<bool>("SoftDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("RoleId")
                        .IsUnique();

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Address = "RandomAdress1",
                            FirstName = "Bodil",
                            LastName = "Bodilsen",
                            Mail = "Bodil@Bodilsen.com",
                            Password = "Bodil123456",
                            Phone = "88888888",
                            RoleId = 1,
                            SoftDelete = false,
                            Username = "Bodil",
                            ZipCode = "1000"
                        },
                        new
                        {
                            ID = 2,
                            Address = "RandomAdress2",
                            FirstName = "Hans",
                            LastName = "Hansen",
                            Mail = "Hans@Hansen.com",
                            Password = "Hans123456",
                            Phone = "44444444",
                            RoleId = 2,
                            SoftDelete = false,
                            Username = "Hans",
                            ZipCode = "5000"
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.Cart", b =>
                {
                    b.HasOne("DataLayer.Entities.Product", "Product")
                        .WithMany("Carts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Entities.User", "User")
                        .WithMany("Carts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataLayer.Entities.Product", b =>
                {
                    b.HasOne("DataLayer.Entities.Types", "Type")
                        .WithMany("Products")
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("DataLayer.Entities.User", b =>
                {
                    b.HasOne("DataLayer.Entities.Roles", "Role")
                        .WithOne("User")
                        .HasForeignKey("DataLayer.Entities.User", "RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DataLayer.Entities.Product", b =>
                {
                    b.Navigation("Carts");
                });

            modelBuilder.Entity("DataLayer.Entities.Roles", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entities.Types", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DataLayer.Entities.User", b =>
                {
                    b.Navigation("Carts");
                });
#pragma warning restore 612, 618
        }
    }
}
