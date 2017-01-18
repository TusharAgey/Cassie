using Cassie.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cassie.Helpers
{

    public class ReadAllMyTopicList
    {
        DatabaseHelperClass Db_Helper = new DatabaseHelperClass();
        public ObservableCollection<MyTopic> GetAllToDo()
        {
            return Db_Helper.ReadContacts4();
        }
    }
    public class ReadAllNewTopicList
    {
        DatabaseHelperClass Db_Helper = new DatabaseHelperClass();
        public ObservableCollection<NewTopic> GetAllToDo()
        {
            return Db_Helper.ReadContacts3();
        }
    }
    public class ReadAllWedTopicList
    {
        DatabaseHelperClass Db_Helper = new DatabaseHelperClass();
        public ObservableCollection<WedTopic> GetAllToDo()
        {
            return Db_Helper.ReadContacts();
        }
    }
    public class ReadAllFriTopicList
    {
        DatabaseHelperClass Db_Helper = new DatabaseHelperClass();
        public ObservableCollection<FriTopic> GetAllToDo()
        {
            return Db_Helper.ReadContacts2();
        }
    }
    public class ReadAllSunTopicList
    {
        DatabaseHelperClass Db_Helper = new DatabaseHelperClass();
        public ObservableCollection<SunTopic> GetAllToDo()
        {
            return Db_Helper.ReadContacts1();
        }
    }
}
