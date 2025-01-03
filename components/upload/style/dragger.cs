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
        public static CSSObject GenDraggerStyle(UploadToken token)
        {
            var componentCls = token.ComponentCls;
            var iconCls = token.IconCls;
            return new CSSObject
            {
                [$@"{componentCls}-wrapper"] = new CSSObject
                {
                    [$@"{componentCls}-drag"] = new CSSObject
                    {
                        Position = "relative",
                        Width = "100%",
                        Height = "100%",
                        TextAlign = "center",
                        Background = token.ColorFillAlter,
                        Border = $@"{Unit(token.LineWidth)} dashed {token.ColorBorder}",
                        BorderRadius = token.BorderRadiusLG,
                        Cursor = "pointer",
                        Transition = $@"{token.MotionDurationSlow}",
                        [componentCls] = new CSSObject
                        {
                            Padding = token.Padding,
                        },
                        [$@"{componentCls}-btn"] = new CSSObject
                        {
                            Display = "table",
                            Width = "100%",
                            Height = "100%",
                            Outline = "none",
                            BorderRadius = token.BorderRadiusLG,
                            ["&:focus-visible"] = new CSSObject
                            {
                                Outline = $@"{Unit(token.LineWidthFocus)} solid {token.ColorPrimaryBorder}",
                            },
                        },
                        [$@"{componentCls}-drag-container"] = new CSSObject
                        {
                            Display = "table-cell",
                            VerticalAlign = "middle",
                        },
                        [$@"{componentCls}-disabled):hover,
          &-hover:not({componentCls}-disabled)
        "] = new CSSObject
                        {
                            BorderColor = token.ColorPrimaryHover,
                        },
                        [$@"{componentCls}-drag-icon"] = new CSSObject
                        {
                            MarginBottom = token.Margin,
                            [iconCls] = new CSSObject
                            {
                                Color = token.ColorPrimary,
                                FontSize = token.UploadThumbnailSize,
                            },
                        },
                        [$@"{componentCls}-text"] = new CSSObject
                        {
                            Margin = $@"{Unit(token.MarginXXS)}",
                            Color = token.ColorTextHeading,
                            FontSize = token.FontSizeLG,
                        },
                        [$@"{componentCls}-hint"] = new CSSObject
                        {
                            Color = token.ColorTextDescription,
                            FontSize = token.FontSize,
                        },
                        [$@"{componentCls}-disabled"] = new CSSObject
                        {
                            [$@"{componentCls}-drag-icon {iconCls},
            p{componentCls}-text,
            p{componentCls}-hint
          "] = new CSSObject
                            {
                                Color = token.ColorTextDisabled,
                            },
                        },
                    },
                },
            };
        }

        public static object DraggerDefault()
        {
            return GenDraggerStyle;
        }
    }
}