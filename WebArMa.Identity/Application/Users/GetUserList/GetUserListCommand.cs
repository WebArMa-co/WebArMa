using WebArMa.Application.Dtos;
using WebArMa.Application.Enums.Sort;
using WebArMa.Application.Interfaces.Mediator;
using WebArMa.Identity.Application.Users.Dtos;
using WebArMa.Identity.Application.Users.Enums;

namespace WebArMa.Identity.Application.Users.GetUserList
{
	public class GetUserListCommand(int pageNumber = 1, int pageSize = 10, string? search = null, bool? profileCompleted = null) : IWebArMaCommand<PagedResult<UserDto>>
	{
		public int PageNumber { get; private set; } = pageNumber;
		public int PageSize { get; private set; } = pageSize;
		public string? Search { get; private set; } = search;
		public bool? ProfileCompleted { get; private set; } = profileCompleted;
		public SortType SortType { get; set; } = SortType.Descending;
		public UserSort SortBy { get; set; } = UserSort.CreateTime;
	}
}