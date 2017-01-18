using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using Cassie.Helpers;
using Cassie.Model;
using System.Collections.ObjectModel;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Cassie
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DatabaseHelperClass DB_Helper = new DatabaseHelperClass();
        ObservableCollection<MyTopic> DB_MyTopic = new ObservableCollection<MyTopic>();
        ObservableCollection<NewTopic> DB_NewTopic = new ObservableCollection<NewTopic>();
        ObservableCollection<WedTopic> DB_WedTopic = new ObservableCollection<WedTopic>();
        ObservableCollection<FriTopic> DB_FriTopic = new ObservableCollection<FriTopic>();
        ObservableCollection<SunTopic> DB_SunTopic = new ObservableCollection<SunTopic>();
        String[] CurrTopicName;
        int[] CurrTopicId;
        enum sections {NEWONE, WEDNESSDAY, FRIDAY, SUNDAY, NONVALID};
        sections[] house;
        int len, index;
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void MsgButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            myMethods.releaseAll();
            App.Current.Exit();
        }

        private void topicAddButton_Click(object sender, RoutedEventArgs e)
        {
            DB_Helper.Insert(new MyTopic(topicTextBox.Text));
            DB_Helper.Insert(new NewTopic(topicTextBox.Text));
            topicTextBox.Text = "";
        }
            
        private void mainPivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DB_MyTopic = new ReadAllMyTopicList().GetAllToDo();//Get all DB contacts 
            DB_SunTopic = new ReadAllSunTopicList().GetAllToDo();
            DB_FriTopic = new ReadAllFriTopicList().GetAllToDo();
            DB_NewTopic = new ReadAllNewTopicList().GetAllToDo();
            DB_WedTopic = new ReadAllWedTopicList().GetAllToDo();
            CurrTopicId = new int[DB_MyTopic.Count];//created total topic numbered array of ID
            CurrTopicName = new string[DB_MyTopic.Count];//created total topic numbered array of Topic Names
            house = new sections[DB_MyTopic.Count];
            int j = 0;
            for (j = 0; j < DB_MyTopic.Count; j++) {
                house[j] = sections.NONVALID;
            }

            if (mainPivot.SelectedItem == homePivot)
            {
                retrieveNumTopic();
            }
            else if (mainPivot.SelectedItem == studyPivot) {
                startStudy(DateTime.Now.DayOfWeek);
                mainPivot.IsLocked = true;
            }

        }

        private void startStudy(DayOfWeek day)
        {
            List<NewTopic> t1 = DB_NewTopic.ToList();
            int i = 0;
            foreach(var topic in t1)//Prepare arrays of data here!
            {
                CurrTopicId[i] = topic.Id;
                CurrTopicName[i] = topic.TopicName;
                house[i] = sections.NEWONE;
                i++;
            } 
            if (day == DayOfWeek.Sunday) {
                List<SunTopic> t2 = DB_SunTopic.ToList();
                foreach (var topic in t2)//Prepare arrays of data here!
                {
                    CurrTopicId[i] = topic.Id;
                    CurrTopicName[i] = topic.TopicName;
                    house[i] = sections.SUNDAY;
                    i++;
                }
            }
            else if (day == DayOfWeek.Wednesday) {
                List<WedTopic> t3 = DB_WedTopic.ToList();
                foreach (var topic in t3)//Prepare arrays of data here!
                {
                    CurrTopicId[i] = topic.Id;
                    CurrTopicName[i] = topic.TopicName;
                    house[i] = sections.WEDNESSDAY;
                    i++;
                }
            }
            else if(day == DayOfWeek.Friday) {
                List<FriTopic> t4 = DB_FriTopic.ToList();
                foreach (var topic in t4)//Prepare arrays of data here!
                {
                    CurrTopicId[i] = topic.Id;
                    CurrTopicName[i] = topic.TopicName;
                    house[i] = sections.FRIDAY;
                    i++;
                }
                
            }
            len = i;
            index = 0;
            topicExplainTextBlock.Text = "Explain: " + CurrTopicName[index];
        }

        private void retrieveNumTopic()
        {
            topicTextBlock.Text = "Total Topics added till date:- " + DB_MyTopic.Count.ToString();
        }

        private void wrongButton_Click(object sender, RoutedEventArgs e)
        {
            //delete this Id valued topic and send it to NewTopic Stack
            if (house[index] == sections.NEWONE) { }//do nothing, because its already a new topic
            else if (house[index] == sections.WEDNESSDAY) //delete currtopicid[index] from wednessday table and insert it into newone table
            {
                DB_Helper.DeleteWedTopic(CurrTopicId[index]);
                DB_Helper.Insert(new NewTopic(CurrTopicName[index]));
            }
            else if (house[index] == sections.FRIDAY) {
                DB_Helper.DeleteFriTopic(CurrTopicId[index]);
                DB_Helper.Insert(new NewTopic(CurrTopicName[index]));
            }
            else if (house[index] == sections.SUNDAY) {
                DB_Helper.DeleteSunTopic(CurrTopicId[index]);
                DB_Helper.Insert(new NewTopic(CurrTopicName[index]));
            }
            index++;
            if (index >= len)
            {
                topicExplainTextBlock.Text = "Done Studying! All the best.";
                mainPivot.IsLocked = false;
            }
            else
                topicExplainTextBlock.Text = "Explain: " + CurrTopicName[index];
        }

        private void rightButton_Click(object sender, RoutedEventArgs e)
        {
            //delete this Id valued topic and graduate it to next stack.
            if (house[index] == sections.NEWONE) {//delete currtopicid[index] from newone table and insert it into wednessday's table!
                DB_Helper.DeleteNewTopic(CurrTopicId[index]);
                DB_Helper.Insert(new WedTopic(CurrTopicName[index]));
            }
            else if (house[index] == sections.WEDNESSDAY) //delete currtopicid[index] from wednessday table and insert it into newone table
            {
                DB_Helper.DeleteWedTopic(CurrTopicId[index]);
                DB_Helper.Insert(new FriTopic(CurrTopicName[index]));
            }
            else if (house[index] == sections.FRIDAY)
            {
                DB_Helper.DeleteFriTopic(CurrTopicId[index]);
                DB_Helper.Insert(new SunTopic(CurrTopicName[index]));
            }
            else if (house[index] == sections.SUNDAY)//Do nothing, the card's been graduated!
            {
            }
            index++;
            if (index >= len)
            {
                topicExplainTextBlock.Text = "Done Studying! All the best.";
                mainPivot.IsLocked = false;
            }
            else
                topicExplainTextBlock.Text = "Explain: " + CurrTopicName[index];
        }

    }
}
 