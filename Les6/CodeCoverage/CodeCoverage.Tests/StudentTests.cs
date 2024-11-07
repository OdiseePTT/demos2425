using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCoverage.Tests
{
    internal class StudentTests
    {
        [Test]
         public void Test()
        {
            Student student = new Student("John", 15);

            bool result = student.IsGeslaagd();

            Assert.That(result, Is.True);
        }

        [Test]
        public void Test2()
        {
            Student student = new Student("John", 15);

            Graad result = student.GetGraad();

            Assert.That(result, Is.EqualTo(Graad.Onderscheiding));
        }

        [Test]
        public void Test3()
        {
            Student student = new Student("John", 1);

            Graad result = student.GetGraad();

            Assert.That(result, Is.EqualTo(Graad.Onvoldoende));
        }
    }
}
