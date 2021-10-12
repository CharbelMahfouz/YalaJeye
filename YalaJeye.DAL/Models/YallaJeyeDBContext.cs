using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace YalaJeye.DAL.Models
{
    public partial class YallaJeyeDBContext : IdentityDbContext<ApplicationUser>
    {
        public YallaJeyeDBContext()
        {
        }

        public YallaJeyeDBContext(DbContextOptions<YallaJeyeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        //public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        //public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        //public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        //public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        //public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        //public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        //public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Cargo> Cargos { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<CustomOrder> CustomOrders { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemIngredient> ItemIngredients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<OrderItemType> OrderItemTypes { get; set; }
        public virtual DbSet<OrderList> OrderLists { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<PlacedQuickOrder> PlacedQuickOrders { get; set; }
        public virtual DbSet<QuickOrder> QuickOrders { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<RestaurantCategory> RestaurantCategories { get; set; }
        public virtual DbSet<RestaurantOrder> RestaurantOrders { get; set; }
        public virtual DbSet<RestaurantOrderItem> RestaurantOrderItems { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.Address1)
                    .HasMaxLength(1000)
                    .HasColumnName("address");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_City");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_Customer");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.ToTable("Cargo");

                entity.Property(e => e.CargoDescription)
                    .HasMaxLength(500)
                    .HasColumnName("cargo_description");

                entity.Property(e => e.OrderItemId).HasColumnName("order_item_id");

                entity.Property(e => e.VehicleTypeId).HasColumnName("vehicle_type_id");

                entity.HasOne(d => d.OrderItem)
                    .WithOne(p => p.Cargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cargo_OrderItem");

                entity.HasOne(d => d.VehicleType)
                    .WithMany(p => p.Cargos)
                    .HasForeignKey(d => d.VehicleTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cargo_VehicleType");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(250)
                    .HasColumnName("category_name");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CityName)
                    .HasMaxLength(250)
                    .HasColumnName("city_name");
            });

            modelBuilder.Entity<CustomOrder>(entity =>
            {
                entity.ToTable("CustomOrder");

                entity.Property(e => e.CustomOrderDetails)
                    .HasMaxLength(200)
                    .HasColumnName("custom_order_details");

                entity.Property(e => e.CustomOrderTitle)
                    .HasMaxLength(200)
                    .HasColumnName("custom_order_title");

                entity.Property(e => e.OrderItemId).HasColumnName("order_item_id");

                entity.HasOne(d => d.OrderItem)
                    .WithOne(p => p.CustomOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomOrder_OrderItem");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(200)
                    .HasColumnName("customer_name");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(320)
                    .HasColumnName("email_address");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.Property(e => e.PhotoUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("photo_url");

                entity.Property(e => e.UserId)
                    .HasMaxLength(450)
                    .HasColumnName("user_id");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_City");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event");

                entity.Property(e => e.EventDate)
                    .HasColumnType("datetime")
                    .HasColumnName("event_date");

                entity.Property(e => e.EventDescription)
                    .HasMaxLength(1000)
                    .HasColumnName("event_description");

                entity.Property(e => e.EventName)
                    .HasMaxLength(250)
                    .HasColumnName("event_name");

                entity.Property(e => e.EventPhotoUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("event_photo_url");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(250)
                    .HasColumnName("item_name");

                entity.Property(e => e.PhotoUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("photo_URL");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.RestaurantCategoryId).HasColumnName("restaurant_category_id");

                entity.HasOne(d => d.RestaurantCategory)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.RestaurantCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Item_RestaurantCategory");
            });

            modelBuilder.Entity<ItemIngredient>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ItemIngredient");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.ItemIngredientName)
                    .HasMaxLength(250)
                    .HasColumnName("item_ingredient_name");

                entity.HasOne(d => d.Item)
                    .WithMany()
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemIngredient_Item");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.DeliveryPrice).HasColumnName("delivery_price");

                entity.Property(e => e.IsPlaced).HasColumnName("is_placed");

                entity.Property(e => e.OrderListId).HasColumnName("order_list_id");

                entity.Property(e => e.OrderNumber).HasColumnName("order_number");

                entity.Property(e => e.OrderStatusId).HasColumnName("order_status_id");

                entity.HasOne(d => d.OrderList)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_OrderList");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_OrderStatus");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("OrderItem");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.OrderItemTypeId).HasColumnName("order_item_type_id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderListItem_Order");

                entity.HasOne(d => d.OrderItemType)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderItemTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItem_OrderItemType");
            });

            modelBuilder.Entity<OrderItemType>(entity =>
            {
                entity.ToTable("OrderItemType");

                entity.Property(e => e.Type)
                    .HasMaxLength(200)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<OrderList>(entity =>
            {
                entity.ToTable("OrderList");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderLists)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderList_Customer");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("OrderStatus");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(250)
                    .HasColumnName("status_name");
            });

            modelBuilder.Entity<PlacedQuickOrder>(entity =>
            {
                entity.ToTable("PlacedQuickOrder");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.OrderItemId).HasColumnName("order_item_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.QuickOrderId).HasColumnName("quick_order_id");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.PlacedQuickOrder)
                    .HasForeignKey<PlacedQuickOrder>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlacedQuickOrder_QuickOrder");

                entity.HasOne(d => d.OrderItem)
                    .WithOne(p => p.PlacedQuickOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlacedQuickOrder_OrderItem");
            });

            modelBuilder.Entity<QuickOrder>(entity =>
            {
                entity.ToTable("QuickOrder");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.PhotoUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("photo_url");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.QuickOrderName)
                    .HasMaxLength(255)
                    .HasColumnName("quick_order_name");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("Restaurant");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.Property(e => e.PhotoUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("photo_url");

                entity.Property(e => e.RestaurantName)
                    .HasMaxLength(250)
                    .HasColumnName("restaurant_name");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Restaurants)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Restaurant_Restaurant");
            });

            modelBuilder.Entity<RestaurantCategory>(entity =>
            {
                entity.ToTable("RestaurantCategory");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.RestaurantId).HasColumnName("restaurant_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.RestaurantCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RestaurantCategory_Category");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.RestaurantCategories)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RestaurantCategory_Restaurant");
            });

            modelBuilder.Entity<RestaurantOrder>(entity =>
            {
                entity.ToTable("RestaurantOrder");

                entity.Property(e => e.OrderItemId).HasColumnName("order_item_id");

                entity.Property(e => e.RestaurantId).HasColumnName("restaurant_id");

                entity.Property(e => e.TotalPrice).HasColumnName("total_price");

                entity.HasOne(d => d.OrderItem)
                    .WithOne(p => p.RestaurantOrder)
                    .HasConstraintName("FK_RestaurantOrder_OrderItem");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.RestaurantOrders)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RestaurantOrder_Restaurant");
            });

            modelBuilder.Entity<RestaurantOrderItem>(entity =>
            {
                entity.ToTable("RestaurantOrderItem");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.RestaurantOrderId).HasColumnName("restaurant_order_id");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.RestaurantOrderItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RestaurantOrderItem_Item");

                entity.HasOne(d => d.RestaurantOrder)
                    .WithMany(p => p.RestaurantOrderItems)
                    .HasForeignKey(d => d.RestaurantOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RestaurantOrderItem_RestaurantOrder");
            });

            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.ToTable("VehicleType");

                entity.Property(e => e.VehicleType1)
                    .HasMaxLength(200)
                    .HasColumnName("vehicle_type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
