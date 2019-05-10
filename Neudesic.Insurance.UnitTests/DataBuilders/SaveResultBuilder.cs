using Neudesic.Insurance.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neudesic.Insurance.UnitTests.DataBuilders
{
    public class SaveResultBuilder<T>
    {
        private readonly SaveResult<T> _result;

        public SaveResultBuilder()
        {
            _result = new SaveResult<T>
            {
                IsSuccess = true,
                Message = string.Empty,
                Data = default(T)
            };
        }

        public SaveResultBuilder<T> Success()
        {
            _result.IsSuccess = true;
            return this;
        }

        public SaveResultBuilder<T> Failed()
        {
            _result.IsSuccess = false;
            return this;
        }

        public SaveResultBuilder<T> WithMessage(string message)
        {
            _result.Message = message;
            return this;
        }

        public SaveResultBuilder<T> WithData(T data)
        {
            _result.Data = data;
            return this;
        }

        public SaveResult<T> Build()
        {
            return _result;
        }
    }
}
