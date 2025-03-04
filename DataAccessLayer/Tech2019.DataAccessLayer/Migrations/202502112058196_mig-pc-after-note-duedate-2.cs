﻿namespace Tech2019.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migpcafternoteduedate2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutId = c.Int(nullable: false, identity: true),
                        AboutDescription = c.String(nullable: false, maxLength: 500),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        DataStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AboutId);
            
            CreateTable(
                "dbo.Actions",
                c => new
                    {
                        ActionId = c.Int(nullable: false, identity: true),
                        Customer = c.Int(nullable: false),
                        Employee = c.Short(nullable: false),
                        AcceptedDate = c.DateTime(nullable: false),
                        CompletedDate = c.DateTime(),
                        ProductSerialNumber = c.String(maxLength: 5),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        DataStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActionId)
                .ForeignKey("dbo.Customers", t => t.Customer)
                .ForeignKey("dbo.Employees", t => t.Employee)
                .Index(t => t.Customer)
                .Index(t => t.Employee);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerFirstName = c.String(nullable: false, maxLength: 50),
                        CustomerLastName = c.String(nullable: false, maxLength: 50),
                        CustomerPhoneNumber = c.String(nullable: false, maxLength: 20),
                        CustomerEmail = c.String(nullable: false, maxLength: 50),
                        CustomerCity = c.String(nullable: false, maxLength: 50),
                        CustomerDistrict = c.String(nullable: false, maxLength: 50),
                        CustomerAddress = c.String(maxLength: 250),
                        CustomerBank = c.String(maxLength: 50),
                        CustomerTaxNumber = c.String(maxLength: 50),
                        CustomerTaxOffice = c.String(maxLength: 50),
                        CustomerStatus = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        DataStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        InvoiceSerialCharacter = c.String(maxLength: 1),
                        InvoiceSequenceNumber = c.String(nullable: false, maxLength: 6),
                        InvoiceDate = c.DateTime(nullable: false),
                        InvoiceTaxOffice = c.String(maxLength: 50),
                        Customer = c.Int(nullable: false),
                        Employee = c.Short(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        DataStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Customers", t => t.Customer)
                .ForeignKey("dbo.Employees", t => t.Employee)
                .Index(t => t.Customer)
                .Index(t => t.Employee);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Short(nullable: false, identity: true),
                        EmployeeFirstName = c.String(nullable: false, maxLength: 50),
                        EmployeeLastName = c.String(nullable: false, maxLength: 50),
                        Department = c.Byte(nullable: false),
                        EmployeeProfilePhoto = c.String(),
                        EmployeeMail = c.String(maxLength: 100),
                        EmployeePhoneNumber = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        DataStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Departments", t => t.Department)
                .Index(t => t.Department);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Byte(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false, maxLength: 50),
                        DepartmentDescription = c.String(maxLength: 100),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        DataStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SaleId = c.Int(nullable: false, identity: true),
                        Product = c.Int(nullable: false),
                        Customer = c.Int(nullable: false),
                        Employee = c.Short(nullable: false),
                        SaleDate = c.DateTime(nullable: false),
                        SaleQuantity = c.Short(nullable: false),
                        SaleTotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductSerialNumber = c.String(maxLength: 5),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        DataStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SaleId)
                .ForeignKey("dbo.Customers", t => t.Customer)
                .ForeignKey("dbo.Employees", t => t.Employee)
                .ForeignKey("dbo.Products", t => t.Product)
                .Index(t => t.Product)
                .Index(t => t.Customer)
                .Index(t => t.Employee);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 50),
                        ProductBrand = c.String(nullable: false, maxLength: 50),
                        ProductPurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductSalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stock = c.Short(nullable: false),
                        ProductStatus = c.Int(nullable: false),
                        Category = c.Byte(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        DataStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.Category)
                .Index(t => t.Category);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Byte(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        DataStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        InvoiceDetailId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 50),
                        ProductSaleQuantity = c.Short(nullable: false),
                        ProductUnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductTotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Invoice = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        DataStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceDetailId)
                .ForeignKey("dbo.Invoices", t => t.Invoice)
                .Index(t => t.Invoice);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Byte(nullable: false),
                        AdminUsername = c.String(),
                        AdminPassword = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        DataStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ExpenseId = c.Int(nullable: false, identity: true),
                        ExpenseDescription = c.String(),
                        ExpenseDate = c.DateTime(nullable: false),
                        ExpenseTotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        DataStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExpenseId);
            
            CreateTable(
                "dbo.FaultDetails",
                c => new
                    {
                        FaultDetailId = c.Int(nullable: false, identity: true),
                        Action = c.Int(nullable: false),
                        FaultProblem = c.String(),
                        FaultDescription = c.String(),
                        FaultPrePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FaultNetPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FaultOperation = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        DataStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FaultDetailId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        SenderName = c.String(nullable: false, maxLength: 50),
                        SenderMail = c.String(nullable: false, maxLength: 100),
                        MessageTitle = c.String(nullable: false, maxLength: 50),
                        MessageContent = c.String(nullable: false, maxLength: 500),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        DataStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        NoteId = c.Int(nullable: false, identity: true),
                        NoteTitle = c.String(),
                        NoteDescription = c.String(),
                        NoteStatus = c.Int(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        DataStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NoteId);
            
            CreateTable(
                "dbo.ProductTraces",
                c => new
                    {
                        ProductTraceId = c.Int(nullable: false, identity: true),
                        ProductTraceDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ProductSerialNumber = c.String(maxLength: 5),
                        ProductTraceInformation = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        DataStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductTraceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Actions", "Employee", "dbo.Employees");
            DropForeignKey("dbo.Actions", "Customer", "dbo.Customers");
            DropForeignKey("dbo.InvoiceDetails", "Invoice", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "Employee", "dbo.Employees");
            DropForeignKey("dbo.Sales", "Product", "dbo.Products");
            DropForeignKey("dbo.Products", "Category", "dbo.Categories");
            DropForeignKey("dbo.Sales", "Employee", "dbo.Employees");
            DropForeignKey("dbo.Sales", "Customer", "dbo.Customers");
            DropForeignKey("dbo.Employees", "Department", "dbo.Departments");
            DropForeignKey("dbo.Invoices", "Customer", "dbo.Customers");
            DropIndex("dbo.InvoiceDetails", new[] { "Invoice" });
            DropIndex("dbo.Products", new[] { "Category" });
            DropIndex("dbo.Sales", new[] { "Employee" });
            DropIndex("dbo.Sales", new[] { "Customer" });
            DropIndex("dbo.Sales", new[] { "Product" });
            DropIndex("dbo.Employees", new[] { "Department" });
            DropIndex("dbo.Invoices", new[] { "Employee" });
            DropIndex("dbo.Invoices", new[] { "Customer" });
            DropIndex("dbo.Actions", new[] { "Employee" });
            DropIndex("dbo.Actions", new[] { "Customer" });
            DropTable("dbo.ProductTraces");
            DropTable("dbo.Notes");
            DropTable("dbo.Messages");
            DropTable("dbo.FaultDetails");
            DropTable("dbo.Expenses");
            DropTable("dbo.Admins");
            DropTable("dbo.InvoiceDetails");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Sales");
            DropTable("dbo.Departments");
            DropTable("dbo.Employees");
            DropTable("dbo.Invoices");
            DropTable("dbo.Customers");
            DropTable("dbo.Actions");
            DropTable("dbo.Abouts");
        }
    }
}
