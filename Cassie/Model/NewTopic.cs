using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cassie.Model
{
    public class NewTopic
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }
        public string TopicName { get; set; }
        public NewTopic()
        {
            //empty constructor
        }
        public NewTopic(string p1)
        {
            TopicName = p1;
        }
    }
}
