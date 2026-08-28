using FluentValidation;
using WebArMa.Application.Abstractions.Mediator;

namespace WebArMa.Blogs.Application.Blogs.CreateBlog
{
    public class CreateBlogCommandValidator : WebArMaValidation<CreateBlogCommand, Guid>
    {
        public CreateBlogCommandValidator()
        {
            RuleFor(b => b.Title)
                .NotEmpty()
                .WithMessage("عنوان مطلب الزامی است")
                .MaximumLength(200)
                .WithMessage("عنوان مطلب نمی‌تواند بیشتر از 200 کاراکتر باشد");

            RuleFor(b => b.Slug)
                .NotEmpty()
                .WithMessage("اسلاگ مطلب الزامی است")
                .MaximumLength(200)
                .WithMessage("اسلاگ مطلب نمی‌تواند بیشتر از 200 کاراکتر باشد");

            RuleFor(b => b.Content)
                .NotEmpty()
                .WithMessage("محتوای مطلب الزامی است");

            RuleFor(b => b.BlogCategoryIds)
                .NotNull()
                .WithMessage("انتخاب حداقل یک دسته‌بندی الزامی است")
                .NotEmpty()
                .WithMessage("انتخاب حداقل یک دسته‌بندی الزامی است");

            RuleForEach(b => b.BlogCategoryIds)
                .NotEmpty()
                .WithMessage("شناسه دسته‌بندی معتبر نیست");

            RuleFor(b => b.MetaDescription)
                .NotEmpty()
                .WithMessage("توضیحات متا الزامی است")
                .MaximumLength(160)
                .WithMessage("توضیحات متا نمی‌تواند بیشتر از 160 کاراکتر باشد");

            RuleFor(b => b.MetaTitle)
                .MaximumLength(60)
                .WithMessage("عنوان متا نمی‌تواند بیشتر از 60 کاراکتر باشد")
                .When(b => !string.IsNullOrWhiteSpace(b.MetaTitle));

            RuleFor(b => b.CanonicalUrl)
                .MaximumLength(500)
                .WithMessage("آدرس Canonical نمی‌تواند بیشتر از 500 کاراکتر باشد")
                .Must(BeValidUrl)
                .WithMessage("آدرس Canonical معتبر نیست")
                .When(b => !string.IsNullOrWhiteSpace(b.CanonicalUrl));

            RuleFor(b => b.OgImage)
                .MaximumLength(500)
                .WithMessage("آدرس تصویر OG نمی‌تواند بیشتر از 500 کاراکتر باشد")
                .Must(BeValidUrl)
                .WithMessage("آدرس تصویر OG معتبر نیست")
                .When(b => !string.IsNullOrWhiteSpace(b.OgImage));

            RuleFor(b => b.CoverImage)
                .MaximumLength(500)
                .WithMessage("آدرس تصویر کاور نمی‌تواند بیشتر از 500 کاراکتر باشد")
                .Must(BeValidUrl)
                .WithMessage("آدرس تصویر کاور معتبر نیست")
                .When(b => !string.IsNullOrWhiteSpace(b.CoverImage));

            RuleFor(b => b.PublishedAt)
                .NotEmpty()
                .WithMessage("تاریخ انتشار الزامی است");

            RuleFor(b => b.Status)
                .IsInEnum()
                .WithMessage("وضعیت مطلب معتبر نیست");
        }

        private static bool BeValidUrl(string? url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out var uri)
                   && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
        }
    }
}
