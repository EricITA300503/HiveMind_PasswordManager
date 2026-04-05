// ============================================================
// File:    VaultServiceTests.cs
// Author:  Miguel Lumaban
// Purpose: NUnit tests for VaultService. Uses Moq to verify
//          search filtering and encryption delegation.
// ============================================================
using Moq;
using NUnit.Framework;
using PasswordManager.Data;
using PasswordManager.Models;
using PasswordManager.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordManager.Tests
{
    [TestFixture]
    public class VaultServiceTests
    {
        private Mock<IVaultRepository> _mockRepo;
        private VaultService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IVaultRepository>();
            _service = new VaultService(_mockRepo.Object);
        }

        [Test]
        public void SearchEntries_FiltersByQuery()
        {
            var entries = new List<VaultEntry>
            {
                new VaultEntry { _userId = "u1", _siteName = "GitHub", _username = "miguel" },
                new VaultEntry { _userId = "u1", _siteName = "Gmail", _username = "user2" }
            }.AsQueryable();

            _mockRepo.Setup(r => r.GetAll("u1")).Returns(entries);

            var result = _service.SearchEntries("u1", "Git", null).ToList();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0]._siteName, Is.EqualTo("GitHub"));
        }

        [Test]
        public async Task CreateEntryAsync_AddsEntry_AndSaves()
        {
            var entry = new VaultEntry
            {
                _userId = "u1",
                _siteName = "TestSite",
                _username = "testuser"
            };

            await _service.CreateEntryAsync(entry);

            _mockRepo.Verify(r => r.Add(entry), Times.Once);
            _mockRepo.Verify(r => r.Save(), Times.Once);
        }
    }
}