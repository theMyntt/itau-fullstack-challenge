using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Exceptions;

namespace Domain.Tests.Entities
{
    public class ClientEntityTest
    {
        private readonly string _firstName = "GABRIEL";
        private readonly string _lastName = "ARAÚJO";

        [Fact]
        public void ShouldBuildANewEntity()
        {
            var entity = ClientEntity.Build(_firstName, _lastName, 30);

            Assert.NotNull(entity);
            Assert.IsType<ClientEntity>(entity);
            Assert.Equal(_lastName, entity.LastName);
            Assert.Equal(_firstName, entity.FirstName);
            Assert.Equal(30, entity.Participation);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("bf8beb46-e03e-4517-ad21-b1c4bedcb374", null)]
        [InlineData(null, "2024-12-01T00:00:00Z")]
        [InlineData("bf8beb46-e03e-4517-ad21-b1c4bedcb374", "2024-12-01T00:00:00Z")]

        public void ShouldBuildANewEntityWithPartialAttributes(string? id, string? time)
        {
            Guid? newId = string.IsNullOrEmpty(id) ? null : Guid.Parse(id);
            DateTime? newTime = string.IsNullOrEmpty(time) ? null : DateTime.Parse(time);

            var entity = ClientEntity.Build(_firstName, _lastName, 30, newId, newTime);

            Assert.NotNull(entity);
            Assert.Equal(_lastName, entity.LastName);
            Assert.Equal(_firstName, entity.FirstName);
            Assert.Equal(30, entity.Participation);

            if (id == null)
                Assert.NotEqual(Guid.Empty, entity.Id);
            else
                Assert.Equal(newId, entity.Id);

            if (time == null)
                Assert.True(entity.CreatedAt <= DateTime.UtcNow);
            else
                Assert.Equal(newTime, entity.CreatedAt);
        }

        [Fact]
        public void ShouldThrowParticipationNotValid()
        {
            Assert.Throws<ParticipationNotValidException>(() =>
            {
                ClientEntity.Build(_firstName, _lastName, -1);
            });
        }

        [Fact]
        public void ShouldThrowDateNotValid()
        {
            Assert.Throws<DateNotValidException>(() =>
            {
                ClientEntity.Build(_firstName, _lastName, 30, createdAt: DateTime.UtcNow.AddDays(2));
            });
        }
    }
}
