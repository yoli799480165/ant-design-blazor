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
        public static CSSObject GenButtonBorderStyle(string buttonTypeCls, string borderColor)
        {
            return new CSSObject
            {
                [$@"{buttonTypeCls}"] = new CSSObject
                {
                    ["&:not(:last-child)"] = new CSSObject
                    {
                        [$@"{buttonTypeCls}"] = new CSSObject
                        {
                            ["&:not(:disabled)"] = new CSSObject
                            {
                                BorderInlineEndColor = borderColor,
                            },
                        },
                    },
                    ["&:not(:first-child)"] = new CSSObject
                    {
                        [$@"{buttonTypeCls}"] = new CSSObject
                        {
                            ["&:not(:disabled)"] = new CSSObject
                            {
                                BorderInlineStartColor = borderColor,
                            },
                        },
                    },
                },
            };
        }

        public static CSSObject GenGroupStyle(ButtonToken token)
        {
            var componentCls = token.ComponentCls;
            var fontSize = token.FontSize;
            var lineWidth = token.LineWidth;
            var groupBorderColor = token.GroupBorderColor;
            var colorErrorHover = token.ColorErrorHover;
            return new CSSObject
            {
                [$@"{componentCls}-group"] = new object[]
                {
                    new object
                    {
                        Position = "relative",
                        Display = "inline-flex",
                        [$@"{componentCls}"] = new object
                        {
                            ["&:not(:last-child)"] = new object
                            {
                                [$@"{componentCls}"] = new object
                                {
                                    BorderStartEndRadius = 0,
                                    BorderEndEndRadius = 0,
                                },
                            },
                            ["&:not(:first-child)"] = new object
                            {
                                MarginInlineStart = token.Calc(lineWidth).Mul(-1).Equal(),
                                [$@"{componentCls}"] = new object
                                {
                                    BorderStartStartRadius = 0,
                                    BorderEndStartRadius = 0,
                                },
                            },
                        },
                        [componentCls] = new object
                        {
                            Position = "relative",
                            ZIndex = 1,
                            ["&:hover, &:focus, &:active"] = new object
                            {
                                ZIndex = 2,
                            },
                            ["&[disabled]"] = new object
                            {
                                ZIndex = 0,
                            },
                        },
                        [$@"{componentCls}-icon-only"] = new object
                        {
                        },
                    },
                    GenButtonBorderStyle($@"{componentCls}-primary", groupBorderColor),
                    GenButtonBorderStyle($@"{componentCls}-danger", colorErrorHover)
                },
            };
        }

        public static object GroupDefault()
        {
            return GenGroupStyle;
        }
    }
}