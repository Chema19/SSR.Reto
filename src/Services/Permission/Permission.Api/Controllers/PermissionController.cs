using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Permission.Service.EventHandlers.Commands;
using Permission.Service.Queries;
using Permission.Service.Queries.DTOs;
using Service.Common.Collection;

namespace Permission.Api.Controllers
{
    [ApiController]
    [Route("permissions")]
    public class PermissionController : ControllerBase
    {
        private readonly ILogger<PermissionController> _logger;
        private readonly IPermissionQueryService _permissionQueryService;
        private readonly IMediator _mediator;

        public PermissionController(ILogger<PermissionController> logger,
            IPermissionQueryService permissionQueryService,
            IMediator mediator)
        {
            _logger = logger;
            _permissionQueryService = permissionQueryService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<PermissionsDto>> GetAll(int page = 1, int take = 10, string ids = null)
        {
            IEnumerable<int> permissions = null;
            if (!string.IsNullOrEmpty(ids))
            {
                permissions = ids.Split(',').Select(x => Convert.ToInt32(x));
            }
            return await _permissionQueryService.GetAllAsync(page, take, permissions);
        }
        [HttpGet("{id}")]
        public async Task<PermissionsDto> Get(int id)
        {
            return await _permissionQueryService.GetAsync(id);
        }
        [HttpPost]
        public async Task<IActionResult> Create(PermissionCreateCommand command)
        {
            await _mediator.Publish(command);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PermissionUpdateCommand command)
        {
            command.Id = id;
            await _mediator.Publish(command);
            return Ok();
        }
    }
}
