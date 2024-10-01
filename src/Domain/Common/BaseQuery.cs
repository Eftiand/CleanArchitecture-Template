using CleanArchitecture.Domain.Messaging;
using MediatR;

namespace CleanArchitecture.Domain.Common;

public record BaseQuery<T> : IRequest<T>;
