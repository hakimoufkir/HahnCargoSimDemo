using HahnCargoSimBack.Models;

namespace HahnCargoSimBack.Services.User;

public interface IUser
{
    LoginResponse Auth(UserAuthenticate userAuthenticate);

    int GetAmount();
}