using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cassie.Model
{
    public class SunTopic
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }
        public string TopicName { get; set; }
        public SunTopic()
        {
            //empty constructor
        }
        public SunTopic(string p1)
        {
            TopicName = p1;
        }
    }
}
