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
    public partial class PaginationStyle
    {
        public static CSSObject GenBorderedStyle(PaginationToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [$@"{componentCls}{componentCls}-bordered{componentCls}-disabled:not({componentCls}-mini)"] = new CSSObject
                {
                    ["&, &:hover"] = new CSSObject
                    {
                        [$@"{componentCls}-item-link"] = new CSSObject
                        {
                            BorderColor = token.ColorBorder,
                        },
                    },
                    ["&:focus-visible"] = new CSSObject
                    {
                        [$@"{componentCls}-item-link"] = new CSSObject
                        {
                            BorderColor = token.ColorBorder,
                        },
                    },
                    [$@"{componentCls}-item, {componentCls}-item-link"] = new CSSObject
                    {
                        BackgroundColor = token.ColorBgContainerDisabled,
                        BorderColor = token.ColorBorder,
                        [$@"{componentCls}-item-active)"] = new CSSObject
                        {
                            BackgroundColor = token.ColorBgContainerDisabled,
                            BorderColor = token.ColorBorder,
                            ["a"] = new CSSObject
                            {
                                Color = token.ColorTextDisabled,
                            },
                        },
                        [$@"{componentCls}-item-active"] = new CSSObject
                        {
                            BackgroundColor = token.ItemActiveBgDisabled,
                        },
                    },
                    [$@"{componentCls}-prev, {componentCls}-next"] = new CSSObject
                    {
                        ["&:hover button"] = new CSSObject
                        {
                            BackgroundColor = token.ColorBgContainerDisabled,
                            BorderColor = token.ColorBorder,
                            Color = token.ColorTextDisabled,
                        },
                        [$@"{componentCls}-item-link"] = new CSSObject
                        {
                            BackgroundColor = token.ColorBgContainerDisabled,
                            BorderColor = token.ColorBorder,
                        },
                    },
                },
                [$@"{componentCls}{componentCls}-bordered:not({componentCls}-mini)"] = new CSSObject
                {
                    [$@"{componentCls}-prev, {componentCls}-next"] = new CSSObject
                    {
                        ["&:hover button"] = new CSSObject
                        {
                            BorderColor = token.ColorPrimaryHover,
                            BackgroundColor = token.ItemBg,
                        },
                        [$@"{componentCls}-item-link"] = new CSSObject
                        {
                            BackgroundColor = token.ItemLinkBg,
                            BorderColor = token.ColorBorder,
                        },
                        [$@"{componentCls}-item-link"] = new CSSObject
                        {
                            BorderColor = token.ColorPrimary,
                            BackgroundColor = token.ItemBg,
                            Color = token.ColorPrimary,
                        },
                        [$@"{componentCls}-disabled"] = new CSSObject
                        {
                            [$@"{componentCls}-item-link"] = new CSSObject
                            {
                                BorderColor = token.ColorBorder,
                                Color = token.ColorTextDisabled,
                            },
                        },
                    },
                    [$@"{componentCls}-item"] = new CSSObject
                    {
                        BackgroundColor = token.ItemBg,
                        Border = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorBorder}",
                        [$@"{componentCls}-item-active)"] = new CSSObject
                        {
                            BorderColor = token.ColorPrimary,
                            BackgroundColor = token.ItemBg,
                            ["a"] = new CSSObject
                            {
                                Color = token.ColorPrimary,
                            },
                        },
                        ["&-active"] = new CSSObject
                        {
                            BorderColor = token.ColorPrimary,
                        },
                    },
                },
            };
        }

        public static object BorderedDefault()
        {
            return GenSubStyleComponent(new object[] { "Pagination", "bordered" }, (PaginationToken token) =>
            {
                var paginationToken = PrepareToken(token);
                return new object[]
                {
                    GenBorderedStyle(paginationToken)
                };
            }, PrepareComponentToken);
        }
    }
}