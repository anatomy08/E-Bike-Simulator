using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_IOS
using Unity.Notifications.iOS;
#endif
public class iOSNotificationHandler : MonoBehaviour
{

#if UNITY_IOS 
    public void ScheduleNotifaction(int minutes)
    {
        iOSNotification notification = new iOSNotification
        {
            Title = "Energy Recharged",
            Subtitle = "Your Energy has been Recharged INSAN!",
            Body = "INSAN! PUNO NA ANG ENERGY, MEKUS-MEKUS NA YAN! LARO KA NA ULIT! ",
            ShowInForeground = true,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
            CategoryIdentifier = "category_a",
            ThreadIdentifier = "thread1",
            Trigger = new iOSNotificationTimeIntervalTrigger
            {
                TimeInterval = new System.TimeSpan(0, minutes, 0),
                Repeats = false
            }

        };

        iOSNotificationCenter.ScheduleNotification(notification);
    }
#endif    
}
