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
        public static CSSObject GenPictureStyle(UploadToken token)
        {
            var componentCls = token.ComponentCls;
            var iconCls = token.IconCls;
            var uploadThumbnailSize = token.UploadThumbnailSize;
            var uploadProgressOffset = token.UploadProgressOffset;
            var calc = token.Calc;
            var listCls = $@"{componentCls}-list";
            var itemCls = $@"{listCls}-item";
            return new CSSObject
            {
                [$@"{componentCls}-wrapper"] = new CSSObject
                {
                    [$@"{listCls}{listCls}-picture,
        {listCls}{listCls}-picture-card,
        {listCls}{listCls}-picture-circle
      "] = new CSSObject
                    {
                        [itemCls] = new CSSObject
                        {
                            Position = "relative",
                            Height = Calc(uploadThumbnailSize).Add(Calc(token.LineWidth).Mul(2)).Add(Calc(token.PaddingXS).Mul(2)).Equal(),
                            Padding = token.PaddingXS,
                            Border = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorBorder}",
                            BorderRadius = token.BorderRadiusLG,
                            ["&:hover"] = new CSSObject
                            {
                                Background = "transparent",
                            },
                            [$@"{itemCls}-thumbnail"] = new CSSObject
                            {
                                ["..."] = textEllipsis,
                                Width = uploadThumbnailSize,
                                Height = uploadThumbnailSize,
                                LineHeight = Unit(Calc(uploadThumbnailSize).Add(token.PaddingSM).Equal()),
                                TextAlign = "center",
                                Flex = "none",
                                [iconCls] = new CSSObject
                                {
                                    FontSize = token.FontSizeHeading2,
                                    Color = token.ColorPrimary,
                                },
                                ["img"] = new CSSObject
                                {
                                    Display = "block",
                                    Width = "100%",
                                    Height = "100%",
                                    Overflow = "hidden",
                                },
                            },
                            [$@"{itemCls}-progress"] = new CSSObject
                            {
                                Bottom = uploadProgressOffset,
                                Width = $@"{Unit(Calc(token.PaddingSM).Mul(2).Equal())})",
                                MarginTop = 0,
                                PaddingInlineStart = Calc(uploadThumbnailSize).Add(token.PaddingXS).Equal(),
                            },
                        },
                        [$@"{itemCls}-error"] = new CSSObject
                        {
                            BorderColor = token.ColorError,
                            [$@"{itemCls}-thumbnail {iconCls}"] = new CSSObject
                            {
                                [$@"{blue[0]}']"] = new CSSObject
                                {
                                    ["fill"] = token.ColorErrorBg,
                                },
                                [$@"{blue.Primary}']"] = new CSSObject
                                {
                                    ["fill"] = token.ColorError,
                                },
                            },
                        },
                        [$@"{itemCls}-uploading"] = new CSSObject
                        {
                            BorderStyle = "dashed",
                            [$@"{itemCls}-name"] = new CSSObject
                            {
                                MarginBottom = uploadProgressOffset,
                            },
                        },
                    },
                    [$@"{listCls}{listCls}-picture-circle {itemCls}"] = new CSSObject
                    {
                        [$@"{itemCls}-thumbnail"] = new CSSObject
                        {
                            BorderRadius = "50%",
                        },
                    },
                },
            };
        }

        public static CSSObject GenPictureCardStyle(UploadToken token)
        {
            var componentCls = token.ComponentCls;
            var iconCls = token.IconCls;
            var fontSizeLG = token.FontSizeLG;
            var colorTextLightSolid = token.ColorTextLightSolid;
            var calc = token.Calc;
            var listCls = $@"{componentCls}-list";
            var itemCls = $@"{listCls}-item";
            var uploadPictureCardSize = token.UploadPicCardSize;
            return new CSSObject
            {
                [$@"{componentCls}-wrapper{componentCls}-picture-card-wrapper,
      {componentCls}-wrapper{componentCls}-picture-circle-wrapper
    "] = new CSSObject
                {
                    ["..."] = ClearFix(),
                    Display = "block",
                    [$@"{componentCls}{componentCls}-select"] = new CSSObject
                    {
                        Width = uploadPictureCardSize,
                        Height = uploadPictureCardSize,
                        TextAlign = "center",
                        VerticalAlign = "top",
                        BackgroundColor = token.ColorFillAlter,
                        Border = $@"{Unit(token.LineWidth)} dashed {token.ColorBorder}",
                        BorderRadius = token.BorderRadiusLG,
                        Cursor = "pointer",
                        Transition = $@"{token.MotionDurationSlow}",
                        [$@"{componentCls}"] = new CSSObject
                        {
                            Display = "flex",
                            AlignItems = "center",
                            JustifyContent = "center",
                            Height = "100%",
                            TextAlign = "center",
                        },
                        [$@"{componentCls}-disabled):hover"] = new CSSObject
                        {
                            BorderColor = token.ColorPrimary,
                        },
                    },
                    [$@"{listCls}{listCls}-picture-card, {listCls}{listCls}-picture-circle"] = new CSSObject
                    {
                        Display = "flex",
                        FlexWrap = "wrap",
                        ["@supports not (gap: 1px)"] = new CSSObject
                        {
                            ["& > *"] = new CSSObject
                            {
                                MarginBlockEnd = token.MarginXS,
                                MarginInlineEnd = token.MarginXS,
                            },
                        },
                        ["@supports (gap: 1px)"] = new CSSObject
                        {
                            Gap = token.MarginXS,
                        },
                        [$@"{listCls}-item-container"] = new CSSObject
                        {
                            Display = "inline-block",
                            Width = uploadPictureCardSize,
                            Height = uploadPictureCardSize,
                            VerticalAlign = "top",
                        },
                        ["&::after"] = new CSSObject
                        {
                            Display = "none",
                        },
                        ["&::before"] = new CSSObject
                        {
                            Display = "none",
                        },
                        [itemCls] = new CSSObject
                        {
                            Height = "100%",
                            Margin = 0,
                            ["&::before"] = new CSSObject
                            {
                                Position = "absolute",
                                ZIndex = 1,
                                Width = $@"{Unit(Calc(token.PaddingXS).Mul(2).Equal())})",
                                Height = $@"{Unit(Calc(token.PaddingXS).Mul(2).Equal())})",
                                BackgroundColor = token.ColorBgMask,
                                Opacity = 0,
                                Transition = $@"{token.MotionDurationSlow}",
                                Content = "\" \"",
                            },
                        },
                        [$@"{itemCls}:hover"] = new CSSObject
                        {
                            [$@"{itemCls}-actions"] = new CSSObject
                            {
                                Opacity = 1,
                            },
                        },
                        [$@"{itemCls}-actions"] = new CSSObject
                        {
                            Position = "absolute",
                            InsetInlineStart = 0,
                            ZIndex = 10,
                            Width = "100%",
                            WhiteSpace = "nowrap",
                            TextAlign = "center",
                            Opacity = 0,
                            Transition = $@"{token.MotionDurationSlow}",
                            [$@"{iconCls}-eye,
            {iconCls}-download,
            {iconCls}-delete
          "] = new CSSObject
                            {
                                ZIndex = 10,
                                Width = fontSizeLG,
                                Margin = $@"{Unit(token.MarginXXS)}",
                                FontSize = fontSizeLG,
                                Cursor = "pointer",
                                Transition = $@"{token.MotionDurationSlow}",
                                Color = colorTextLightSolid,
                                ["&:hover"] = new CSSObject
                                {
                                    Color = colorTextLightSolid,
                                },
                                ["svg"] = new CSSObject
                                {
                                    VerticalAlign = "baseline",
                                },
                            },
                        },
                        [$@"{itemCls}-thumbnail, {itemCls}-thumbnail img"] = new CSSObject
                        {
                            Position = "static",
                            Display = "block",
                            Width = "100%",
                            Height = "100%",
                            ObjectFit = "contain",
                        },
                        [$@"{itemCls}-name"] = new CSSObject
                        {
                            Display = "none",
                            TextAlign = "center",
                        },
                        [$@"{itemCls}-file + {itemCls}-name"] = new CSSObject
                        {
                            Position = "absolute",
                            Bottom = token.Margin,
                            Display = "block",
                            Width = $@"{Unit(Calc(token.PaddingXS).Mul(2).Equal())})",
                        },
                        [$@"{itemCls}-uploading"] = new CSSObject
                        {
                            [$@"{itemCls}"] = new CSSObject
                            {
                                BackgroundColor = token.ColorFillAlter,
                            },
                            [$@"{iconCls}-eye, {iconCls}-download, {iconCls}-delete"] = new CSSObject
                            {
                                Display = "none",
                            },
                        },
                        [$@"{itemCls}-progress"] = new CSSObject
                        {
                            Bottom = token.MarginXL,
                            Width = $@"{Unit(Calc(token.PaddingXS).Mul(2).Equal())})",
                            PaddingInlineStart = 0,
                        },
                    },
                },
                [$@"{componentCls}-wrapper{componentCls}-picture-circle-wrapper"] = new CSSObject
                {
                    [$@"{componentCls}{componentCls}-select"] = new CSSObject
                    {
                        BorderRadius = "50%",
                    },
                },
            };
        }
    }
}