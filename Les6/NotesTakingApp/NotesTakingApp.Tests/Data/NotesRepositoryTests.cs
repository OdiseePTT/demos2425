using AutoFixture;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NotesTakingApp.Data;
using NUnit.Framework;
using System.Data.Common;

namespace NotesTakingApp.Tests.Data
{
    public class NotesRepositoryTests
    {
        DbContextOptions options;

        private AppDbContext GetDbContext()
        {
            return new AppDbContext(options);
        }

        [SetUp]
        public void SetUp()
        {
            DbConnection connection = new SqliteConnection("filename=:memory:");
            connection.Open();

            options = new DbContextOptionsBuilder<AppDbContext>().UseSqlite(connection).Options;

            AppDbContext context = GetDbContext();
            context.Database.EnsureCreated();
        }

        [Test]
        public void CreateNote_WithNote_AddNoteToDatabase()
        {
            // Arrange
            AppDbContext context = GetDbContext();
            NotesRepository sut = new NotesRepository(context);
            Note note = new Note();
            note.Title = "Test";
            note.Content = "Notitie in unit test";

            // Act
            sut.CreateNote(note);

            // Assert
            Assert.That(context.Notes, Is.EquivalentTo(new List<Note>() { note}) );
        }

        [Test]
        public void GetAllNotes_WithNotesInDB_ReturnsAllItems()
        {
            // Arrange
            AppDbContext dbContext = GetDbContext();
            List<Note> notes = new Fixture().CreateMany<Note>(10).ToList();
            SeedDatabase(dbContext, notes);
            NotesRepository sut = new NotesRepository(dbContext);

            // Act
            List<Note> result = sut.GetAllNotes();

            // Assert
            Assert.That(result, Is.EquivalentTo(notes));
        }

        [Test]
        public void GetAllNotes_WithoutNotesInDB_ReturnsEmptyList()
        {
            // Arrange

            // Act

            // Assert
        }

        [Test]
        public void GetNoteById_WithExistingNoteId_ReturnsNote()
        {
            // Arrange
            AppDbContext dbContext = GetDbContext();
            Note note = new Note();
            note.Title = "Test";
            note.Content = "Dit is een unit test content";
            note.Id = 1;
            SeedDatabase(dbContext, new List<Note>() { note });
              
            List<Note> notes = new Fixture()
                .CreateMany<Note>(10)
                .ToList();

            SeedDatabase(dbContext, notes);
            NotesRepository sut = new NotesRepository(dbContext);

            // Act
            Note? result = sut.GetNoteById(1);

            // Assert
            Assert.That(result, Is.EqualTo(note).UsingPropertiesComparer());
        }

        [Test]
        public void GetNoteById_WithNonExistingId_ReturnsNull()
        {
            // Arrange

            // Act

            // Assert
        }

        [Test]
        public void DeleteNote_WithExistingNote_RemovesNote()
        {
            // Arrange

            // Act

            // Assert
        }

        private void SeedDatabase(AppDbContext dbContext, List<Note> notes)
        {
            dbContext.Notes.AddRange(notes);
            dbContext.SaveChanges();
        } 
    }
}
