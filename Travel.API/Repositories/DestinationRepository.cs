﻿using Travel.API.Contracts;
using Travel.API.Entities;
using Travel.API.Entities.Context;

namespace Travel.API.Repositories
{
    public class DestinationRepository : 
        RepositoryBase<Destination>, IDestinationRepository
    {
        public DestinationRepository(TravelPlannerDbContext dbContext) : base(dbContext){
        }
    }
}
