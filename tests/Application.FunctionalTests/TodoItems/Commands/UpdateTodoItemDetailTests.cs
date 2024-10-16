﻿using CleanArchitecture.Application.TodoItems.Commands.CreateTodoItem;
using CleanArchitecture.Application.TodoItems.Commands.UpdateTodoItem;
using CleanArchitecture.Application.TodoItems.Commands.UpdateTodoItemDetail;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.FunctionalTests.TodoItems.Commands;

using static Testing;

public class UpdateTodoItemDetailTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoItemId()
    {
        var command = new UpdateTodoItemCommand { Id = Guid.NewGuid(), Title = "New Title" };
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public Task ShouldUpdateTodoItem()
    {
        //var userId = await RunAsDefaultUserAsync();

        //var itemId = await SendAsync(new CreateTodoItemCommand
        //{
        //    Title = "New Item"
        //});

        //var command = new UpdateTodoItemDetailCommand
        //{
        //    Id = itemId,
        //    Note = "This is the note.",
        //    Priority = PriorityLevel.High
        //};

        //await SendAsync(command);

        //var item = await FindAsync<TodoItem>(itemId);

        //item.Should().NotBeNull();
        //item!.ListId.Should().Be(command.ListId);
        //item.Note.Should().Be(command.Note);
        //item.Priority.Should().Be(command.Priority);
        //item.LastModifiedBy.Should().NotBeNull();
        //item.LastModifiedBy.Should().Be(userId);
        //item.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));

        return Task.CompletedTask;
    }
}
