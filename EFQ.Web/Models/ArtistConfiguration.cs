using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#nullable disable

namespace JDege.EFQ.Web.Models
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artist");

            builder.Property(e => e.Name).HasMaxLength(120);

            seedData(builder);
        }

        private void seedData(EntityTypeBuilder<Artist> builder)
        {
            builder.HasData(
                new Artist
                {
                    ArtistId = 1,
                    Name = "AC/DC"
                },
                new Artist
                {
                    ArtistId = 2,
                    Name = "Accept"
                },
                new Artist
                {
                    ArtistId = 3,
                    Name = "Aerosmith"
                },
                new Artist
                {
                    ArtistId = 4,
                    Name = "Alanis Morissette"
                },
                new Artist
                {
                    ArtistId = 5,
                    Name = "Alice In Chains"
                },
                new Artist
                {
                    ArtistId = 6,
                    Name = "Antônio Carlos Jobim"
                },
                new Artist
                {
                    ArtistId = 7,
                    Name = "Apocalyptica"
                },
                new Artist
                {
                    ArtistId = 8,
                    Name = "Audioslave"
                },
                new Artist
                {
                    ArtistId = 9,
                    Name = "BackBeat"
                },
                new Artist
                {
                    ArtistId = 10,
                    Name = "Billy Cobham"
                },
                new Artist
                {
                    ArtistId = 11,
                    Name = "Black Label Society"
                },
                new Artist
                {
                    ArtistId = 12,
                    Name = "Black Sabbath"
                },
                new Artist
                {
                    ArtistId = 13,
                    Name = "Body Count"
                },
                new Artist
                {
                    ArtistId = 14,
                    Name = "Bruce Dickinson"
                },
                new Artist
                {
                    ArtistId = 15,
                    Name = "Buddy Guy"
                },
                new Artist
                {
                    ArtistId = 16,
                    Name = "Caetano Veloso"
                },
                new Artist
                {
                    ArtistId = 17,
                    Name = "Chico Buarque"
                },
                new Artist
                {
                    ArtistId = 18,
                    Name = "Chico Science & Nação Zumbi"
                },
                new Artist
                {
                    ArtistId = 19,
                    Name = "Cidade Negra"
                },
                new Artist
                {
                    ArtistId = 20,
                    Name = "Cláudio Zoli"
                },
                new Artist
                {
                    ArtistId = 21,
                    Name = "Various Artists"
                },
                new Artist
                {
                    ArtistId = 22,
                    Name = "Led Zeppelin"
                },
                new Artist
                {
                    ArtistId = 23,
                    Name = "Frank Zappa & Captain Beefheart"
                },
                new Artist
                {
                    ArtistId = 24,
                    Name = "Marcos Valle"
                },
                new Artist
                {
                    ArtistId = 25,
                    Name = "Milton Nascimento & Bebeto"
                },
                new Artist
                {
                    ArtistId = 26,
                    Name = "Azymuth"
                },
                new Artist
                {
                    ArtistId = 27,
                    Name = "Gilberto Gil"
                },
                new Artist
                {
                    ArtistId = 28,
                    Name = "João Gilberto"
                },
                new Artist
                {
                    ArtistId = 29,
                    Name = "Bebel Gilberto"
                },
                new Artist
                {
                    ArtistId = 30,
                    Name = "Jorge Vercilo"
                },
                new Artist
                {
                    ArtistId = 31,
                    Name = "Baby Consuelo"
                },
                new Artist
                {
                    ArtistId = 32,
                    Name = "Ney Matogrosso"
                },
                new Artist
                {
                    ArtistId = 33,
                    Name = "Luiz Melodia"
                },
                new Artist
                {
                    ArtistId = 34,
                    Name = "Nando Reis"
                },
                new Artist
                {
                    ArtistId = 35,
                    Name = "Pedro Luís & A Parede"
                },
                new Artist
                {
                    ArtistId = 36,
                    Name = "O Rappa"
                },
                new Artist
                {
                    ArtistId = 37,
                    Name = "Ed Motta"
                },
                new Artist
                {
                    ArtistId = 38,
                    Name = "Banda Black Rio"
                },
                new Artist
                {
                    ArtistId = 39,
                    Name = "Fernanda Porto"
                },
                new Artist
                {
                    ArtistId = 40,
                    Name = "Os Cariocas"
                },
                new Artist
                {
                    ArtistId = 41,
                    Name = "Elis Regina"
                },
                new Artist
                {
                    ArtistId = 42,
                    Name = "Milton Nascimento"
                },
                new Artist
                {
                    ArtistId = 43,
                    Name = "A Cor Do Som"
                },
                new Artist
                {
                    ArtistId = 44,
                    Name = "Kid Abelha"
                },
                new Artist
                {
                    ArtistId = 45,
                    Name = "Sandra De Sá"
                },
                new Artist
                {
                    ArtistId = 46,
                    Name = "Jorge Ben"
                },
                new Artist
                {
                    ArtistId = 47,
                    Name = "Hermeto Pascoal"
                },
                new Artist
                {
                    ArtistId = 48,
                    Name = "Barão Vermelho"
                },
                new Artist
                {
                    ArtistId = 49,
                    Name = "Edson, DJ Marky & DJ Patife Featuring Fernanda Porto"
                },
                new Artist
                {
                    ArtistId = 50,
                    Name = "Metallica"
                },
                new Artist
                {
                    ArtistId = 51,
                    Name = "Queen"
                },
                new Artist
                {
                    ArtistId = 52,
                    Name = "Kiss"
                },
                new Artist
                {
                    ArtistId = 53,
                    Name = "Spyro Gyra"
                },
                new Artist
                {
                    ArtistId = 54,
                    Name = "Green Day"
                },
                new Artist
                {
                    ArtistId = 55,
                    Name = "David Coverdale"
                },
                new Artist
                {
                    ArtistId = 56,
                    Name = "Gonzaguinha"
                },
                new Artist
                {
                    ArtistId = 57,
                    Name = "Os Mutantes"
                },
                new Artist
                {
                    ArtistId = 58,
                    Name = "Deep Purple"
                },
                new Artist
                {
                    ArtistId = 59,
                    Name = "Santana"
                },
                new Artist
                {
                    ArtistId = 60,
                    Name = "Santana Feat. Dave Matthews"
                },
                new Artist
                {
                    ArtistId = 61,
                    Name = "Santana Feat. Everlast"
                },
                new Artist
                {
                    ArtistId = 62,
                    Name = "Santana Feat. Rob Thomas"
                },
                new Artist
                {
                    ArtistId = 63,
                    Name = "Santana Feat. Lauryn Hill & Cee-Lo"
                },
                new Artist
                {
                    ArtistId = 64,
                    Name = "Santana Feat. The Project G&B"
                },
                new Artist
                {
                    ArtistId = 65,
                    Name = "Santana Feat. Maná"
                },
                new Artist
                {
                    ArtistId = 66,
                    Name = "Santana Feat. Eagle-Eye Cherry"
                },
                new Artist
                {
                    ArtistId = 67,
                    Name = "Santana Feat. Eric Clapton"
                },
                new Artist
                {
                    ArtistId = 68,
                    Name = "Miles Davis"
                },
                new Artist
                {
                    ArtistId = 69,
                    Name = "Gene Krupa"
                },
                new Artist
                {
                    ArtistId = 70,
                    Name = "Toquinho & Vinícius"
                },
                new Artist
                {
                    ArtistId = 71,
                    Name = "Vinícius De Moraes & Baden Powell"
                },
                new Artist
                {
                    ArtistId = 72,
                    Name = "Vinícius De Moraes"
                },
                new Artist
                {
                    ArtistId = 73,
                    Name = "Vinícius E Qurteto Em Cy"
                },
                new Artist
                {
                    ArtistId = 74,
                    Name = "Vinícius E Odette Lara"
                },
                new Artist
                {
                    ArtistId = 75,
                    Name = "Vinicius, Toquinho & Quarteto Em Cy"
                },
                new Artist
                {
                    ArtistId = 76,
                    Name = "Creedence Clearwater Revival"
                },
                new Artist
                {
                    ArtistId = 77,
                    Name = "Cássia Eller"
                },
                new Artist
                {
                    ArtistId = 78,
                    Name = "Def Leppard"
                },
                new Artist
                {
                    ArtistId = 79,
                    Name = "Dennis Chambers"
                },
                new Artist
                {
                    ArtistId = 80,
                    Name = "Djavan"
                },
                new Artist
                {
                    ArtistId = 81,
                    Name = "Eric Clapton"
                },
                new Artist
                {
                    ArtistId = 82,
                    Name = "Faith No More"
                },
                new Artist
                {
                    ArtistId = 83,
                    Name = "Falamansa"
                },
                new Artist
                {
                    ArtistId = 84,
                    Name = "Foo Fighters"
                },
                new Artist
                {
                    ArtistId = 85,
                    Name = "Frank Sinatra"
                },
                new Artist
                {
                    ArtistId = 86,
                    Name = "Funk Como Le Gusta"
                },
                new Artist
                {
                    ArtistId = 87,
                    Name = "Godsmack"
                },
                new Artist
                {
                    ArtistId = 88,
                    Name = "Guns N' Roses"
                },
                new Artist
                {
                    ArtistId = 89,
                    Name = "Incognito"
                },
                new Artist
                {
                    ArtistId = 90,
                    Name = "Iron Maiden"
                },
                new Artist
                {
                    ArtistId = 91,
                    Name = "James Brown"
                },
                new Artist
                {
                    ArtistId = 92,
                    Name = "Jamiroquai"
                },
                new Artist
                {
                    ArtistId = 93,
                    Name = "JET"
                },
                new Artist
                {
                    ArtistId = 94,
                    Name = "Jimi Hendrix"
                },
                new Artist
                {
                    ArtistId = 95,
                    Name = "Joe Satriani"
                },
                new Artist
                {
                    ArtistId = 96,
                    Name = "Jota Quest"
                },
                new Artist
                {
                    ArtistId = 97,
                    Name = "João Suplicy"
                },
                new Artist
                {
                    ArtistId = 98,
                    Name = "Judas Priest"
                },
                new Artist
                {
                    ArtistId = 99,
                    Name = "Legião Urbana"
                },
                new Artist
                {
                    ArtistId = 100,
                    Name = "Lenny Kravitz"
                },
                new Artist
                {
                    ArtistId = 101,
                    Name = "Lulu Santos"
                },
                new Artist
                {
                    ArtistId = 102,
                    Name = "Marillion"
                },
                new Artist
                {
                    ArtistId = 103,
                    Name = "Marisa Monte"
                },
                new Artist
                {
                    ArtistId = 104,
                    Name = "Marvin Gaye"
                },
                new Artist
                {
                    ArtistId = 105,
                    Name = "Men At Work"
                },
                new Artist
                {
                    ArtistId = 106,
                    Name = "Motörhead"
                },
                new Artist
                {
                    ArtistId = 107,
                    Name = "Motörhead & Girlschool"
                },
                new Artist
                {
                    ArtistId = 108,
                    Name = "Mônica Marianno"
                },
                new Artist
                {
                    ArtistId = 109,
                    Name = "Mötley Crüe"
                },
                new Artist
                {
                    ArtistId = 110,
                    Name = "Nirvana"
                },
                new Artist
                {
                    ArtistId = 111,
                    Name = "O Terço"
                },
                new Artist
                {
                    ArtistId = 112,
                    Name = "Olodum"
                },
                new Artist
                {
                    ArtistId = 113,
                    Name = "Os Paralamas Do Sucesso"
                },
                new Artist
                {
                    ArtistId = 114,
                    Name = "Ozzy Osbourne"
                },
                new Artist
                {
                    ArtistId = 115,
                    Name = "Page & Plant"
                },
                new Artist
                {
                    ArtistId = 116,
                    Name = "Passengers"
                },
                new Artist
                {
                    ArtistId = 117,
                    Name = "Paul D'Ianno"
                },
                new Artist
                {
                    ArtistId = 118,
                    Name = "Pearl Jam"
                },
                new Artist
                {
                    ArtistId = 119,
                    Name = "Peter Tosh"
                },
                new Artist
                {
                    ArtistId = 120,
                    Name = "Pink Floyd"
                },
                new Artist
                {
                    ArtistId = 121,
                    Name = "Planet Hemp"
                },
                new Artist
                {
                    ArtistId = 122,
                    Name = "R.E.M. Feat. Kate Pearson"
                },
                new Artist
                {
                    ArtistId = 123,
                    Name = "R.E.M. Feat. KRS-One"
                },
                new Artist
                {
                    ArtistId = 124,
                    Name = "R.E.M."
                },
                new Artist
                {
                    ArtistId = 125,
                    Name = "Raimundos"
                },
                new Artist
                {
                    ArtistId = 126,
                    Name = "Raul Seixas"
                },
                new Artist
                {
                    ArtistId = 127,
                    Name = "Red Hot Chili Peppers"
                },
                new Artist
                {
                    ArtistId = 128,
                    Name = "Rush"
                },
                new Artist
                {
                    ArtistId = 129,
                    Name = "Simply Red"
                },
                new Artist
                {
                    ArtistId = 130,
                    Name = "Skank"
                },
                new Artist
                {
                    ArtistId = 131,
                    Name = "Smashing Pumpkins"
                },
                new Artist
                {
                    ArtistId = 132,
                    Name = "Soundgarden"
                },
                new Artist
                {
                    ArtistId = 133,
                    Name = "Stevie Ray Vaughan & Double Trouble"
                },
                new Artist
                {
                    ArtistId = 134,
                    Name = "Stone Temple Pilots"
                },
                new Artist
                {
                    ArtistId = 135,
                    Name = "System Of A Down"
                },
                new Artist
                {
                    ArtistId = 136,
                    Name = "Terry Bozzio, Tony Levin & Steve Stevens"
                },
                new Artist
                {
                    ArtistId = 137,
                    Name = "The Black Crowes"
                },
                new Artist
                {
                    ArtistId = 138,
                    Name = "The Clash"
                },
                new Artist
                {
                    ArtistId = 139,
                    Name = "The Cult"
                },
                new Artist
                {
                    ArtistId = 140,
                    Name = "The Doors"
                },
                new Artist
                {
                    ArtistId = 141,
                    Name = "The Police"
                },
                new Artist
                {
                    ArtistId = 142,
                    Name = "The Rolling Stones"
                },
                new Artist
                {
                    ArtistId = 143,
                    Name = "The Tea Party"
                },
                new Artist
                {
                    ArtistId = 144,
                    Name = "The Who"
                },
                new Artist
                {
                    ArtistId = 145,
                    Name = "Tim Maia"
                },
                new Artist
                {
                    ArtistId = 146,
                    Name = "Titãs"
                },
                new Artist
                {
                    ArtistId = 147,
                    Name = "Battlestar Galactica"
                },
                new Artist
                {
                    ArtistId = 148,
                    Name = "Heroes"
                },
                new Artist
                {
                    ArtistId = 149,
                    Name = "Lost"
                },
                new Artist
                {
                    ArtistId = 150,
                    Name = "U2"
                },
                new Artist
                {
                    ArtistId = 151,
                    Name = "UB40"
                },
                new Artist
                {
                    ArtistId = 152,
                    Name = "Van Halen"
                },
                new Artist
                {
                    ArtistId = 153,
                    Name = "Velvet Revolver"
                },
                new Artist
                {
                    ArtistId = 154,
                    Name = "Whitesnake"
                },
                new Artist
                {
                    ArtistId = 155,
                    Name = "Zeca Pagodinho"
                },
                new Artist
                {
                    ArtistId = 156,
                    Name = "The Office"
                },
                new Artist
                {
                    ArtistId = 157,
                    Name = "Dread Zeppelin"
                },
                new Artist
                {
                    ArtistId = 158,
                    Name = "Battlestar Galactica (Classic)"
                },
                new Artist
                {
                    ArtistId = 159,
                    Name = "Aquaman"
                },
                new Artist
                {
                    ArtistId = 160,
                    Name = "Christina Aguilera featuring BigElf"
                },
                new Artist
                {
                    ArtistId = 161,
                    Name = "Aerosmith & Sierra Leone's Refugee Allstars"
                },
                new Artist
                {
                    ArtistId = 162,
                    Name = "Los Lonely Boys"
                },
                new Artist
                {
                    ArtistId = 163,
                    Name = "Corinne Bailey Rae"
                },
                new Artist
                {
                    ArtistId = 164,
                    Name = "Dhani Harrison & Jakob Dylan"
                },
                new Artist
                {
                    ArtistId = 165,
                    Name = "Jackson Browne"
                },
                new Artist
                {
                    ArtistId = 166,
                    Name = "Avril Lavigne"
                },
                new Artist
                {
                    ArtistId = 167,
                    Name = "Big & Rich"
                },
                new Artist
                {
                    ArtistId = 168,
                    Name = "Youssou N'Dour"
                },
                new Artist
                {
                    ArtistId = 169,
                    Name = "Black Eyed Peas"
                },
                new Artist
                {
                    ArtistId = 170,
                    Name = "Jack Johnson"
                },
                new Artist
                {
                    ArtistId = 171,
                    Name = "Ben Harper"
                },
                new Artist
                {
                    ArtistId = 172,
                    Name = "Snow Patrol"
                },
                new Artist
                {
                    ArtistId = 173,
                    Name = "Matisyahu"
                },
                new Artist
                {
                    ArtistId = 174,
                    Name = "The Postal Service"
                },
                new Artist
                {
                    ArtistId = 175,
                    Name = "Jaguares"
                },
                new Artist
                {
                    ArtistId = 176,
                    Name = "The Flaming Lips"
                },
                new Artist
                {
                    ArtistId = 177,
                    Name = "Jack's Mannequin & Mick Fleetwood"
                },
                new Artist
                {
                    ArtistId = 178,
                    Name = "Regina Spektor"
                },
                new Artist
                {
                    ArtistId = 179,
                    Name = "Scorpions"
                },
                new Artist
                {
                    ArtistId = 180,
                    Name = "House Of Pain"
                },
                new Artist
                {
                    ArtistId = 181,
                    Name = "Xis"
                },
                new Artist
                {
                    ArtistId = 182,
                    Name = "Nega Gizza"
                },
                new Artist
                {
                    ArtistId = 183,
                    Name = "Gustavo & Andres Veiga & Salazar"
                },
                new Artist
                {
                    ArtistId = 184,
                    Name = "Rodox"
                },
                new Artist
                {
                    ArtistId = 185,
                    Name = "Charlie Brown Jr."
                },
                new Artist
                {
                    ArtistId = 186,
                    Name = "Pedro Luís E A Parede"
                },
                new Artist
                {
                    ArtistId = 187,
                    Name = "Los Hermanos"
                },
                new Artist
                {
                    ArtistId = 188,
                    Name = "Mundo Livre S/A"
                },
                new Artist
                {
                    ArtistId = 189,
                    Name = "Otto"
                },
                new Artist
                {
                    ArtistId = 190,
                    Name = "Instituto"
                },
                new Artist
                {
                    ArtistId = 191,
                    Name = "Nação Zumbi"
                },
                new Artist
                {
                    ArtistId = 192,
                    Name = "DJ Dolores & Orchestra Santa Massa"
                },
                new Artist
                {
                    ArtistId = 193,
                    Name = "Seu Jorge"
                },
                new Artist
                {
                    ArtistId = 194,
                    Name = "Sabotage E Instituto"
                },
                new Artist
                {
                    ArtistId = 195,
                    Name = "Stereo Maracana"
                },
                new Artist
                {
                    ArtistId = 196,
                    Name = "Cake"
                },
                new Artist
                {
                    ArtistId = 197,
                    Name = "Aisha Duo"
                },
                new Artist
                {
                    ArtistId = 198,
                    Name = "Habib Koité and Bamada"
                },
                new Artist
                {
                    ArtistId = 199,
                    Name = "Karsh Kale"
                },
                new Artist
                {
                    ArtistId = 200,
                    Name = "The Posies"
                },
                new Artist
                {
                    ArtistId = 201,
                    Name = "Luciana Souza/Romero Lubambo"
                },
                new Artist
                {
                    ArtistId = 202,
                    Name = "Aaron Goldberg"
                },
                new Artist
                {
                    ArtistId = 203,
                    Name = "Nicolaus Esterhazy Sinfonia"
                },
                new Artist
                {
                    ArtistId = 204,
                    Name = "Temple of the Dog"
                },
                new Artist
                {
                    ArtistId = 205,
                    Name = "Chris Cornell"
                },
                new Artist
                {
                    ArtistId = 206,
                    Name = "Alberto Turco & Nova Schola Gregoriana"
                },
                new Artist
                {
                    ArtistId = 207,
                    Name = "Richard Marlow & The Choir of Trinity College, Cambridge"
                },
                new Artist
                {
                    ArtistId = 208,
                    Name = "English Concert & Trevor Pinnock"
                },
                new Artist
                {
                    ArtistId = 209,
                    Name = "Anne-Sophie Mutter, Herbert Von Karajan & Wiener Philharmoniker"
                },
                new Artist
                {
                    ArtistId = 210,
                    Name = "Hilary Hahn, Jeffrey Kahane, Los Angeles Chamber Orchestra & Margaret Batjer"
                },
                new Artist
                {
                    ArtistId = 211,
                    Name = "Wilhelm Kempff"
                },
                new Artist
                {
                    ArtistId = 212,
                    Name = "Yo-Yo Ma"
                },
                new Artist
                {
                    ArtistId = 213,
                    Name = "Scholars Baroque Ensemble"
                },
                new Artist
                {
                    ArtistId = 214,
                    Name = "Academy of St. Martin in the Fields & Sir Neville Marriner"
                },
                new Artist
                {
                    ArtistId = 215,
                    Name = "Academy of St. Martin in the Fields Chamber Ensemble & Sir Neville Marriner"
                },
                new Artist
                {
                    ArtistId = 216,
                    Name = "Berliner Philharmoniker, Claudio Abbado & Sabine Meyer"
                },
                new Artist
                {
                    ArtistId = 217,
                    Name = "Royal Philharmonic Orchestra & Sir Thomas Beecham"
                },
                new Artist
                {
                    ArtistId = 218,
                    Name = "Orchestre Révolutionnaire et Romantique & John Eliot Gardiner"
                },
                new Artist
                {
                    ArtistId = 219,
                    Name = "Britten Sinfonia, Ivor Bolton & Lesley Garrett"
                },
                new Artist
                {
                    ArtistId = 220,
                    Name = "Chicago Symphony Chorus, Chicago Symphony Orchestra & Sir Georg Solti"
                },
                new Artist
                {
                    ArtistId = 221,
                    Name = "Sir Georg Solti & Wiener Philharmoniker"
                },
                new Artist
                {
                    ArtistId = 222,
                    Name = "Academy of St. Martin in the Fields, John Birch, Sir Neville Marriner & Sylvia McNair"
                },
                new Artist
                {
                    ArtistId = 223,
                    Name = "London Symphony Orchestra & Sir Charles Mackerras"
                },
                new Artist
                {
                    ArtistId = 224,
                    Name = "Barry Wordsworth & BBC Concert Orchestra"
                },
                new Artist
                {
                    ArtistId = 225,
                    Name = "Herbert Von Karajan, Mirella Freni & Wiener Philharmoniker"
                },
                new Artist
                {
                    ArtistId = 226,
                    Name = "Eugene Ormandy"
                },
                new Artist
                {
                    ArtistId = 227,
                    Name = "Luciano Pavarotti"
                },
                new Artist
                {
                    ArtistId = 228,
                    Name = "Leonard Bernstein & New York Philharmonic"
                },
                new Artist
                {
                    ArtistId = 229,
                    Name = "Boston Symphony Orchestra & Seiji Ozawa"
                },
                new Artist
                {
                    ArtistId = 230,
                    Name = "Aaron Copland & London Symphony Orchestra"
                },
                new Artist
                {
                    ArtistId = 231,
                    Name = "Ton Koopman"
                },
                new Artist
                {
                    ArtistId = 232,
                    Name = "Sergei Prokofiev & Yuri Temirkanov"
                },
                new Artist
                {
                    ArtistId = 233,
                    Name = "Chicago Symphony Orchestra & Fritz Reiner"
                },
                new Artist
                {
                    ArtistId = 234,
                    Name = "Orchestra of The Age of Enlightenment"
                },
                new Artist
                {
                    ArtistId = 235,
                    Name = "Emanuel Ax, Eugene Ormandy & Philadelphia Orchestra"
                },
                new Artist
                {
                    ArtistId = 236,
                    Name = "James Levine"
                },
                new Artist
                {
                    ArtistId = 237,
                    Name = "Berliner Philharmoniker & Hans Rosbaud"
                },
                new Artist
                {
                    ArtistId = 238,
                    Name = "Maurizio Pollini"
                },
                new Artist
                {
                    ArtistId = 239,
                    Name = "Academy of St. Martin in the Fields, Sir Neville Marriner & William Bennett"
                },
                new Artist
                {
                    ArtistId = 240,
                    Name = "Gustav Mahler"
                },
                new Artist
                {
                    ArtistId = 241,
                    Name = "Felix Schmidt, London Symphony Orchestra & Rafael Frühbeck de Burgos"
                },
                new Artist
                {
                    ArtistId = 242,
                    Name = "Edo de Waart & San Francisco Symphony"
                },
                new Artist
                {
                    ArtistId = 243,
                    Name = "Antal Doráti & London Symphony Orchestra"
                },
                new Artist
                {
                    ArtistId = 244,
                    Name = "Choir Of Westminster Abbey & Simon Preston"
                },
                new Artist
                {
                    ArtistId = 245,
                    Name = "Michael Tilson Thomas & San Francisco Symphony"
                },
                new Artist
                {
                    ArtistId = 246,
                    Name = "Chor der Wiener Staatsoper, Herbert Von Karajan & Wiener Philharmoniker"
                },
                new Artist
                {
                    ArtistId = 247,
                    Name = "The King's Singers"
                },
                new Artist
                {
                    ArtistId = 248,
                    Name = "Berliner Philharmoniker & Herbert Von Karajan"
                },
                new Artist
                {
                    ArtistId = 249,
                    Name = "Sir Georg Solti, Sumi Jo & Wiener Philharmoniker"
                },
                new Artist
                {
                    ArtistId = 250,
                    Name = "Christopher O'Riley"
                },
                new Artist
                {
                    ArtistId = 251,
                    Name = "Fretwork"
                },
                new Artist
                {
                    ArtistId = 252,
                    Name = "Amy Winehouse"
                },
                new Artist
                {
                    ArtistId = 253,
                    Name = "Calexico"
                },
                new Artist
                {
                    ArtistId = 254,
                    Name = "Otto Klemperer & Philharmonia Orchestra"
                },
                new Artist
                {
                    ArtistId = 255,
                    Name = "Yehudi Menuhin"
                },
                new Artist
                {
                    ArtistId = 256,
                    Name = "Philharmonia Orchestra & Sir Neville Marriner"
                },
                new Artist
                {
                    ArtistId = 257,
                    Name = "Academy of St. Martin in the Fields, Sir Neville Marriner & Thurston Dart"
                },
                new Artist
                {
                    ArtistId = 258,
                    Name = "Les Arts Florissants & William Christie"
                },
                new Artist
                {
                    ArtistId = 259,
                    Name = "The 12 Cellists of The Berlin Philharmonic"
                },
                new Artist
                {
                    ArtistId = 260,
                    Name = "Adrian Leaper & Doreen de Feis"
                },
                new Artist
                {
                    ArtistId = 261,
                    Name = "Roger Norrington, London Classical Players"
                },
                new Artist
                {
                    ArtistId = 262,
                    Name = "Charles Dutoit & L'Orchestre Symphonique de Montréal"
                },
                new Artist
                {
                    ArtistId = 263,
                    Name = "Equale Brass Ensemble, John Eliot Gardiner & Munich Monteverdi Orchestra and Choir"
                },
                new Artist
                {
                    ArtistId = 264,
                    Name = "Kent Nagano and Orchestre de l'Opéra de Lyon"
                },
                new Artist
                {
                    ArtistId = 265,
                    Name = "Julian Bream"
                },
                new Artist
                {
                    ArtistId = 266,
                    Name = "Martin Roscoe"
                },
                new Artist
                {
                    ArtistId = 267,
                    Name = "Göteborgs Symfoniker & Neeme Järvi"
                },
                new Artist
                {
                    ArtistId = 268,
                    Name = "Itzhak Perlman"
                },
                new Artist
                {
                    ArtistId = 269,
                    Name = "Michele Campanella"
                },
                new Artist
                {
                    ArtistId = 270,
                    Name = "Gerald Moore"
                },
                new Artist
                {
                    ArtistId = 271,
                    Name = "Mela Tenenbaum, Pro Musica Prague & Richard Kapp"
                },
                new Artist
                {
                    ArtistId = 272,
                    Name = "Emerson String Quartet"
                },
                new Artist
                {
                    ArtistId = 273,
                    Name = "C. Monteverdi, Nigel Rogers - Chiaroscuro; London Baroque; London Cornett & Sackbu"
                },
                new Artist
                {
                    ArtistId = 274,
                    Name = "Nash Ensemble"
                },
                new Artist
                {
                    ArtistId = 275,
                    Name = "Philip Glass Ensemble"
                }
            );
        }
    }
}
