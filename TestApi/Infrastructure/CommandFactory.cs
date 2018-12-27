using System;
using System.Threading.Tasks;
using BusinessLayer.Commands;
using BusinessLayer.Managers;
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
                case TaskMoveCommand taskMoveCommand:
                    MoveTaskViewModel moveTaskViewModel = viewModel as MoveTaskViewModel;
                    if (moveTaskViewModel == null)
                    {
                        throw new ArgumentException(_invalidViewModelTypeErrorMessage);
                    }
                    taskMoveCommand.Task = await _taskManager.GetAsync(moveTaskViewModel.TaskId);
                    taskMoveCommand.TargetColumn = await _columnManager.GetAsync(moveTaskViewModel.TargetColumnId);
                    break;

                case TaskCreateCommand taskCreateCommand:
                    CreateTaskViewModel createTaskViewModel = viewModel as CreateTaskViewModel;
                    if (createTaskViewModel==null)
                    {
                        throw new ArgumentException(_invalidViewModelTypeErrorMessage);
                    }
                    taskCreateCommand.Column = await _columnManager.GetAsync(createTaskViewModel.ColumnId);
                    taskCreateCommand.Name = createTaskViewModel.Name;
                    break;
            }
        }
    }
}
