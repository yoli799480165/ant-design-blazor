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
    public partial class InputStyle
    {
        public static CSSObject GenOTPStyle(InputToken token)
        {
            var componentCls = token.ComponentCls;
            var paddingXS = token.PaddingXS;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    Display = "inline-flex",
                    AlignItems = "center",
                    FlexWrap = "nowrap",
                    ColumnGap = paddingXS,
                    ["&-rtl"] = new CSSObject
                    {
                        Direction = "rtl",
                    },
                    [$@"{componentCls}-input"] = new CSSObject
                    {
                        TextAlign = "center",
                        PaddingInline = token.PaddingXXS,
                    },
                    [$@"{componentCls}-sm {componentCls}-input"] = new CSSObject
                    {
                        PaddingInline = token.Calc(token.PaddingXXS).Div(2).Equal(),
                    },
                    [$@"{componentCls}-lg {componentCls}-input"] = new CSSObject
                    {
                        PaddingInline = token.PaddingXS,
                    },
                },
            };
        }

        public static object OtpDefault()
        {
            return GenStyleHooks(new object[] { "Input", "OTP" }, (InputToken token) =>
            {
                var inputToken = MergeToken(token, InitInputToken(token));
                return new object[]
                {
                    GenOTPStyle(inputToken)
                };
            }, initComponentToken);
        }
    }
}