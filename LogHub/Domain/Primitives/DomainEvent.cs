using System.ComponentModel.DataAnnotations.Schema;
using MediatR;

namespace LogHub.Domain.Primitives;

[NotMapped]
public record DomainEvent(Guid Id) : INotification;
