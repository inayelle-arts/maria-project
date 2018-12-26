using System.Threading.Tasks;
using BusinessLayer.Constraints;
using BusinessLayer.Models;
using DataAccessLayer;

namespace BusinessLayer.Managers
{
	public sealed class ConstraintManager
	{
		private readonly DefaultContext _context;
	    private readonly ConstraintCollection _constraints;

		public ConstraintManager(DefaultContext context, ConstraintCollection constraints)
		{
			_context = context;
		    _constraints = constraints;
		}

		public async Task<ConstraintValidationResultSet> ValidateConstraintsAsync(MoveTaskCommand model)
		{
			var lockedConstraint = _constraints.GetConstraint<LockedTaskConstraint>();
			return await model.Accept(lockedConstraint);
		}
	}
}