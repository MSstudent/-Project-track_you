using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using Com.AMap.Maps.Api;
using Com.AMap.Maps.Api.BaseTypes;
using Com.AMap.Maps.Api.Overlays;
using Windows.UI.Core;
using System.Diagnostics;
using Microsoft.Live;
using Microsoft.VisualBasic;
using Com.AMap.Search.API.Options;
using Com.AMap.Search.API.Result;
using Com.AMap.Search.API;
using Com.AMap.Maps.Api.Layers;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Networking.PushNotifications;

namespace kter_myelement
{
    public class TodoItem
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }
    }

    public class location
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
        [JsonProperty(PropertyName = "x")]
        public double x { get; set; }
        [JsonProperty(PropertyName = "y")]
        public double y { get; set; }
        [JsonProperty(PropertyName = "user_id")]
        public string user_id { get; set; }
    }

    public class location2
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public double x { get; set; }

        public double y { get; set; }

        public string user_id { get; set; }

        public ImageSource image { get; set; }

        public int value { get; set; }
    }

    public class circle
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "userid1")]
        public string userid1 { get; set; }
        [JsonProperty(PropertyName = "userid2")]
        public string userid2 { get; set; }
        [JsonProperty(PropertyName = "value")]
        public int value { get; set; }
    }

    public class people
    {
        public string id { get; set; }
        public int value { get; set; }
    }

    public class talk
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "username1")]
        public string username1 { get; set; }
        [JsonProperty(PropertyName = "userid1")]
        public string userid1 { get; set; }
        [JsonProperty(PropertyName = "username2")]
        public string username2 { get; set; }
        [JsonProperty(PropertyName = "userid2")]
        public string userid2 { get; set; }
        [JsonProperty(PropertyName = "text")]
        public string text { get; set; }
    }

    public class Channel
    {
        public int Id { get; set; }


        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }
        [JsonProperty(PropertyName = "userid")]
        public string userid { get; set; }


    }

    public sealed partial class MainPage : Page
    {
        string globalid;
        string globalname;

        double me_x;
        double me_y;

        AMarker marker = new AMarker();
        AMarker marker2 = new AMarker();
        ATip tip = new ATip();
        ATip tip2 = new ATip();
        bool pick = false;
        bool pick2 = false;
        MapLayer markLayer;
        String name;
      
        private MobileServiceCollection<location, location> items;//个人表
        private MobileServiceCollection<circle, circle> items2;//关系表
        private MobileServiceCollection<talk, talk> talkitems;//talk表
        private List<location2> items2_t; //个人加关系表
        private IMobileServiceTable<location> todoTable = App.MobileService.GetTable<location>();//云个人表
        private IMobileServiceTable<circle> todoTable2 = App.MobileService.GetTable<circle>();//云关系表
        private IMobileServiceTable<talk> talktable = App.MobileService.GetTable<talk>();//云talk表

        private MobileServiceUser user;
        private async System.Threading.Tasks.Task Authenticate()
        {
            while (user == null)
            {
                string message;
                try
                {
                    user = await App.MobileService
                        .LoginAsync(MobileServiceAuthenticationProvider.MicrosoftAccount);
              
                    message =
                        string.Format("登陆成功");
                    //RefreshTodoItems();
               
                }
                catch (InvalidOperationException)
                {
                    message = "您必须登陆";
                }

                
                var dialog = new MessageDialog(message);
                dialog.Commands.Add(new UICommand("OK"));
                await dialog.ShowAsync();
            }
            /*if (user != null)
            {
                await RefreshTodoItems();

                Boolean check = false;
                //MessageDialog msg = new MessageDialog(ListItems.Items.Count.ToString());
                //await msg.ShowAsync();

                for (int i = 0; i < ListItems.Items.Count; i++)
                {
                    location item = new location();
                    item = ListItems.Items[i] as location;

                    if (item.user_id.Equals(user.UserId.ToString()))
                    {
                        if (item.Text != "")
                            name = item.Text;
                        check = true;
                        //break;
                    }

                }
                if (!check)
                    nameinput.Visibility = Windows.UI.Xaml.Visibility.Visible;
                else
                    nameinput.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }*/
            if (user != null)
            {
                await RefreshTodoItems();

                Boolean check = false;
                name = "";
                //MessageDialog msg = new MessageDialog(ListItems.Items.Count.ToString());
                //await msg.ShowAsync();

                for (int i = 0; i < ListItems.Items.Count; i++)
                {
                    location2 item = new location2();
                    item = ListItems.Items[i] as location2;

                    if (item.user_id.Equals(user.UserId.ToString()))
                    {
                        if (item.Text != "")
                            name = item.Text;
                        check = true;
                        //break;
                    }

                }
                if (!check)
                    nameinput.Visibility = Windows.UI.Xaml.Visibility.Visible;
                else
                    nameinput.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

                AcquirePushChannel();

                for (int i = 0; i < items2_t.Count; i++)
                    if (items2_t[i].Text.Equals(name))
                    {
                        me_x = items2_t[i].x;
                        me_y = items2_t[i].y;
                    }
            }

        }

        /*private LiveConnectSession session;
        private MobileServiceUser loginResult;
        private async System.Threading.Tasks.Task Authenticate()
        {
            LiveAuthClient liveIdClient = new LiveAuthClient("你的url");


            while (session == null)
            {
                // Force a logout to make it easier to test with multiple Microsoft Accounts
                if (liveIdClient.CanLogout)
                    liveIdClient.Logout();


                LiveLoginResult result = await liveIdClient.LoginAsync(new[] { "wl.basic" });
                if (result.Status == LiveConnectSessionStatus.Connected)
                {
                    session = result.Session;
                    LiveConnectClient client = new LiveConnectClient(result.Session);
                    LiveOperationResult meResult = await client.GetAsync("me");
                    loginResult = await App.MobileService
                        .LoginWithMicrosoftAccountAsync(result.Session.AuthenticationToken);

                    string title = string.Format("Welcome {0}!", meResult.Result["first_name"]);
                    var message = string.Format("You are now logged in - {0}", meResult.Result["first_name"]);
                    var dialog = new MessageDialog(message, title);
                    dialog.Commands.Add(new UICommand("OK"));
                    await dialog.ShowAsync();
                }
                else
                {
                    session = null;
                    var dialog = new MessageDialog("You must log in.", "Login Required");
                    dialog.Commands.Add(new UICommand("OK"));
                    await dialog.ShowAsync();
                }
            }


        }*/

        public MainPage()
        {
            this.InitializeComponent();

            markLayer = new MapLayer(map);
            map.Children.Add(markLayer);
            AMapConfig.Key = "你的key";
            AMapSearchConfig.Key = "你的key";
            marker.LngLat = map.Center;
            marker2.LngLat = map.Center;
            marker.IconURI = new Uri("ms-appx:///Assets/icon/marker_sprite_blue.png", UriKind.Absolute);
            nameinput.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

            marker.TipFrameworkElement = tip;  //将信息窗口赋值给marker
            tip.Title = "我";

            marker2.TipFrameworkElement = tip2;  
            /*if (user != null)
            {
                MessageDialog msg = new MessageDialog("dsa");
                msg.ShowAsync();
                Boolean check = false;

                for (int i = 0; i < ListItems.Items.Count; i++)
                {
                    location item = new location();
                    item = ListItems.Items[i] as location;

                    if (item.user_id.Equals(user.UserId.ToString()))
                    {
                        check = true;
                        break;
                    }

                }
                if (!check)
                    nameinput.Visibility = Windows.UI.Xaml.Visibility.Visible;
                else
                    nameinput.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }*/
        }

        public static PushNotificationChannel CurrentChannel { get; private set; }


        private async void AcquirePushChannel()
        {
            CurrentChannel =
                await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();


            IMobileServiceTable<Channel> channelTable = App.MobileService.GetTable<Channel>();
            var channel = new Channel { Uri = CurrentChannel.Uri,userid=user.UserId };
            await channelTable.InsertAsync(channel);
        }

        public const double EARTH_RADIUS = 6378.137;
        public static double rad(double d)
        {
            return d * Math.PI / 180.0;
        }

        public static double GetDistance(double lat1, double lng1, double lat2, double lng2)
        {
            double radLat1 = rad(lat1);
            double radLat2 = rad(lat2);
            double a = radLat1 - radLat2;
            double b = rad(lng1) - rad(lng2);
            double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
             Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * EARTH_RADIUS;
            s = Math.Round(s * 1000);
            //s = Math.Round(s * 10) / 10;
            return s;
        }

        private async void senttalkcontent(string username1,string userid1,string username2,string userid2,string text)
        {
            talk talkitem = new talk();
            talkitem.username1 = username1;
            talkitem.userid1 = userid1;
            talkitem.username2 = username2;
            talkitem.userid2 = userid2;
            talkitem.text = text;
            talkbox.Text = "";
            await talktable.InsertAsync(talkitem);
            await talktable.DeleteAsync(talkitem);
        }

        private async void driveroute()
        {
            RouteSearchOption rgo = new RouteSearchOption();
            rgo.X1 = marker.LngLat.LngX;
            rgo.Y1 = marker.LngLat.LatY;
            rgo.X2 = marker2.LngLat.LngX;
            rgo.Y2 = marker2.LngLat.LatY;

            APolyline pol = new APolyline();
            pol.LineThickness = 5;
            ObservableCollection<ALngLat> lnglatRoute = new ObservableCollection<ALngLat>();    //线路坐标
            lnglatRoute.Add(new ALngLat(marker.LngLat.LngX, marker.LngLat.LatY));
            RouteSearchResult rgcs = await RouteSearch.RouteSearchWithOption(rgo);
            IEnumerable<String> lnglatstring;
            IEnumerable<RouteSegment> rsegment = rgcs.Segment;
            foreach (RouteSegment rs in rsegment)
            {
                lnglatstring = rs.Coor.Split(new Char[] { ';' });
                foreach (String ss in lnglatstring)
                {
                    String[] lnglatds = ss.Split(new Char[] { ',' });
                    lnglatRoute.Add(new ALngLat(Double.Parse(lnglatds[0]), Double.Parse(lnglatds[1])));
                }
            }

            pol.LngLats = lnglatRoute;
            markLayer.Children.Clear();
            markLayer.Children.Add(pol);
            map.SetOverlaysFitView();
            //map.SetZoomAndCenter(Convert.ToInt32(marker2.LngLat.LngX-marker.LngLat.LngX),map.Center);
        }

        private async void busroute()
        {
            markLayer.Children.Clear();
            BusRouteSearchOption rgo = new BusRouteSearchOption();
            rgo.X1 = marker.LngLat.LngX;
            rgo.Y1 = marker.LngLat.LatY;
            rgo.X2 = marker2.LngLat.LngX;
            rgo.Y2 = marker2.LngLat.LatY;
            rgo.CityCode = "010";
            APolyline pol = new APolyline();
            pol.LineThickness = 5;
            ObservableCollection<ALngLat> lnglatRoute = new ObservableCollection<ALngLat>();  //线路坐标
            lnglatRoute.Add(new ALngLat(marker.LngLat.LngX, marker.LngLat.LatY));
            BusRouteSearchResult rgcs = await BusRouteSearch.BusRouteSearchWithOption(rgo);
            if (rgcs.Erro != null)
            {
                MessageDialog msd = new MessageDialog("查询公交失败！" + rgcs.Erro.Message, "提示");
                this.Dispatcher.RunAsync(CoreDispatcherPriority.Low, () =>
                {
                    msd.ShowAsync();
                });
                return;
            }
            else
            {
                this.Dispatcher.RunAsync(CoreDispatcherPriority.High, () =>
                {
                    ALngLat lnglat = new ALngLat(marker.LngLat.LngX, marker.LngLat.LatY);
                    AMarker poiMarker = new AMarker();
                    poiMarker.IconURI = new Uri("/Samples/qd.png", UriKind.Relative);
                    poiMarker.LngLat = lnglat;
                    //ATip tip = new ATip();
                    //tip.Title = poist.Name;
                    //tip.ContentText = poist.Address;
                    //poiMarker.TipFrameworkElement = tip;
                    markLayer.Children.Add(poiMarker);

                    ALngLat lnglated = new ALngLat(marker2.LngLat.LngX, marker2.LngLat.LatY);
                    AMarker poiMarkered = new AMarker();
                    poiMarkered.IconURI = new Uri("/Samples/zd.png", UriKind.Relative);
                    poiMarkered.LngLat = lnglated;
                    //ATip tiped = new ATip();
                    /*tiped.Title = poied.Name;
                    tiped.ContentText = poied.Address;*/
                    //poiMarkered.TipFrameworkElement = tiped;
                    markLayer.Children.Add(poiMarkered);


                    //ObservableCollection<ALngLat> lnglatRoute = new ObservableCollection<ALngLat>(); //线路坐标
                    //APolyline pol = new APolyline();
                    //pol.LineThickness = 5;

                    IEnumerable<Bus> busInfo = rgcs.Routes;
                    IEnumerable<String> lnglatstring;
                    IEnumerable<String> passdeportstring;
                    //画公交线路和公交站点
                    foreach (Bus bus in busInfo)
                    {
                        IEnumerable<BusSegment> bussegmentInfo = bus.SegmentArray;
                        foreach (BusSegment bs in bussegmentInfo)
                        {

                            lnglatstring = bs.CoordinateList.Split(new Char[] { ';' });
                            passdeportstring = bs.PassDeportCoordinate.Split(new Char[] { ';' });
                            String[] passport = bs.PassDeportName.Split(' ');
                            int i = 0;
                            foreach (String ss in lnglatstring)
                            {
                                String[] lnglatds = ss.Split(new Char[] { ',' });
                                lnglatRoute.Add(new ALngLat(Double.Parse(lnglatds[0]), Double.Parse(lnglatds[1])));
                            }

                            foreach (String ss in passdeportstring)
                            {

                                String[] lnglatds = ss.Split(new Char[] { ',' });
                                try
                                {
                                    ALngLat lnglatpassdeport = new ALngLat(Double.Parse(lnglatds[0]), Double.Parse(lnglatds[1]));
                                    ATip tipStart = new ATip();
                                    //tipStart.Anchor = new Point(0,1);
                                    tipStart.Title = passport[i];
                                    AMarker marker3 = new AMarker();
                                    marker3.Anchor = new Point(0.46, 1);
                                    marker3.IconURI = new Uri("http://api.amap.com/webapi/static/Images/bx11.png");
                                    marker3.LngLat = lnglatpassdeport;
                                    marker3.TipFrameworkElement = tipStart;
                                    markLayer.Children.Add(marker3);
                                    //  Canvas.SetTop(marker,100);
                                    marker3.TipAnchor = new Point(0.35, 1);
                                }
                                catch (Exception e)
                                {
                                    MessageDialog msg = new MessageDialog("无法找到站牌");
                                    msg.ShowAsync();
                                }
                            }
                        }
                        break;
                    }


                    pol.LngLats = lnglatRoute;
                    markLayer.Children.Insert(0, pol);

                    map.SetOverlaysFitView();
                });
            }


        }

        private async void InsertTodoItem(location location_item)
        {
            // This code inserts a new TodoItem into the database. When the operation completes
            // and Mobile Services has assigned an Id, the item is added to the CollectionView
            await todoTable.InsertAsync(location_item);
            location2 location_item2 = new location2();
            location_item2.Id = location_item.Id;
            location_item2.Text = location_item.Text;
            location_item2.user_id = location_item.user_id;
            location_item2.x = location_item.x;
            location_item2.y = location_item.y;

            location_item2.value = 10;
            location_item2.image = new BitmapImage(new Uri("ms-appx:///Assets/res/我.png", UriKind.Absolute));

            items2_t.Add(location_item2);
            await RefreshTodoItems();
            //items.Add(location_item);                        
        }

        private async void DeleteTodoItem(location2 location_item)
        {
            //await todoTable.DeleteAsync(location_item);
            location location_item2 = new location();
            location_item2.Id = location_item.Id;
            location_item2.Text = location_item.Text;
            location_item2.user_id = location_item.user_id;
            location_item2.x = location_item.x;
            location_item2.y = location_item.y;


            items2_t.Remove(location_item);
            await todoTable.DeleteAsync(location_item2);
            await RefreshTodoItems();
            //items.Remove(location_item);
        }

        private async System.Threading.Tasks.Task RefreshTodoItems()
        //private async void RefreshTodoItems()//ready to delete
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {
                // This code refreshes the entries in the list view by querying the TodoItems table.
                // The query excludes completed TodoItems
                items = await todoTable.ToCollectionAsync();
                    //.Where(location_item => location_item.x == 1)
                    //.ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException e)
            {
                exception = e;
            }

            /*if (exception != null)
            {
                await new MessageDialog(exception.Message, "Error loading items").ShowAsync();
            }
            else
            {
                ListItems.ItemsSource = items;
            }*/

            try
            {
                // This code refreshes the entries in the list view by querying the TodoItems table.
                // The query excludes completed TodoItems
                items2 = await todoTable2.ToCollectionAsync();
                    //.Where(location_item => location_item.x == 1)
                    //.ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException e)
            {
                exception = e;
            }

            items2_t = new List<location2>();
            items2_t.Clear();
            string userid = user.UserId;
            int len1 = items.Count;
            for (int i = 0; i < len1; i++)
            {
                
                    location2 item2 = new location2();
                    item2.Id = items[i].Id;
                    item2.Text = items[i].Text;
                    item2.user_id = items[i].user_id;
                    item2.x = items[i].x;
                    item2.y = items[i].y;
                    item2.value = 0;

                    if (item2.user_id.Equals(userid))
                    {
                        item2.value = 10;
                        item2.image = new BitmapImage(new Uri("ms-appx:///Assets/res/本尊.png", UriKind.Absolute));
                        items2_t.Add(item2);
                        continue;
                    }

                    int len2 = items2.Count;
                    for (int j = 0; j < len2; j++)
                    {
                        if ((items2[j].userid1.Equals(userid) && items2[j].userid2.Equals(item2.user_id)) || (items2[j].userid1.Equals(item2.user_id) && items2[j].userid2.Equals(userid)))
                        {
                            item2.value = items2[j].value;
                            break;
                        }
                    }


                    if (item2.value == 10)
                        item2.image = new BitmapImage(new Uri("ms-appx:///Assets/res/本尊.png", UriKind.Absolute));
                    else
                    if (item2.value==2)
                        item2.image = new BitmapImage(new Uri("ms-appx:///Assets/res/熟悉.png", UriKind.Absolute));
                    else
                        item2.image = new BitmapImage(new Uri("ms-appx:///Assets/res/陌生.png", UriKind.Absolute));

                    items2_t.Add(item2);
            
            }

            if (exception != null)
            {
                await new MessageDialog(exception.Message, "Error loading items").ShowAsync();
            }
            else
            {
                IEnumerable<location2> query = items2_t.OrderByDescending(i => i.value);//降序
                //IEnumerable<location2> query = items2_t.OrderBy(i => i.value);//升序

                ListItems.ItemsSource = query;
            }
        }

        private async void UpdateCheckedTodoItem(location2 item)
        {
            // This code takes a freshly completed TodoItem and updates the database. When the MobileService 
            // responds, the item is removed from the list 
            location location_item2 = new location();
            location_item2.Id = item.Id;
            location_item2.Text = item.Text;
            location_item2.user_id = item.user_id;
            location_item2.x = item.x;
            location_item2.y = item.y;

            await todoTable.UpdateAsync(location_item2);
            await RefreshTodoItems();
            //items.Remove(item);
        }

        private async System.Threading.Tasks.Task locateme()
        {
            AGeolocator ageol = new AGeolocator();    //初始化一个AGeolocator对象
            //设置位置改变监听器，调用ageol_PositionChanged 函数  
            ageol.PositionChanged += ageol_PositionChanged;  
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshTodoItems();
        }

        private async void CheckBoxComplete_Checked(object sender, RoutedEventArgs e)
        {
            pick2 = true;//确定marker2已选
            ListViewItem cb = (ListViewItem)sender;
            //CheckBox cb = (CheckBox)sender;
            location2 item = cb.DataContext as location2;
            //UpdateCheckedTodoItem(item);
            //item=await todoTable.LookupAsync(item.Id);

                //marker2.LngLat = marker.LngLat;
            //marker2.LngLat.LngX = item.x;
            //marker2.LngLat.LatY = item.y;
            tip2.Title = item.Text;
            marker2.LngLat = new ALngLat(item.x, item.y);
            marker2.IconURI = new Uri("ms-appx:///Assets/icon/marker_sprite.png", UriKind.Absolute);
            if (!map.Children.Contains(marker2))
                map.Children.Add(marker2);

            map.SetZoomAndCenter(15, marker2.LngLat);

            globalid = item.user_id;
            globalname = item.Text;
            talkbox.Visibility = Windows.UI.Xaml.Visibility.Visible;
            talkbox.Text = "";
            talkboard.Visibility = Windows.UI.Xaml.Visibility.Visible;

            /*MessageDialog msg = new MessageDialog(item.x.ToString()+" "+marker2.LngLat.LngX.ToString());
            await msg.ShowAsync();*/
       
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await Authenticate();
            //await RefreshTodoItems();
        }

        private async void uploadme_Click(object sender, RoutedEventArgs e)
        {
            //pick = true;//确定marker已选
            /*AGeolocator ageol = new AGeolocator();    //初始化一个AGeolocator对象
            //设置位置改变监听器，调用ageol_PositionChanged 函数  
            ageol.PositionChanged += ageol_PositionChanged;*/
            if (!pick)
            {
                MessageDialog msg = new MessageDialog("请先定位");
                await msg.ShowAsync();
            }
            else
            {
                Boolean check = false;
                if (ListItems.Items.Count == 0)
                    check = true;

                for (int i = 0; i < ListItems.Items.Count; i++)
                {
                    location2 item = new location2();
                    item = ListItems.Items[i] as location2;

                    if (item.user_id.Equals(user.UserId.ToString()))
                    {
                        check = true;

                        item.x = marker.LngLat.LngX;
                        item.y = marker.LngLat.LatY;
                        UpdateCheckedTodoItem(item);
                        /*MessageDialog msg = new MessageDialog(item.x.ToString() + " " + item.y.ToString());
                        msg.ShowAsync();*/

                        //break;
                    }

                }


                if (!check)
                {
                    var location_item = new location { x = marker.LngLat.LngX, y = marker.LngLat.LatY, Text = name, user_id = user.UserId.ToString() };
                    InsertTodoItem(location_item);
                }

                me_x = marker.LngLat.LngX;
                me_y = marker.LngLat.LatY;

                for (int i = 0; i < items2_t.Count; i++)
                {
                    if (items2_t[i].value>0&&items2_t[i].Text!=name)
                    {
                        //MessageDialog msg = new MessageDialog(items2_t[i].value.ToString());
                        /*MessageDialog msg = new MessageDialog(GetDistance(me_y,me_x,items2_t[i].y,items2_t[i].x).ToString());
                        await msg.ShowAsync();*/
                        double dist=GetDistance(me_y,me_x,items2_t[i].y,items2_t[i].x);
                        if (dist < 2000)
                        {
                            senttalkcontent("0","0",items2_t[i].Text,items2_t[i].user_id,name+"在您附近"+dist.ToString()+"米");
                        }
                    }
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AGeolocator ageol = new AGeolocator();    //初始化一个AGeolocator对象
            //设置位置改变监听器，调用ageol_PositionChanged 函数  
            ageol.PositionChanged += ageol_PositionChanged;  

        }

        void ageol_PositionChanged(AGeolocator sender, APositionChangedEventArgs args)
        {
            pick = true;//确定marker已选
            //map.Children.Add(marker); 
            this.Dispatcher.RunAsync(CoreDispatcherPriority.High, () =>
            {
                //第一次定位
                if (!map.Children.Contains(marker))
                {
                    marker.LngLat = args.LngLat;   //点标注的经纬度为当前定位获取的经纬度
                    map.Children.Add(marker); //将点标注添加到地图上
                }
                //位置改变时的定位
                else
                {
                    marker.LngLat = args.LngLat;
                }
                map.SetZoomAndCenter(15, args.LngLat);

                Debug.WriteLine("定位精度：" + args.Accuracy);//单位米
            });
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (namebox.Text != "")
            {
                name = namebox.Text;
                nameinput.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            pick2 = true;//确定marker2已选
            for (int i = 0; i < ListItems.Items.Count; i++)
            {
                location2 item = new location2();
                item = ListItems.Items[i] as location2;
                if (item.Text == TextInput.Text)
                {
                    marker2.LngLat = new ALngLat(item.x, item.y);
                    marker2.IconURI = new Uri("ms-appx:///Assets/icon/marker_sprite.png", UriKind.Absolute);
                    if (!map.Children.Contains(marker2))
                        map.Children.Add(marker2);
                    tip2.Title = item.Text;

                    map.SetZoomAndCenter(15, marker2.LngLat);

                    globalid = item.user_id;
                    globalname = item.Text;
                    talkbox.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    talkbox.Text = "";
                    talkboard.Visibility = Windows.UI.Xaml.Visibility.Visible;

                    break;
                }
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < ListItems.Items.Count; i++)
            {
                location2 item = new location2();
                item = ListItems.Items[i] as location2;
                if (item.user_id == user.UserId.ToString())
                    DeleteTodoItem(item);
            }
        }

        private void TextInput_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            pick2 = true;//确定marker2已选
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (nameinput.Visibility == Windows.UI.Xaml.Visibility.Collapsed)
                {
                    for (int i = 0; i < ListItems.Items.Count; i++)
                    {
                        location2 item = new location2();
                        item = ListItems.Items[i] as location2;
                        if (item.Text == TextInput.Text)
                        {
                            marker2.LngLat = new ALngLat(item.x, item.y);
                            marker2.IconURI = new Uri("ms-appx:///Assets/icon/marker_sprite.png", UriKind.Absolute);
                            if (!map.Children.Contains(marker2))
                                map.Children.Add(marker2);
                            tip2.Title = item.Text;

                            map.SetZoomAndCenter(15, marker2.LngLat);
                            break;
                        }
                    }
                }

            }
        }

        private void namebox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (nameinput.Visibility == Windows.UI.Xaml.Visibility.Visible)
                {
                    if (namebox.Text != "")
                    {
                        name = namebox.Text;
                        nameinput.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    }
                }
            }
        }

        private async void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (!pick)
            {
                MessageDialog msg = new MessageDialog("请先定位");
                await msg.ShowAsync();
            }
            else
            {
                if (!pick2)
                {
                    MessageDialog msg = new MessageDialog("请先选定对方");
                    await msg.ShowAsync();
                }
                else
                {
                    if (trans_sch.SelectedIndex.ToString().Equals("0"))
                        driveroute();
                    else
                        busroute();
                }
            }
        }

        /*private async void Button_Click_6(object sender, RoutedEventArgs e)
        {
            circle a = new circle();
            a.userid1 = user.UserId;
            a.userid2 = items2_t[0].user_id;
            a.value = 2;
            await App.MobileService.GetTable<circle>().InsertAsync(a);

            int i=Convert.ToInt32(talkbox.Text);
            string st= items2_t[i].Text;
            MessageDialog msg = new MessageDialog(st);
            await msg.ShowAsync();
        }*/



        private async void talkboard_click(object sender, RoutedEventArgs e)
        {
            senttalkcontent(name, user.UserId, globalname, globalid, talkbox.Text);
        }

        private async void talkbox_keyup(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
                senttalkcontent(name, user.UserId, globalname, globalid, talkbox.Text);
        }


    }
}
