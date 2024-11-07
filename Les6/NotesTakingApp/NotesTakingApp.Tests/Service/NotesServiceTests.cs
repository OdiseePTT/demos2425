using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesTakingApp.Tests.Service
{
    public class NotesServiceTests
    {
        [Test]
        public void GetNotes_WithDefaultValues_ReturnsFirst5Items()
        {
            // Arrange

            // Act

            // Assert
        }

        [Test]
        public void GetNotes_WithOffset2AndLimit2_ReturnsItem3And4()
        {
            // Arrange

            // Act

            // Assert
        }

        [Test]
        public void SearchNote_WithNoNotesInDb_ReturnsEmptyList()
        {
            // Arrange

            // Act

            // Assert
        }

        [Test]
        public void SearchNote_WithNotesInDBAndSearchQueryThatDoenstMatch_ReturnsEmptyList()
        {
            // Arrange

            // Act

            // Assert
        }

        [Test]
        public void SearchNote_WithNotesInDBAndSearchQueryThatMatch_ReturnsCorrectList()
        {
            // Arrange

            // Act

            // Assert
        }


        [Test]
        public void CreateNote_WithTitleAndString_CallsCreateNoteWithCorrectNoteObject()
        {
            // Arrange

            // Act

            // Assert
        }

        [Test]
        public void DeleteNote_WithNonExistingID_ReturnsFalseAndDontCallDeleteNote()
        {
            // Arrange

            // Act

            // Assert
        }


        [Test]
        public void DeleteNote_WithExistingID_ReturnsTrueAndCallsDeleteNoteWithCorrectObject()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
