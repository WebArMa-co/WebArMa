using Mapster;
using Microsoft.EntityFrameworkCore;
using WebArMa.Application.Contexts;
using WebArMa.Application.Dtos;
using WebArMa.Application.Interfaces.Mediator;
using WebArMa.Application.Mappings;
using WebArMa.RealStates.Application.Dtos;
using WebArMa.RealStates.Domain;
using WebArMa.RealStates.Domain.Enums;

namespace WebArMa.RealStates.Application.GetPropertyList.GetPropertyListQuery
{
    public sealed record GetPropertyListQuery(
        int Page = 1,
        int PageSize = 20,

        PropertyType? PropertyType = null,
        UsageType? UsageType = null,
        PropertyStatus? Status = null,

        Guid? ProvinceGuid = null,
        Guid? CityGuid = null,
        Guid? NeighborhoodGuid = null,

        decimal? MinArea = null,
        decimal? MaxArea = null,

        int? MinRooms = null,
        int? MaxRooms = null,

        int? MinBedrooms = null,
        int? MaxBedrooms = null,

        int? Floor = null,

        int? MinYearBuilt = null,
        int? MaxYearBuilt = null,

        bool? HasParking = null,
        bool? HasStorage = null,
        bool? HasElevator = null,
        bool? HasBalcony = null,
        bool? HasTerrace = null,
        bool? HasYard = null,
        bool? HasPool = null,
        bool? HasSauna = null,
        bool? HasJacuzzi = null,
        bool? HasSecurity = null,
        bool? HasCCTV = null
    ) : IWebArMaQuery<PagedResult<PropertyListItemDto>>;

    public sealed class GetPropertyListQueryHandler(
    IWebArMaDbContext dbContext,
    WebArMaTypeAdapterConfig config)
    : IWebArMaQueryHandler<
        GetPropertyListQuery,
        PagedResult<PropertyListItemDto>>
    {
        public async ValueTask<PagedResult<PropertyListItemDto>> Handle(
            GetPropertyListQuery request,
            CancellationToken cancellationToken)
        {
            var page = Math.Max(request.Page, 1);
            var pageSize = Math.Clamp(request.PageSize, 1, 100);

            var query = dbContext
                .Set<Property>()
                .AsNoTracking();

            query = ApplyFilters(query, request);

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderByDescending(x => x.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectToType<PropertyListItemDto>(config)
                .ToListAsync(cancellationToken);

            return new PagedResult<PropertyListItemDto>(
                items,
                totalCount,
                page,
                pageSize);
        }

        private static IQueryable<Property> ApplyFilters(
            IQueryable<Property> query,
            GetPropertyListQuery request)
        {
            if (request.PropertyType.HasValue)
            {
                query = query.Where(x =>
                    x.PropertyType == request.PropertyType.Value);
            }

            if (request.UsageType.HasValue)
            {
                query = query.Where(x =>
                    x.UsageType == request.UsageType.Value);
            }

            if (request.Status.HasValue)
            {
                query = query.Where(x =>
                    x.Status == request.Status.Value);
            }

            if (request.ProvinceGuid.HasValue)
            {
                query = query.Where(x =>
                    x.Address.Neighborhood.City.Province.Guid ==
                    request.ProvinceGuid.Value);
            }

            if (request.CityGuid.HasValue)
            {
                query = query.Where(x =>
                    x.Address.Neighborhood.City.Guid ==
                    request.CityGuid.Value);
            }

            if (request.NeighborhoodGuid.HasValue)
            {
                query = query.Where(x =>
                    x.Address.Neighborhood.Guid ==
                    request.NeighborhoodGuid.Value);
            }

            if (request.MinArea.HasValue)
            {
                query = query.Where(x =>
                    x.Specifications.Area >= request.MinArea.Value);
            }

            if (request.MaxArea.HasValue)
            {
                query = query.Where(x =>
                    x.Specifications.Area <= request.MaxArea.Value);
            }

            if (request.MinRooms.HasValue)
            {
                query = query.Where(x =>
                    x.Specifications.Rooms >= request.MinRooms.Value);
            }

            if (request.MaxRooms.HasValue)
            {
                query = query.Where(x =>
                    x.Specifications.Rooms <= request.MaxRooms.Value);
            }

            if (request.MinBedrooms.HasValue)
            {
                query = query.Where(x =>
                    x.Specifications.Bedrooms >= request.MinBedrooms.Value);
            }

            if (request.MaxBedrooms.HasValue)
            {
                query = query.Where(x =>
                    x.Specifications.Bedrooms <= request.MaxBedrooms.Value);
            }

            if (request.Floor.HasValue)
            {
                query = query.Where(x =>
                    x.Specifications.Floor == request.Floor.Value);
            }

            if (request.MinYearBuilt.HasValue)
            {
                query = query.Where(x =>
                    x.Specifications.YearBuilt >= request.MinYearBuilt.Value);
            }

            if (request.MaxYearBuilt.HasValue)
            {
                query = query.Where(x =>
                    x.Specifications.YearBuilt <= request.MaxYearBuilt.Value);
            }

            if (request.HasParking.HasValue)
            {
                query = query.Where(x =>
                    x.Features.HasParking == request.HasParking.Value);
            }

            if (request.HasStorage.HasValue)
            {
                query = query.Where(x =>
                    x.Features.HasStorage == request.HasStorage.Value);
            }

            if (request.HasElevator.HasValue)
            {
                query = query.Where(x =>
                    x.Features.HasElevator == request.HasElevator.Value);
            }

            if (request.HasBalcony.HasValue)
            {
                query = query.Where(x =>
                    x.Features.HasBalcony == request.HasBalcony.Value);
            }

            if (request.HasTerrace.HasValue)
            {
                query = query.Where(x =>
                    x.Features.HasTerrace == request.HasTerrace.Value);
            }

            if (request.HasYard.HasValue)
            {
                query = query.Where(x =>
                    x.Features.HasYard == request.HasYard.Value);
            }

            if (request.HasPool.HasValue)
            {
                query = query.Where(x =>
                    x.Features.HasPool == request.HasPool.Value);
            }

            if (request.HasSauna.HasValue)
            {
                query = query.Where(x =>
                    x.Features.HasSauna == request.HasSauna.Value);
            }

            if (request.HasJacuzzi.HasValue)
            {
                query = query.Where(x =>
                    x.Features.HasJacuzzi == request.HasJacuzzi.Value);
            }

            if (request.HasSecurity.HasValue)
            {
                query = query.Where(x =>
                    x.Features.HasSecurity == request.HasSecurity.Value);
            }

            if (request.HasCCTV.HasValue)
            {
                query = query.Where(x =>
                    x.Features.HasCCTV == request.HasCCTV.Value);
            }

            return query;
        }
    }

}
