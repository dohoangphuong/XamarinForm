using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Gcm;
using Android.Media;
using Android.Support.V4.App;
using Android.Graphics;

namespace TNPA.Droid.Services
{
    /// <summary>
    /// Class này dùng để nhận tin nhắn từ GCM
    /// </summary>
    [Service(Exported = false), IntentFilter(new[] { "com.google.android.c2dm.intent.RECEIVE" })]
    public class MyGcmListenerService : GcmListenerService
    {
        /// <summary>
        /// Hàm này dùng để  nhận tin nhắn từ GCM
        /// </summary>
        /// <param name="from"></param>
        /// <param name="data"></param>
        public override void OnMessageReceived(string from, Bundle data)
        {
            var message = data.GetString("message");
            SendNotification(message);
        }
        /// <summary>
        /// Hàm xử lý tin nhắn nhận được
        /// Hiện thị thông báo cho người dùng
        /// </summary>
        /// <param name="message"></param>
        void SendNotification(string message)
        {
            // Khai báo activity được sử dụng để mở khi nhấn vào thông báo
            var intent = new Intent(this, typeof(ChiTietPhanAnhActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            
            // Truyền dữ liệu cho màn hình
            intent.PutExtra("dsPhanAnh", message);
            intent.PutExtra("Position", 0);
            intent.PutExtra("totalItem", 1);

            var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.UpdateCurrent);

            var defaultSoundUri = RingtoneManager.GetDefaultUri(RingtoneType.Notification);// Tạo tiếng thông báo
            

            // Tạo notifictation
            var notificationBuilder = new NotificationCompat.Builder(this)
                .SetSmallIcon(Resource.Drawable.logo)
                .SetContentTitle(Resources.GetString(Resource.String.app_name))
                .SetContentText(Config.Notification)
                .SetAutoCancel(true)
                .SetSound(defaultSoundUri)
                .SetStyle(new NotificationCompat.BigTextStyle()
                .BigText(Config.Notification))
                .SetContentIntent(pendingIntent);
           

            const int notificationId = 0;
            var notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
            notificationManager.Notify(notificationId, notificationBuilder.Build());
        }
    }
}