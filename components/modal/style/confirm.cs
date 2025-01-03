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
    public partial class ModalStyle
    {
        public static CSSObject GenModalConfirmStyle(ModalToken token)
        {
            var componentCls = token.ComponentCls;
            var titleFontSize = token.TitleFontSize;
            var titleLineHeight = token.TitleLineHeight;
            var modalConfirmIconSize = token.ModalConfirmIconSize;
            var fontSize = token.FontSize;
            var lineHeight = token.LineHeight;
            var modalTitleHeight = token.ModalTitleHeight;
            var fontHeight = token.FontHeight;
            var confirmBodyPadding = token.ConfirmBodyPadding;
            var confirmComponentCls = $@"{componentCls}-confirm";
            return new CSSObject
            {
                [confirmComponentCls] = new CSSObject
                {
                    ["&-rtl"] = new CSSObject
                    {
                        Direction = "rtl",
                    },
                    [$@"{token.AntCls}-modal-header"] = new CSSObject
                    {
                        Display = "none",
                    },
                    [$@"{confirmComponentCls}-body-wrapper"] = new CSSObject
                    {
                        ["..."] = ClearFix(),
                    },
                    [$@"{componentCls} {componentCls}-body"] = new CSSObject
                    {
                        Padding = confirmBodyPadding,
                    },
                    [$@"{confirmComponentCls}-body"] = new CSSObject
                    {
                        Display = "flex",
                        FlexWrap = "nowrap",
                        AlignItems = "start",
                        [$@"{token.IconCls}"] = new CSSObject
                        {
                            Flex = "none",
                            FontSize = modalConfirmIconSize,
                            MarginInlineEnd = token.ConfirmIconMarginInlineEnd,
                            MarginTop = token.Calc(token.Calc(fontHeight).Sub(modalConfirmIconSize).Equal()).Div(2).Equal(),
                        },
                        [$@"{token.IconCls}"] = new CSSObject
                        {
                            MarginTop = token.Calc(token.Calc(modalTitleHeight).Sub(modalConfirmIconSize).Equal()).Div(2).Equal(),
                        },
                    },
                    [$@"{confirmComponentCls}-paragraph"] = new CSSObject
                    {
                        Display = "flex",
                        FlexDirection = "column",
                        Flex = "auto",
                        RowGap = token.MarginXS,
                        MaxWidth = $@"{Unit(token.MarginSM)})",
                    },
                    [$@"{token.IconCls} + {confirmComponentCls}-paragraph"] = new CSSObject
                    {
                        MaxWidth = $@"{Unit(token.Calc(token.ModalConfirmIconSize).Add(token.MarginSM).Equal())})",
                    },
                    [$@"{confirmComponentCls}-title"] = new CSSObject
                    {
                        Color = token.ColorTextHeading,
                        FontWeight = token.FontWeightStrong,
                        FontSize = titleFontSize,
                        LineHeight = titleLineHeight,
                    },
                    [$@"{confirmComponentCls}-content"] = new CSSObject
                    {
                        Color = token.ColorText,
                    },
                    [$@"{confirmComponentCls}-btns"] = new CSSObject
                    {
                        TextAlign = "end",
                        MarginTop = token.ConfirmBtnsMarginTop,
                        [$@"{token.AntCls}-btn + {token.AntCls}-btn"] = new CSSObject
                        {
                            MarginBottom = 0,
                            MarginInlineStart = token.MarginXS,
                        },
                    },
                },
                [$@"{confirmComponentCls}-error {confirmComponentCls}-body > {token.IconCls}"] = new CSSObject
                {
                    Color = token.ColorError,
                },
                [$@"{confirmComponentCls}-warning {confirmComponentCls}-body > {token.IconCls},
        {confirmComponentCls}-confirm {confirmComponentCls}-body > {token.IconCls}"] = new CSSObject
                {
                    Color = token.ColorWarning,
                },
                [$@"{confirmComponentCls}-info {confirmComponentCls}-body > {token.IconCls}"] = new CSSObject
                {
                    Color = token.ColorInfo,
                },
                [$@"{confirmComponentCls}-success {confirmComponentCls}-body > {token.IconCls}"] = new CSSObject
                {
                    Color = token.ColorSuccess,
                },
            };
        }

        public static object ConfirmDefault()
        {
            return GenSubStyleComponent(new object[] { "Modal", "confirm" }, (ModalToken token) =>
            {
                var modalToken = PrepareToken(token);
                return new object[]
                {
                    GenModalConfirmStyle(modalToken)
                };
            }, PrepareComponentToken, new object { Order = -1000, });
        }
    }
}