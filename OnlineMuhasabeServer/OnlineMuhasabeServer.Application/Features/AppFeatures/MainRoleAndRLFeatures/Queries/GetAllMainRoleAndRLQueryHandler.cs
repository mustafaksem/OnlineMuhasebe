using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRLFeatures.Queries
{
    public sealed class GetAllMainRoleAndRLQueryHandler : 
        IQueryHandler<GetAllMainRoleAndRLQuery, GetAllMainRoleAndRLQueryResponse>
    {
        private readonly IMainRoleAndRoleRelationshipService _roleRelationshipService;

        public GetAllMainRoleAndRLQueryHandler(IMainRoleAndRoleRelationshipService roleRelationshipService)
        {
            _roleRelationshipService = roleRelationshipService;
        }

        public async Task<GetAllMainRoleAndRLQueryResponse> Handle(GetAllMainRoleAndRLQuery request, CancellationToken cancellationToken)
        {
            return new( await _roleRelationshipService
                .GetAll()
                .Include("AppRole")
                .Include("MainRole")
                .ToListAsync());

        }
    }
}
