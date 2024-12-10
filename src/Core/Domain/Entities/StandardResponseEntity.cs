using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;
using Domain.Validators;

namespace Domain.Entities
{
    public class StandardResponseEntity
    {
        public string Message { get; private set; }
        public int StatusCode { get; private set; }

        private StandardResponseEntity(string message, int statusCode) 
        {
            Message = message;
            StatusCode = statusCode;
        }

        public static StandardResponseEntity Build(string message, int statusCode)
        {
            var entity = new StandardResponseEntity(message, statusCode);

            ValidateDomain(entity);

            return entity;
        }

        private static void ValidateDomain(StandardResponseEntity entity)
        {
            GenericDomainValidator.When(!(Enum.IsDefined(typeof(HttpStatusCode), entity.StatusCode)), new StatusCodeNotValidException());
        }
    }
}
