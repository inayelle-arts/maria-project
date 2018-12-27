using System.Collections.Generic;

namespace BusinessLayer.Constraints
{
	public sealed class ConstraintValidationResultSet
	{
		public bool         IsValid => Errors.Count == 0;
		public List<string> Errors  { get; }

		public ConstraintValidationResultSet(List<string> errors = null)
		{
			Errors = errors ?? new List<string>();
		}

		public void AppendErrors(ConstraintValidationResultSet another)
		{
			Errors.AddRange(another.Errors);
		}
	}
}