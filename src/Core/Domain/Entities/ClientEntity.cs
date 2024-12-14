using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;
using Domain.Validators;

namespace Domain.Entities
{
    public class ClientEntity
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Participation { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private ClientEntity(string firstName, string lastName, int participation, Guid? id = null, DateTime? createdAt = null) 
        {
            Id = id ?? Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            CreatedAt = createdAt ?? DateTime.UtcNow;
            Participation = participation;
        }

        public static ClientEntity Build(string firstName, string lastName, int participation, Guid? id = null, DateTime? createdAt = null)
        {
            var entity = new ClientEntity(firstName, lastName, participation, id, createdAt);

            ValidateDomain(entity);

            return entity;
        }

        private static void ValidateDomain(ClientEntity entity)
        {
            GenericDomainValidator.When(entity.Participation < 1 || entity.Participation > 100, new ParticipationNotValid());
            GenericDomainValidator.When(entity.CreatedAt > DateTime.UtcNow, new DateNotValidException());
        }
    }
}
