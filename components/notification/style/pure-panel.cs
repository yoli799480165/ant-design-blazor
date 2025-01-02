using System;
using AntDesign;
using CssInCSharp;
using CssInCSharp.Colors;
using static CssInCSharp.Css.CSSUtil;
using static AntDesign.GlobalStyle;
using static AntDesign.Theme;
using static AntDesign.StyleUtil;
using Keyframes = CssInCSharp.Keyframe;

namespace AntDesign.Styles
{
    public partial class NotificationStyle
    {
        public static object PurePanelDefault()
        {
            return GenSubStyleComponent(new object[] { "Notification", "PurePanel" }, (NotificationToken token) =>
            {
                var noticeCls = $@"{token.ComponentCls}-notice";
                var notificationToken = PrepareNotificationToken(token);
                return new object
                {
                    [$@"{noticeCls}-pure-panel"] = new object
                    {
                        ["..."] = GenNoticeStyle(notificationToken),
                        Width = notificationToken.Width,
                        MaxWidth = $@"{Unit(token.calc(notificationToken.notificationMarginEdge).mul(2).Equal())})",
                        Margin = 0,
                    },
                };
            }, prepareComponentToken);
        }
    }
}