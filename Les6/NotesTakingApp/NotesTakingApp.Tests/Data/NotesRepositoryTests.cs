using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NotesTakingApp.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesTakingApp.Tests.Data
{
    public class NotesRepositoryTests
    {

        [Test]
        public void CreateNote_WithNote_AddNoteToDatabase()
        {
            // Arrange

            // Act

            // Assert
        }

        [Test]
        public void GetAllNotes_WithNotesInDB_ReturnsAllItems()
        {
            // Arrange

            // Act

            // Assert
        }

        [Tes            ]
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

            // Act

            // Assert
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
    }
}
