using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Blog.API.Models.Context;

namespace Blog.API.Migrations
{
    [DbContext(typeof(BlogContext))]
    [Migration("20170525113348_25-05-2017-1")]
    partial class _250520171
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Blog.Model.Data.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Blog.Model.Data.Entry", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Summary");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("Blog.Model.Data.EntryCategory", b =>
                {
                    b.Property<long>("EntryId");

                    b.Property<long>("CategoryId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<long>("Id");

                    b.HasKey("EntryId", "CategoryId");

                    b.HasIndex("Id");

                    b.ToTable("EntryCategory");
                });

            modelBuilder.Entity("Blog.Model.Data.EntryCategory", b =>
                {
                    b.HasOne("Blog.Model.Data.Category", "Category")
                        .WithMany("CategoryEntries")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Blog.Model.Data.Entry", "Entry")
                        .WithMany("EntryCategories")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
