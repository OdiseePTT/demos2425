using Hangman.Repositories;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Tests
{
    internal class HangmanGameTests
    {

        [Test]
        public void ctor_WithWordsRepo_GetRandomWoordWordtAangeroepen()
        {
            // Arrange
            IWoordRepository woordRepository = Substitute.For<IWoordRepository>();
          
            // Act
            HangmanGame sut = new HangmanGame(woordRepository);

            // Assert
            woordRepository.Received(1).GetRandomWoord();
        }

        [TestCase("Appel", "_____")]
        [TestCase("Peer", "____")]
        [TestCase("Banaan", "______")]
        public void ctor_MetRandomWoord_ReturnsJuisteAantalLiggendeStreepjes(string randomwoord, string verwachtResultaat)
        {
            // Arrange
            IWoordRepository woordRepository = Substitute.For<IWoordRepository>();
            woordRepository.GetRandomWoord().Returns(randomwoord);

            // Act
            HangmanGame sut = new HangmanGame(woordRepository);

            // Assert
            Assert.That(sut.TeRadenWoord, Is.EqualTo(verwachtResultaat));
        }

        [Test]
        public void RaadLetter_MetReedsgekozenLetter_ReturnsLetterAlgeraden()
        {
            // Arrange
            IWoordRepository woordRepository = Substitute.For<IWoordRepository>();
            HangmanGame sut = new HangmanGame(woordRepository);
            sut.RaadLetter('a');

            // Act
            GameStatus result = sut.RaadLetter('a');

            // Assert
            Assert.That(result, Is.EqualTo(GameStatus.AlGeraden));
        }

        [Test]
        public void RaadLetter_MetLetterAanwezigInWoord_ReturnsLetterAanwezigEnLevensBlijvenOngewijzigd()
        {

            // Arrange
            IWoordRepository woordRepository = Substitute.For<IWoordRepository>();
            woordRepository.GetRandomWoord().Returns("appel");
            HangmanGame sut = new HangmanGame(woordRepository);

            // Act
            GameStatus result = sut.RaadLetter('a');

            // Assert
            Assert.That(result, Is.EqualTo(GameStatus.LetterAanwezig));
            Assert.That(sut.Levens, Is.EqualTo(10));
        }

        [TestCase("appel", 'a', "a____")]
        [TestCase("appel", 'p', "_pp__")]
        [TestCase("peer", 'p', "p___")]
        public void RaadLetter_MetLetterAanwezigInWoord_ReplaceUnderscoreWithGuessedLetter(string teRadenWoord, char letter, string result)
        {
            // Arrange
            IWoordRepository woordRepository = Substitute.For<IWoordRepository>();
            woordRepository.GetRandomWoord().Returns(teRadenWoord);
            HangmanGame sut = new HangmanGame(woordRepository);

            // Act
            sut.RaadLetter(letter);

            // Assert
            Assert.That(sut.TeRadenWoord, Is.EqualTo(result));
        }

        [Test]
        public void RaadLetter_MetAlCorrectGeradenLetters_TeRadenWoordHoudtRekeningMetEerderGeradenLetters()
        {
            // Arrange
            IWoordRepository woordRepository = Substitute.For<IWoordRepository>();
            woordRepository.GetRandomWoord().Returns("appel");
            HangmanGame sut = new HangmanGame(woordRepository);
            sut.RaadLetter('a');

            // act
            sut.RaadLetter('p');

            // Assert
            Assert.That(sut.TeRadenWoord, Is.EqualTo("app__"));
        }

        [Test]
        public void RaadLetter_MetLetterNietAanwezigInWoord_ReturnsLetterAfwezig()
        {
            // Arrange
            IWoordRepository woordRepository = Substitute.For<IWoordRepository>();
            woordRepository.GetRandomWoord().Returns("peer");
            HangmanGame sut = new HangmanGame(woordRepository);

            // Act
            GameStatus result = sut.RaadLetter('a');

            // Assert
            Assert.That(result, Is.EqualTo(GameStatus.LetterAfwezig));
        }

        [Test]
        public void RaadLetter_MetLetterNietAanwezigInWoord_VerminderdLevensVanSpeler()
        {
            // Arrange
            IWoordRepository woordRepository = Substitute.For<IWoordRepository>();
            woordRepository.GetRandomWoord().Returns("appel");
            HangmanGame sut = new HangmanGame(woordRepository);

            // Act
            sut.RaadLetter('z');

            // Assert
            Assert.That(sut.Levens, Is.EqualTo(9));
        }

        [Test]
        public void RaadLetter_MetLetterNietAanwezigInWoordEnAlFoutGeradenLettersAanwezig_VerminderdLevensVanSpeler()
        {
            // Arrange
            IWoordRepository woordRepository = Substitute.For<IWoordRepository>();
            woordRepository.GetRandomWoord().Returns("appel");
            HangmanGame sut = new HangmanGame(woordRepository);

            // Act
            sut.RaadLetter('z');
            sut.RaadLetter('y');

            // Assert
            Assert.That(sut.Levens, Is.EqualTo(8));
        }
    }
}
