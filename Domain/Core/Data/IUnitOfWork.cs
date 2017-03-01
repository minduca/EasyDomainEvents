using System.Threading.Tasks;

namespace Minduca.Domain.Core.Data
{
	/// <summary>
	/// Unit of work that handles the database connection
	/// </summary>
	public interface IUnitOfWork
	{
        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        void Save();
    }
}