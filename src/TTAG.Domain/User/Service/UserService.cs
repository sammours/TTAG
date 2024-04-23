namespace TTAG.Domain.Service
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Model;
    using TTAG.Domain.Cryptography;
    using TTAG.Domain.Repository;
    using TTAG.Domain.Validation;

    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly VividHashing hashing;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            this.hashing = new VividHashing();
        }

        public async Task<User> AddOrUpdateAsync(User user)
        {
            var validator = new UserValidator(user);
            if (!validator.IsValid())
            {
                throw new Exception(validator.GetMessage());
            }

            var salt = this.hashing.GetSalt();
            var cipher = this.hashing.GetCipherText(user.Password, salt);

            user.Salt = salt;
            user.Password = cipher;

            user = await this.userRepository.AddOrUpdateAsync(user).ConfigureAwait(false);
            return user;
        }

        public string Login(string username, string password)
        {
            var user = this.userRepository.GetAll().Where(x => x.UserName == username).FirstOrDefault();

            if (user == null)
            {
                return string.Empty;
            }

            var salt = user.Salt;

            if (this.hashing.CompareHash(password, user.Password, salt))
            {
                return user.Id;
            }

            return string.Empty;
        }
    }
}
