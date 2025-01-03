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
    public partial class ButtonStyle
    {
        public static CSSObject GenButtonCompactStyle(ButtonToken token)
        {
            var componentCls = token.ComponentCls;
            var colorPrimaryHover = token.ColorPrimaryHover;
            var lineWidth = token.LineWidth;
            var calc = token.Calc;
            var insetOffset = Calc(lineWidth).Mul(-1).Equal();
            var getCompactBorderStyle = (boolean vertical) =>
            {
                return (new object
                {
                    [$@"{componentCls}-compact{vertical ? "-vertical" : ""}-item{componentCls}-primary:not([disabled])"] = new object
                    {
                        ["& + &::before"] = new object
                        {
                            Position = "absolute",
                            Top = vertical ? insetOffset : 0,
                            InsetInlineStart = vertical ? 0 : insetOffset,
                            BackgroundColor = colorPrimaryHover,
                            Content = "\"\"",
                            Width = vertical ? "100%" : lineWidth,
                            Height = vertical ? lineWidth : "100%",
                        },
                    },
                }

                ) as CSSObject;
            };
            return new CSSObject
            {
                ["..."] = GetCompactBorderStyle(),
                ["..."] = GetCompactBorderStyle(true),
            };
        }

        public static object CompactDefault()
        {
            return GenSubStyleComponent(new object[] { "Button", "compact" }, (ButtonToken token) =>
            {
                var buttonToken = PrepareToken(token);
                return new object[]
                {
                    GenCompactItemStyle(buttonToken),
                    GenCompactItemVerticalStyle(buttonToken),
                    GenButtonCompactStyle(buttonToken)
                };
            }, PrepareComponentToken);
        }
    }
}