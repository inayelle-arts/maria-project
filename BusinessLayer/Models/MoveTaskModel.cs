using System.Threading.Tasks;
using BusinessLayer.Constraints;
using DataAccessLayer.Entities;
using Task = DataAccessLayer.Entities.Task;

namespace BusinessLayer.Models
{
	public sealed class MoveTaskModel
	{
		public Task   Task         { get; set; }
		public Column TargetColumn { get; set; }
		public User   User         { get; set; }

		public async Task<ConstraintValidationResultSet> Accept(IConstraintValidator validator)
		{
			return await validator.ValidateAsync(this);
		}
	}
}