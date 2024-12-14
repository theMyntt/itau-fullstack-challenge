using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;

namespace Domain.Tests.Exceptions
{
    public class ParticipationNotValidTest
    {
        [Fact]
        public async Task ShouldThrow()
        {
            var exception = await Assert.ThrowsAsync<ParticipationNotValidException>(() => throw new ParticipationNotValidException());
            Assert.IsType<ParticipationNotValidException?>(exception);
        }

        [Fact]
        public async Task ShouldHaveCorrectMessage()
        {
            var exception = await Assert.ThrowsAsync<ParticipationNotValidException>(() => throw new ParticipationNotValidException());
            Assert.Equal("Participation needs to be >= 1 and <= 100", exception.Message);
        }
    }
}
