using CleanArchitecture.Domain.Messaging;
using MediatR;

namespace CleanArchitecture.Domain.Common;

public record BaseCommand<T> : IRequest<T>, ICommand;
