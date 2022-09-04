using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Core.Utilities.Verification;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IActivation _activation;
        private IUserDal _userdal;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IActivation activation,IUserDal userDal)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _activation = activation;
            _userdal = userDal;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var createToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(createToken);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByEmail(userForLoginDto.Email);
            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            var kont = CheckActivation(userForLoginDto);
            if(!kont.Success)
            {
                return new ErrorDataResult<User>();
            }
           
            return new SuccessDataResult<User>(userToCheck.Data, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            var chehck = _activation.SenderMessage(userForRegisterDto.Email,_activation.CreateCode());
            var codeKey = chehck.ActivationKey;
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Email = userForRegisterDto.Email,
                Status = true,
                ActivaionStatus = false,
                ActivationCode = codeKey
            };

            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistrationSuccessful);

        }

        public IResult UserExixts(string email)
        {
            if (_userService.GetByEmail(email).Data!=null)
            {
                return new ErrorResult(Messages.UserAvailable);
            }
            return new SuccessResult();
        }

        public IDataResult<User> CheckActivation(UserForLoginDto userForLoginDto)
        {

            var userToCheck = _userService.GetByEmail(userForLoginDto.Email);
            if (userToCheck.Data.ActivaionStatus == false)
            {
                var userCodeKey = userToCheck.Data.ActivationCode;
                bool kontrol = _activation.ChechkActivation(userForLoginDto.ActivationCode, userCodeKey);
                if (kontrol == false)
                {
                    return new ErrorDataResult<User>("kodu girin");
                }
                var userDb = _userdal.Get(u=>u.Id==userToCheck.Data.Id);
                userDb.ActivaionStatus = true;
                _userdal.Update(userDb);
                var userToChecke = _userService.GetByEmail(userForLoginDto.Email);

                return new SuccessDataResult<User>(userToChecke.Data, Messages.SuccessfulLogin);
            }
            return new SuccessDataResult<User>();
        }

    }
}
//var dbFilm = _filmDal.Get(f => f.Id == id);
//dbFilm.State = 1(önceden 0 dı 1 yaptım)
//_filmDal.Update(dbFilm);