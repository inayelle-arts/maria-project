using System.Threading.Tasks;
using BusinessLayer.Constraints;
using DataAccessLayer.Entities;
using Task = DataAccessLayer.Entities.Task;

namespace BusinessLayer.Models
{
	public sealed class MoveTaskCommand : CommandBase
    {
		public Task   Task         { get; set; }
		public Column TargetColumn { get; set; }

        public bool IsValid {
            get
            {
                return Task!=null&&TargetColumn!=null;
            }
        }

        public async Task<ConstraintValidationResultSet> Accept(IConstraintValidator<MoveTaskCommand> validator)
		{
			return await validator.ValidateAsync(this);
		}
	}
}