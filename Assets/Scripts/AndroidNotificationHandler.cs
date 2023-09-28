using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif

public class AndroidNotificationHandler : MonoBehaviour
{
#if UNITY_ANDROID
    const string ChannelId = "notification_channel";
    public void ScheduleNotification(DateTime dateTime)
    {
        AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel
        {
            Id = ChannelId,
            Name = "Notification Channel",
            Description = "Some random description",
            Importance = Importance.Default

        };

        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel); // we register from android

        AndroidNotification notification = new AndroidNotification 
        {
            Title = "Energy Recharged",
            Text = "INSAN! PUNO NA ANG ENERGY, MEKUS-MEKUS NA YAN! LARO KA NA ULIT!", 
            SmallIcon = "default",
            LargeIcon = "default",
            FireTime = dateTime
        };

        AndroidNotificationCenter.SendNotification(notification, ChannelId);
    }
#endif
}
