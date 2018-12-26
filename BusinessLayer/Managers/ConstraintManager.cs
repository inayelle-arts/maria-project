using System.Threading.Tasks;
using BusinessLayer.Constraints;
using BusinessLayer.Models;
using DataAccessLayer;

namespace BusinessLayer.Managers
{
	public sealed class ConstraintManager
	{
		private readonly DefaultContext _context;

		public ConstraintManager(DefaultContext context)
		{
			_context = context;
		}

		public async Task<ConstraintValidationResultSet> ValidateConstraintsAsync(MoveTaskModel model)
		{
			var lockedConstraint = new LockedTaskConstraint(_context);
			return await model.Accept(lockedConstraint);
		}
	}
}