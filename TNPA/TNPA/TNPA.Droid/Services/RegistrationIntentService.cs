using Android.App;
using Android.Content;
using Android.Gms.Gcm;
using Android.Gms.Gcm.Iid;
using Android.Preferences;
using Android.Support.V4.Content;
using System;
using System.Collections.Generic;

namespace TNPA.Droid
{
    /// <summary>
    /// Class này dùng để đăng ký GCM
    /// Khi đăng ký sẽ nhận được token từ GCM
    /// Khi có tin nhắn mới GCM sẽ gửi tới ứng dụng thông qua token(gửi tới single device) hoặc topic (nhiền device có thể nhận được tin nhấn nếu cùng theo dõi 1 topic)
    /// </summary>
    [Service(Exported = false)]
    public class RegistrationIntentService : IntentService
    {
        static object locker = new object();
        ISharedPreferences sharedPreferences;
        public RegistrationIntentService() : base("RegistrationIntentService") { }
        protected override void OnHandleIntent(Intent intent)
        {
            sharedPreferences = PreferenceManager.GetDefaultSharedPreferences(this);
            try
            {
                lock (locker)
                {
                    var instanceID = InstanceID.GetInstance(this);
                    // Lấy token cho device
                    var token = instanceID.GetToken(
                        Config.GCMSENDER_ID, GoogleCloudMessaging.InstanceIdScope, null);

                    sharedPreferences.Edit().PutString(Config.GCMToken, token).Apply();
                    SendRegistrationToAppServer(token);
                    Subscribe(token);
                }
            }
            catch (Exception e)
            {
                sharedPreferences.Edit().PutString(Config.GCMToken, string.Empty).Apply();
                return;
            }
            var registrationComplete = new Intent(Config.REGISTRATION_COMPLETE);
            LocalBroadcastManager.GetInstance(this).SendBroadcast(registrationComplete);
        }
        /// <summary>
        /// Dùng để custom việc sử dụng token( mình k sài :P)
        /// </summary>
        /// <param name="token"></param>
        void SendRegistrationToAppServer(string token)
        {
            // Add custom implementation here as needed.
        }
        /// <summary>
        /// Sử dụng token để đăng ký việc theo dõi các topic
        /// Ở đây ứng dụng sử dụng MaPhanAnhKenhKhacID để làm topic
        /// Khi người dùng gửi phản ánh từ mobile thành công sẽ nhận về 1 MaPhanAnhKenhKhacID  và theo dõi topic này
        /// Khi server xử lý hoàn tất cho phản ánh thì gửi tin nhắn tới topic mang tên MaPhanAnhKenhKhacID thông qua GCM (nội dung tin nhắn chứa MaPhanAnhKenhKhacID)
        /// Vì ứng dụng theo dõi topic ứng với MaPhanAnhKenhKhacID nên sẽ nhận được tin
        /// </summary>
        /// <param name="token"></param>
        void Subscribe(string token)
        {
            ICollection<string> TOPICS = sharedPreferences.GetStringSet(Config.GCMTopic, null);
            if(TOPICS == null)
            {
                TOPICS = new List<string>();
                TOPICS.Add("global");
                sharedPreferences.Edit().PutStringSet(Config.GCMTopic, TOPICS).Apply();
            }
            foreach (var topic in TOPICS)
            {
                var pubSub = GcmPubSub.GetInstance(this);
                pubSub.Subscribe(token, "/topics/" + topic, null);
            }
        }
    }
}