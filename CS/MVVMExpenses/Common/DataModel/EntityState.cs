using System;
using System.Linq;

namespace MVVMExpenses.Common.DataModel {
    /// <summary>
    /// Represents the state of the entity relative to the unit of work.
    /// </summary>
    public enum EntityState {

        /// <summary>
        /// The object exists but is not being tracked. 
        /// An entity is in this state immediately after it has been created and before it is added to the unit of work. 
        /// An entity is also in this state after it has been removed from the unit of work by calling the IUnitOfWork.Detach method.
        /// </summary>
        Detached = 1,

        /// <summary>
        /// The object has not been modified since it was attached to the unit of work or since the last time that the IUnitOfWork.SaveChanges method was called.
        /// </summary>
        Unchanged = 2,

        /// <summary>
        /// The object is new, has been added to the unit of work, and the IUnitOfWork.SaveChanges method has not been called. 
        /// After the changes are saved, the object state changes to Unchanged.
        /// </summary>
        Added = 4,

        /// <summary>
        /// The object has been deleted from the unit of work. After the changes are saved, the object state changes to Detached.
        /// </summary>
        Deleted = 8,

        /// <summary>
        /// One of the scalar properties on the object has been modified and the IUnitOfWork.SaveChanges method has not been called. 
        /// After the changes are saved, the object state changes to Unchanged.
        /// </summary>
        Modified = 16,
    }
}
