using System.Threading.Tasks;
using BusinessLayer.Models;

namespace BusinessLayer.Constraints
{
	public interface IConstraintValidator
	{
		Task<ConstraintValidationResultSet> ValidateAsync(MoveTaskModel model);
	}
}