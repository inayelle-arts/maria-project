using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Constraints;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TestApi.Controllers.Response
{
    public class ResponseResultSetBase
    {
        public ResponseStatus Status { get; set; }
        public string Message { get; set; }

        public static ResponseResultSetBase FromConstraintResult(ConstraintValidationResultSet resultSet)
        {
            if (!resultSet.IsValid)
            {
                return new ResponseResultSet<IEnumerable<string>>()
                {
                    Status = ResponseStatus.Failed,
                    Message = "Constraint test failed",
                    Data = resultSet.Errors
                };

            }
            return new ResponseResultSet<Empty>()
            {
                Status = ResponseStatus.Success,
                Message = "OK"
            };
        }

        public static ResponseResultSetBase FromConstraintResult<T>(ConstraintValidationResultSet resultSet, T data)
        {
            if (!resultSet.IsValid)
            {
                return new ResponseResultSet<IEnumerable<string>>()
                {
                    Status = ResponseStatus.Failed,
                    Message = "Constraint test failed",
                    Data = resultSet.Errors
                };
            }
            return new ResponseResultSet<T>()
            {
                Status = ResponseStatus.Success,
                Message = "OK",
                Data = data
            };
        }

        public static ResponseResultSetBase FromInvalidModelState(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
            return new ResponseResultSet<IEnumerable<string>>
            {
                Status = ResponseStatus.Failed,
                Message = "Model state is invalid",
                Data = errors
            };
        }

    }
}
