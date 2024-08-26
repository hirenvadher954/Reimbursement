using Entities.Models;

namespace Service.Contracts;

public interface IServiceBase<TDocument, TDto, TId>
    where TDocument : BaseEntity<TId>
{
    /// <summary>
    /// Gets the document by id.
    /// </summary>
    /// <param name="id">The id of the document.</param>
    /// <returns>the document matching the provided id.</returns>
    Task<TDto> GetItemByIdAsync(TId id);

    /// <summary>
    /// Creates a new document.
    /// </summary>
    /// <param name="document">The document to create.</param>
    /// <returns>the result contains the new document.</returns>
    Task<TDto> CreateItemAsync(TDto document);

    /// <summary>
    /// Updates a document.
    /// </summary>
    /// <param name="id">The id of the document to update.</param>
    /// <param name="document">The document to update.</param>
    /// <returns>the result contains the updated document.</returns>
    Task<TDto> UpdateItemAsync(TId id, TDto document);

    /// <summary>
    /// DeleteItemAsync method.
    /// </summary>
    /// <param name="id">id.</param>
    /// <returns> true if the document was deleted.</returns>
    Task<bool> DeleteItemAsync(TId id);


    /// <summary>
    /// Get all items.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<TDto>> GetAllItemsAsync();
}