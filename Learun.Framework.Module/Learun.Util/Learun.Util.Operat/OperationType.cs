using System.ComponentModel;

namespace Learun.Util.Operat
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.03.08
    /// 描 述：操作类型
    /// </summary>
    public enum OperationType
    {
        /// <summary>
        /// 其他
        /// </summary>
        [Description("其他")]
        Other = 0,
        /// <summary>
        /// 登陆
        /// </summary>
        [Description("登录")]
        Login = 1,
        /// <summary>
        /// 登陆
        /// </summary>
        [Description("退出")]
        Exit = 2,
        /// <summary>
        /// 访问
        /// </summary>
        [Description("访问")]
        Visit = 3,
        /// <summary>
        /// 离开
        /// </summary>
        [Description("离开")]
        Leave = 4,
        /// <summary>
        /// 新增
        /// </summary>
        [Description("新增")]
        Create = 5,
        /// <summary>
        /// 删除
        /// </summary>
        [Description("删除")]
        Delete = 6,
        /// <summary>
        /// 修改
        /// </summary>
        [Description("修改")]
        Update = 7,
        /// <summary>
        /// 提交
        /// </summary>
        [Description("提交")]
        Submit = 8,
        /// <summary>
        /// 异常
        /// </summary>
        [Description("异常")]
        Exception = 9,
        /// <summary>
        /// 异常
        /// </summary>
        [Description("移动登录")]
        AppLogin = 10,
    }


    public enum LeaveType
    {

        /// <summary>
        ///事假
        /// </summary>
        [Description("事假")]
        事假 = 1,
        /// <summary>
        /// 病假
        /// </summary>
        [Description("病假")]
        病假 = 2,
        /// <summary>
        ///婚假
        /// </summary>
        [Description("婚假")]
        婚假 = 3,
        /// <summary>
        /// 离开
        /// </summary>
        [Description("年假")]
        年假 = 4,
        /// <summary>
        /// 产假
        /// </summary>
        [Description("产假")]
        Create = 5,
        /// <summary>
        ///调休
        /// </summary>
        [Description("调休")]
        调休 = 6,
        /// <summary>
        ///陪产假
        /// </summary>
        [Description("陪产假")]
        陪产假 = 7,
        /// <summary>
        /// 例假
        /// </summary>
        [Description("例假")]
        例假 = 8,
        /// <summary>
        /// 丧假
        /// </summary>
        [Description("丧假")]
        丧假 = 9,
        /// <summary>
        /// 哺乳假
        /// </summary>
        [Description("哺乳假")]
        哺乳假 = 10,


    }
}
