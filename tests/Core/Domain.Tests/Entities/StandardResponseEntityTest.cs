using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Exceptions;

namespace Domain.Tests.Entities
{
    public class StandardResponseEntityTest
    {
        [Fact]
        public void ShouldGiveErrorWhenStatusCodeIsNotValid()
        {
            var statusCode = 0;
            var message = "Test message";
            
            var exception = Assert.Throws<StatusCodeNotValidException>(() => StandardResponseEntity.Build(statusCode: statusCode, message: message));

            Assert.Equal("StatusCode is not valid", exception.Message);
        }

        [Fact]
        public void ShouldBuildCorrect()
        {
            var statusCode = 200;
            var message = "Test message";

            var entity = StandardResponseEntity.Build(statusCode: statusCode, message: message);

            Assert.Equal(statusCode, entity.StatusCode);
            Assert.Equal(message, entity.Message);
        }
    }
}
