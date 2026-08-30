using Mapster;
using Microsoft.EntityFrameworkCore;
using WebArMa.Application.Contexts;
using WebArMa.Application.Dtos;
using WebArMa.Application.Enums.Sort;
using WebArMa.Application.Interfaces.Mediator;
using WebArMa.Application.Mappings;
using WebArMa.Common.Extensions;
using WebArMa.Identity.Application.Users.Dtos;
using WebArMa.Identity.Application.Users.Enums;
using WebArMa.Identity.Domain.Entities;

namespace WebArMa.Identity.Application.Users.GetUserList
{
	public class GetUserListCommandHandler(IWebArMaDbContext dbContext, WebArMaTypeAdapterConfig config) : IWebArMaCommandHandler<GetUserListCommand, PagedResult<UserDto>>
	{
		public async ValueTask<PagedResult<UserDto>> Handle(GetUserListCommand request, CancellationToken cancellationToken)
		{
			var query = dbContext.Set<User>().AsNoTracking().AsQueryable();

			if (!string.IsNullOrWhiteSpace(request.Search))
			{
				var search = request.Search.Trim();
				query = query.Where(u => u.PhoneNumber.Contains(search) || u.FirstName!.Contains(search) || u.LastName!.Contains(search) || u.DisplayName!.Contains(search));
			}

			if (request.ProfileCompleted.HasValue)
			{
				query = query.Where(u => u.ProfileCompleted == request.ProfileCompleted.Value);
			}

			query = ApplySort(query, request.SortBy, request.SortType);

			var totalCount = await query.CountAsync(cancellationToken: cancellationToken);
			query = query.Paginate(request.PageNumber, request.PageSize);
			var users = await query.ProjectToType<UserDto>(config).ToListAsync(cancellationToken);

			return new PagedResult<UserDto>(users, totalCount, request.PageNumber, request.PageSize);
		}

		private static IQueryable<User> ApplySort(IQueryable<User> query, UserSort sortBy, SortType sortType)
		{
			return (sortBy, sortType) switch
			{
				(UserSort.CreateTime, SortType.Ascending) => query.OrderBy(u => u.CreatedAt),
				(UserSort.CreateTime, SortType.Descending) => query.OrderByDescending(u => u.CreatedAt),
				(UserSort.UpdateTime, SortType.Ascending) => query.OrderBy(u => u.UpdatedAt),
				(UserSort.UpdateTime, SortType.Descending) => query.OrderByDescending(u => u.UpdatedAt),
				(UserSort.PhoneNumber, SortType.Ascending) => query.OrderBy(u => u.PhoneNumber),
				(UserSort.PhoneNumber, SortType.Descending) => query.OrderByDescending(u => u.PhoneNumber),
				_ => query.OrderByDescending(u => u.CreatedAt)
			};
		}
	}
}