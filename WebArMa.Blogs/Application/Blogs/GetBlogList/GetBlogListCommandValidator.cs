using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebArMa.Application.Abstractions.Mediator;
using WebArMa.Application.Dtos;
using WebArMa.Blogs.Application.Blogs.Dtos;

namespace WebArMa.Blogs.Application.Blogs.GetBlogList
{
    public class GetBlogListCommandValidator : WebArMaCommandValidation<GetBlogListCommand, PagedResult<BlogDto>>
    {
        public GetBlogListCommandValidator()
        {
            RuleFor(x => x.PageNumber).GreaterThan(0).WithMessage("شماره صفحه باید بزرگتر از صفر باشد");
            RuleFor(x => x.PageSize).GreaterThan(0).LessThanOrEqualTo(100).WithMessage("تعداد آیتم در صفحه باید بین 1 تا 100 باشد");
            RuleFor(x => x.Status).IsInEnum().When(x => x.Status.HasValue).WithMessage("وضعیت مطلب معتبر نیست");
            RuleFor(x => x.Search).MaximumLength(200).When(x => !string.IsNullOrWhiteSpace(x.Search)).WithMessage("عبارت جستجو نمی‌تواند بیشتر از 200 کاراکتر باشد");
        }
    }
}
