using ISSLab.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ISSLab.Model.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> allUsers;

        public UserRepository()
        {
            allUsers = new List<User>();
        }

        public List<User> FindAllUsers()
        {
            return allUsers;
        }

        public User FindById(Guid id)
        {
            for (int i = 0; i < allUsers.Count; i++)
            {
                if (allUsers[i].Id == id)
                {
                    return allUsers[i];
                }
            }
            throw new Exception("User does not exist");
        }
        public void AddUser(User newUser)
        {
            allUsers.Add(newUser);
        }

        public void DeleteUser(Guid id)
        {
            for (int i = 0; i < allUsers.Count; i++)
            {
                if (allUsers[i].Id == id)
                {
                    allUsers.RemoveAt(i);
                    break;
                }
            }
        }

        public void AddToCart(Guid groupId, Guid userId, Guid postId)
        {
            User? user = allUsers.Find(user => user.Id == userId);
            if (user == null)
                throw new Exception("No such user");

            Cart? cart = user.Carts.Find(c => c.GroupId == groupId);

            if (cart == null)
            {
                cart = new Cart(groupId, userId);
                user.Carts.Add(cart);
            }
            if (cart.Posts.Contains(postId))
                return;
            cart.Posts.Add(postId);
        }

        public void AddToFavorites(Guid groupId, Guid userId, Guid postId)
        {
            User? user = allUsers.Find(user => user.Id == userId);

            if (user == null)
            {
                throw new Exception("No such user");
            }

            Favorites? favoriteFromGroup = user.Favorites.Find(c => c.GroupId == groupId);

            if (favoriteFromGroup == null)
            {
                favoriteFromGroup = new Favorites(userId, groupId);
                user.Favorites.Add(favoriteFromGroup);
            }
            if (favoriteFromGroup.Posts.Contains(postId))
                return;
            favoriteFromGroup.Posts.Add(postId);
        }
    }
}
