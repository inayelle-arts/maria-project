using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Commands;
using BusinessLayer.Constraints;
using BusinessLayer.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TestApi.Controllers.Response;
using TestApi.ViewModels;

namespace TestApi.Infrastructure
{
	public class CommandValidationFilter<TViewModel, TCommand> : IAsyncActionFilter where TCommand : CommandBase
	                                                                                where TViewModel : ViewModelBase
	{
		private readonly CommandFactory<TCommand> _commandFactory;
		private readonly ConstraintManager        _constraintManager;

		public CommandValidationFilter(CommandFactory<TCommand> commandFactory, ConstraintManager constraintManager)
		{
			_commandFactory    = commandFactory;
			_constraintManager = constraintManager;
		}

		public async Task OnActionExecutionAsync(ActionExecutingContext actionContext, ActionExecutionDelegate next)
		{
			if (!actionContext.ModelState.IsValid)
			{
				actionContext.Result =
						new JsonResult(ResponseResultSetBase.FromInvalidModelState(actionContext.ModelState));
				return;
			}

			foreach (var argument in actionContext.ActionArguments.Values.Where(v => v is TViewModel))
			{
				TViewModel model   = argument as TViewModel;
				var        command = await _commandFactory.CreateCommandAsync(model);
				actionContext.RouteData.Values.Add("command", command);

				var constraintResult = await ProcessCommand(command);

				if (constraintResult == null)
				{
					break;
				}

				if (!constraintResult.IsValid)
				{
					actionContext.Result = new JsonResult(ResponseResultSetBase.FromConstraintResult(constraintResult));
					return;
				}
			}

			await next();
		}

		private async Task<ConstraintValidationResultSet> ProcessCommand(TCommand command)
		{
			ConstraintValidationResultSet resultSet = null;

			if (command is TaskMoveCommand mtc)
			{
				resultSet = await _constraintManager.ValidateConstraintsAsync(mtc);
			}

			return resultSet;
		}
	}
}