using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#nullable disable

namespace JDege.EFQ.Web.Models
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Album");

            builder.HasIndex(e => e.ArtistId, "IFK_AlbumArtistId");

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(160);

            builder.HasOne(d => d.Artist)
                .WithMany(p => p.Albums)
                .HasForeignKey(d => d.ArtistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AlbumArtistId");

            seedData(builder);
        }

        private void seedData(EntityTypeBuilder<Album> builder)
        {
            builder.HasData(
                new Album
                {
                    AlbumId = 1,
                    Title = "For Those About To Rock We Salute You",
                    ArtistId = 1
                },
                new Album
                {
                    AlbumId = 2,
                    Title = "Balls to the Wall",
                    ArtistId = 2
                },
                new Album
                {
                    AlbumId = 3,
                    Title = "Restless and Wild",
                    ArtistId = 2
                },
                new Album
                {
                    AlbumId = 4,
                    Title = "Let There Be Rock",
                    ArtistId = 1
                },
                new Album
                {
                    AlbumId = 5,
                    Title = "Big Ones",
                    ArtistId = 3
                },
                new Album
                {
                    AlbumId = 6,
                    Title = "Jagged Little Pill",
                    ArtistId = 4
                },
                new Album
                {
                    AlbumId = 7,
                    Title = "Facelift",
                    ArtistId = 5
                },
                new Album
                {
                    AlbumId = 8,
                    Title = "Warner 25 Anos",
                    ArtistId = 6
                },
                new Album
                {
                    AlbumId = 9,
                    Title = "Plays Metallica By Four Cellos",
                    ArtistId = 7
                },
                new Album
                {
                    AlbumId = 10,
                    Title = "Audioslave",
                    ArtistId = 8
                },
                new Album
                {
                    AlbumId = 11,
                    Title = "Out Of Exile",
                    ArtistId = 8
                },
                new Album
                {
                    AlbumId = 12,
                    Title = "BackBeat Soundtrack",
                    ArtistId = 9
                },
                new Album
                {
                    AlbumId = 13,
                    Title = "The Best Of Billy Cobham",
                    ArtistId = 10
                },
                new Album
                {
                    AlbumId = 14,
                    Title = "Alcohol Fueled Brewtality Live! [Disc 1]",
                    ArtistId = 11
                },
                new Album
                {
                    AlbumId = 15,
                    Title = "Alcohol Fueled Brewtality Live! [Disc 2]",
                    ArtistId = 11
                },
                new Album
                {
                    AlbumId = 16,
                    Title = "Black Sabbath",
                    ArtistId = 12
                },
                new Album
                {
                    AlbumId = 17,
                    Title = "Black Sabbath Vol. 4 (Remaster)",
                    ArtistId = 12
                },
                new Album
                {
                    AlbumId = 18,
                    Title = "Body Count",
                    ArtistId = 13
                },
                new Album
                {
                    AlbumId = 19,
                    Title = "Chemical Wedding",
                    ArtistId = 14
                },
                new Album
                {
                    AlbumId = 20,
                    Title = "The Best Of Buddy Guy - The Millenium Collection",
                    ArtistId = 15
                },
                new Album
                {
                    AlbumId = 21,
                    Title = "Prenda Minha",
                    ArtistId = 16
                },
                new Album
                {
                    AlbumId = 22,
                    Title = "Sozinho Remix Ao Vivo",
                    ArtistId = 16
                },
                new Album
                {
                    AlbumId = 23,
                    Title = "Minha Historia",
                    ArtistId = 17
                },
                new Album
                {
                    AlbumId = 24,
                    Title = "Afrociberdelia",
                    ArtistId = 18
                },
                new Album
                {
                    AlbumId = 25,
                    Title = "Da Lama Ao Caos",
                    ArtistId = 18
                },
                new Album
                {
                    AlbumId = 26,
                    Title = "Acústico MTV [Live]",
                    ArtistId = 19
                },
                new Album
                {
                    AlbumId = 27,
                    Title = "Cidade Negra - Hits",
                    ArtistId = 19
                },
                new Album
                {
                    AlbumId = 28,
                    Title = "Na Pista",
                    ArtistId = 20
                },
                new Album
                {
                    AlbumId = 29,
                    Title = "Axé Bahia 2001",
                    ArtistId = 21
                },
                new Album
                {
                    AlbumId = 30,
                    Title = "BBC Sessions [Disc 1] [Live]",
                    ArtistId = 22
                },
                new Album
                {
                    AlbumId = 31,
                    Title = "Bongo Fury",
                    ArtistId = 23
                },
                new Album
                {
                    AlbumId = 32,
                    Title = "Carnaval 2001",
                    ArtistId = 21
                },
                new Album
                {
                    AlbumId = 33,
                    Title = "Chill: Brazil (Disc 1)",
                    ArtistId = 24
                },
                new Album
                {
                    AlbumId = 34,
                    Title = "Chill: Brazil (Disc 2)",
                    ArtistId = 6
                },
                new Album
                {
                    AlbumId = 35,
                    Title = "Garage Inc. (Disc 1)",
                    ArtistId = 50
                },
                new Album
                {
                    AlbumId = 36,
                    Title = "Greatest Hits II",
                    ArtistId = 51
                },
                new Album
                {
                    AlbumId = 37,
                    Title = "Greatest Kiss",
                    ArtistId = 52
                },
                new Album
                {
                    AlbumId = 38,
                    Title = "Heart of the Night",
                    ArtistId = 53
                },
                new Album
                {
                    AlbumId = 39,
                    Title = "International Superhits",
                    ArtistId = 54
                },
                new Album
                {
                    AlbumId = 40,
                    Title = "Into The Light",
                    ArtistId = 55
                },
                new Album
                {
                    AlbumId = 41,
                    Title = "Meus Momentos",
                    ArtistId = 56
                },
                new Album
                {
                    AlbumId = 42,
                    Title = "Minha História",
                    ArtistId = 57
                },
                new Album
                {
                    AlbumId = 43,
                    Title = "MK III The Final Concerts [Disc 1]",
                    ArtistId = 58
                },
                new Album
                {
                    AlbumId = 44,
                    Title = "Physical Graffiti [Disc 1]",
                    ArtistId = 22
                },
                new Album
                {
                    AlbumId = 45,
                    Title = "Sambas De Enredo 2001",
                    ArtistId = 21
                },
                new Album
                {
                    AlbumId = 46,
                    Title = "Supernatural",
                    ArtistId = 59
                },
                new Album
                {
                    AlbumId = 47,
                    Title = "The Best of Ed Motta",
                    ArtistId = 37
                },
                new Album
                {
                    AlbumId = 48,
                    Title = "The Essential Miles Davis [Disc 1]",
                    ArtistId = 68
                },
                new Album
                {
                    AlbumId = 49,
                    Title = "The Essential Miles Davis [Disc 2]",
                    ArtistId = 68
                },
                new Album
                {
                    AlbumId = 50,
                    Title = "The Final Concerts (Disc 2)",
                    ArtistId = 58
                },
                new Album
                {
                    AlbumId = 51,
                    Title = "Up An' Atom",
                    ArtistId = 69
                },
                new Album
                {
                    AlbumId = 52,
                    Title = "Vinícius De Moraes - Sem Limite",
                    ArtistId = 70
                },
                new Album
                {
                    AlbumId = 53,
                    Title = "Vozes do MPB",
                    ArtistId = 21
                },
                new Album
                {
                    AlbumId = 54,
                    Title = "Chronicle, Vol. 1",
                    ArtistId = 76
                },
                new Album
                {
                    AlbumId = 55,
                    Title = "Chronicle, Vol. 2",
                    ArtistId = 76
                },
                new Album
                {
                    AlbumId = 56,
                    Title = "Cássia Eller - Coleção Sem Limite [Disc 2]",
                    ArtistId = 77
                },
                new Album
                {
                    AlbumId = 57,
                    Title = "Cássia Eller - Sem Limite [Disc 1]",
                    ArtistId = 77
                },
                new Album
                {
                    AlbumId = 58,
                    Title = "Come Taste The Band",
                    ArtistId = 58
                },
                new Album
                {
                    AlbumId = 59,
                    Title = "Deep Purple In Rock",
                    ArtistId = 58
                },
                new Album
                {
                    AlbumId = 60,
                    Title = "Fireball",
                    ArtistId = 58
                },
                new Album
                {
                    AlbumId = 61,
                    Title = "Knocking at Your Back Door: The Best Of Deep Purple in the 80's",
                    ArtistId = 58
                },
                new Album
                {
                    AlbumId = 62,
                    Title = "Machine Head",
                    ArtistId = 58
                },
                new Album
                {
                    AlbumId = 63,
                    Title = "Purpendicular",
                    ArtistId = 58
                },
                new Album
                {
                    AlbumId = 64,
                    Title = "Slaves And Masters",
                    ArtistId = 58
                },
                new Album
                {
                    AlbumId = 65,
                    Title = "Stormbringer",
                    ArtistId = 58
                },
                new Album
                {
                    AlbumId = 66,
                    Title = "The Battle Rages On",
                    ArtistId = 58
                },
                new Album
                {
                    AlbumId = 67,
                    Title = "Vault: Def Leppard's Greatest Hits",
                    ArtistId = 78
                },
                new Album
                {
                    AlbumId = 68,
                    Title = "Outbreak",
                    ArtistId = 79
                },
                new Album
                {
                    AlbumId = 69,
                    Title = "Djavan Ao Vivo - Vol. 02",
                    ArtistId = 80
                },
                new Album
                {
                    AlbumId = 70,
                    Title = "Djavan Ao Vivo - Vol. 1",
                    ArtistId = 80
                },
                new Album
                {
                    AlbumId = 71,
                    Title = "Elis Regina-Minha História",
                    ArtistId = 41
                },
                new Album
                {
                    AlbumId = 72,
                    Title = "The Cream Of Clapton",
                    ArtistId = 81
                },
                new Album
                {
                    AlbumId = 73,
                    Title = "Unplugged",
                    ArtistId = 81
                },
                new Album
                {
                    AlbumId = 74,
                    Title = "Album Of The Year",
                    ArtistId = 82
                },
                new Album
                {
                    AlbumId = 75,
                    Title = "Angel Dust",
                    ArtistId = 82
                },
                new Album
                {
                    AlbumId = 76,
                    Title = "King For A Day Fool For A Lifetime",
                    ArtistId = 82
                },
                new Album
                {
                    AlbumId = 77,
                    Title = "The Real Thing",
                    ArtistId = 82
                },
                new Album
                {
                    AlbumId = 78,
                    Title = "Deixa Entrar",
                    ArtistId = 83
                },
                new Album
                {
                    AlbumId = 79,
                    Title = "In Your Honor [Disc 1]",
                    ArtistId = 84
                },
                new Album
                {
                    AlbumId = 80,
                    Title = "In Your Honor [Disc 2]",
                    ArtistId = 84
                },
                new Album
                {
                    AlbumId = 81,
                    Title = "One By One",
                    ArtistId = 84
                },
                new Album
                {
                    AlbumId = 82,
                    Title = "The Colour And The Shape",
                    ArtistId = 84
                },
                new Album
                {
                    AlbumId = 83,
                    Title = "My Way: The Best Of Frank Sinatra [Disc 1]",
                    ArtistId = 85
                },
                new Album
                {
                    AlbumId = 84,
                    Title = "Roda De Funk",
                    ArtistId = 86
                },
                new Album
                {
                    AlbumId = 85,
                    Title = "As Canções de Eu Tu Eles",
                    ArtistId = 27
                },
                new Album
                {
                    AlbumId = 86,
                    Title = "Quanta Gente Veio Ver (Live)",
                    ArtistId = 27
                },
                new Album
                {
                    AlbumId = 87,
                    Title = "Quanta Gente Veio ver--Bônus De Carnaval",
                    ArtistId = 27
                },
                new Album
                {
                    AlbumId = 88,
                    Title = "Faceless",
                    ArtistId = 87
                },
                new Album
                {
                    AlbumId = 89,
                    Title = "American Idiot",
                    ArtistId = 54
                },
                new Album
                {
                    AlbumId = 90,
                    Title = "Appetite for Destruction",
                    ArtistId = 88
                },
                new Album
                {
                    AlbumId = 91,
                    Title = "Use Your Illusion I",
                    ArtistId = 88
                },
                new Album
                {
                    AlbumId = 92,
                    Title = "Use Your Illusion II",
                    ArtistId = 88
                },
                new Album
                {
                    AlbumId = 93,
                    Title = "Blue Moods",
                    ArtistId = 89
                },
                new Album
                {
                    AlbumId = 94,
                    Title = "A Matter of Life and Death",
                    ArtistId = 90
                },
                new Album
                {
                    AlbumId = 95,
                    Title = "A Real Dead One",
                    ArtistId = 90
                },
                new Album
                {
                    AlbumId = 96,
                    Title = "A Real Live One",
                    ArtistId = 90
                },
                new Album
                {
                    AlbumId = 97,
                    Title = "Brave New World",
                    ArtistId = 90
                },
                new Album
                {
                    AlbumId = 98,
                    Title = "Dance Of Death",
                    ArtistId = 90
                },
                new Album
                {
                    AlbumId = 99,
                    Title = "Fear Of The Dark",
                    ArtistId = 90
                },
                new Album
                {
                    AlbumId = 100,
                    Title = "Iron Maiden",
                    ArtistId = 90
                },
                new Album
                {
                    AlbumId = 101,
                    Title = "Killers",
                    ArtistId = 90
                },
                new Album
                {
                    AlbumId = 102,
                    Title = "Live After Death",
                    ArtistId = 90
                },
                new Album
                {
                    AlbumId = 103,
                    Title = "Live At Donington 1992 (Disc 1)",
                    ArtistId = 90
                },
                new Album
                {
                    AlbumId = 104,
                    Title = "Live At Donington 1992 (Disc 2)",
                    ArtistId = 90
                },
                new Album
                {
                    AlbumId = 105,
                    Title = "No Prayer For The Dying",
                    ArtistId = 90
                },
                new Album
                {
                    AlbumId = 106,
                    Title = "Piece Of Mind",
                    ArtistId = 90
                },
                new Album
                {
                    AlbumId = 107,
                    Title = "Powerslave",
                    ArtistId = 90
                },
                new Album
                {
                    AlbumId = 108,
                    Title = "Rock In Rio [CD1]",
                    ArtistId = 90
                },
                new Album
                {
                    AlbumId = 109,
                    Title = "Rock In Rio [CD2]",
                    ArtistId = 90
                },
                new Album
                {
                    AlbumId = 110,
                    Title = "Seventh Son of a Seventh Son",
                    ArtistId = 90
                },
                new Album
                {
                    AlbumId = 111,
                    Title = "Somewhere in Time",
                    ArtistId = 90
                },
                new Album
                {
                    AlbumId = 112,
                    Title = "The Number of The Beast",
                    ArtistId = 90
                },
                new Album
                {
                    AlbumId = 113,
                    Title = "The X Factor",
                    ArtistId = 90
                },
                new Album
                {
                    AlbumId = 114,
                    Title = "Virtual XI",
                    ArtistId = 90
                },
                new Album
                {
                    AlbumId = 115,
                    Title = "Sex Machine",
                    ArtistId = 91
                },
                new Album
                {
                    AlbumId = 116,
                    Title = "Emergency On Planet Earth",
                    ArtistId = 92
                },
                new Album
                {
                    AlbumId = 117,
                    Title = "Synkronized",
                    ArtistId = 92
                },
                new Album
                {
                    AlbumId = 118,
                    Title = "The Return Of The Space Cowboy",
                    ArtistId = 92
                },
                new Album
                {
                    AlbumId = 119,
                    Title = "Get Born",
                    ArtistId = 93
                },
                new Album
                {
                    AlbumId = 120,
                    Title = "Are You Experienced?",
                    ArtistId = 94
                },
                new Album
                {
                    AlbumId = 121,
                    Title = "Surfing with the Alien (Remastered)",
                    ArtistId = 95
                },
                new Album
                {
                    AlbumId = 122,
                    Title = "Jorge Ben Jor 25 Anos",
                    ArtistId = 46
                },
                new Album
                {
                    AlbumId = 123,
                    Title = "Jota Quest-1995",
                    ArtistId = 96
                },
                new Album
                {
                    AlbumId = 124,
                    Title = "Cafezinho",
                    ArtistId = 97
                },
                new Album
                {
                    AlbumId = 125,
                    Title = "Living After Midnight",
                    ArtistId = 98
                },
                new Album
                {
                    AlbumId = 126,
                    Title = "Unplugged [Live]",
                    ArtistId = 52
                },
                new Album
                {
                    AlbumId = 127,
                    Title = "BBC Sessions [Disc 2] [Live]",
                    ArtistId = 22
                },
                new Album
                {
                    AlbumId = 128,
                    Title = "Coda",
                    ArtistId = 22
                },
                new Album
                {
                    AlbumId = 129,
                    Title = "Houses Of The Holy",
                    ArtistId = 22
                },
                new Album
                {
                    AlbumId = 130,
                    Title = "In Through The Out Door",
                    ArtistId = 22
                },
                new Album
                {
                    AlbumId = 131,
                    Title = "IV",
                    ArtistId = 22
                },
                new Album
                {
                    AlbumId = 132,
                    Title = "Led Zeppelin I",
                    ArtistId = 22
                },
                new Album
                {
                    AlbumId = 133,
                    Title = "Led Zeppelin II",
                    ArtistId = 22
                },
                new Album
                {
                    AlbumId = 134,
                    Title = "Led Zeppelin III",
                    ArtistId = 22
                },
                new Album
                {
                    AlbumId = 135,
                    Title = "Physical Graffiti [Disc 2]",
                    ArtistId = 22
                },
                new Album
                {
                    AlbumId = 136,
                    Title = "Presence",
                    ArtistId = 22
                },
                new Album
                {
                    AlbumId = 137,
                    Title = "The Song Remains The Same (Disc 1)",
                    ArtistId = 22
                },
                new Album
                {
                    AlbumId = 138,
                    Title = "The Song Remains The Same (Disc 2)",
                    ArtistId = 22
                },
                new Album
                {
                    AlbumId = 139,
                    Title = "A TempestadeTempestade Ou O Livro Dos Dias",
                    ArtistId = 99
                },
                new Album
                {
                    AlbumId = 140,
                    Title = "Mais Do Mesmo",
                    ArtistId = 99
                },
                new Album
                {
                    AlbumId = 141,
                    Title = "Greatest Hits",
                    ArtistId = 100
                },
                new Album
                {
                    AlbumId = 142,
                    Title = "Lulu Santos - RCA 100 Anos De Música - Álbum 01",
                    ArtistId = 101
                },
                new Album
                {
                    AlbumId = 143,
                    Title = "Lulu Santos - RCA 100 Anos De Música - Álbum 02",
                    ArtistId = 101
                },
                new Album
                {
                    AlbumId = 144,
                    Title = "Misplaced Childhood",
                    ArtistId = 102
                },
                new Album
                {
                    AlbumId = 145,
                    Title = "Barulhinho Bom",
                    ArtistId = 103
                },
                new Album
                {
                    AlbumId = 146,
                    Title = "Seek And Shall Find: More Of The Best (1963-1981)",
                    ArtistId = 104
                },
                new Album
                {
                    AlbumId = 147,
                    Title = "The Best Of Men At Work",
                    ArtistId = 105
                },
                new Album
                {
                    AlbumId = 148,
                    Title = "Black Album",
                    ArtistId = 50
                },
                new Album
                {
                    AlbumId = 149,
                    Title = "Garage Inc. (Disc 2)",
                    ArtistId = 50
                },
                new Album
                {
                    AlbumId = 150,
                    Title = "Kill 'Em All",
                    ArtistId = 50
                },
                new Album
                {
                    AlbumId = 151,
                    Title = "Load",
                    ArtistId = 50
                },
                new Album
                {
                    AlbumId = 152,
                    Title = "Master Of Puppets",
                    ArtistId = 50
                },
                new Album
                {
                    AlbumId = 153,
                    Title = "ReLoad",
                    ArtistId = 50
                },
                new Album
                {
                    AlbumId = 154,
                    Title = "Ride The Lightning",
                    ArtistId = 50
                },
                new Album
                {
                    AlbumId = 155,
                    Title = "St. Anger",
                    ArtistId = 50
                },
                new Album
                {
                    AlbumId = 156,
                    Title = "...And Justice For All",
                    ArtistId = 50
                },
                new Album
                {
                    AlbumId = 157,
                    Title = "Miles Ahead",
                    ArtistId = 68
                },
                new Album
                {
                    AlbumId = 158,
                    Title = "Milton Nascimento Ao Vivo",
                    ArtistId = 42
                },
                new Album
                {
                    AlbumId = 159,
                    Title = "Minas",
                    ArtistId = 42
                },
                new Album
                {
                    AlbumId = 160,
                    Title = "Ace Of Spades",
                    ArtistId = 106
                },
                new Album
                {
                    AlbumId = 161,
                    Title = "Demorou...",
                    ArtistId = 108
                },
                new Album
                {
                    AlbumId = 162,
                    Title = "Motley Crue Greatest Hits",
                    ArtistId = 109
                },
                new Album
                {
                    AlbumId = 163,
                    Title = "From The Muddy Banks Of The Wishkah [Live]",
                    ArtistId = 110
                },
                new Album
                {
                    AlbumId = 164,
                    Title = "Nevermind",
                    ArtistId = 110
                },
                new Album
                {
                    AlbumId = 165,
                    Title = "Compositores",
                    ArtistId = 111
                },
                new Album
                {
                    AlbumId = 166,
                    Title = "Olodum",
                    ArtistId = 112
                },
                new Album
                {
                    AlbumId = 167,
                    Title = "Acústico MTV",
                    ArtistId = 113
                },
                new Album
                {
                    AlbumId = 168,
                    Title = "Arquivo II",
                    ArtistId = 113
                },
                new Album
                {
                    AlbumId = 169,
                    Title = "Arquivo Os Paralamas Do Sucesso",
                    ArtistId = 113
                },
                new Album
                {
                    AlbumId = 170,
                    Title = "Bark at the Moon (Remastered)",
                    ArtistId = 114
                },
                new Album
                {
                    AlbumId = 171,
                    Title = "Blizzard of Ozz",
                    ArtistId = 114
                },
                new Album
                {
                    AlbumId = 172,
                    Title = "Diary of a Madman (Remastered)",
                    ArtistId = 114
                },
                new Album
                {
                    AlbumId = 173,
                    Title = "No More Tears (Remastered)",
                    ArtistId = 114
                },
                new Album
                {
                    AlbumId = 174,
                    Title = "Tribute",
                    ArtistId = 114
                },
                new Album
                {
                    AlbumId = 175,
                    Title = "Walking Into Clarksdale",
                    ArtistId = 115
                },
                new Album
                {
                    AlbumId = 176,
                    Title = "Original Soundtracks 1",
                    ArtistId = 116
                },
                new Album
                {
                    AlbumId = 177,
                    Title = "The Beast Live",
                    ArtistId = 117
                },
                new Album
                {
                    AlbumId = 178,
                    Title = "Live On Two Legs [Live]",
                    ArtistId = 118
                },
                new Album
                {
                    AlbumId = 179,
                    Title = "Pearl Jam",
                    ArtistId = 118
                },
                new Album
                {
                    AlbumId = 180,
                    Title = "Riot Act",
                    ArtistId = 118
                },
                new Album
                {
                    AlbumId = 181,
                    Title = "Ten",
                    ArtistId = 118
                },
                new Album
                {
                    AlbumId = 182,
                    Title = "Vs.",
                    ArtistId = 118
                },
                new Album
                {
                    AlbumId = 183,
                    Title = "Dark Side Of The Moon",
                    ArtistId = 120
                },
                new Album
                {
                    AlbumId = 184,
                    Title = "Os Cães Ladram Mas A Caravana Não Pára",
                    ArtistId = 121
                },
                new Album
                {
                    AlbumId = 185,
                    Title = "Greatest Hits I",
                    ArtistId = 51
                },
                new Album
                {
                    AlbumId = 186,
                    Title = "News Of The World",
                    ArtistId = 51
                },
                new Album
                {
                    AlbumId = 187,
                    Title = "Out Of Time",
                    ArtistId = 122
                },
                new Album
                {
                    AlbumId = 188,
                    Title = "Green",
                    ArtistId = 124
                },
                new Album
                {
                    AlbumId = 189,
                    Title = "New Adventures In Hi-Fi",
                    ArtistId = 124
                },
                new Album
                {
                    AlbumId = 190,
                    Title = "The Best Of R.E.M.: The IRS Years",
                    ArtistId = 124
                },
                new Album
                {
                    AlbumId = 191,
                    Title = "Cesta Básica",
                    ArtistId = 125
                },
                new Album
                {
                    AlbumId = 192,
                    Title = "Raul Seixas",
                    ArtistId = 126
                },
                new Album
                {
                    AlbumId = 193,
                    Title = "Blood Sugar Sex Magik",
                    ArtistId = 127
                },
                new Album
                {
                    AlbumId = 194,
                    Title = "By The Way",
                    ArtistId = 127
                },
                new Album
                {
                    AlbumId = 195,
                    Title = "Californication",
                    ArtistId = 127
                },
                new Album
                {
                    AlbumId = 196,
                    Title = "Retrospective I (1974-1980)",
                    ArtistId = 128
                },
                new Album
                {
                    AlbumId = 197,
                    Title = "Santana - As Years Go By",
                    ArtistId = 59
                },
                new Album
                {
                    AlbumId = 198,
                    Title = "Santana Live",
                    ArtistId = 59
                },
                new Album
                {
                    AlbumId = 199,
                    Title = "Maquinarama",
                    ArtistId = 130
                },
                new Album
                {
                    AlbumId = 200,
                    Title = "O Samba Poconé",
                    ArtistId = 130
                },
                new Album
                {
                    AlbumId = 201,
                    Title = "Judas 0: B-Sides and Rarities",
                    ArtistId = 131
                },
                new Album
                {
                    AlbumId = 202,
                    Title = "Rotten Apples: Greatest Hits",
                    ArtistId = 131
                },
                new Album
                {
                    AlbumId = 203,
                    Title = "A-Sides",
                    ArtistId = 132
                },
                new Album
                {
                    AlbumId = 204,
                    Title = "Morning Dance",
                    ArtistId = 53
                },
                new Album
                {
                    AlbumId = 205,
                    Title = "In Step",
                    ArtistId = 133
                },
                new Album
                {
                    AlbumId = 206,
                    Title = "Core",
                    ArtistId = 134
                },
                new Album
                {
                    AlbumId = 207,
                    Title = "Mezmerize",
                    ArtistId = 135
                },
                new Album
                {
                    AlbumId = 208,
                    Title = "[1997] Black Light Syndrome",
                    ArtistId = 136
                },
                new Album
                {
                    AlbumId = 209,
                    Title = "Live [Disc 1]",
                    ArtistId = 137
                },
                new Album
                {
                    AlbumId = 210,
                    Title = "Live [Disc 2]",
                    ArtistId = 137
                },
                new Album
                {
                    AlbumId = 211,
                    Title = "The Singles",
                    ArtistId = 138
                },
                new Album
                {
                    AlbumId = 212,
                    Title = "Beyond Good And Evil",
                    ArtistId = 139
                },
                new Album
                {
                    AlbumId = 213,
                    Title = "Pure Cult: The Best Of The Cult (For Rockers, Ravers, Lovers & Sinners) [UK]",
                    ArtistId = 139
                },
                new Album
                {
                    AlbumId = 214,
                    Title = "The Doors",
                    ArtistId = 140
                },
                new Album
                {
                    AlbumId = 215,
                    Title = "The Police Greatest Hits",
                    ArtistId = 141
                },
                new Album
                {
                    AlbumId = 216,
                    Title = "Hot Rocks, 1964-1971 (Disc 1)",
                    ArtistId = 142
                },
                new Album
                {
                    AlbumId = 217,
                    Title = "No Security",
                    ArtistId = 142
                },
                new Album
                {
                    AlbumId = 218,
                    Title = "Voodoo Lounge",
                    ArtistId = 142
                },
                new Album
                {
                    AlbumId = 219,
                    Title = "Tangents",
                    ArtistId = 143
                },
                new Album
                {
                    AlbumId = 220,
                    Title = "Transmission",
                    ArtistId = 143
                },
                new Album
                {
                    AlbumId = 221,
                    Title = "My Generation - The Very Best Of The Who",
                    ArtistId = 144
                },
                new Album
                {
                    AlbumId = 222,
                    Title = "Serie Sem Limite (Disc 1)",
                    ArtistId = 145
                },
                new Album
                {
                    AlbumId = 223,
                    Title = "Serie Sem Limite (Disc 2)",
                    ArtistId = 145
                },
                new Album
                {
                    AlbumId = 224,
                    Title = "Acústico",
                    ArtistId = 146
                },
                new Album
                {
                    AlbumId = 225,
                    Title = "Volume Dois",
                    ArtistId = 146
                },
                new Album
                {
                    AlbumId = 226,
                    Title = "Battlestar Galactica: The Story So Far",
                    ArtistId = 147
                },
                new Album
                {
                    AlbumId = 227,
                    Title = "Battlestar Galactica, Season 3",
                    ArtistId = 147
                },
                new Album
                {
                    AlbumId = 228,
                    Title = "Heroes, Season 1",
                    ArtistId = 148
                },
                new Album
                {
                    AlbumId = 229,
                    Title = "Lost, Season 3",
                    ArtistId = 149
                },
                new Album
                {
                    AlbumId = 230,
                    Title = "Lost, Season 1",
                    ArtistId = 149
                },
                new Album
                {
                    AlbumId = 231,
                    Title = "Lost, Season 2",
                    ArtistId = 149
                },
                new Album
                {
                    AlbumId = 232,
                    Title = "Achtung Baby",
                    ArtistId = 150
                },
                new Album
                {
                    AlbumId = 233,
                    Title = "All That You Can't Leave Behind",
                    ArtistId = 150
                },
                new Album
                {
                    AlbumId = 234,
                    Title = "B-Sides 1980-1990",
                    ArtistId = 150
                },
                new Album
                {
                    AlbumId = 235,
                    Title = "How To Dismantle An Atomic Bomb",
                    ArtistId = 150
                },
                new Album
                {
                    AlbumId = 236,
                    Title = "Pop",
                    ArtistId = 150
                },
                new Album
                {
                    AlbumId = 237,
                    Title = "Rattle And Hum",
                    ArtistId = 150
                },
                new Album
                {
                    AlbumId = 238,
                    Title = "The Best Of 1980-1990",
                    ArtistId = 150
                },
                new Album
                {
                    AlbumId = 239,
                    Title = "War",
                    ArtistId = 150
                },
                new Album
                {
                    AlbumId = 240,
                    Title = "Zooropa",
                    ArtistId = 150
                },
                new Album
                {
                    AlbumId = 241,
                    Title = "UB40 The Best Of - Volume Two [UK]",
                    ArtistId = 151
                },
                new Album
                {
                    AlbumId = 242,
                    Title = "Diver Down",
                    ArtistId = 152
                },
                new Album
                {
                    AlbumId = 243,
                    Title = "The Best Of Van Halen, Vol. I",
                    ArtistId = 152
                },
                new Album
                {
                    AlbumId = 244,
                    Title = "Van Halen",
                    ArtistId = 152
                },
                new Album
                {
                    AlbumId = 245,
                    Title = "Van Halen III",
                    ArtistId = 152
                },
                new Album
                {
                    AlbumId = 246,
                    Title = "Contraband",
                    ArtistId = 153
                },
                new Album
                {
                    AlbumId = 247,
                    Title = "Vinicius De Moraes",
                    ArtistId = 72
                },
                new Album
                {
                    AlbumId = 248,
                    Title = "Ao Vivo [IMPORT]",
                    ArtistId = 155
                },
                new Album
                {
                    AlbumId = 249,
                    Title = "The Office, Season 1",
                    ArtistId = 156
                },
                new Album
                {
                    AlbumId = 250,
                    Title = "The Office, Season 2",
                    ArtistId = 156
                },
                new Album
                {
                    AlbumId = 251,
                    Title = "The Office, Season 3",
                    ArtistId = 156
                },
                new Album
                {
                    AlbumId = 252,
                    Title = "Un-Led-Ed",
                    ArtistId = 157
                },
                new Album
                {
                    AlbumId = 253,
                    Title = "Battlestar Galactica (Classic), Season 1",
                    ArtistId = 158
                },
                new Album
                {
                    AlbumId = 254,
                    Title = "Aquaman",
                    ArtistId = 159
                },
                new Album
                {
                    AlbumId = 255,
                    Title = "Instant Karma: The Amnesty International Campaign to Save Darfur",
                    ArtistId = 150
                },
                new Album
                {
                    AlbumId = 256,
                    Title = "Speak of the Devil",
                    ArtistId = 114
                },
                new Album
                {
                    AlbumId = 257,
                    Title = "20th Century Masters - The Millennium Collection: The Best of Scorpions",
                    ArtistId = 179
                },
                new Album
                {
                    AlbumId = 258,
                    Title = "House of Pain",
                    ArtistId = 180
                },
                new Album
                {
                    AlbumId = 259,
                    Title = "Radio Brasil (O Som da Jovem Vanguarda) - Seleccao de Henrique Amaro",
                    ArtistId = 36
                },
                new Album
                {
                    AlbumId = 260,
                    Title = "Cake: B-Sides and Rarities",
                    ArtistId = 196
                },
                new Album
                {
                    AlbumId = 261,
                    Title = "LOST, Season 4",
                    ArtistId = 149
                },
                new Album
                {
                    AlbumId = 262,
                    Title = "Quiet Songs",
                    ArtistId = 197
                },
                new Album
                {
                    AlbumId = 263,
                    Title = "Muso Ko",
                    ArtistId = 198
                },
                new Album
                {
                    AlbumId = 264,
                    Title = "Realize",
                    ArtistId = 199
                },
                new Album
                {
                    AlbumId = 265,
                    Title = "Every Kind of Light",
                    ArtistId = 200
                },
                new Album
                {
                    AlbumId = 266,
                    Title = "Duos II",
                    ArtistId = 201
                },
                new Album
                {
                    AlbumId = 267,
                    Title = "Worlds",
                    ArtistId = 202
                },
                new Album
                {
                    AlbumId = 268,
                    Title = "The Best of Beethoven",
                    ArtistId = 203
                },
                new Album
                {
                    AlbumId = 269,
                    Title = "Temple of the Dog",
                    ArtistId = 204
                },
                new Album
                {
                    AlbumId = 270,
                    Title = "Carry On",
                    ArtistId = 205
                },
                new Album
                {
                    AlbumId = 271,
                    Title = "Revelations",
                    ArtistId = 8
                },
                new Album
                {
                    AlbumId = 272,
                    Title = "Adorate Deum: Gregorian Chant from the Proper of the Mass",
                    ArtistId = 206
                },
                new Album
                {
                    AlbumId = 273,
                    Title = "Allegri: Miserere",
                    ArtistId = 207
                },
                new Album
                {
                    AlbumId = 274,
                    Title = "Pachelbel: Canon & Gigue",
                    ArtistId = 208
                },
                new Album
                {
                    AlbumId = 275,
                    Title = "Vivaldi: The Four Seasons",
                    ArtistId = 209
                },
                new Album
                {
                    AlbumId = 276,
                    Title = "Bach: Violin Concertos",
                    ArtistId = 210
                },
                new Album
                {
                    AlbumId = 277,
                    Title = "Bach: Goldberg Variations",
                    ArtistId = 211
                },
                new Album
                {
                    AlbumId = 278,
                    Title = "Bach: The Cello Suites",
                    ArtistId = 212
                },
                new Album
                {
                    AlbumId = 279,
                    Title = "Handel: The Messiah (Highlights)",
                    ArtistId = 213
                },
                new Album
                {
                    AlbumId = 280,
                    Title = "The World of Classical Favourites",
                    ArtistId = 214
                },
                new Album
                {
                    AlbumId = 281,
                    Title = "Sir Neville Marriner: A Celebration",
                    ArtistId = 215
                },
                new Album
                {
                    AlbumId = 282,
                    Title = "Mozart: Wind Concertos",
                    ArtistId = 216
                },
                new Album
                {
                    AlbumId = 283,
                    Title = "Haydn: Symphonies 99 - 104",
                    ArtistId = 217
                },
                new Album
                {
                    AlbumId = 284,
                    Title = "Beethoven: Symhonies Nos. 5 & 6",
                    ArtistId = 218
                },
                new Album
                {
                    AlbumId = 285,
                    Title = "A Soprano Inspired",
                    ArtistId = 219
                },
                new Album
                {
                    AlbumId = 286,
                    Title = "Great Opera Choruses",
                    ArtistId = 220
                },
                new Album
                {
                    AlbumId = 287,
                    Title = "Wagner: Favourite Overtures",
                    ArtistId = 221
                },
                new Album
                {
                    AlbumId = 288,
                    Title = "Fauré: Requiem, Ravel: Pavane & Others",
                    ArtistId = 222
                },
                new Album
                {
                    AlbumId = 289,
                    Title = "Tchaikovsky: The Nutcracker",
                    ArtistId = 223
                },
                new Album
                {
                    AlbumId = 290,
                    Title = "The Last Night of the Proms",
                    ArtistId = 224
                },
                new Album
                {
                    AlbumId = 291,
                    Title = "Puccini: Madama Butterfly - Highlights",
                    ArtistId = 225
                },
                new Album
                {
                    AlbumId = 292,
                    Title = "Holst: The Planets, Op. 32 & Vaughan Williams: Fantasies",
                    ArtistId = 226
                },
                new Album
                {
                    AlbumId = 293,
                    Title = "Pavarotti's Opera Made Easy",
                    ArtistId = 227
                },
                new Album
                {
                    AlbumId = 294,
                    Title = "Great Performances - Barber's Adagio and Other Romantic Favorites for Strings",
                    ArtistId = 228
                },
                new Album
                {
                    AlbumId = 295,
                    Title = "Carmina Burana",
                    ArtistId = 229
                },
                new Album
                {
                    AlbumId = 296,
                    Title = "A Copland Celebration, Vol. I",
                    ArtistId = 230
                },
                new Album
                {
                    AlbumId = 297,
                    Title = "Bach: Toccata & Fugue in D Minor",
                    ArtistId = 231
                },
                new Album
                {
                    AlbumId = 298,
                    Title = "Prokofiev: Symphony No.1",
                    ArtistId = 232
                },
                new Album
                {
                    AlbumId = 299,
                    Title = "Scheherazade",
                    ArtistId = 233
                },
                new Album
                {
                    AlbumId = 300,
                    Title = "Bach: The Brandenburg Concertos",
                    ArtistId = 234
                },
                new Album
                {
                    AlbumId = 301,
                    Title = "Chopin: Piano Concertos Nos. 1 & 2",
                    ArtistId = 235
                },
                new Album
                {
                    AlbumId = 302,
                    Title = "Mascagni: Cavalleria Rusticana",
                    ArtistId = 236
                },
                new Album
                {
                    AlbumId = 303,
                    Title = "Sibelius: Finlandia",
                    ArtistId = 237
                },
                new Album
                {
                    AlbumId = 304,
                    Title = "Beethoven Piano Sonatas: Moonlight & Pastorale",
                    ArtistId = 238
                },
                new Album
                {
                    AlbumId = 305,
                    Title = "Great Recordings of the Century - Mahler: Das Lied von der Erde",
                    ArtistId = 240
                },
                new Album
                {
                    AlbumId = 306,
                    Title = "Elgar: Cello Concerto & Vaughan Williams: Fantasias",
                    ArtistId = 241
                },
                new Album
                {
                    AlbumId = 307,
                    Title = "Adams, John: The Chairman Dances",
                    ArtistId = 242
                },
                new Album
                {
                    AlbumId = 308,
                    Title = "Tchaikovsky: 1812 Festival Overture, Op.49, Capriccio Italien & Beethoven: Wellington's Victory",
                    ArtistId = 243
                },
                new Album
                {
                    AlbumId = 309,
                    Title = "Palestrina: Missa Papae Marcelli & Allegri: Miserere",
                    ArtistId = 244
                },
                new Album
                {
                    AlbumId = 310,
                    Title = "Prokofiev: Romeo & Juliet",
                    ArtistId = 245
                },
                new Album
                {
                    AlbumId = 311,
                    Title = "Strauss: Waltzes",
                    ArtistId = 226
                },
                new Album
                {
                    AlbumId = 312,
                    Title = "Berlioz: Symphonie Fantastique",
                    ArtistId = 245
                },
                new Album
                {
                    AlbumId = 313,
                    Title = "Bizet: Carmen Highlights",
                    ArtistId = 246
                },
                new Album
                {
                    AlbumId = 314,
                    Title = "English Renaissance",
                    ArtistId = 247
                },
                new Album
                {
                    AlbumId = 315,
                    Title = "Handel: Music for the Royal Fireworks (Original Version 1749)",
                    ArtistId = 208
                },
                new Album
                {
                    AlbumId = 316,
                    Title = "Grieg: Peer Gynt Suites & Sibelius: Pelléas et Mélisande",
                    ArtistId = 248
                },
                new Album
                {
                    AlbumId = 317,
                    Title = "Mozart Gala: Famous Arias",
                    ArtistId = 249
                },
                new Album
                {
                    AlbumId = 318,
                    Title = "SCRIABIN: Vers la flamme",
                    ArtistId = 250
                },
                new Album
                {
                    AlbumId = 319,
                    Title = "Armada: Music from the Courts of England and Spain",
                    ArtistId = 251
                },
                new Album
                {
                    AlbumId = 320,
                    Title = "Mozart: Symphonies Nos. 40 & 41",
                    ArtistId = 248
                },
                new Album
                {
                    AlbumId = 321,
                    Title = "Back to Black",
                    ArtistId = 252
                },
                new Album
                {
                    AlbumId = 322,
                    Title = "Frank",
                    ArtistId = 252
                },
                new Album
                {
                    AlbumId = 323,
                    Title = "Carried to Dust (Bonus Track Version)",
                    ArtistId = 253
                },
                new Album
                {
                    AlbumId = 324,
                    Title = "Beethoven: Symphony No. 6 'Pastoral' Etc.",
                    ArtistId = 254
                },
                new Album
                {
                    AlbumId = 325,
                    Title = "Bartok: Violin & Viola Concertos",
                    ArtistId = 255
                },
                new Album
                {
                    AlbumId = 326,
                    Title = "Mendelssohn: A Midsummer Night's Dream",
                    ArtistId = 256
                },
                new Album
                {
                    AlbumId = 327,
                    Title = "Bach: Orchestral Suites Nos. 1 - 4",
                    ArtistId = 257
                },
                new Album
                {
                    AlbumId = 328,
                    Title = "Charpentier: Divertissements, Airs & Concerts",
                    ArtistId = 258
                },
                new Album
                {
                    AlbumId = 329,
                    Title = "South American Getaway",
                    ArtistId = 259
                },
                new Album
                {
                    AlbumId = 330,
                    Title = "Górecki: Symphony No. 3",
                    ArtistId = 260
                },
                new Album
                {
                    AlbumId = 331,
                    Title = "Purcell: The Fairy Queen",
                    ArtistId = 261
                },
                new Album
                {
                    AlbumId = 332,
                    Title = "The Ultimate Relexation Album",
                    ArtistId = 262
                },
                new Album
                {
                    AlbumId = 333,
                    Title = "Purcell: Music for the Queen Mary",
                    ArtistId = 263
                },
                new Album
                {
                    AlbumId = 334,
                    Title = "Weill: The Seven Deadly Sins",
                    ArtistId = 264
                },
                new Album
                {
                    AlbumId = 335,
                    Title = "J.S. Bach: Chaconne, Suite in E Minor, Partita in E Major & Prelude, Fugue and Allegro",
                    ArtistId = 265
                },
                new Album
                {
                    AlbumId = 336,
                    Title = "Prokofiev: Symphony No.5 & Stravinksy: Le Sacre Du Printemps",
                    ArtistId = 248
                },
                new Album
                {
                    AlbumId = 337,
                    Title = "Szymanowski: Piano Works, Vol. 1",
                    ArtistId = 266
                },
                new Album
                {
                    AlbumId = 338,
                    Title = "Nielsen: The Six Symphonies",
                    ArtistId = 267
                },
                new Album
                {
                    AlbumId = 339,
                    Title = "Great Recordings of the Century: Paganini's 24 Caprices",
                    ArtistId = 268
                },
                new Album
                {
                    AlbumId = 340,
                    Title = "Liszt - 12 Études D'Execution Transcendante",
                    ArtistId = 269
                },
                new Album
                {
                    AlbumId = 341,
                    Title = "Great Recordings of the Century - Shubert: Schwanengesang, 4 Lieder",
                    ArtistId = 270
                },
                new Album
                {
                    AlbumId = 342,
                    Title = "Locatelli: Concertos for Violin, Strings and Continuo, Vol. 3",
                    ArtistId = 271
                },
                new Album
                {
                    AlbumId = 343,
                    Title = "Respighi:Pines of Rome",
                    ArtistId = 226
                },
                new Album
                {
                    AlbumId = 344,
                    Title = "Schubert: The Late String Quartets & String Quintet (3 CD's)",
                    ArtistId = 272
                },
                new Album
                {
                    AlbumId = 345,
                    Title = "Monteverdi: L'Orfeo",
                    ArtistId = 273
                },
                new Album
                {
                    AlbumId = 346,
                    Title = "Mozart: Chamber Music",
                    ArtistId = 274
                },
                new Album
                {
                    AlbumId = 347,
                    Title = "Koyaanisqatsi (Soundtrack from the Motion Picture)",
                    ArtistId = 275
                }
            );
        }
    }
}
