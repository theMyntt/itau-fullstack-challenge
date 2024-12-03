﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Validators;

namespace Domain.Tests.Validators
{
    public class GenericDomainValidatorTest
    {
        [Fact]
        public void ShouldGiveMeAnError()
        {
            var exception = Assert.Throws<Exception>(() => GenericDomainValidator.When(false, new Exception("Mock error")));
            Assert.Equal("Mock error", exception.Message);
        }

        [Fact]
        public void ShouldGiveSuccess()
        {
            var exception = true;
            try
            {
                GenericDomainValidator.When(true, new Exception("Mock error"));
            }
            catch (Exception)
            {
                exception = false;
            }

            Assert.True(exception);
        }
    }
}