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
    public partial class TypographyStyle
    {
        public static CSSObject GetTitleStyle(number fontSize, number lineHeight, string color, TypographyToken token)
        {
            var titleMarginBottom = token.TitleMarginBottom;
            var fontWeightStrong = token.FontWeightStrong;
            return new CSSObject
            {
                MarginBottom = titleMarginBottom,
                FontWeight = fontWeightStrong,
            };
        }

        public static object GetTitleStyles(TypographyToken token)
        {
            var headings = new object[]
            {
                1,
                2,
                3,
                4,
                5
            };
            var styles = new object
            {
            }

            as CSSObject;
            return styles;
        }

        public static object GetLinkStyles(TypographyToken token)
        {
            var componentCls = token.ComponentCls;
            return new object
            {
                ["a&, a"] = new object
                {
                    ["..."] = OperationUnit(token),
                    UserSelect = "text",
                    [$@"{componentCls}-disabled"] = new object
                    {
                        Color = token.ColorTextDisabled,
                        Cursor = "not-allowed",
                        ["&:active, &:hover"] = new object
                        {
                            Color = token.ColorTextDisabled,
                        },
                        ["&:active"] = new object
                        {
                            PointerEvents = "none",
                        },
                    },
                },
            };
        }

        public static CSSObject GetResetStyles(TypographyToken token)
        {
            return new CSSObject
            {
                ["code"] = new CSSObject
                {
                    Margin = "0 0.2em",
                    PaddingInline = "0.4em",
                    PaddingBlock = "0.2em 0.1em",
                    FontSize = "85%",
                    FontFamily = token.FontFamilyCode,
                    Background = "rgba(150, 150, 150, 0.1)",
                    Border = "1px solid rgba(100, 100, 100, 0.2)",
                    BorderRadius = 3,
                },
                ["kbd"] = new CSSObject
                {
                    Margin = "0 0.2em",
                    PaddingInline = "0.4em",
                    PaddingBlock = "0.15em 0.1em",
                    FontSize = "90%",
                    FontFamily = token.FontFamilyCode,
                    Background = "rgba(150, 150, 150, 0.06)",
                    Border = "1px solid rgba(100, 100, 100, 0.2)",
                    BorderBottomWidth = 2,
                    BorderRadius = 3,
                },
                ["mark"] = new CSSObject
                {
                    Padding = 0,
                    BackgroundColor = gold[2],
                },
                ["u, ins"] = new CSSObject
                {
                    TextDecoration = "underline",
                    TextDecorationSkipInk = "auto",
                },
                ["s, del"] = new CSSObject
                {
                    TextDecoration = "line-through",
                },
                ["strong"] = new CSSObject
                {
                    FontWeight = 600,
                },
                ["ul, ol"] = new CSSObject
                {
                    MarginInline = 0,
                    MarginBlock = "0 1em",
                    Padding = 0,
                    ["li"] = new CSSObject
                    {
                        MarginInline = "20px 0",
                        MarginBlock = 0,
                        PaddingInline = "4px 0",
                        PaddingBlock = 0,
                    },
                },
                ["ul"] = new CSSObject
                {
                    ListStyleType = "circle",
                    ["ul"] = new CSSObject
                    {
                        ListStyleType = "disc",
                    },
                },
                ["ol"] = new CSSObject
                {
                    ListStyleType = "decimal",
                },
                ["pre, blockquote"] = new CSSObject
                {
                    Margin = "1em 0",
                },
                ["pre"] = new CSSObject
                {
                    Padding = "0.4em 0.6em",
                    WhiteSpace = "pre-wrap",
                    WordWrap = "break-word",
                    Background = "rgba(150, 150, 150, 0.1)",
                    Border = "1px solid rgba(100, 100, 100, 0.2)",
                    BorderRadius = 3,
                    FontFamily = token.FontFamilyCode,
                    ["code"] = new CSSObject
                    {
                        Display = "inline",
                        Margin = 0,
                        Padding = 0,
                        FontSize = "inherit",
                        FontFamily = "inherit",
                        Background = "transparent",
                        Border = 0,
                    },
                },
                ["blockquote"] = new CSSObject
                {
                    PaddingInline = "0.6em 0",
                    PaddingBlock = 0,
                    BorderInlineStart = "4px solid rgba(100, 100, 100, 0.2)",
                    Opacity = 0.85,
                },
            };
        }

        public static object GetEditableStyles(TypographyToken token)
        {
            var componentCls = token.ComponentCls;
            var paddingSM = token.PaddingSM;
            var inputShift = paddingSM;
            return new object
            {
                ["&-edit-content"] = new object
                {
                    Position = "relative",
                    ["div&"] = new object
                    {
                        InsetInlineStart = token.calc(token.paddingSM).mul(-1).Equal(),
                        MarginTop = token.calc(inputShift).mul(-1).Equal(),
                        MarginBottom = $@"{Unit(inputShift)})",
                    },
                    [$@"{componentCls}-edit-content-confirm"] = new object
                    {
                        Position = "absolute",
                        InsetInlineEnd = token.calc(token.marginXS).add(2).Equal(),
                        InsetBlockEnd = token.MarginXS,
                        Color = token.ColorTextDescription,
                        FontWeight = "normal",
                        FontSize = token.FontSize,
                        FontStyle = "normal",
                        PointerEvents = "none",
                    },
                    ["textarea"] = new object
                    {
                        Margin = "0!important",
                        MozTransition = "none",
                        Height = "1em",
                    },
                },
            };
        }

        public static object GetCopyableStyles(TypographyToken token)
        {
            return new object
            {
                [$@"{token.ComponentCls}-copy-success"] = new object
                {
                    ["\n    &,\n    &:hover,\n    &:focus"] = new object
                    {
                        Color = token.ColorSuccess,
                    },
                },
                [$@"{token.ComponentCls}-copy-icon-only"] = new object
                {
                    MarginInlineStart = 0,
                },
            };
        }

        public static CSSObject GetEllipsisStyles()
        {
            return new CSSObject
            {
                ["\n  a&-ellipsis,\n  span&-ellipsis\n  "] = new CSSObject
                {
                    Display = "inline-block",
                    MaxWidth = "100%",
                },
                ["&-ellipsis-single-line"] = new CSSObject
                {
                    WhiteSpace = "nowrap",
                    Overflow = "hidden",
                    TextOverflow = "ellipsis",
                    ["a&, span&"] = new CSSObject
                    {
                        VerticalAlign = "bottom",
                    },
                    ["> code"] = new CSSObject
                    {
                        PaddingBlock = 0,
                        MaxWidth = "calc(100% - 1.2em)",
                        Display = "inline-block",
                        Overflow = "hidden",
                        TextOverflow = "ellipsis",
                        VerticalAlign = "bottom",
                        BoxSizing = "content-box",
                    },
                },
                ["&-ellipsis-multiple-line"] = new CSSObject
                {
                    Display = "-webkit-box",
                    Overflow = "hidden",
                    WebkitLineClamp = 3,
                    WebkitBoxOrient = "vertical",
                },
            };
        }
    }
}