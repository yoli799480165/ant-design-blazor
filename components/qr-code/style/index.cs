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
    public partial class QrCodeStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
        }

        public class QRCodeToken : ComponentToken
        {
            public string QRCodeTextColor { get; set; }
            public string QRCodeMaskBackgroundColor { get; set; }
        }

        public static CSSObject GenQRCodeStyle(QrCodeToken token)
        {
            var componentCls = token.ComponentCls;
            var lineWidth = token.LineWidth;
            var lineType = token.LineType;
            var colorSplit = token.ColorSplit;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    Display = "flex",
                    JustifyContent = "center",
                    AlignItems = "center",
                    Padding = token.PaddingSM,
                    BackgroundColor = token.ColorWhite,
                    BorderRadius = token.BorderRadiusLG,
                    Border = $@"{Unit(lineWidth)} {lineType} {colorSplit}",
                    Position = "relative",
                    Overflow = "hidden",
                    [$@"{componentCls}-mask"] = new CSSObject
                    {
                        Position = "absolute",
                        InsetBlockStart = 0,
                        InsetInlineStart = 0,
                        ZIndex = 10,
                        Display = "flex",
                        FlexDirection = "column",
                        JustifyContent = "center",
                        AlignItems = "center",
                        Width = "100%",
                        Height = "100%",
                        Color = token.ColorText,
                        LineHeight = token.LineHeight,
                        Background = token.QRCodeMaskBackgroundColor,
                        TextAlign = "center",
                        [$@"{componentCls}-expired, & > {componentCls}-scanned"] = new CSSObject
                        {
                            Color = token.QRCodeTextColor,
                        },
                    },
                    ["> canvas"] = new CSSObject
                    {
                        AlignSelf = "stretch",
                        Flex = "auto",
                        MinWidth = 0,
                    },
                    ["&-icon"] = new CSSObject
                    {
                        MarginBlockEnd = token.MarginXS,
                        FontSize = token.ControlHeight,
                    },
                },
                [$@"{componentCls}-borderless"] = new CSSObject
                {
                    BorderColor = "transparent",
                    Padding = 0,
                    BorderRadius = 0,
                },
            };
        }

        public static QrCodeToken PrepareComponentToken(QrCodeToken token)
        {
            return new QrCodeToken
            {
                QRCodeMaskBackgroundColor = new TinyColor(token.ColorBgContainer).SetAlpha(0.96).ToRgbString(),
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("QRCode", (QrCodeToken token) =>
            {
                var mergedToken = MergeToken(token, new object { QRCodeTextColor = token.ColorText, });
                return GenQRCodeStyle(mergedToken);
            }, PrepareComponentToken);
        }
    }
}