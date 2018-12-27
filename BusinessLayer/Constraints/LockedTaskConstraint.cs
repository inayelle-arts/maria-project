using System.Threading.Tasks;
using BusinessLayer.Commands;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Constraints
{
	public sealed class LockedTaskConstraint : ConstraintValidatorBase, IConstraintValidator<TaskMoveCommand>
	{
		private readonly DefaultContext _context;

		public LockedTaskConstraint(DefaultContext context)
		{
			_context = context;
		}

		public async Task<ConstraintValidationResultSet> ValidateAsync(TaskMoveCommand command)
		{
		    if (!command.IsValid)
		    {
                return new ConstraintValidationResultSet()
                {
                    Errors =
                    {
                        "Command data is not valid"
                    }
                };
		    }

		    var constraint = await _context.SequentialTaskConstraints
			                               .FirstOrDefaultAsync(c => c.OwnerId == command.Task.Id);

			if (constraint == null)
			{
				return new ConstraintValidationResultSet();
			}

			return new ConstraintValidationResultSet
			{
					Errors = { "Task is locked by parent task + " + constraint.ParentTaskId }
			};
		}
	}
}