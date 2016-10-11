﻿using System.ComponentModel;
namespace Entities.Enums
{
    /// <summary>
    /// Danh sách các nhóm chức năng
    /// </summary>
    public enum ModuleGroupEnum
    {
        //[Description("Quản trị hệ thống")]
        //System = 1,
        //[Description("Quản trị nội dung")]
        //Content = 2,
        //[Description("Quản lý hồ sơ cựu sinh viên")]
        //Profile = 3,
        //[Description("Ban liên lạc")]
        //Committee = 4,

        [Description("Quản trị hệ thống")]
        System = 1,
        [Description("Quản lý nhà cho thuê")]
        Nha = 2,
        [Description("Quản lý khách thuê")]
        Khach = 3,
        [Description("Quản lý nhu cầu thuê")]
        NhuCauThue = 4,
        [Description("Quản lý công việc")]
        CongViec = 5,
    }
}