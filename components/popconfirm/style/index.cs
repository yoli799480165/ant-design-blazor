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
    public partial class PopconfirmStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public double ZIndexPopup { get; set; }
        }

        public class PopconfirmToken : ComponentToken
        {
        }

        public static CSSObject GenBaseStyle(PopconfirmToken token)
        {
            var componentCls = token.ComponentCls;
            var iconCls = token.IconCls;
            var antCls = token.AntCls;
            var zIndexPopup = token.ZIndexPopup;
            var colorText = token.ColorText;
            var colorWarning = token.ColorWarning;
            var marginXXS = token.MarginXXS;
            var marginXS = token.MarginXS;
            var fontSize = token.FontSize;
            var fontWeightStrong = token.FontWeightStrong;
            var colorTextHeading = token.ColorTextHeading;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ZIndex = zIndexPopup,
                    [$@"{antCls}-popover"] = new CSSObject
                    {
                    },
                    [$@"{componentCls}-message"] = new CSSObject
                    {
                        MarginBottom = marginXS,
                        Display = "flex",
                        FlexWrap = "nowrap",
                        AlignItems = "start",
                        [$@"{componentCls}-message-icon {iconCls}"] = new CSSObject
                        {
                            Color = colorWarning,
                            LineHeight = 1,
                            MarginInlineEnd = marginXS,
                        },
                        [$@"{componentCls}-title"] = new CSSObject
                        {
                            FontWeight = fontWeightStrong,
                            Color = colorTextHeading,
                            ["&:only-child"] = new CSSObject
                            {
                                FontWeight = "normal",
                            },
                        },
                        [$@"{componentCls}-description"] = new CSSObject
                        {
                            MarginTop = marginXXS,
                            Color = colorText,
                        },
                    },
                    [$@"{componentCls}-buttons"] = new CSSObject
                    {
                        TextAlign = "end",
                        WhiteSpace = "nowrap",
                        ["button"] = new CSSObject
                        {
                            MarginInlineStart = marginXS,
                        },
                    },
                },
            };
        }

        public static PopconfirmToken PrepareComponentToken(PopconfirmToken token)
        {
            var zIndexPopupBase = token.ZIndexPopupBase;
            return new PopconfirmToken
            {
                ZIndexPopup = zIndexPopupBase + 60,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Popconfirm", (PopconfirmToken token) =>
            {
                return GenBaseStyle(token);
            }, prepareComponentToken, new object { ResetStyle = false, });
        }
    }
}