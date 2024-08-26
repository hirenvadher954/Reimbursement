namespace Entities.Models.DataTransferObjects;

public abstract class BaseEntityDTO<TId>
{
    public TId Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}