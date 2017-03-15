using System;

namespace com.mytube.mini.core.Contracts
{
    public interface IEntityCreatable : IEntity
    {
        /// <summary>
        /// Created Date, will be used in CreateRepository
        /// </summary>
        DateTime CreatedDate { get; set; }

        /// <summary>
        /// Initialize th entity
        /// </summary>
        /// <returns>True if successfully created otherwise false</returns>
        bool Create();
    }
}
