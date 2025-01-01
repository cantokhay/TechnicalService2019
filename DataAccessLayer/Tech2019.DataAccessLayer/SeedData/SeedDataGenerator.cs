using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tech2019.DataAccessLayer.Context;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.SeedData
{
    public static class SeedDataGenerator
    {
        public static async Task SeedAsync()
        {
            using (var db = new TechDBContext())
            {
                db.Database.Initialize(false);

                byte maxCustomerCount = 40;
                byte maxDepartmentCount = 6;
                byte maxCategoryCount = 20;
                byte maxNoteCount = 75;
                ushort maxSaleCount = 150;
                byte maxActionCount = 100;
                byte maxProductTraceCount = maxActionCount;
                ushort maxInvoiceCount = maxSaleCount;

                if (db.Customers.Count() <= maxCustomerCount || db.Departments.Count() <= maxDepartmentCount || db.Categories.Count() <= maxCategoryCount || db.Notes.Count() <= maxNoteCount || db.Actions.Count() <= maxActionCount || db.Sales.Count() <= maxSaleCount || db.ProductTraces.Count() <= maxActionCount || db.Invoices.Count() <= maxInvoiceCount)
                {

                    byte customerCountToGenerate = (byte)(maxCustomerCount - db.Customers.Count());
                    byte departmentCountToGenerate = (byte)(maxDepartmentCount - db.Departments.Count());
                    byte categoryCountToGenerate = (byte)(maxCategoryCount - db.Categories.Count());
                    byte noteCountToGenerate = (byte)(maxNoteCount - db.Notes.Count());
                    ushort saleCountToGenerate = (ushort)(maxSaleCount - db.Sales.Count());
                    byte actionCountToGenerate = (byte)(maxActionCount - db.Actions.Count());
                    byte productTraceToGenerate = (byte)(maxProductTraceCount - db.ProductTraces.Count());
                    ushort invoiceCountToGenerate = (ushort)(maxInvoiceCount - db.Invoices.Count());

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

                    await db.SaveChangesAsync();
                }

                #region Faker Generation Methods

                void GenerateProductTraces(byte productTraceToGenerate, List<EntityLayer.Concrete.Action> actions)
                {
                    var faker = new Faker();

                    foreach (var action in actions.Take(productTraceToGenerate))
                    {
                        if (!db.ProductTraces.Any(pt => pt.ProductSerialNumber == action.ProductSerialNumber))
                        {
                            var productTrace = new ProductTrace
                            {
                                ProductSerialNumber = action.ProductSerialNumber,
                                ProductTraceDate = action.CompletedDate ?? DateTime.Now,
                                ProductTraceInformation = EnsureMaxLength(faker.Lorem.Sentence(), 250)
                            };

                            db.ProductTraces.Add(productTrace);
                        }
                    }
                    db.SaveChanges();
                }

                void GenerateActions(ushort actionCountToGenerate, List<Sale> sales)
                {
                    var faker = new Faker();
                    var existingEmployees = db.Employees.Select(e => e.EmployeeId).ToList();

                    var selectedSales = sales.OrderBy(x => faker.Random.Number()).Take(actionCountToGenerate).ToList();

                    var actions = new List<EntityLayer.Concrete.Action>();

                    foreach (var sale in selectedSales)
                    {
                        if (!db.Actions.Any(a => a.ProductSerialNumber == sale.ProductSerialNumber))
                        {
                            var action = new EntityLayer.Concrete.Action
                            {
                                Customer = sale.Customer,
                                Employee = faker.PickRandom(existingEmployees),
                                AcceptedDate = sale.SaleDate.AddDays(faker.Random.Number(1, 30)),
                                CompletedDate = sale.SaleDate.AddDays(faker.Random.Number(31, 60)),
                                ProductSerialNumber = sale.ProductSerialNumber
                            };

                            db.Actions.Add(action);
                        }
                    }

                    db.SaveChanges();
                }

                void GenerateDepartmentsAndEmployees(byte departmentCountToGenerate)
                {
                    var faker = new Faker();

                    var departmentNames = new[]
                    {
                    "IT", "HR", "Finance", "Sales", "Marketing",
                    "Logistics", "Production", "R&D", "Customer Service", "Quality Assurance"
                };

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

                            db.Employees.Add(employee);
                        }
                    }

                    db.SaveChanges();
                }

                void GenerateCustomers(byte customerCountToGenerate)
                {
                    var faker = new Faker();

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
                            CustomerStatus = faker.Random.Bool().ToString(),
                            CustomerBank = EnsureMaxLength(pickedBank, 50)
                        };

                        db.Customers.Add(customer);
                    }

                    db.SaveChanges();
                }

                void GenerateCategoriesAndProducts(byte categoryCountToGenerate)
                {
                    var faker = new Faker();

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

                    var existingCategories = db.Categories.Select(c => c.CategoryName).ToList();
                    var remainingCategories = categoryProducts.Keys.Except(existingCategories).ToList();

                    byte missingCategories = Math.Max(categoryCountToGenerate, (byte)0);

                    foreach (var categoryName in remainingCategories.Take(missingCategories))
                    {
                        var category = new Category
                        {
                            CategoryName = EnsureMaxLength(categoryName, 50)
                        };
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
                                    ProductStatus = faker.Random.Bool(),
                                    Category = category.CategoryId
                                };

                                db.Products.Add(product);
                            }
                        }
                    }

                    db.SaveChanges();
                }

                void GenerateNotes(byte noteCountToGenerate)
                {
                    var faker = new Faker();
                    var existingNotes = db.Notes.Select(n => n.NoteTitle).ToList();
                    for (byte i = 0; i < noteCountToGenerate; i++)
                    {
                        var note = new Note
                        {
                            NoteTitle = EnsureMaxLength(faker.Lorem.Word(), 50),
                            NoteDescription = EnsureMaxLength(faker.Lorem.Sentences(2, "\n"), 500),
                            NoteStatus = faker.Random.Bool()
                        };
                        db.Notes.Add(note);
                    }
                    db.SaveChanges();
                }

                void GenerateSales(ushort saleCountToGenerate)
                {
                    var faker = new Faker();
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

                        db.Sales.Add(sale);
                    }
                    db.SaveChanges();
                }

                void GenerateInvoices(ushort invoiceCountToGenerate)
                {
                    var faker = new Faker();

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

                        db.Invoices.Add(invoice);
                    }

                    db.SaveChanges();
                }


                #region Helper Methods

                string EnsureMaxLength(string value, int maxLength)
                {
                    if (string.IsNullOrEmpty(value)) return value;
                    return value.Length <= maxLength ? value : value.Substring(0, maxLength);
                }

                string GeneratePhoneNumber()
                {
                    var faker = new Faker();
                    var areaCode = (short)faker.Random.Number(100, 999);
                    var centralOfficeCode = (short)faker.Random.Number(100, 999);
                    var lineNumberPart1 = (short)faker.Random.Number(10, 99);
                    var lineNumberPart2 = (short)faker.Random.Number(10, 99);

                    return $"({areaCode}) {centralOfficeCode}-{lineNumberPart1}{lineNumberPart2}";
                }

                string GenerateAvatarUrl()
                {
                    var faker = new Faker();
                    var avatarUrls = new[]
                    {
                    "https://robohash.org/" + faker.Random.Number(1, 200) + ".png",
                };

                    return faker.PickRandom(avatarUrls); // Rastgele bir URL seç
                }

                List<KeyValuePair<string, string>> GenerateSerialSequenceDictionary(ushort count)
                {
                    var faker = new Faker();

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

                    if (serialSequencePairs.Count < count)
                    {
                        throw new InvalidOperationException("Unable to generate enough unique serial-sequence pairs.");
                    }

                    return serialSequencePairs;
                }



                #endregion

                #endregion
            }
        }
    }
}
