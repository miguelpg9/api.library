using api.library.Models;
using Microsoft.EntityFrameworkCore;

namespace api.library.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(LibraryDbContext db)
    {
        if (await db.Books.AnyAsync() || await db.Authors.AnyAsync() || await db.Members.AnyAsync())
        {
            return;
        }

        var garciaMarquez = new Author
        {
            FirstName = "Gabriel",
            LastName = "García Márquez",
            Nationality = "Colombiano",
            BirthDate = new DateTime(1927, 3, 6),
            Biography = "Escritor y periodista colombiano, premio Nobel de Literatura en 1982.",
        };

        var allende = new Author
        {
            FirstName = "Isabel",
            LastName = "Allende",
            Nationality = "Chilena",
            BirthDate = new DateTime(1942, 8, 2),
            Biography = "Escritora chilena, una de las autoras más leídas en español.",
        };

        var cervantes = new Author
        {
            FirstName = "Miguel",
            LastName = "de Cervantes",
            Nationality = "Español",
            BirthDate = new DateTime(1547, 9, 29),
            Biography = "Autor del Quijote, la obra cumbre de la literatura en español.",
        };

        var bookCienAnos = new Book
        {
            Title = "Cien años de soledad",
            Isbn = "978-84-376-0494-7",
            PublicationYear = 1967,
            Publisher = "Editorial Sudamericana",
            Genre = "Realismo mágico",
            Quantity = 5,
            Authors = [garciaMarquez],
        };

        var bookAmorColera = new Book
        {
            Title = "El amor en los tiempos del cólera",
            Isbn = "978-84-204-8518-0",
            PublicationYear = 1985,
            Publisher = "Editorial Sudamericana",
            Genre = "Novela",
            Quantity = 3,
            Authors = [garciaMarquez],
        };

        var bookCasaEspiritus = new Book
        {
            Title = "La casa de los espíritus",
            Isbn = "978-84-204-4449-1",
            PublicationYear = 1982,
            Publisher = "Plaza & Janés",
            Genre = "Realismo mágico",
            Quantity = 4,
            Authors = [allende],
        };

        var bookPaula = new Book
        {
            Title = "Paula",
            Isbn = "978-84-204-8372-8",
            PublicationYear = 1994,
            Publisher = "Plaza & Janés",
            Genre = "Autobiografía",
            Quantity = 2,
            Authors = [allende],
        };

        var bookQuijote = new Book
        {
            Title = "Don Quijote de la Mancha",
            Isbn = "978-84-670-3718-4",
            PublicationYear = 1605,
            Publisher = "Espasa",
            Genre = "Clásico",
            Quantity = 6,
            Authors = [cervantes],
        };

        var member1 = new Member
        {
            FirstName = "Ana",
            LastName = "Torres",
            Email = "ana.torres@mail.com",
            Phone = "+34 600 111 222",
            MembershipDate = DateTime.UtcNow,
            IsActive = true,
        };

        var member2 = new Member
        {
            FirstName = "Pedro",
            LastName = "Sánchez",
            Email = "pedro.sanchez@mail.com",
            Phone = "+34 600 333 444",
            MembershipDate = DateTime.UtcNow,
            IsActive = true,
        };

        db.Authors.AddRange(garciaMarquez, allende, cervantes);
        db.Books.AddRange(bookCienAnos, bookAmorColera, bookCasaEspiritus, bookPaula, bookQuijote);
        db.Members.AddRange(member1, member2);

        await db.SaveChangesAsync();
    }
}