using System.Data.Entity;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.Context
{
    public class TechDBContext : DbContext
    {
        public TechDBContext() : base("TechDBContext") { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<ProductTrace> ProductTraces { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<FaultDetail> FaultDetails { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<About> Abouts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ConfigureCategory(modelBuilder);
            ConfigureProduct(modelBuilder);
            ConfigureCustomer(modelBuilder);
            ConfigureSale(modelBuilder);
            ConfigureEmployee(modelBuilder);
            ConfigureDepartment(modelBuilder);
            ConfigureInvoice(modelBuilder);
            ConfigureInvoiceDetail(modelBuilder);
            ConfigureAction(modelBuilder);
            ConfigureProductTrace(modelBuilder);
            ConfigureMessage(modelBuilder);
            ConfigureAbout(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        #region Fluent API Configurations
        private void ConfigureCategory(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasKey(c => c.CategoryId);

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryId)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .HasMaxLength(50)
                .IsRequired();
        }

        private void ConfigureAbout(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>()
                .HasKey(a => a.AboutId);

            modelBuilder.Entity<About>()
                .Property(a => a.AboutDescription)
                .HasMaxLength(500)
                .IsRequired();
        }

        private void ConfigureProduct(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductId);

            modelBuilder.Entity<Product>()
                .Property(p => p.ProductName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.ProductBrand)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .HasRequired(p => p.CategoryNavigation)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.Category)
                .WillCascadeOnDelete(false);
        }

        private void ConfigureCustomer(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId);

            modelBuilder.Entity<Customer>()
                .Property(c => c.CustomerFirstName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(c => c.CustomerLastName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(c => c.CustomerPhoneNumber)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(c => c.CustomerEmail)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(c => c.CustomerCity)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(c => c.CustomerDistrict)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(c => c.CustomerAddress)
                .HasMaxLength(250);

            modelBuilder.Entity<Customer>()
                .Property(c => c.CustomerBank)
                .HasMaxLength(50);

            modelBuilder.Entity<Customer>()
                .Property(c => c.CustomerTaxNumber)
                .HasMaxLength(50);

            modelBuilder.Entity<Customer>()
                .Property(c => c.CustomerTaxOffice)
                .HasMaxLength(50);
        }

        private void ConfigureSale(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>()
                .HasKey(s => s.SaleId);

            modelBuilder.Entity<Sale>()
                .HasRequired(s => s.ProductNavigation)
                .WithMany(p => p.Sales)
                .HasForeignKey(s => s.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sale>()
                .Property(a => a.ProductSerialNumber)
                .HasMaxLength(5);

            modelBuilder.Entity<Sale>()
                .HasRequired(s => s.CustomerNavigation)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sale>()
                .HasRequired(s => s.EmployeeNavigation)
                .WithMany(e => e.Sales)
                .HasForeignKey(s => s.Employee)
                .WillCascadeOnDelete(false);
        }

        private void ConfigureEmployee(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasKey(e => e.EmployeeId);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeFirstName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeLastName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeMail)
                .HasMaxLength(100);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeePhoneNumber)
                .HasMaxLength(50);

            modelBuilder.Entity<Employee>()
                .HasRequired(e => e.DepartmentNavigation)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.Department)
                .WillCascadeOnDelete(false);
        }

        private void ConfigureDepartment(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasKey(d => d.DepartmentId);

            modelBuilder.Entity<Department>()
                .Property(d => d.DepartmentId)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);


            modelBuilder.Entity<Department>()
                .Property(d => d.DepartmentName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Department>()
                .Property(d => d.DepartmentDescription)
                .HasMaxLength(100);
        }

        private void ConfigureMessage(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasKey(d => d.MessageId);

            modelBuilder.Entity<Message>()
                .Property(d => d.MessageId)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);


            modelBuilder.Entity<Message>()
                .Property(d => d.SenderName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Message>()
                .Property(d => d.SenderMail)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Message>()
                .Property(d => d.MessageTitle)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Message>()
                .Property(d => d.MessageContent)
                .HasMaxLength(500)
                .IsRequired();
        }

        private void ConfigureInvoice(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
                .HasKey(i => i.InvoiceId);

            modelBuilder.Entity<Invoice>()
                .Property(i => i.InvoiceSerialCharacter)
                .HasMaxLength(1);

            modelBuilder.Entity<Invoice>()
                .Property(i => i.InvoiceSequenceNumber)
                .HasMaxLength(6)
                .IsRequired();

            modelBuilder.Entity<Invoice>()
                .Property(i => i.InvoiceTaxOffice)
                .HasMaxLength(50);

            modelBuilder.Entity<Invoice>()
                .HasRequired(i => i.CustomerNavigation)
                .WithMany(c => c.Invoices)
                .HasForeignKey(i => i.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Invoice>()
                .HasRequired(i => i.EmployeeNavigation)
                .WithMany(c => c.Invoices)
                .HasForeignKey(i => i.Employee)
                .WillCascadeOnDelete(false);
        }

        private void ConfigureInvoiceDetail(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceDetail>()
                .HasKey(id => id.InvoiceDetailId);

            modelBuilder.Entity<InvoiceDetail>()
                .Property(id => id.ProductName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<InvoiceDetail>()
                .HasRequired(id => id.InvoiceNavigation)
                .WithMany(i => i.InvoiceDetails)
                .HasForeignKey(id => id.Invoice)
                .WillCascadeOnDelete(false);
        }

        private void ConfigureAction(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Action>()
                .HasKey(a => a.ActionId);

            modelBuilder.Entity<Action>()
                .HasRequired(a => a.CustomerNavigation)
                .WithMany(c => c.Actions)
                .HasForeignKey(a => a.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Action>()
                .Property(a => a.ProductSerialNumber)
                .HasMaxLength(5);

            modelBuilder.Entity<Action>()
                .HasRequired(a => a.EmployeeNavigation)
                .WithMany(e => e.Actions)
                .HasForeignKey(a => a.Employee)
                .WillCascadeOnDelete(false);
        }

        private void ConfigureProductTrace(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductTrace>()
                .HasKey(pt => pt.ProductTraceId);

            modelBuilder.Entity<ProductTrace>()
                .Property(pt => pt.ProductTraceInformation)
                .HasMaxLength(250);

            modelBuilder.Entity<ProductTrace>()
                .Property(pt => pt.ProductTraceDate)
                .HasColumnType("datetime2");

            modelBuilder.Entity<ProductTrace>()
                .Property(pt => pt.ProductSerialNumber)
                .HasMaxLength(5);
        }
        #endregion
    }
}
