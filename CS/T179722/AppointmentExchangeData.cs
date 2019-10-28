using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace T179722 {
    [Serializable]
    [ComVisible(true)]
    [SecurityCritical]
    public class AppointmentExchangeData : ISerializable {
        public AppointmentExchangeData() {

        }

        public AppointmentExchangeData(SerializationInfo info, StreamingContext context) {
            Subject = (string)info.GetValue(nameof(Subject), typeof(string));
            Description = (string)info.GetValue(nameof(Description), typeof(string));
            LabelKey = (int)info.GetValue(nameof(LabelKey), typeof(int));
            StatusKey = (int)info.GetValue(nameof(StatusKey), typeof(int));
            Start = (DateTime)info.GetValue(nameof(Start), typeof(DateTime));
            Duration = (TimeSpan)info.GetValue(nameof(Duration), typeof(TimeSpan));

        }

        public string Subject { get; set; }
        public string Description { get; set; }
        public int LabelKey { get; set; }
        public int StatusKey { get; set; }
        public DateTime Start { get; set; }
        public TimeSpan Duration { get; set; }

        [SecurityCritical]
        public void GetObjectData(SerializationInfo info, StreamingContext context) {
            info.AddValue(nameof(Subject), Subject, typeof(string));
            info.AddValue(nameof(Description), Description, typeof(string));
            info.AddValue(nameof(LabelKey), LabelKey, typeof(int));
            info.AddValue(nameof(StatusKey), StatusKey, typeof(int));
            info.AddValue(nameof(Start), Start, typeof(DateTime));
            info.AddValue(nameof(Duration), Duration, typeof(TimeSpan));
        }

    }
}