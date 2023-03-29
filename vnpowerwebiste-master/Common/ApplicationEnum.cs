using System.ComponentModel;

namespace Common
{
    public enum ApplicationStatus
    {
        [Description("Đã xóa")]
        Delete = -1,
       /* [Description("Chưa xử lý")]
        Notyet = 1,*/
        [Description("Đang xử lý")]
        InProgress = 1,
        [Description("Hoàn thành")]
        Completed = 2,
    }

    public enum PostType
    {
        [Description("Trang chủ")]
        Home = 1,
        [Description("Bác sĩ")]
        Doctor = 2,
        [Description("Đặt lịch")]
        Appointment = 3,
    }
    public enum ContactStatus
    {
        [Description("Chưa trả lời")]
        NotYet = 0,     
        [Description("Đã trả lời")]
        Replied = 1,        
        [Description("Deleted")]
        Deleted = -1
    }
    public enum CommonStatus
    {
        [Description("Đã xóa")]
        Deleted = 2,

        [Description("Hoạt động")]
        Active = 1,

        [Description("Không Hoạt động")]
        DeActive = 0
    }

   
}
