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
        /// Initialize the entity
        /// </summary>
        bool Create();
    }
}
