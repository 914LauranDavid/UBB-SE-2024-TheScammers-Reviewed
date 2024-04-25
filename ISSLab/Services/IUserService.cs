using ISSLab.Model;

namespace ISSLab.Services
{
    public interface IUserService
    {
        void AddItemToCart(Guid groupId, Guid postId, Guid userId);
        void AddItemToFavorites(Guid groupId, Guid postId, Guid userId);
        void AddUser(User user);
        List<Post> GetFavoritePosts(Guid groupId, Guid userId);
        User GetUserById(Guid id);
        List<User> GetUsers();
        void RemoveUser(User user);
        List<Post> GetItemsFromCart(Guid userId, Guid groupId);
    }
}
