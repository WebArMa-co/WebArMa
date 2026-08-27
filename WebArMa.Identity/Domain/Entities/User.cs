using WebArMa.Domain.Entities;
using WebArMa.Identity.Domain.Helpers;

namespace WebArMa.Identity.Domain.Entities
{
    public record User : WebArMaEntityBase
    {
        public static User Create(string firstName, string lastName, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("نام الزامی است");
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("نام خانوادگی الزامی است");
            }

            if (!IranianPhoneNumber.IsValid(phoneNumber))
            {
                throw new ArgumentException("شماره تماس وارد شده معتبر نمی‌باشد");
            }

            return new User
            {
                FirstName = firstName.Trim(),
                LastName = lastName.Trim(),
                PhoneNumber = phoneNumber.Trim()
            };
        }

        public User()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            PhoneNumber = string.Empty;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
    }
}
