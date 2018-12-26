using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Managers;
using BusinessLayer.Models;
using TestApi.ViewModels;

namespace TestApi.Infrastructure
{
    public class CommandFactory<TModel> where TModel : CommandBase
    {
        private readonly TaskManager _taskManager;
        private readonly ColumnManager _columnManager;
        private readonly UserManager _userManager;
        private readonly ConstraintManager _constraintManager;
        private readonly string _invalidViewModelTypeErrorMessage = "VM type is not supported via this command";


        public CommandFactory(TaskManager taskManager,
            ConstraintManager constraintManager,
            ColumnManager columnManager,
            UserManager userManager)
        {
            _taskManager = taskManager;
            _columnManager = columnManager;
            _userManager = userManager;
            _constraintManager = constraintManager;
        }

        public async Task<TModel> CreateCommandAsync<TViewModel>(TViewModel viewModel) where TViewModel:ViewModelBase
        {
            var command = Activator.CreateInstance<TModel>();

            command.User = await _userManager.GetCurrentUserAsync();
            command.InitiationDate = DateTime.Now;

            await FillTypeSpecificCommandFields(command,viewModel);
            return command;
        }

        private async Task FillTypeSpecificCommandFields(TModel command, ViewModelBase viewModel)
        {
            switch (command)
            {
                case MoveTaskCommand moveTaskCommand:
                    MoveTaskViewModel moveTaskViewModel = viewModel as MoveTaskViewModel;
                    if (moveTaskViewModel == null)
                    {
                        throw new ArgumentException(_invalidViewModelTypeErrorMessage);
                    }
                    moveTaskCommand.Task = await _taskManager.GetAsync(moveTaskViewModel.TaskId);
                    moveTaskCommand.TargetColumn = await _columnManager.GetAsync(moveTaskViewModel.TargetColumnId);
                    break;
            }
        }
    }
}
