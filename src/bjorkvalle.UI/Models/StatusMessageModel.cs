using bjorkvalle.UI.Enums;

namespace bjorkvalle.UI.Models
{
    public class StatusMessageModel
    {
        public string Message { get; set; }
        public Status Status { get; set; }
        public Color Color => Status switch
        {
            Status.Success => Color.Success,
            Status.Warning => Color.Warning,
            Status.Error => Color.Error,
            _ => Color.None
        };
    }

    public enum Status
    {
        Default,
        Success,
        Warning,
        Error
    }
}
