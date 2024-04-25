using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using ISSLab.Model;
using ISSLab.Model.Repositories;
namespace ISSLab.Services
{
    public class UserService : IUserService
    {
        private IUserRepository users;
        private IPostRepository posts;
        private IGroupRepository groups;

        public UserService(IUserRepository users, IPostRepository posts, IGroupRepository groups)
        {
            this.users = users;
            this.posts = posts;
            this.groups = groups;
        }

        public void AddUser(User user)
        {
            users.AddUser(user);
        }

        public void RemoveUser(User user)
        {
            users.DeleteUser(user.Id);
        }

        public User GetUserById(Guid id)
        {
            User? user = users.FindById(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        public List<User> GetUsers()
        {
            return users.FindAllUsers();
        }

        public void AddItemToCart(Guid groupId, Guid postId, Guid userId)
        {
            users.AddToCart(groupId, userId, postId);

        }

        public void AddItemToFavorites(Guid groupId, Guid postId, Guid userId)
        {
            users.AddToFavorites(groupId, userId, postId);
        }

        public List<Post> GetFavoritePosts(Guid groupId, Guid userId)
        {
            List<Post> favoritePosts = new List<Post>();
            Favorites favorites = users.FindById(userId).Favorites.Find(f => f.GroupId == groupId);
            if (favorites == null)
            {
                users.FindById(userId).Favorites.Add(new Favorites(userId, groupId));
                return new List<Post>();
            }
            foreach (Guid postId in favorites.Posts)
            {
                favoritePosts.Add(posts.getById(postId));
            }
            return favoritePosts;
        }

        public List<Post> GetItemsFromCart(Guid userId, Guid groupId)
        {
            Cart cart = users.FindById(userId).Carts.Find(c => c.GroupId == groupId);
            List<Post> cartedPosts = new List<Post>();
            if (cart == null)
            {
                users.FindById(userId).Carts.Add(new Cart(groupId, userId));
                return new List<Post>();
            }
            foreach (Guid postId in cart.Posts)
            {
                cartedPosts.Add(posts.getById(postId));
            }
            return cartedPosts;
        }
    }
}
