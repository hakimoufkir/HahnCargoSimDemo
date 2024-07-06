using HahnCargoSimBack.Models;

namespace HahnCargoSimBack.Services.User;

public interface IUser
{
     Task<LoginResponse> Auth(UserAuthenticate userAuthenticate);

     Task<int> GetAmount(string token);
}