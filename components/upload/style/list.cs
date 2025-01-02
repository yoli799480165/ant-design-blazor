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
    public partial class UploadStyle
    {
        public static CSSObject GenListStyle(UploadToken token)
        {
            var componentCls = token.ComponentCls;
            var iconCls = token.IconCls;
            var fontSize = token.FontSize;
            var lineHeight = token.LineHeight;
            var calc = token.Calc;
            var itemCls = $@"{componentCls}-list-item";
            var actionsCls = $@"{itemCls}-actions";
            var actionCls = $@"{itemCls}-action";
            return new CSSObject
            {
                [$@"{componentCls}-wrapper"] = new CSSObject
                {
                    [$@"{componentCls}-list"] = new CSSObject
                    {
                        ["..."] = ClearFix(),
                        LineHeight = token.LineHeight,
                        [itemCls] = new CSSObject
                        {
                            Position = "relative",
                            Height = calc(token.lineHeight).mul(fontSize).Equal(),
                            MarginTop = token.MarginXS,
                            Display = "flex",
                            AlignItems = "center",
                            Transition = $@"{token.MotionDurationSlow}",
                            BorderRadius = token.BorderRadiusSM,
                            ["&:hover"] = new CSSObject
                            {
                                BackgroundColor = token.ControlItemBgHover,
                            },
                            [$@"{itemCls}-name"] = new CSSObject
                            {
                                ["..."] = textEllipsis,
                                Padding = $@"{Unit(token.PaddingXS)}",
                                Flex = "auto",
                                Transition = $@"{token.MotionDurationSlow}",
                            },
                            [actionsCls] = new CSSObject
                            {
                                WhiteSpace = "nowrap",
                                [actionCls] = new CSSObject
                                {
                                    Opacity = 0,
                                },
                                [iconCls] = new CSSObject
                                {
                                    Color = token.ActionsColor,
                                    Transition = $@"{token.MotionDurationSlow}",
                                },
                                [$@"{actionCls}:focus-visible,
              &.picture {actionCls}
            "] = new CSSObject
                                {
                                    Opacity = 1,
                                },
                            },
                            [$@"{componentCls}-icon {iconCls}"] = new CSSObject
                            {
                                Color = token.ColorTextDescription,
                            },
                            [$@"{itemCls}-progress"] = new CSSObject
                            {
                                Position = "absolute",
                                Bottom = token.calc(token.uploadProgressOffset).mul(-1).Equal(),
                                Width = "100%",
                                PaddingInlineStart = calc(fontSize).add(token.paddingXS).Equal(),
                                LineHeight = 0,
                                PointerEvents = "none",
                                ["> div"] = new CSSObject
                                {
                                    Margin = 0,
                                },
                            },
                        },
                        [$@"{itemCls}:hover {actionCls}"] = new CSSObject
                        {
                            Opacity = 1,
                        },
                        [$@"{itemCls}-error"] = new CSSObject
                        {
                            Color = token.ColorError,
                            [$@"{itemCls}-name, {componentCls}-icon {iconCls}"] = new CSSObject
                            {
                                Color = token.ColorError,
                            },
                            [actionsCls] = new CSSObject
                            {
                                [$@"{iconCls}, {iconCls}:hover"] = new CSSObject
                                {
                                    Color = token.ColorError,
                                },
                                [actionCls] = new CSSObject
                                {
                                    Opacity = 1,
                                },
                            },
                        },
                        [$@"{componentCls}-list-item-container"] = new CSSObject
                        {
                            Transition = $@"{token.MotionDurationSlow}, height {token.MotionDurationSlow}",
                            ["&::before"] = new CSSObject
                            {
                                Display = "table",
                                Width = 0,
                                Height = 0,
                                Content = "\"\"",
                            },
                        },
                    },
                },
            };
        }

        public static object ListDefault()
        {
            return genListStyle;
        }
    }
}