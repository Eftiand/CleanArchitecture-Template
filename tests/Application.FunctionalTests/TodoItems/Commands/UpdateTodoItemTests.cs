﻿using CleanArchitecture.Application.TodoItems.Commands.CreateTodoItem;
using CleanArchitecture.Application.TodoItems.Commands.UpdateTodoItem;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.FunctionalTests.TodoItems.Commands;

using static Testing;

public class UpdateTodoItemTests : BaseTestFixture
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
       // var userId = await RunAsDefaultUserAsync();

       // var itemId = await SendAsync(new CreateTodoItemCommand
       // {
       //     Title = "New Item"
       // });

       // var command = new UpdateTodoItemCommand
       // {
       //     Id = itemId,
       //     Title = "Updated Item Title"
       // };

       // await SendAsync(command);

       // var item = await FindAsync<TodoItem>(itemId);

       // item.Should().NotBeNull();
       // item!.Title.Should().Be(command.Title);
       // item.LastModifiedBy.Should().NotBeNull();
       // item.LastModifiedBy.Should().Be(userId);
       // item.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));

         return Task.CompletedTask;
    }
}
