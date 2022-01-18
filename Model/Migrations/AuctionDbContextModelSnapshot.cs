﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model.Configuration;

#nullable disable

namespace Model.Migrations
{
    [DbContext(typeof(AuctionDbContext))]
    partial class AuctionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Model.Entity.Auction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AUCTION_ID");

                    b.Property<int?>("BUYER_ID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("DESCRIPTION");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("END_DATE");

                    b.Property<decimal?>("FinalPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("SELLER_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("START_DATE");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("TITLE");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BUYER_ID");

                    b.HasIndex("SELLER_ID");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("AUCTIONS_BT");
                });

            modelBuilder.Entity("Model.Entity.AuctionCategorie", b =>
                {
                    b.Property<string>("CATEGORIE")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AUCTION_ID")
                        .HasColumnType("int");

                    b.HasKey("CATEGORIE", "AUCTION_ID");

                    b.HasIndex("AUCTION_ID");

                    b.ToTable("AUCTION_HAS_CATEGORIES");
                });

            modelBuilder.Entity("Model.Entity.AuctionImage", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IMAGE_ID");

                    b.Property<int?>("AUCTION_ID")
                        .HasColumnType("int");

                    b.Property<int>("TempId")
                        .HasColumnType("int");

                    b.HasKey("ImageId");

                    b.HasAlternateKey("TempId");

                    b.HasIndex("AUCTION_ID");

                    b.ToTable("AUCTION_IMAGES");
                });

            modelBuilder.Entity("Model.Entity.BiddingAuctionBid", b =>
                {
                    b.Property<int>("AUCTION_ID")
                        .HasColumnType("int");

                    b.Property<int>("BIDDER_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("BidDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("BID_DATE");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("PRICE");

                    b.HasKey("AUCTION_ID");

                    b.HasIndex("BIDDER_ID");

                    b.ToTable("BIDDING_AUCTION_BIDS");
                });

            modelBuilder.Entity("Model.Entity.Categorie", b =>
                {
                    b.Property<string>("Label")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("LABEL");

                    b.HasKey("Label");

                    b.ToTable("CATEGORIES");
                });

            modelBuilder.Entity("Model.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("BALANCE");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(32)")
                        .HasColumnName("FIRST_NAME");

                    b.Property<ulong>("IsAdmin")
                        .HasColumnType("bit")
                        .HasColumnName("IS_ADMIN");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(32)")
                        .HasColumnName("LAST_NAME");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext")
                        .HasColumnName("PHONE_NUMBER");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(16)")
                        .HasColumnName("USERNAME");

                    b.HasKey("Id");

                    b.ToTable("USERS");
                });

            modelBuilder.Entity("Model.Entity.BiddingAuction", b =>
                {
                    b.HasBaseType("Model.Entity.Auction");

                    b.Property<decimal?>("InstantBuyPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("StartingPrice")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("STARTING_PRICE");

                    b.Property<decimal?>("Step")
                        .HasColumnType("decimal(65,30)");

                    b.ToTable("BIDDING_AUCTION");
                });

            modelBuilder.Entity("Model.Entity.BuyAuction", b =>
                {
                    b.HasBaseType("Model.Entity.Auction");

                    b.Property<decimal>("MinimumPrice")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("MINIMUM_PRICE");

                    b.ToTable("BUY_AUCTION");
                });

            modelBuilder.Entity("Model.Entity.Auction", b =>
                {
                    b.HasOne("Model.Entity.User", "Buyer")
                        .WithMany()
                        .HasForeignKey("BUYER_ID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Entity.User", "Seller")
                        .WithMany()
                        .HasForeignKey("SELLER_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entity.User", null)
                        .WithMany("Sells")
                        .HasForeignKey("UserId");

                    b.HasOne("Model.Entity.User", null)
                        .WithMany("Buys")
                        .HasForeignKey("UserId1");

                    b.Navigation("Buyer");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("Model.Entity.AuctionCategorie", b =>
                {
                    b.HasOne("Model.Entity.Auction", "Auction")
                        .WithMany("Categories")
                        .HasForeignKey("AUCTION_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entity.Categorie", "Categorie")
                        .WithMany("Auctions")
                        .HasForeignKey("CATEGORIE")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auction");

                    b.Navigation("Categorie");
                });

            modelBuilder.Entity("Model.Entity.AuctionImage", b =>
                {
                    b.HasOne("Model.Entity.Auction", "Auction")
                        .WithMany("Images")
                        .HasForeignKey("AUCTION_ID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("EFCAT.Model.Annotation.Image", "Image", b1 =>
                        {
                            b1.Property<int>("AuctionImageImageId")
                                .HasColumnType("int");

                            b1.Property<byte[]>("Content")
                                .IsRequired()
                                .HasColumnType("longblob")
                                .HasColumnName("IMAGE_CONTENT");

                            b1.Property<string>("Type")
                                .IsRequired()
                                .HasColumnType("varchar(32)")
                                .HasColumnName("IMAGE_TYPE");

                            b1.HasKey("AuctionImageImageId");

                            b1.ToTable("AUCTION_IMAGES");

                            b1.WithOwner()
                                .HasForeignKey("AuctionImageImageId");
                        });

                    b.Navigation("Auction");

                    b.Navigation("Image")
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Entity.BiddingAuctionBid", b =>
                {
                    b.HasOne("Model.Entity.BiddingAuction", "Auction")
                        .WithMany("Bidders")
                        .HasForeignKey("AUCTION_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entity.User", "Bidder")
                        .WithMany()
                        .HasForeignKey("BIDDER_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auction");

                    b.Navigation("Bidder");
                });

            modelBuilder.Entity("Model.Entity.User", b =>
                {
                    b.OwnsOne("EFCAT.Model.Annotation.Image", "Image", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<byte[]>("Content")
                                .IsRequired()
                                .HasColumnType("longblob")
                                .HasColumnName("IMAGE_CONTENT");

                            b1.Property<string>("Type")
                                .IsRequired()
                                .HasColumnType("varchar(32)")
                                .HasColumnName("IMAGE_TYPE");

                            b1.HasKey("UserId");

                            b1.ToTable("USERS");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Model.Entity.BiddingAuction", b =>
                {
                    b.HasOne("Model.Entity.Auction", null)
                        .WithOne()
                        .HasForeignKey("Model.Entity.BiddingAuction", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Entity.BuyAuction", b =>
                {
                    b.HasOne("Model.Entity.Auction", null)
                        .WithOne()
                        .HasForeignKey("Model.Entity.BuyAuction", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Entity.Auction", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("Model.Entity.Categorie", b =>
                {
                    b.Navigation("Auctions");
                });

            modelBuilder.Entity("Model.Entity.User", b =>
                {
                    b.Navigation("Buys");

                    b.Navigation("Sells");
                });

            modelBuilder.Entity("Model.Entity.BiddingAuction", b =>
                {
                    b.Navigation("Bidders");
                });
#pragma warning restore 612, 618
        }
    }
}
