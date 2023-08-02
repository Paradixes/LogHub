using System.ComponentModel.DataAnnotations.Schema;
using MediatR;

namespace Domain.Primitives;

[NotMapped]
public record DomainEvent(Guid Id) : INotification;