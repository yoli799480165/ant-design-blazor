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
    public partial class ResultStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public double TitleFontSize { get; set; }
            public double SubtitleFontSize { get; set; }
            public double IconFontSize { get; set; }
            public string ExtraMargin { get; set; }
        }

        public class ResultToken : ComponentToken
        {
            public string ImageWidth { get; set; }
            public string ImageHeight { get; set; }
            public string ResultInfoIconColor { get; set; }
            public string ResultSuccessIconColor { get; set; }
            public string ResultWarningIconColor { get; set; }
            public string ResultErrorIconColor { get; set; }
        }

        public static CSSObject GenBaseStyle(ResultToken token)
        {
            var componentCls = token.ComponentCls;
            var lineHeightHeading3 = token.LineHeightHeading3;
            var iconCls = token.IconCls;
            var padding = token.Padding;
            var paddingXL = token.PaddingXL;
            var paddingXS = token.PaddingXS;
            var paddingLG = token.PaddingLG;
            var marginXS = token.MarginXS;
            var lineHeight = token.LineHeight;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    Padding = $@"{Unit(token.calc(paddingLG).mul(2).Equal())} {Unit(paddingXL)}",
                    ["&-rtl"] = new CSSObject
                    {
                        Direction = "rtl",
                    },
                },
                [$@"{componentCls} {componentCls}-image"] = new CSSObject
                {
                    Width = token.ImageWidth,
                    Height = token.ImageHeight,
                    Margin = "auto",
                },
                [$@"{componentCls} {componentCls}-icon"] = new CSSObject
                {
                    MarginBottom = paddingLG,
                    TextAlign = "center",
                    [$@"{iconCls}"] = new CSSObject
                    {
                        FontSize = token.IconFontSize,
                    },
                },
                [$@"{componentCls} {componentCls}-title"] = new CSSObject
                {
                    Color = token.ColorTextHeading,
                    FontSize = token.TitleFontSize,
                    LineHeight = lineHeightHeading3,
                    MarginBlock = marginXS,
                    TextAlign = "center",
                },
                [$@"{componentCls} {componentCls}-subtitle"] = new CSSObject
                {
                    Color = token.ColorTextDescription,
                    FontSize = token.SubtitleFontSize,
                    TextAlign = "center",
                },
                [$@"{componentCls} {componentCls}-content"] = new CSSObject
                {
                    MarginTop = paddingLG,
                    Padding = $@"{Unit(paddingLG)} {Unit(token.calc(padding).mul(2.5).Equal())}",
                    BackgroundColor = token.ColorFillAlter,
                },
                [$@"{componentCls} {componentCls}-extra"] = new CSSObject
                {
                    Margin = token.ExtraMargin,
                    TextAlign = "center",
                    ["& > *"] = new CSSObject
                    {
                        MarginInlineEnd = paddingXS,
                        ["&:last-child"] = new CSSObject
                        {
                            MarginInlineEnd = 0,
                        },
                    },
                },
            };
        }

        public static CSSObject GenStatusIconStyle(ResultToken token)
        {
            var componentCls = token.ComponentCls;
            var iconCls = token.IconCls;
            return new CSSObject
            {
                [$@"{componentCls}-success {componentCls}-icon > {iconCls}"] = new CSSObject
                {
                    Color = token.ResultSuccessIconColor,
                },
                [$@"{componentCls}-error {componentCls}-icon > {iconCls}"] = new CSSObject
                {
                    Color = token.ResultErrorIconColor,
                },
                [$@"{componentCls}-info {componentCls}-icon > {iconCls}"] = new CSSObject
                {
                    Color = token.ResultInfoIconColor,
                },
                [$@"{componentCls}-warning {componentCls}-icon > {iconCls}"] = new CSSObject
                {
                    Color = token.ResultWarningIconColor,
                },
            };
        }

        public static CSSObject GenResultStyle(ResultToken token)
        {
            return new object[]
            {
                GenBaseStyle(token),
                GenStatusIconStyle(token)
            };
        }

        public static CSSObject GetStyle(ResultToken token)
        {
            return GenResultStyle(token);
        }

        public static ResultToken PrepareComponentToken(ResultToken token)
        {
            return new ResultToken
            {
                TitleFontSize = token.FontSizeHeading3,
                SubtitleFontSize = token.FontSize,
                IconFontSize = token.FontSizeHeading3 * 3,
                ExtraMargin = $@"{token.PaddingLG}px 0 0 0",
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Result", (ResultToken token) =>
            {
                var resultInfoIconColor = token.ColorInfo;
                var resultErrorIconColor = token.ColorError;
                var resultSuccessIconColor = token.ColorSuccess;
                var resultWarningIconColor = token.ColorWarning;
                var resultToken = MergeToken(token, new object { ImageWidth = 250, ImageHeight = 295, });
                return new object[]
                {
                    GetStyle(resultToken)
                };
            }, prepareComponentToken);
        }
    }
}