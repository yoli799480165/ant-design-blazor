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
    public partial class LayoutStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public string ColorBgHeader { get; set; }
            public string ColorBgBody { get; set; }
            public string ColorBgTrigger { get; set; }
            public string BodyBg { get; set; }
            public string HeaderBg { get; set; }
            public string HeaderHeight { get; set; }
            public string HeaderPadding { get; set; }
            public string HeaderColor { get; set; }
            public string FooterPadding { get; set; }
            public string FooterBg { get; set; }
            public string SiderBg { get; set; }
            public string TriggerHeight { get; set; }
            public string TriggerBg { get; set; }
            public string TriggerColor { get; set; }
            public double ZeroTriggerWidth { get; set; }
            public double ZeroTriggerHeight { get; set; }
            public string LightSiderBg { get; set; }
            public string LightTriggerBg { get; set; }
            public string LightTriggerColor { get; set; }
        }

        public class LayoutToken : ComponentToken
        {
        }

        public static CSSObject GenLayoutStyle(LayoutToken token)
        {
            var antCls = token.AntCls;
            var componentCls = token.ComponentCls;
            var colorText = token.ColorText;
            var footerBg = token.FooterBg;
            var headerHeight = token.HeaderHeight;
            var headerPadding = token.HeaderPadding;
            var headerColor = token.HeaderColor;
            var footerPadding = token.FooterPadding;
            var fontSize = token.FontSize;
            var bodyBg = token.BodyBg;
            var headerBg = token.HeaderBg;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    Display = "flex",
                    Flex = "auto",
                    FlexDirection = "column",
                    MinHeight = 0,
                    Background = bodyBg,
                    ["&, *"] = new CSSObject
                    {
                        BoxSizing = "border-box",
                    },
                    [$@"{componentCls}-has-sider"] = new CSSObject
                    {
                        FlexDirection = "row",
                        [$@"{componentCls}, > {componentCls}-content"] = new CSSObject
                        {
                            Width = 0,
                        },
                    },
                    [$@"{componentCls}-header, &{componentCls}-footer"] = new CSSObject
                    {
                        Flex = "0 0 auto",
                    },
                    ["&-rtl"] = new CSSObject
                    {
                        Direction = "rtl",
                    },
                },
                [$@"{componentCls}-header"] = new CSSObject
                {
                    Height = headerHeight,
                    Padding = headerPadding,
                    Color = headerColor,
                    LineHeight = Unit(headerHeight),
                    Background = headerBg,
                    [$@"{antCls}-menu"] = new CSSObject
                    {
                        LineHeight = "inherit",
                    },
                },
                [$@"{componentCls}-footer"] = new CSSObject
                {
                    Padding = footerPadding,
                    Color = colorText,
                    Background = footerBg,
                },
                [$@"{componentCls}-content"] = new CSSObject
                {
                    Flex = "auto",
                    Color = colorText,
                    MinHeight = 0,
                },
            };
        }

        public static LayoutToken PrepareComponentToken(LayoutToken token)
        {
            var colorBgLayout = token.ColorBgLayout;
            var controlHeight = token.ControlHeight;
            var controlHeightLG = token.ControlHeightLG;
            var colorText = token.ColorText;
            var controlHeightSM = token.ControlHeightSM;
            var marginXXS = token.MarginXXS;
            var colorTextLightSolid = token.ColorTextLightSolid;
            var colorBgContainer = token.ColorBgContainer;
            var paddingInline = controlHeightLG * 1.25;
            return new LayoutToken
            {
                ColorBgHeader = "#001529",
                ColorBgBody = colorBgLayout,
                ColorBgTrigger = "#002140",
                BodyBg = colorBgLayout,
                HeaderBg = "#001529",
                HeaderHeight = controlHeight * 2,
                HeaderPadding = $@"{paddingInline}px",
                HeaderColor = colorText,
                FooterPadding = $@"{controlHeightSM}px {paddingInline}px",
                FooterBg = colorBgLayout,
                SiderBg = "#001529",
                TriggerHeight = controlHeightLG + marginXXS * 2,
                TriggerBg = "#002140",
                TriggerColor = colorTextLightSolid,
                ZeroTriggerWidth = controlHeightLG,
                ZeroTriggerHeight = controlHeightLG,
                LightSiderBg = colorBgContainer,
                LightTriggerBg = colorBgContainer,
                LightTriggerColor = colorText,
            };
        }

        public object DEPRECATED_TOKENS = new object[]
        {
            new object[]
            {
                "colorBgBody",
                "bodyBg"
            },
            new object[]
            {
                "colorBgHeader",
                "headerBg"
            },
            new object[]
            {
                "colorBgTrigger",
                "triggerBg"
            }
        };
        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Layout", (LayoutToken token) =>
            {
                return new object[]
                {
                    GenLayoutStyle(token)
                };
            }, PrepareComponentToken, new object { DeprecatedTokens = DEPRECATED_TOKENS, });
        }
    }
}