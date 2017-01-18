using SQLite;
using Cassie.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cassie.Helpers
{
    public class DatabaseHelperClass
    {
        SQLiteConnection dbConn;

        //Create Tabble 
        public async Task<bool> onCreate(string DB_PATH)
        {
            try
            {
                if (!CheckFileExists(DB_PATH).Result)
                {
                    using (dbConn = new SQLiteConnection(DB_PATH))
                    {
                        dbConn.CreateTable<MyTopic>();
                        dbConn.CreateTable<WedTopic>();
                        dbConn.CreateTable<SunTopic>();
                        dbConn.CreateTable<NewTopic>();
                        dbConn.CreateTable<FriTopic>();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<MyTopic> ReturnMaxIndex()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                return dbConn.Query<MyTopic>("select Id from MyTopic order by(Id) DESC LIMIT 1");
            }
        }

        private async Task<bool> CheckFileExists(string fileName)
        {
            try
            {
                var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Retrieve the specific contact from the database. 

        public ObservableCollection<MyTopic> ReadContacts4()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                List<MyTopic> myCollection = dbConn.Table<MyTopic>().ToList<MyTopic>();
                ObservableCollection<MyTopic> ContactsList = new ObservableCollection<MyTopic>(myCollection);
                return ContactsList;
            }
        }
        public ObservableCollection<NewTopic> ReadContacts3()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                List<NewTopic> myCollection = dbConn.Table<NewTopic>().ToList<NewTopic>();
                ObservableCollection<NewTopic> ContactsList = new ObservableCollection<NewTopic>(myCollection);
                return ContactsList;
            }
        }
        public ObservableCollection<FriTopic> ReadContacts2()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                List<FriTopic> myCollection = dbConn.Table<FriTopic>().ToList<FriTopic>();
                ObservableCollection<FriTopic> ContactsList = new ObservableCollection<FriTopic>(myCollection);
                return ContactsList;
            }
        }
        public ObservableCollection<SunTopic> ReadContacts1()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                List<SunTopic> myCollection = dbConn.Table<SunTopic>().ToList<SunTopic>();
                ObservableCollection<SunTopic> ContactsList = new ObservableCollection<SunTopic>(myCollection);
                return ContactsList;
            }
        }
        public ObservableCollection<WedTopic> ReadContacts()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                List<WedTopic> myCollection = dbConn.Table<WedTopic>().ToList<WedTopic>();
                ObservableCollection<WedTopic> ContactsList = new ObservableCollection<WedTopic>(myCollection);
                return ContactsList;
            }
        }

        //Inserting data
        public void Insert(MyTopic newcontact)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Insert(newcontact);
                });
            }
        }
        public void Insert(NewTopic newcontact)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Insert(newcontact);
                });
            }
        }
        public void Insert(WedTopic newcontact)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Insert(newcontact);
                });
            }
        }
        public void Insert(FriTopic newcontact)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Insert(newcontact);
                });
            }
        }
        public void Insert(SunTopic newcontact)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Insert(newcontact);
                });
            }
        }

        //Delete specific contact 
        public void DeleteMyTopic(int Id)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingconact = dbConn.Query<MyTopic>("select * from MyTopic where Id =" + Id).FirstOrDefault();
                if (existingconact != null)
                {
                    dbConn.RunInTransaction(() =>
                    {
                        dbConn.Delete(existingconact);
                    });
                }
            }
        }
        public void DeleteNewTopic(int Id)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingconact = dbConn.Query<NewTopic>("select * from NewTopic where Id =" + Id).FirstOrDefault();
                if (existingconact != null)
                {
                    dbConn.RunInTransaction(() =>
                    {
                        dbConn.Delete(existingconact);
                    });
                }
            }
        }
        public void DeleteFriTopic(int Id)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingconact = dbConn.Query<FriTopic>("select * from FriTopic where Id =" + Id).FirstOrDefault();
                if (existingconact != null)
                {
                    dbConn.RunInTransaction(() =>
                    {
                        dbConn.Delete(existingconact);
                    });
                }
            }
        }
        public void DeleteWedTopic(int Id)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingconact = dbConn.Query<WedTopic>("select * from WedTopic where Id =" + Id).FirstOrDefault();
                if (existingconact != null)
                {
                    dbConn.RunInTransaction(() =>
                    {
                        dbConn.Delete(existingconact);
                    });
                }
            }
        }
        public void DeleteSunTopic(int Id)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingconact = dbConn.Query<SunTopic>("select * from SunTopic where Id =" + Id).FirstOrDefault();
                if (existingconact != null)
                {
                    dbConn.RunInTransaction(() =>
                    {
                        dbConn.Delete(existingconact);
                    });
                }
            }
        }

        //Delete all contactlist or delete Contacts table 
    }
}
