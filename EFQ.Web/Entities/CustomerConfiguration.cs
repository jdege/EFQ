using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#nullable disable

namespace JDege.EFQ.Web.Entities
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasIndex(e => e.SupportRepId, "IFK_CustomerSupportRepId");

            builder.Property(e => e.Address).HasMaxLength(70);

            builder.Property(e => e.City).HasMaxLength(40);

            builder.Property(e => e.Company).HasMaxLength(80);

            builder.Property(e => e.Country).HasMaxLength(40);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(e => e.Fax).HasMaxLength(24);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.Phone).HasMaxLength(24);

            builder.Property(e => e.PostalCode).HasMaxLength(10);

            builder.Property(e => e.State).HasMaxLength(40);

            builder.HasOne(d => d.SupportRep)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.SupportRepId)
                .HasConstraintName("FK_CustomerSupportRepId");

            seedData(builder);
        }
        private void seedData(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer
                {
                    CustomerId = 1,
                    FirstName = "Luís",
                    LastName = "Gonçalves",
                    Company = "Embraer - Empresa Brasileira de Aeronáutica S.A.",
                    Address = "Av. Brigadeiro Faria Lima, 2170",
                    City = "São José dos Campos",
                    State = "SP",
                    Country = "Brazil",
                    PostalCode = "12227-000",
                    Phone = "+55 (12) 3923-5555",
                    Fax = "+55 (12) 3923-5566",
                    Email = "luisg@embraer.com.br",
                    SupportRepId = 3
                },
                new Customer
                {
                    CustomerId = 2,
                    FirstName = "Leonie",
                    LastName = "Köhler",
                    Company = null,
                    Address = "Theodor-Heuss-Straße 34",
                    City = "Stuttgart",
                    State = null,
                    Country = "Germany",
                    PostalCode = "70174",
                    Phone = "+49 0711 2842222",
                    Fax = null,
                    Email = "leonekohler@surfeu.de",
                    SupportRepId = 5
                },
                new Customer
                {
                    CustomerId = 3,
                    FirstName = "François",
                    LastName = "Tremblay",
                    Company = null,
                    Address = "1498 rue Bélanger",
                    City = "Montréal",
                    State = "QC",
                    Country = "Canada",
                    PostalCode = "H2G 1A7",
                    Phone = "+1 (514) 721-4711",
                    Fax = null,
                    Email = "ftremblay@gmail.com",
                    SupportRepId = 3
                },
                new Customer
                {
                    CustomerId = 4,
                    FirstName = "Bjørn",
                    LastName = "Hansen",
                    Company = null,
                    Address = "Ullevålsveien 14",
                    City = "Oslo",
                    State = null,
                    Country = "Norway",
                    PostalCode = "0171",
                    Phone = "+47 22 44 22 22",
                    Fax = null,
                    Email = "bjorn.hansen@yahoo.no",
                    SupportRepId = 4
                },
                new Customer
                {
                    CustomerId = 5,
                    FirstName = "František",
                    LastName = "Wichterlová",
                    Company = "JetBrains s.r.o.",
                    Address = "Klanova 9/506",
                    City = "Prague",
                    State = null,
                    Country = "Czech Republic",
                    PostalCode = "14700",
                    Phone = "+420 2 4172 5555",
                    Fax = "+420 2 4172 5555",
                    Email = "frantisekw@jetbrains.com",
                    SupportRepId = 4
                },
                new Customer
                {
                    CustomerId = 6,
                    FirstName = "Helena",
                    LastName = "Holý",
                    Company = null,
                    Address = "Rilská 3174/6",
                    City = "Prague",
                    State = null,
                    Country = "Czech Republic",
                    PostalCode = "14300",
                    Phone = "+420 2 4177 0449",
                    Fax = null,
                    Email = "hholy@gmail.com",
                    SupportRepId = 5
                },
                new Customer
                {
                    CustomerId = 7,
                    FirstName = "Astrid",
                    LastName = "Gruber",
                    Company = null,
                    Address = "Rotenturmstraße 4, 1010 Innere Stadt",
                    City = "Vienne",
                    State = null,
                    Country = "Austria",
                    PostalCode = "1010",
                    Phone = "+43 01 5134505",
                    Fax = null,
                    Email = "astrid.gruber@apple.at",
                    SupportRepId = 5
                },
                new Customer
                {
                    CustomerId = 8,
                    FirstName = "Daan",
                    LastName = "Peeters",
                    Company = null,
                    Address = "Grétrystraat 63",
                    City = "Brussels",
                    State = null,
                    Country = "Belgium",
                    PostalCode = "1000",
                    Phone = "+32 02 219 03 03",
                    Fax = null,
                    Email = "daan_peeters@apple.be",
                    SupportRepId = 4
                },
                new Customer
                {
                    CustomerId = 9,
                    FirstName = "Kara",
                    LastName = "Nielsen",
                    Company = null,
                    Address = "Sønder Boulevard 51",
                    City = "Copenhagen",
                    State = null,
                    Country = "Denmark",
                    PostalCode = "1720",
                    Phone = "+453 3331 9991",
                    Fax = null,
                    Email = "kara.nielsen@jubii.dk",
                    SupportRepId = 4
                },
                new Customer
                {
                    CustomerId = 10,
                    FirstName = "Eduardo",
                    LastName = "Martins",
                    Company = "Woodstock Discos",
                    Address = "Rua Dr. Falcão Filho, 155",
                    City = "São Paulo",
                    State = "SP",
                    Country = "Brazil",
                    PostalCode = "01007-010",
                    Phone = "+55 (11) 3033-5446",
                    Fax = "+55 (11) 3033-4564",
                    Email = "eduardo@woodstock.com.br",
                    SupportRepId = 4
                },
                new Customer
                {
                    CustomerId = 11,
                    FirstName = "Alexandre",
                    LastName = "Rocha",
                    Company = "Banco do Brasil S.A.",
                    Address = "Av. Paulista, 2022",
                    City = "São Paulo",
                    State = "SP",
                    Country = "Brazil",
                    PostalCode = "01310-200",
                    Phone = "+55 (11) 3055-3278",
                    Fax = "+55 (11) 3055-8131",
                    Email = "alero@uol.com.br",
                    SupportRepId = 5
                },
                new Customer
                {
                    CustomerId = 12,
                    FirstName = "Roberto",
                    LastName = "Almeida",
                    Company = "Riotur",
                    Address = "Praça Pio X, 119",
                    City = "Rio de Janeiro",
                    State = "RJ",
                    Country = "Brazil",
                    PostalCode = "20040-020",
                    Phone = "+55 (21) 2271-7000",
                    Fax = "+55 (21) 2271-7070",
                    Email = "roberto.almeida@riotur.gov.br",
                    SupportRepId = 3
                },
                new Customer
                {
                    CustomerId = 13,
                    FirstName = "Fernanda",
                    LastName = "Ramos",
                    Company = null,
                    Address = "Qe 7 Bloco G",
                    City = "Brasília",
                    State = "DF",
                    Country = "Brazil",
                    PostalCode = "71020-677",
                    Phone = "+55 (61) 3363-5547",
                    Fax = "+55 (61) 3363-7855",
                    Email = "fernadaramos4@uol.com.br",
                    SupportRepId = 4
                },
                new Customer
                {
                    CustomerId = 14,
                    FirstName = "Mark",
                    LastName = "Philips",
                    Company = "Telus",
                    Address = "8210 111 ST NW",
                    City = "Edmonton",
                    State = "AB",
                    Country = "Canada",
                    PostalCode = "T6G 2C7",
                    Phone = "+1 (780) 434-4554",
                    Fax = "+1 (780) 434-5565",
                    Email = "mphilips12@shaw.ca",
                    SupportRepId = 5
                },
                new Customer
                {
                    CustomerId = 15,
                    FirstName = "Jennifer",
                    LastName = "Peterson",
                    Company = "Rogers Canada",
                    Address = "700 W Pender Street",
                    City = "Vancouver",
                    State = "BC",
                    Country = "Canada",
                    PostalCode = "V6C 1G8",
                    Phone = "+1 (604) 688-2255",
                    Fax = "+1 (604) 688-8756",
                    Email = "jenniferp@rogers.ca",
                    SupportRepId = 3
                },
                new Customer
                {
                    CustomerId = 16,
                    FirstName = "Frank",
                    LastName = "Harris",
                    Company = "Google Inc.",
                    Address = "1600 Amphitheatre Parkway",
                    City = "Mountain View",
                    State = "CA",
                    Country = "USA",
                    PostalCode = "94043-1351",
                    Phone = "+1 (650) 253-0000",
                    Fax = "+1 (650) 253-0000",
                    Email = "fharris@google.com",
                    SupportRepId = 4
                },
                new Customer
                {
                    CustomerId = 17,
                    FirstName = "Jack",
                    LastName = "Smith",
                    Company = "Microsoft Corporation",
                    Address = "1 Microsoft Way",
                    City = "Redmond",
                    State = "WA",
                    Country = "USA",
                    PostalCode = "98052-8300",
                    Phone = "+1 (425) 882-8080",
                    Fax = "+1 (425) 882-8081",
                    Email = "jacksmith@microsoft.com",
                    SupportRepId = 5
                },
                new Customer
                {
                    CustomerId = 18,
                    FirstName = "Michelle",
                    LastName = "Brooks",
                    Company = null,
                    Address = "627 Broadway",
                    City = "New York",
                    State = "NY",
                    Country = "USA",
                    PostalCode = "10012-2612",
                    Phone = "+1 (212) 221-3546",
                    Fax = "+1 (212) 221-4679",
                    Email = "michelleb@aol.com",
                    SupportRepId = 3
                },
                new Customer
                {
                    CustomerId = 19,
                    FirstName = "Tim",
                    LastName = "Goyer",
                    Company = "Apple Inc.",
                    Address = "1 Infinite Loop",
                    City = "Cupertino",
                    State = "CA",
                    Country = "USA",
                    PostalCode = "95014",
                    Phone = "+1 (408) 996-1010",
                    Fax = "+1 (408) 996-1011",
                    Email = "tgoyer@apple.com",
                    SupportRepId = 3
                },
                new Customer
                {
                    CustomerId = 20,
                    FirstName = "Dan",
                    LastName = "Miller",
                    Company = null,
                    Address = "541 Del Medio Avenue",
                    City = "Mountain View",
                    State = "CA",
                    Country = "USA",
                    PostalCode = "94040-111",
                    Phone = "+1 (650) 644-3358",
                    Fax = null,
                    Email = "dmiller@comcast.com",
                    SupportRepId = 4
                },
                new Customer
                {
                    CustomerId = 21,
                    FirstName = "Kathy",
                    LastName = "Chase",
                    Company = null,
                    Address = "801 W 4th Street",
                    City = "Reno",
                    State = "NV",
                    Country = "USA",
                    PostalCode = "89503",
                    Phone = "+1 (775) 223-7665",
                    Fax = null,
                    Email = "kachase@hotmail.com",
                    SupportRepId = 5
                },
                new Customer
                {
                    CustomerId = 22,
                    FirstName = "Heather",
                    LastName = "Leacock",
                    Company = null,
                    Address = "120 S Orange Ave",
                    City = "Orlando",
                    State = "FL",
                    Country = "USA",
                    PostalCode = "32801",
                    Phone = "+1 (407) 999-7788",
                    Fax = null,
                    Email = "hleacock@gmail.com",
                    SupportRepId = 4
                },
                new Customer
                {
                    CustomerId = 23,
                    FirstName = "John",
                    LastName = "Gordon",
                    Company = null,
                    Address = "69 Salem Street",
                    City = "Boston",
                    State = "MA",
                    Country = "USA",
                    PostalCode = "2113",
                    Phone = "+1 (617) 522-1333",
                    Fax = null,
                    Email = "johngordon22@yahoo.com",
                    SupportRepId = 4
                },
                new Customer
                {
                    CustomerId = 24,
                    FirstName = "Frank",
                    LastName = "Ralston",
                    Company = null,
                    Address = "162 E Superior Street",
                    City = "Chicago",
                    State = "IL",
                    Country = "USA",
                    PostalCode = "60611",
                    Phone = "+1 (312) 332-3232",
                    Fax = null,
                    Email = "fralston@gmail.com",
                    SupportRepId = 3
                },
                new Customer
                {
                    CustomerId = 25,
                    FirstName = "Victor",
                    LastName = "Stevens",
                    Company = null,
                    Address = "319 N. Frances Street",
                    City = "Madison",
                    State = "WI",
                    Country = "USA",
                    PostalCode = "53703",
                    Phone = "+1 (608) 257-0597",
                    Fax = null,
                    Email = "vstevens@yahoo.com",
                    SupportRepId = 5
                },
                new Customer
                {
                    CustomerId = 26,
                    FirstName = "Richard",
                    LastName = "Cunningham",
                    Company = null,
                    Address = "2211 W Berry Street",
                    City = "Fort Worth",
                    State = "TX",
                    Country = "USA",
                    PostalCode = "76110",
                    Phone = "+1 (817) 924-7272",
                    Fax = null,
                    Email = "ricunningham@hotmail.com",
                    SupportRepId = 4
                },
                new Customer
                {
                    CustomerId = 27,
                    FirstName = "Patrick",
                    LastName = "Gray",
                    Company = null,
                    Address = "1033 N Park Ave",
                    City = "Tucson",
                    State = "AZ",
                    Country = "USA",
                    PostalCode = "85719",
                    Phone = "+1 (520) 622-4200",
                    Fax = null,
                    Email = "patrick.gray@aol.com",
                    SupportRepId = 4
                },
                new Customer
                {
                    CustomerId = 28,
                    FirstName = "Julia",
                    LastName = "Barnett",
                    Company = null,
                    Address = "302 S 700 E",
                    City = "Salt Lake City",
                    State = "UT",
                    Country = "USA",
                    PostalCode = "84102",
                    Phone = "+1 (801) 531-7272",
                    Fax = null,
                    Email = "jubarnett@gmail.com",
                    SupportRepId = 5
                },
                new Customer
                {
                    CustomerId = 29,
                    FirstName = "Robert",
                    LastName = "Brown",
                    Company = null,
                    Address = "796 Dundas Street West",
                    City = "Toronto",
                    State = "ON",
                    Country = "Canada",
                    PostalCode = "M6J 1V1",
                    Phone = "+1 (416) 363-8888",
                    Fax = null,
                    Email = "robbrown@shaw.ca",
                    SupportRepId = 3
                },
                new Customer
                {
                    CustomerId = 30,
                    FirstName = "Edward",
                    LastName = "Francis",
                    Company = null,
                    Address = "230 Elgin Street",
                    City = "Ottawa",
                    State = "ON",
                    Country = "Canada",
                    PostalCode = "K2P 1L7",
                    Phone = "+1 (613) 234-3322",
                    Fax = null,
                    Email = "edfrancis@yachoo.ca",
                    SupportRepId = 3
                },
                new Customer
                {
                    CustomerId = 31,
                    FirstName = "Martha",
                    LastName = "Silk",
                    Company = null,
                    Address = "194A Chain Lake Drive",
                    City = "Halifax",
                    State = "NS",
                    Country = "Canada",
                    PostalCode = "B3S 1C5",
                    Phone = "+1 (902) 450-0450",
                    Fax = null,
                    Email = "marthasilk@gmail.com",
                    SupportRepId = 5
                },
                new Customer
                {
                    CustomerId = 32,
                    FirstName = "Aaron",
                    LastName = "Mitchell",
                    Company = null,
                    Address = "696 Osborne Street",
                    City = "Winnipeg",
                    State = "MB",
                    Country = "Canada",
                    PostalCode = "R3L 2B9",
                    Phone = "+1 (204) 452-6452",
                    Fax = null,
                    Email = "aaronmitchell@yahoo.ca",
                    SupportRepId = 4
                },
                new Customer
                {
                    CustomerId = 33,
                    FirstName = "Ellie",
                    LastName = "Sullivan",
                    Company = null,
                    Address = "5112 48 Street",
                    City = "Yellowknife",
                    State = "NT",
                    Country = "Canada",
                    PostalCode = "X1A 1N6",
                    Phone = "+1 (867) 920-2233",
                    Fax = null,
                    Email = "ellie.sullivan@shaw.ca",
                    SupportRepId = 3
                },
                new Customer
                {
                    CustomerId = 34,
                    FirstName = "João",
                    LastName = "Fernandes",
                    Company = null,
                    Address = "Rua da Assunção 53",
                    City = "Lisbon",
                    State = null,
                    Country = "Portugal",
                    PostalCode = null,
                    Phone = "+351 (213) 466-111",
                    Fax = null,
                    Email = "jfernandes@yahoo.pt",
                    SupportRepId = 4
                },
                new Customer
                {
                    CustomerId = 35,
                    FirstName = "Madalena",
                    LastName = "Sampaio",
                    Company = null,
                    Address = "Rua dos Campeões Europeus de Viena, 4350",
                    City = "Porto",
                    State = null,
                    Country = "Portugal",
                    PostalCode = null,
                    Phone = "+351 (225) 022-448",
                    Fax = null,
                    Email = "masampaio@sapo.pt",
                    SupportRepId = 4
                },
                new Customer
                {
                    CustomerId = 36,
                    FirstName = "Hannah",
                    LastName = "Schneider",
                    Company = null,
                    Address = "Tauentzienstraße 8",
                    City = "Berlin",
                    State = null,
                    Country = "Germany",
                    PostalCode = "10789",
                    Phone = "+49 030 26550280",
                    Fax = null,
                    Email = "hannah.schneider@yahoo.de",
                    SupportRepId = 5
                },
                new Customer
                {
                    CustomerId = 37,
                    FirstName = "Fynn",
                    LastName = "Zimmermann",
                    Company = null,
                    Address = "Berger Straße 10",
                    City = "Frankfurt",
                    State = null,
                    Country = "Germany",
                    PostalCode = "60316",
                    Phone = "+49 069 40598889",
                    Fax = null,
                    Email = "fzimmermann@yahoo.de",
                    SupportRepId = 3
                },
                new Customer
                {
                    CustomerId = 38,
                    FirstName = "Niklas",
                    LastName = "Schröder",
                    Company = null,
                    Address = "Barbarossastraße 19",
                    City = "Berlin",
                    State = null,
                    Country = "Germany",
                    PostalCode = "10779",
                    Phone = "+49 030 2141444",
                    Fax = null,
                    Email = "nschroder@surfeu.de",
                    SupportRepId = 3
                },
                new Customer
                {
                    CustomerId = 39,
                    FirstName = "Camille",
                    LastName = "Bernard",
                    Company = null,
                    Address = "4, Rue Milton",
                    City = "Paris",
                    State = null,
                    Country = "France",
                    PostalCode = "75009",
                    Phone = "+33 01 49 70 65 65",
                    Fax = null,
                    Email = "camille.bernard@yahoo.fr",
                    SupportRepId = 4
                },
                new Customer
                {
                    CustomerId = 40,
                    FirstName = "Dominique",
                    LastName = "Lefebvre",
                    Company = null,
                    Address = "8, Rue Hanovre",
                    City = "Paris",
                    State = null,
                    Country = "France",
                    PostalCode = "75002",
                    Phone = "+33 01 47 42 71 71",
                    Fax = null,
                    Email = "dominiquelefebvre@gmail.com",
                    SupportRepId = 4
                },
                new Customer
                {
                    CustomerId = 41,
                    FirstName = "Marc",
                    LastName = "Dubois",
                    Company = null,
                    Address = "11, Place Bellecour",
                    City = "Lyon",
                    State = null,
                    Country = "France",
                    PostalCode = "69002",
                    Phone = "+33 04 78 30 30 30",
                    Fax = null,
                    Email = "marc.dubois@hotmail.com",
                    SupportRepId = 5
                },
                new Customer
                {
                    CustomerId = 42,
                    FirstName = "Wyatt",
                    LastName = "Girard",
                    Company = null,
                    Address = "9, Place Louis Barthou",
                    City = "Bordeaux",
                    State = null,
                    Country = "France",
                    PostalCode = "33000",
                    Phone = "+33 05 56 96 96 96",
                    Fax = null,
                    Email = "wyatt.girard@yahoo.fr",
                    SupportRepId = 3
                },
                new Customer
                {
                    CustomerId = 43,
                    FirstName = "Isabelle",
                    LastName = "Mercier",
                    Company = null,
                    Address = "68, Rue Jouvence",
                    City = "Dijon",
                    State = null,
                    Country = "France",
                    PostalCode = "21000",
                    Phone = "+33 03 80 73 66 99",
                    Fax = null,
                    Email = "isabelle_mercier@apple.fr",
                    SupportRepId = 3
                },
                new Customer
                {
                    CustomerId = 44,
                    FirstName = "Terhi",
                    LastName = "Hämäläinen",
                    Company = null,
                    Address = "Porthaninkatu 9",
                    City = "Helsinki",
                    State = null,
                    Country = "Finland",
                    PostalCode = "00530",
                    Phone = "+358 09 870 2000",
                    Fax = null,
                    Email = "terhi.hamalainen@apple.fi",
                    SupportRepId = 3
                },
                new Customer
                {
                    CustomerId = 45,
                    FirstName = "Ladislav",
                    LastName = "Kovács",
                    Company = null,
                    Address = "Erzsébet krt. 58.",
                    City = "Budapest",
                    State = null,
                    Country = "Hungary",
                    PostalCode = "H-1073",
                    Phone = null,
                    Fax = null,
                    Email = "ladislav_kovacs@apple.hu",
                    SupportRepId = 3
                },
                new Customer
                {
                    CustomerId = 46,
                    FirstName = "Hugh",
                    LastName = "O'Reilly",
                    Company = null,
                    Address = "3 Chatham Street",
                    City = "Dublin",
                    State = "Dublin",
                    Country = "Ireland",
                    PostalCode = null,
                    Phone = "+353 01 6792424",
                    Fax = null,
                    Email = "hughoreilly@apple.ie",
                    SupportRepId = 3
                },
                new Customer
                {
                    CustomerId = 47,
                    FirstName = "Lucas",
                    LastName = "Mancini",
                    Company = null,
                    Address = "Via Degli Scipioni, 43",
                    City = "Rome",
                    State = "RM",
                    Country = "Italy",
                    PostalCode = "00192",
                    Phone = "+39 06 39733434",
                    Fax = null,
                    Email = "lucas.mancini@yahoo.it",
                    SupportRepId = 5
                },
                new Customer
                {
                    CustomerId = 48,
                    FirstName = "Johannes",
                    LastName = "Van der Berg",
                    Company = null,
                    Address = "Lijnbaansgracht 120bg",
                    City = "Amsterdam",
                    State = "VV",
                    Country = "Netherlands",
                    PostalCode = "1016",
                    Phone = "+31 020 6223130",
                    Fax = null,
                    Email = "johavanderberg@yahoo.nl",
                    SupportRepId = 5
                },
                new Customer
                {
                    CustomerId = 49,
                    FirstName = "Stanisław",
                    LastName = "Wójcik",
                    Company = null,
                    Address = "Ordynacka 10",
                    City = "Warsaw",
                    State = null,
                    Country = "Poland",
                    PostalCode = "00-358",
                    Phone = "+48 22 828 37 39",
                    Fax = null,
                    Email = "stanisław.wójcik@wp.pl",
                    SupportRepId = 4
                },
                new Customer
                {
                    CustomerId = 50,
                    FirstName = "Enrique",
                    LastName = "Muñoz",
                    Company = null,
                    Address = "C/ San Bernardo 85",
                    City = "Madrid",
                    State = null,
                    Country = "Spain",
                    PostalCode = "28015",
                    Phone = "+34 914 454 454",
                    Fax = null,
                    Email = "enrique_munoz@yahoo.es",
                    SupportRepId = 5
                },
                new Customer
                {
                    CustomerId = 51,
                    FirstName = "Joakim",
                    LastName = "Johansson",
                    Company = null,
                    Address = "Celsiusg. 9",
                    City = "Stockholm",
                    State = null,
                    Country = "Sweden",
                    PostalCode = "11230",
                    Phone = "+46 08-651 52 52",
                    Fax = null,
                    Email = "joakim.johansson@yahoo.se",
                    SupportRepId = 5
                },
                new Customer
                {
                    CustomerId = 52,
                    FirstName = "Emma",
                    LastName = "Jones",
                    Company = null,
                    Address = "202 Hoxton Street",
                    City = "London",
                    State = null,
                    Country = "United Kingdom",
                    PostalCode = "N1 5LH",
                    Phone = "+44 020 7707 0707",
                    Fax = null,
                    Email = "emma_jones@hotmail.com",
                    SupportRepId = 3
                },
                new Customer
                {
                    CustomerId = 53,
                    FirstName = "Phil",
                    LastName = "Hughes",
                    Company = null,
                    Address = "113 Lupus St",
                    City = "London",
                    State = null,
                    Country = "United Kingdom",
                    PostalCode = "SW1V 3EN",
                    Phone = "+44 020 7976 5722",
                    Fax = null,
                    Email = "phil.hughes@gmail.com",
                    SupportRepId = 3
                },
                new Customer
                {
                    CustomerId = 54,
                    FirstName = "Steve",
                    LastName = "Murray",
                    Company = null,
                    Address = "110 Raeburn Pl",
                    City = "Edinburgh ",
                    State = null,
                    Country = "United Kingdom",
                    PostalCode = "EH4 1HH",
                    Phone = "+44 0131 315 3300",
                    Fax = null,
                    Email = "steve.murray@yahoo.uk",
                    SupportRepId = 5
                },
                new Customer
                {
                    CustomerId = 55,
                    FirstName = "Mark",
                    LastName = "Taylor",
                    Company = null,
                    Address = "421 Bourke Street",
                    City = "Sidney",
                    State = "NSW",
                    Country = "Australia",
                    PostalCode = "2010",
                    Phone = "+61 (02) 9332 3633",
                    Fax = null,
                    Email = "mark.taylor@yahoo.au",
                    SupportRepId = 4
                },
                new Customer
                {
                    CustomerId = 56,
                    FirstName = "Diego",
                    LastName = "Gutiérrez",
                    Company = null,
                    Address = "307 Macacha Güemes",
                    City = "Buenos Aires",
                    State = null,
                    Country = "Argentina",
                    PostalCode = "1106",
                    Phone = "+54 (0)11 4311 4333",
                    Fax = null,
                    Email = "diego.gutierrez@yahoo.ar",
                    SupportRepId = 4
                },
                new Customer
                {
                    CustomerId = 57,
                    FirstName = "Luis",
                    LastName = "Rojas",
                    Company = null,
                    Address = "Calle Lira, 198",
                    City = "Santiago",
                    State = null,
                    Country = "Chile",
                    PostalCode = null,
                    Phone = "+56 (0)2 635 4444",
                    Fax = null,
                    Email = "luisrojas@yahoo.cl",
                    SupportRepId = 5
                },
                new Customer
                {
                    CustomerId = 58,
                    FirstName = "Manoj",
                    LastName = "Pareek",
                    Company = null,
                    Address = "12,Community Centre",
                    City = "Delhi",
                    State = null,
                    Country = "India",
                    PostalCode = "110017",
                    Phone = "+91 0124 39883988",
                    Fax = null,
                    Email = "manoj.pareek@rediff.com",
                    SupportRepId = 3
                },
                new Customer
                {
                    CustomerId = 59,
                    FirstName = "Puja",
                    LastName = "Srivastava",
                    Company = null,
                    Address = "3,Raj Bhavan Road",
                    City = "Bangalore",
                    State = null,
                    Country = "India",
                    PostalCode = "560001",
                    Phone = "+91 080 22289999",
                    Fax = null,
                    Email = "puja_srivastava@yahoo.in",
                    SupportRepId = 3
                }
            );
        }
    }
}