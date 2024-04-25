
namespace ISSLab.Model.Repositories
{
    public interface IUserRepository
    {
        void AddToCart(Guid groupId, Guid userId, Guid postId);
        void AddToFavorites(Guid groupId, Guid userId, Guid postId);
        void AddUser(User newUser);
        void DeleteUser(Guid id);
        List<User> FindAllUsers();
        User FindById(Guid id);
    }
}
