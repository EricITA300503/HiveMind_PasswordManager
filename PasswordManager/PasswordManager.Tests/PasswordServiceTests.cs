// ============================================================
// File:    PasswordServiceTests.cs
// Author:  Miguel Lumaban
// Purpose: NUnit tests for PasswordService. Verifies password
//          length, character sets, and strength scoring.
// ============================================================
using NUnit.Framework;
using PasswordManager.Models.ViewModels;
using PasswordManager.Services;

namespace PasswordManager.Tests
{
    [TestFixture]
    public class PasswordServiceTests
    {
        private PasswordService _service;

        [SetUp]
        public void Setup()
        {
            _service = new PasswordService();
        }

        [Test]
        public void GeneratePassword_ReturnsCorrectLength()
        {
            var opts = new PasswordOptions
            {
                Length = 20,
                IncludeUppercase = true,
                IncludeNumbers = true,
                IncludeSymbols = false
            };

            var result = _service.GeneratePassword(opts);

            Assert.That(result.Length, Is.EqualTo(20));
        }

        [Test]
        public void CheckStrength_StrongPassword_ReturnsHighScore()
        {
            var result = _service.EvaluateStrength("P@ssw0rd!XyZ9");

            Assert.That(result.Score, Is.EqualTo(4));
        }
    }
}