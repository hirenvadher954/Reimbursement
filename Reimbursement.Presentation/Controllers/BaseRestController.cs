using System.Reflection.Metadata;
using Entities.Exceptions;
using Entities.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reimbursement.Presentation.ActionFilters;
using Service.Contracts;

namespace Reimbursement.Presentation.Controllers;

public abstract class BaseRestController<TDocument, TDTO, TId> : ControllerBase
    where TDocument : BaseEntity<TId>

{
    private readonly IServiceBase<TDocument, TDTO, TId> _service;
    private readonly IValidator<TDTO>? _validator;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseRestController{TDocument, TDto, TId}"/> class.
    /// </summary>
    /// <param name="service">base service</param>
    /// <param name="validator">validator</param>
    protected BaseRestController(IServiceManager service, IValidator<TDTO>? validator = null)
    {
        _service = service.GetServiceBase<TDocument, TDTO, TId>();
        _validator = validator;
    }

    /// <summary>
    /// Get the entity.
    /// </summary>
    /// <param name="id">The Id.</param>
    /// <returns>Action result with dto.</returns>
    /// <exception cref="NotFoundException">Not found exception.</exception>
    [Route("{id:guid}")]
    [HttpGet]
    public virtual async Task<IActionResult> GetEntity([FromRoute] TId id)
    {
        var result = await _service.GetItemByIdAsync(id);
        return Ok(result);
    }

    /// <summary>
    /// Add entity.
    /// </summary>
    /// <param name="dto">The dto to be added.</param>
    /// <returns>The dto added.</returns>
    [Route("")]
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public virtual async Task<IActionResult> AddEntity([FromBody] TDTO dto)
    {
        var createdDto = await PerformValidation(dto, async () => await _service.CreateItemAsync(dto));
        return Ok(createdDto);
    }

    /// <summary>
    /// Update entity.
    /// </summary>
    /// <param name="id">The id of the entity.</param>
    /// <param name="dto">The dto to be updated.</param>
    /// <returns>The dto updated.</returns>
    [Route("{id:guid}")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public virtual async Task<IActionResult> UpdateEntity([FromRoute] TId id, [FromBody] TDTO dto)
    {
        return await PerformValidation(dto, async () => await _service.UpdateItemAsync(id, dto));
    }

    /// <summary>
    /// Delete entity.
    /// </summary>
    /// <param name="id">The id of the entity.</param>
    /// <returns>True if deleted.</returns>
    [Route("{id:guid}")]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public virtual async Task<ActionResult<bool>> DeleteEntity([FromRoute] TId id)
    {
        return await _service.DeleteItemAsync(id);
    }


    // <summary>
    /// Get all entities.
    /// </summary>
    /// <returns>The list of entities.</returns>
    [Route("")]
    [HttpGet]
    public virtual async Task<IActionResult> GetAllEntities()
    {
        var result = await _service.GetAllItemsAsync();
        return Ok(result);
    }


    /// <summary>
    /// Perform validation based on the dto fluentvalidator
    /// </summary>
    /// <param name="dto">dto</param>
    /// <param name="action">action</param>
    /// <returns>Task of action result</returns>
    protected async Task<IActionResult> PerformValidation(TDTO dto, Func<Task<TDTO>> action)
    {
        try
        {
            if (_validator == null)
            {
                dto = await action.Invoke();
                return Ok(dto);
            }

            var result = await _validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            dto = await action.Invoke();
            return Ok(dto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
}