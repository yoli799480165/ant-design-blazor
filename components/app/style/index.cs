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
    public partial class AppStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
        }

        public class AppToken : ComponentToken
        {
        }

        public static CSSObject GenBaseStyle(AppToken token)
        {
            var componentCls = token.ComponentCls;
            var colorText = token.ColorText;
            var fontSize = token.FontSize;
            var lineHeight = token.LineHeight;
            var fontFamily = token.FontFamily;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    Color = colorText,
                    [$@"{componentCls}-rtl"] = new CSSObject
                    {
                        Direction = "rtl",
                    },
                },
            };
        }

        public static AppToken PrepareComponentToken()
        {
            return new AppToken
            {
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("App", GenBaseStyle, PrepareComponentToken);
        }
    }
}