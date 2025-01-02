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
    public partial class BackTopStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public double ZIndexPopup { get; set; }
        }

        public class BackTopToken : ComponentToken
        {
            public string BackTopBackground { get; set; }
            public string BackTopColor { get; set; }
            public string BackTopHoverBackground { get; set; }
            public double BackTopFontSize { get; set; }
            public double BackTopSize { get; set; }
            public string BackTopBlockEnd { get; set; }
            public string BackTopInlineEnd { get; set; }
            public string BackTopInlineEndMD { get; set; }
            public string BackTopInlineEndXS { get; set; }
        }

        public static CSSObject GenSharedBackTopStyle(BackTopToken token)
        {
            var componentCls = token.ComponentCls;
            var backTopFontSize = token.BackTopFontSize;
            var backTopSize = token.BackTopSize;
            var zIndexPopup = token.ZIndexPopup;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    Position = "fixed",
                    InsetInlineEnd = token.BackTopInlineEnd,
                    InsetBlockEnd = token.BackTopBlockEnd,
                    ZIndex = zIndexPopup,
                    Width = 40,
                    Height = 40,
                    Cursor = "pointer",
                    ["&:empty"] = new CSSObject
                    {
                        Display = "none",
                    },
                    [$@"{componentCls}-content"] = new CSSObject
                    {
                        Width = backTopSize,
                        Height = backTopSize,
                        Overflow = "hidden",
                        Color = token.BackTopColor,
                        TextAlign = "center",
                        BackgroundColor = token.BackTopBackground,
                        BorderRadius = backTopSize,
                        Transition = $@"{token.MotionDurationMid}",
                        ["&:hover"] = new CSSObject
                        {
                            BackgroundColor = token.BackTopHoverBackground,
                            Transition = $@"{token.MotionDurationMid}",
                        },
                    },
                    [$@"{componentCls}-icon"] = new CSSObject
                    {
                        FontSize = backTopFontSize,
                        LineHeight = Unit(backTopSize),
                    },
                },
            };
        }

        public static CSSObject GenMediaBackTopStyle(BackTopToken token)
        {
            var componentCls = token.ComponentCls;
            var screenMD = token.ScreenMD;
            var screenXS = token.ScreenXS;
            var backTopInlineEndMD = token.BackTopInlineEndMD;
            var backTopInlineEndXS = token.BackTopInlineEndXS;
            return new CSSObject
            {
                [$@"{Unit(screenMD)})"] = new CSSObject
                {
                    [componentCls] = new CSSObject
                    {
                        InsetInlineEnd = backTopInlineEndMD,
                    },
                },
                [$@"{Unit(screenXS)})"] = new CSSObject
                {
                    [componentCls] = new CSSObject
                    {
                        InsetInlineEnd = backTopInlineEndXS,
                    },
                },
            };
        }

        public static BackTopToken PrepareComponentToken(BackTopToken token)
        {
            return new BackTopToken
            {
                ZIndexPopup = token.ZIndexBase + 10,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("BackTop", (BackTopToken token) =>
            {
                var fontSizeHeading3 = token.FontSizeHeading3;
                var colorTextDescription = token.ColorTextDescription;
                var colorTextLightSolid = token.ColorTextLightSolid;
                var colorText = token.ColorText;
                var controlHeightLG = token.ControlHeightLG;
                var calc = token.Calc;
                var backTopToken = MergeToken(token, new object { BackTopBackground = colorTextDescription, BackTopColor = colorTextLightSolid, BackTopHoverBackground = colorText, BackTopFontSize = fontSizeHeading3, BackTopSize = controlHeightLG, BackTopBlockEnd = calc(controlHeightLG).mul(1.25).Equal(), BackTopInlineEnd = calc(controlHeightLG).mul(2.5).Equal(), BackTopInlineEndMD = calc(controlHeightLG).mul(1.5).Equal(), BackTopInlineEndXS = calc(controlHeightLG).mul(0.5).Equal(), });
                return new object[]
                {
                    GenSharedBackTopStyle(backTopToken),
                    GenMediaBackTopStyle(backTopToken)
                };
            }, prepareComponentToken);
        }
    }
}