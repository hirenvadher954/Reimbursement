using System.Linq.Expressions;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Service.Contracts;

namespace Service;

public class ServiceBase<TDocument, TDto, TId> : IServiceBase<TDocument, TDto, TId>
    where TDocument : BaseEntity<TId>
{
    private readonly IRepositoryBase<TDocument> _repository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceBase{TDocument,TDto}"/> class.
    /// </summary>
    /// <param name="repository">repository.</param>
    /// <param name="mapper">mapper.</param>
    public ServiceBase(IRepositoryManager repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository.GetRepository<TDocument, TId>();
    }

    /// <inheritdoc/>
    public async Task<TDto> GetItemByIdAsync(TId id)
    {
        TDocument document = await GetEntityAndCheckIfItExists(id);
        return _mapper.Map<TDto>(document);
    }

    /// <inheritdoc/>
    public async Task<TDto> CreateItemAsync(TDto dto)
    {
        TDocument document = _mapper.Map<TDocument>(dto);
        _repository.Create(document);
        await _repository.SaveAsync();
        TDto documentToReturn = _mapper.Map<TDto>(document);
        return documentToReturn;
    }

    /// <inheritdoc/>
    public async Task<TDto> UpdateItemAsync(TId id, TDto dto)
    {
        TDocument document = _mapper.Map<TDocument>(dto);
        _repository.Update(document);
        await _repository.SaveAsync();
        TDto documentToReturn = _mapper.Map<TDto>(document);
        return documentToReturn;
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteItemAsync(TId id)
    {
        TDocument document = await GetEntityAndCheckIfItExists(id, true);
        await _repository.SaveAsync();
        return true;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<TDto>> FindByConditionsAsync(Expression<Func<TDocument, bool>> conditions)
    {
        IEnumerable<TDocument> documents = await _repository.FindByCondition(conditions, false).ToListAsync();
        return _mapper.Map<IEnumerable<TDto>>(documents);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<TDto>> GetAllItemsAsync()
    {
        IEnumerable<TDocument> documents = await _repository.FindAll(trackChanges: false).ToListAsync();
        return _mapper.Map<IEnumerable<TDto>>(documents);
    }

    private async Task<TDocument> GetEntityAndCheckIfItExists(TId id, bool trackChanges = false)
    {
        TDocument? document = (await _repository.FindByCondition(x => x.Id.Equals(id), trackChanges).ToListAsync())
            .SingleOrDefault();
        return document ?? throw new NotFoundException($"Entity not found with id:- {id}");
    }
}