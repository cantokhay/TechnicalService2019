using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tech2019.DataAccessLayer.Context;
using Tech2019.EntityLayer.Abstract;
using Tech2019.EntityLayer.Concrete;
using Tech2019.EntityLayer.Enum;

namespace Tech2019.DataAccessLayer.SeedData
{
    public static class SeedDataGenerator
    {
        public static async Task SeedAsync()
        {
            using (var db = new TechDBContext())
            {
                db.Database.Initialize(false);

                var faker = new Faker();

                #region Helper Data
                var departmentNames = new[]
{
                        "IT", "HR", "Finance", "Sales", "Marketing",
                        "Logistics", "Production", "R&D", "Customer Service", "Quality Assurance"
                    };

                var cityDistrictMap = new Dictionary<string, List<string>>
                    {
                        { "Istanbul", new List<string> { "Kadikoy", "Besiktas", "Sisli", "Uskudar", "Maltepe" } },
                        { "Ankara", new List<string> { "Cankaya", "Keçiören", "Mamak", "Yenimahalle", "Altındağ" } },
                        { "Izmir", new List<string> { "Bornova", "Karşıyaka", "Buca", "Balçova", "Konak" } },
                        { "Bursa", new List<string> { "Altıparmak", "Nilüfer", "Osmangazi", "Yıldırım", "Görükle" } },
                        { "Antalya", new List<string> { "Muratpaşa", "Konyaaltı", "Kepez", "Aksu", "Döşemealtı" } },
                        { "Adana", new List<string> { "Seyhan", "Çukurova", "Yüreğir", "Sarıçam", "Ceyhan" } },
                        { "Gaziantep", new List<string> { "Şahinbey", "Şehitkamil", "Oğuzeli", "Araban", "Karkamış" } },
                        { "Konya", new List<string> { "Selçuklu", "Karatay", "Meram", "Beyşehir", "Ereğli" } },
                        { "Diyarbakir", new List<string> { "Bağlar", "Kayapınar", "Sur", "Yenişehir", "Bismil" } },
                        { "Eskisehir", new List<string> { "Odunpazarı", "Tepebaşı", "Çifteler", "Sivrihisar", "Alpu" } }
                    };

                var bankNames = new[] { "Akbank", "Yapı Kredi", "Garanti", "Ziraat", "Vakıfbank",
                                                    "Halkbank", "TEB", "ING", "Şekerbank", "QNB Finansbank" };
                var productBrands = new[]
{
                    "Apple", "Samsung", "Sony", "LG Electronics", "Microsoft", "Dell", "Lenovo", "HP", "Asus", "Acer",
                    "Panasonic", "Philips", "Bosch", "Siemens", "Arçelik", "Beko", "Whirlpool", "General Electric",
                    "Xiaomi", "Huawei", "Toshiba", "Nokia", "Casio", "Temu", "Canon"
                };

                var categoryProducts = new Dictionary<string, string[]>
                {
                    { "Computer", new[] { "Laptop", "Desktop", "Gaming PC", "Workstation", "Server" } },
                    { "Phone", new[] { "Smartphone", "Feature Phone", "Tablet", "Smartwatch" } },
                    { "Appliance", new[] { "Washing Machine", "Refrigerator", "Microwave", "Dishwasher" } },
                    { "Furniture", new[] { "Chair", "Table", "Sofa", "Bed", "Cabinet" } },
                    { "Electronics", new[] { "TV", "Speaker", "Headphones", "Camera", "Monitor" } },
                    { "Sports", new[] { "Football", "Tennis Racket", "Yoga Mat", "Dumbbells", "Basketball" } },
                    { "Toys", new[] { "Action Figure", "Board Game", "Doll", "Puzzle", "Toy Car" } },
                    { "Clothing", new[] { "T-Shirt", "Jeans", "Jacket", "Hat", "Sunglasses" } },
                    { "Books", new[] { "Novel", "Textbook", "Magazine", "Comic Book", "Biography" } },
                    { "Music", new[] { "Guitar", "Piano", "Drums", "Microphone", "Keyboard" } },
                    { "Automotive", new[] { "Car Battery", "Tire", "Engine Oil", "Brake Pads", "Car Wash Kit" } },
                    { "Garden", new[] { "Lawn Mower", "Shovel", "Hose", "Seeds", "Fertilizer" } },
                    { "Health", new[] { "Vitamins", "First Aid Kit", "Face Mask", "Thermometer", "Gloves" } },
                    { "Kitchen", new[] { "Blender", "Knife Set", "Frying Pan", "Toaster", "Kettle" } },
                    { "Office", new[] { "Notebook", "Pen", "Desk", "Chair", "Lamp" } },
                    { "Beauty", new[] { "Lipstick", "Foundation", "Eyeliner", "Perfume", "Nail Polish" } },
                    { "Travel", new[] { "Suitcase", "Backpack", "Travel Pillow", "Map", "Camera" } },
                    { "Fitness", new[] { "Treadmill", "Bicycle", "Rowing Machine", "Weights", "Resistance Bands" } },
                    { "Gaming", new[] { "Console", "Controller", "Headset", "Game Disk", "Mouse" } },
                    { "Pets", new[] { "Dog Food", "Cat Food", "Pet Bed", "Collar", "Aquarium" } },
                    { "Jewelry", new[] { "Ring", "Bracelet", "Necklace", "Earrings", "Watch" } },
                    { "Outdoors", new[] { "Tent", "Sleeping Bag", "Hiking Boots", "Compass", "Flashlight" } },
                    { "Baby", new[] { "Stroller", "Diapers", "Baby Bottle", "Baby Toy", "Crib" } },
                    { "Tools", new[] { "Hammer", "Drill", "Wrench", "Saw", "Screwdriver" } },
                    { "Art", new[] { "Paint", "Canvas", "Brush", "Easel", "Sketchbook" } }
                };

                byte maxCustomerCount = 40;
                byte maxDepartmentCount = 6;
                byte maxAboutCount = 1;
                byte maxCategoryCount = 20;
                byte maxNoteCount = 75;
                ushort maxSaleCount = 150;
                byte maxActionCount = 100;
                byte maxProductTraceCount = maxActionCount;
                ushort maxInvoiceCount = maxSaleCount;
                byte maxMessageCount = maxActionCount;

                #endregion

                if (db.Customers.Count() <= maxCustomerCount || db.Departments.Count() <= maxDepartmentCount || db.Categories.Count() <= maxCategoryCount || db.Notes.Count() <= maxNoteCount || db.Actions.Count() <= maxActionCount || db.Sales.Count() <= maxSaleCount || db.ProductTraces.Count() <= maxActionCount || db.Invoices.Count() <= maxInvoiceCount || db.Messages.Count() < maxMessageCount || db.Abouts.Count() < maxAboutCount)
                {

                    byte customerCountToGenerate = (byte)(maxCustomerCount - db.Customers.Count());
                    byte aboutCountToGenerate = (byte)(maxAboutCount - db.Abouts.Count());
                    byte departmentCountToGenerate = (byte)(maxDepartmentCount - db.Departments.Count());
                    byte categoryCountToGenerate = (byte)(maxCategoryCount - db.Categories.Count());
                    byte noteCountToGenerate = (byte)(maxNoteCount - db.Notes.Count());
                    ushort saleCountToGenerate = (ushort)(maxSaleCount - db.Sales.Count());
                    byte actionCountToGenerate = (byte)(maxActionCount - db.Actions.Count());
                    byte productTraceToGenerate = (byte)(maxProductTraceCount - db.ProductTraces.Count());
                    ushort invoiceCountToGenerate = (ushort)(maxInvoiceCount - db.Invoices.Count());
                    byte messageToGenerate = (byte)(maxMessageCount - db.Messages.Count());

                    GenerateCategoriesAndProducts(categoryCountToGenerate);
                    GenerateCustomers(customerCountToGenerate);
                    GenerateDepartmentsAndEmployees(departmentCountToGenerate);
                    GenerateNotes(noteCountToGenerate);
                    GenerateSales(saleCountToGenerate);
                    var createdSales = db.Sales.ToList();
                    GenerateActions(actionCountToGenerate, createdSales);
                    var createdActions = db.Actions.ToList();
                    GenerateProductTraces(productTraceToGenerate, createdActions);
                    GenerateInvoices(invoiceCountToGenerate);
                    GenerateInvoiceDetails();
                    GenerateMessages(messageToGenerate);
                    GenerateAbouts(aboutCountToGenerate);

                    await db.SaveChangesAsync();
                }

                #region Faker Generation Methods

                void GenerateInvoiceDetails()
                {
                    int existingInvoiceDetailCount = db.InvoiceDetails.Count();
                    if (existingInvoiceDetailCount >= 1000)
                    {
                        return;
                    }

                    var existingInvoices = db.Invoices.Select(i => i.InvoiceId).ToList();
                    var existingProducts = db.Products.Select(p => p.ProductId).ToList();

                    foreach (var invoiceId in existingInvoices)
                    {
                        var numberOfDetails = faker.Random.Number(5, 10);

                        for (int i = 0; i < numberOfDetails; i++)
                        {
                            var product = faker.PickRandom(existingProducts);
                            var quantity = faker.Random.Number(1, 100);
                            var unitPrice = db.Products.Where(p => p.ProductId == product).Select(p => p.ProductSalePrice).FirstOrDefault();
                            var totalPrice = quantity * unitPrice;

                            var invoiceDetail = new InvoiceDetail
                            {
                                ProductName = db.Products.Where(p => p.ProductId == product).Select(p => p.ProductName).FirstOrDefault(),
                                ProductSaleQuantity = (short)quantity,
                                ProductUnitPrice = unitPrice,
                                ProductTotalPrice = totalPrice,
                                Invoice = invoiceId
                            };

                            AssignEntityDatesAndDataStatus(invoiceDetail);
                            db.InvoiceDetails.Add(invoiceDetail);
                        }
                    }
                    db.SaveChanges();
                }

                void GenerateProductTraces(byte productTraceToGenerate, List<EntityLayer.Concrete.Action> actions)
                {
                    foreach (var action in actions.Take(productTraceToGenerate))
                    {
                        if (!db.ProductTraces.Any(pt => pt.ProductSerialNumber == action.ProductSerialNumber))
                        {
                            var productTrace = new ProductTrace
                            {
                                ProductSerialNumber = action.ProductSerialNumber,
                                ProductTraceDate = action.CompletedDate ?? DateTime.Now,
                                ProductTraceInformation = EnsureMaxLength(faker.Lorem.Sentence(), 250),
                                ActionStatusDetail = action.ActionStatusDetail
                            };

                            AssignEntityDatesAndDataStatus(productTrace);
                            db.ProductTraces.Add(productTrace);
                        }
                    }
                    db.SaveChanges();
                }

                void GenerateActions(ushort actionCountToGenerate, List<Sale> sales)
                {
                    var existingEmployees = db.Employees.Select(e => e.EmployeeId).ToList();

                    var selectedSales = sales.OrderBy(x => faker.Random.Number()).Take(actionCountToGenerate).ToList();

                    foreach (var sale in selectedSales)
                    {
                        if (!db.Actions.Any(a => a.ProductSerialNumber == sale.ProductSerialNumber))
                        {
                            var acceptedDate = sale.SaleDate.AddDays(faker.Random.Number(1, 30));
                            var completedDate = sale.SaleDate.AddDays(faker.Random.Number(31, 60));
                            var actionStatus = new[] { ActionStatus.PendingRepair , ActionStatus.OnRepair, ActionStatus.RepairFinished };
                            var actionStatusDetail = new[] { ActionStatusDetail.PendingSparePart, ActionStatusDetail.PendingCustomerApprove, ActionStatusDetail.ActionCancelled, ActionStatusDetail.PendingPayment };

                            acceptedDate = acceptedDate < new DateTime(1753, 1, 1) ? new DateTime(1753, 1, 1) : acceptedDate;
                            completedDate = completedDate < new DateTime(1753, 1, 1) ? new DateTime(1753, 1, 1) : completedDate;

                            var action = new EntityLayer.Concrete.Action
                            {
                                Customer = sale.Customer,
                                Employee = faker.PickRandom(existingEmployees),
                                AcceptedDate = acceptedDate,
                                CompletedDate = completedDate,
                                ProductSerialNumber = sale.ProductSerialNumber,
                                ActionStatus = faker.PickRandom(actionStatus),
                                ActionStatusDetail = faker.PickRandom(actionStatusDetail)
                            };

                            AssignEntityDatesAndDataStatus(action);
                            db.Actions.Add(action);
                        }
                    }
                    db.SaveChanges();
                }

                void GenerateDepartmentsAndEmployees(byte departmentCountToGenerate)
                {
                    var existingDepartments = db.Departments.Select(d => d.DepartmentName).ToList();
                    var remainingDepartments = departmentNames.Except(existingDepartments).ToList();

                    byte missingDepartments = Math.Max(departmentCountToGenerate, (byte)0);

                    foreach (var departmentName in remainingDepartments.Take(missingDepartments))
                    {
                        var department = new Department
                        {
                            DepartmentName = departmentName,
                            DepartmentDescription = EnsureMaxLength(faker.Lorem.Sentence(), 100)
                        };

                        AssignEntityDatesAndDataStatus(department);
                        db.Departments.Add(department);
                        db.SaveChanges();

                        byte employeeCount = (byte)faker.Random.Number(3, 7);

                        for (byte i = 0; i < employeeCount; i++)
                        {
                            var employee = new Employee
                            {
                                EmployeeFirstName = EnsureMaxLength(faker.Name.FirstName(), 50),
                                EmployeeLastName = EnsureMaxLength(faker.Name.LastName(), 50),
                                Department = (byte)department.DepartmentId,
                                EmployeeProfilePhoto = GenerateAvatarUrl(),
                                EmployeeMail = EnsureMaxLength(faker.Internet.Email(), 50),
                                EmployeePhoneNumber = GeneratePhoneNumber()
                            };
                            AssignEntityDatesAndDataStatus(employee);
                            db.Employees.Add(employee);
                        }
                    }
                    db.SaveChanges();
                }

                void GenerateCustomers(byte customerCountToGenerate)
                {
                    var customerStatus = new[] { CustomerStatus.ActiveBuyer, CustomerStatus.PassiveAccount, CustomerStatus.DeletedAccount };

                    for (byte i = 0; i < customerCountToGenerate; i++)
                    {
                        var pickedCity = faker.PickRandom(cityDistrictMap.Keys.ToList());
                        var pickedDistrict = faker.PickRandom(cityDistrictMap[pickedCity]);
                        var pickedBank = faker.PickRandom(bankNames);

                        var customer = new Customer
                        {
                            CustomerFirstName = EnsureMaxLength(faker.Name.FirstName(), 50),
                            CustomerLastName = EnsureMaxLength(faker.Name.LastName(), 50),
                            CustomerPhoneNumber = GeneratePhoneNumber(),
                            CustomerEmail = EnsureMaxLength(faker.Internet.Email(), 50),
                            CustomerAddress = EnsureMaxLength(faker.Address.FullAddress(), 250),
                            CustomerCity = EnsureMaxLength(pickedCity, 50),
                            CustomerDistrict = EnsureMaxLength(pickedDistrict, 50),
                            CustomerTaxNumber = faker.Random.Number(100000000, 999999999).ToString(),
                            CustomerTaxOffice = EnsureMaxLength(faker.Company.CompanyName(), 50),
                            CustomerStatus = faker.PickRandom(customerStatus),
                            CustomerBank = EnsureMaxLength(pickedBank, 50)
                        };

                        AssignEntityDatesAndDataStatus(customer);
                        db.Customers.Add(customer);
                    }
                    db.SaveChanges();
                }

                void GenerateCategoriesAndProducts(byte categoryCountToGenerate)
                {
                    var existingCategories = db.Categories.Select(c => c.CategoryName).ToList();
                    var remainingCategories = categoryProducts.Keys.Except(existingCategories).ToList();
                    var productStatus = new[] { ProductStatus.ActivelySold, ProductStatus.NotAvailableToPurchase, ProductStatus.NotInStock };

                    byte missingCategories = Math.Max(categoryCountToGenerate, (byte)0);

                    foreach (var categoryName in remainingCategories.Take(missingCategories))
                    {
                        var category = new Category
                        {
                            CategoryName = EnsureMaxLength(categoryName, 50)
                        };
                        AssignEntityDatesAndDataStatus(category);
                        db.Categories.Add(category);
                        db.SaveChanges();

                        if (categoryProducts.ContainsKey(categoryName))
                        {
                            var productsForCategory = categoryProducts[categoryName];

                            byte productCount = (byte)faker.Random.Number(3, 7);

                            for (byte i = 0; i < productCount; i++)
                            {
                                var product = new Product
                                {
                                    ProductName = faker.PickRandom(productsForCategory),
                                    ProductBrand = faker.PickRandom(productBrands),
                                    ProductPurchasePrice = decimal.Parse(faker.Commerce.Price(100, 1000)),
                                    ProductSalePrice = decimal.Parse(faker.Commerce.Price(1000, 2000)),
                                    Stock = (short)faker.Random.Number(1, 100),
                                    ProductStatus = faker.PickRandom(productStatus),
                                    Category = category.CategoryId
                                };
                                AssignEntityDatesAndDataStatus(product);
                                db.Products.Add(product);
                            }
                        }
                    }
                    db.SaveChanges();
                }

                void GenerateNotes(byte noteCountToGenerate)
                {
                    var existingNotes = db.Notes.Select(n => n.NoteTitle).ToList();
                    var noteStatus = new[] { NoteStatus.Read, NoteStatus.Unread };
                    for (byte i = 0; i < noteCountToGenerate; i++)
                    {
                        var note = new Note
                        {
                            NoteTitle = EnsureMaxLength(faker.Lorem.Word(), 50),
                            NoteDescription = EnsureMaxLength(faker.Lorem.Sentences(2, "\n"), 500),
                            NoteStatus = faker.PickRandom(noteStatus),
                            DueDate = faker.Date.Between(DateTime.Now, DateTime.Now.AddDays(5))
                        };
                        AssignEntityDatesAndDataStatus(note);
                        db.Notes.Add(note);
                    }
                    db.SaveChanges();
                }

                void GenerateSales(ushort saleCountToGenerate)
                {
                    var existingProducts = db.Products.Select(p => p.ProductId).ToList();
                    var existingCustomers = db.Customers.Select(c => c.CustomerId).ToList();
                    var existingEmployees = db.Employees.Select(e => e.EmployeeId).ToList();

                    var sales = new List<Sale>();

                    for (short i = 0; i < saleCountToGenerate; i++)
                    {
                        var saleDate = faker.Date.Between(DateTime.Now.AddMonths(-12), DateTime.Now.AddMonths(-2));
                        var productSerialNumber = faker.Random.AlphaNumeric(5).ToUpper();

                        var sale = new Sale
                        {
                            Product = faker.PickRandom(existingProducts),
                            Customer = faker.PickRandom(existingCustomers),
                            Employee = faker.PickRandom(existingEmployees),
                            SaleDate = saleDate,
                            SaleQuantity = (short)faker.Random.Number(1, 50),
                            SaleTotalPrice = decimal.Parse(faker.Commerce.Price(100, 10000)),
                            ProductSerialNumber = productSerialNumber
                        };
                        AssignEntityDatesAndDataStatus(sale);
                        db.Sales.Add(sale);
                    }
                    db.SaveChanges();
                }

                void GenerateInvoices(ushort invoiceCountToGenerate)
                {
                    var existingCustomers = db.Customers.Select(x => x.CustomerId).ToList();
                    var existingEmployees = db.Employees.Select(x => x.EmployeeId).ToList();
                    var serialSequencePairs = GenerateSerialSequenceDictionary(invoiceCountToGenerate);

                    foreach (var pair in serialSequencePairs)
                    {
                        var selectedCustomer = faker.PickRandom(existingCustomers);
                        var selectedEmployee = faker.PickRandom(existingEmployees);

                        var invoiceDate = faker.Date.Between(DateTime.Now.AddMonths(-12), DateTime.Now);

                        var invoice = new Invoice
                        {
                            InvoiceSerialCharacter = pair.Key,
                            InvoiceSequenceNumber = pair.Value,
                            InvoiceDate = invoiceDate,
                            InvoiceTaxOffice = faker.Company.CompanyName(),
                            Customer = selectedCustomer,
                            Employee = selectedEmployee
                        };
                        AssignEntityDatesAndDataStatus(invoice);
                        db.Invoices.Add(invoice);
                    }
                    db.SaveChanges();
                }

                void GenerateMessages(int messageCountToGenerate)
                {
                    for (int i = 0; i < messageCountToGenerate; i++)
                    {
                        var message = new Message
                        {
                            SenderName = EnsureMaxLength(faker.Name.FullName(), 50),
                            SenderMail = EnsureMaxLength(faker.Internet.Email(), 100),
                            MessageTitle = EnsureMaxLength(faker.Lorem.Sentence(5), 50),
                            MessageContent = EnsureMaxLength(faker.Lorem.Paragraph(3), 500),
                            CreatedDate = faker.Date.Past(1),
                            ModifiedDate = faker.Random.Bool() ? faker.Date.Recent(30) : (DateTime?)null,
                            DeletedDate = faker.Random.Bool(0.1f) ? faker.Date.Recent(7) : (DateTime?)null,
                            DataStatus = faker.PickRandom<DataStatus>()
                        };

                        AssignEntityDatesAndDataStatus(message);
                        db.Messages.Add(message);
                    }
                    db.SaveChanges();
                }

                void GenerateAbouts(byte aboutCountToGenerate)
                {
                    for (int i = 0; i < aboutCountToGenerate; i++)
                    {
                        var about = new About
                        {
                            AboutDescription = EnsureMaxLength(faker.Lorem.Sentences(5), 500)
                        };

                        AssignEntityDatesAndDataStatus(about);
                        db.Abouts.Add(about);
                    }
                    db.SaveChanges();
                }

                #endregion

                #region Helper Methods

                string EnsureMaxLength(string value, int maxLength)
                {
                    if (string.IsNullOrEmpty(value)) return value;
                    return value.Length <= maxLength ? value : value.Substring(0, maxLength);
                }

                string GeneratePhoneNumber()
                {
                    var areaCode = (short)faker.Random.Number(100, 999);
                    var centralOfficeCode = (short)faker.Random.Number(100, 999);
                    var lineNumberPart1 = (short)faker.Random.Number(10, 99);
                    var lineNumberPart2 = (short)faker.Random.Number(10, 99);

                    return $"({areaCode}) {centralOfficeCode}-{lineNumberPart1}{lineNumberPart2}";
                }

                string GenerateAvatarUrl()
                {
                    var avatarUrls = new[]
                    {
                    "https://robohash.org/" + faker.Random.Number(1, 200) + ".png",
                };

                    return faker.PickRandom(avatarUrls); // Rastgele bir URL seç
                }

                List<KeyValuePair<string, string>> GenerateSerialSequenceDictionary(ushort count)
                {
                    var serialSequencePairs = Enumerable.Range(0, count * 10)
                        .Select(_ =>
                        {
                            var serialCharacter = faker.Random.String2(1, "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                            var sequenceNumber = faker.Random.Replace("######");
                            return new KeyValuePair<string, string>(serialCharacter, sequenceNumber);
                        })
                        .Distinct()
                        .Take(count)
                        .ToList();

                    return serialSequencePairs;
                }

                void AssignEntityDatesAndDataStatus<T>(T entity) where T : class, IGenericEntity
                {
                    var currentDate = DateTime.Now;

                    var dataStatus = new[] { DataStatus.Deleted, DataStatus.Active, DataStatus.Modified };

                    entity.DataStatus = faker.PickRandom(dataStatus);

                    if (entity.DataStatus == DataStatus.Active)
                    {
                        entity.CreatedDate = currentDate.AddDays(-(faker.Random.Number(21, 30)));

                        entity.ModifiedDate = null;
                        entity.DeletedDate = null;
                    }
                    else if (entity.DataStatus == DataStatus.Modified)
                    {
                        entity.CreatedDate = currentDate.AddDays(-(faker.Random.Number(21, 30)));
                        entity.ModifiedDate = currentDate.AddDays(-(faker.Random.Number(11, 20)));
                        entity.DeletedDate = null;
                    }
                    else if (entity.DataStatus == DataStatus.Deleted)
                    {
                        entity.CreatedDate = currentDate.AddDays(-(faker.Random.Number(21, 30)));
                        entity.ModifiedDate = currentDate.AddDays(-(faker.Random.Number(11, 20)));
                        entity.DeletedDate = currentDate.AddDays(-(faker.Random.Number(1, 10)));
                    }
                }

                #endregion

            }
        }
    }
}