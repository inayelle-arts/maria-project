using System.Threading.Tasks;
using BusinessLayer.Constraints;
using DataAccessLayer.Entities;
using BoardTask = DataAccessLayer.Entities.Task;

namespace BusinessLayer.Commands
{
	public sealed class TaskMoveCommand : CommandBase
    {
		public BoardTask Task         { get; set; }
		public Column TargetColumn { get; set; }

        public override bool IsValid => Task!=null&&TargetColumn!=null;

        public async Task<ConstraintValidationResultSet> Accept(IConstraintValidator<TaskMoveCommand> validator)
		{
			return await validator.ValidateAsync(this);
		}
	}
}