using System.Threading.Tasks;
using BusinessLayer.Commands;

namespace BusinessLayer.Constraints
{
	public interface IConstraintValidator<T> where T:CommandBase
	{
		Task<ConstraintValidationResultSet> ValidateAsync(T command);
	}
}