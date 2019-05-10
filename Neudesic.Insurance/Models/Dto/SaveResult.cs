using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neudesic.Insurance.Models.Dto
{
    /// <summary>
    /// Save result with common information
    /// Use this when details about entity is not required
    /// </summary>
    public class SaveResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    /// <summary>
    /// Save result with details of of entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SaveResult<T>: SaveResult
    {
        public T Data { get; set; }
    }
}
