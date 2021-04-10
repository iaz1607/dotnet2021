using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using OnlineStore;
namespace server
{
    public class DbRequests
    {
        // methods from this class is helpful for updating and reading database
        public static int GetItemCount(long itemId)
        {
            return 0;
        }

        public static User GetUserInfo(long userId)
        {
            return null;
        }

        public static bool IsUserExists(string login, string password)
        {
            return false;
        }

        public static void SignUpUser(string login, string password)
        {
            return;
        }

        public static Dictionary<string, Item> LoadAllItems()
        {
            return null;
        }

        public static Item GetItemInfo(long itemId)
        {
            return null;
        }

        public static void UpdateItemInfo(Item item)
        {
            return;
        }
        
        public static void IncreaseUserBalance(long userId, int count)
        {
            return;
        }

        public static void DecreaseUserBalance(long userId, int count)
        {
            return;
        }
    }

    public class API
    {
        // methods from this class takes parameters from client and return answer which will be sent to client
        // method interfaces will be changed later

        public object GetUserInfo(object obj)
        {
            return null;
        }

        public object UpdateUserInfo(object obj)
        {
            return null;
        }

        public object AddNewItem(object obj)
        {
            return null;
        }

        public object GetItemInfo(object obj)
        {
            return null;
        }

        public object UpdateItemInfo(object obj)
        {
            return null;
        }

        public object AuthorizeUser(object obj)
        {
            return null;
        }

        public object RegisterUser(object obj)
        {
            return null;
        }

        public object IsUserAuthorized(object obj)
        {
            return null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            return;
        }
    }
}
