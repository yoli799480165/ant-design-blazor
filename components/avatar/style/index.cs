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
    public partial class AvatarStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public double ContainerSize { get; set; }
            public double ContainerSizeLG { get; set; }
            public double ContainerSizeSM { get; set; }
            public double TextFontSize { get; set; }
            public double TextFontSizeLG { get; set; }
            public double TextFontSizeSM { get; set; }
            public double GroupSpace { get; set; }
            public double GroupOverlapping { get; set; }
            public string GroupBorderColor { get; set; }
        }

        public class AvatarToken : ComponentToken
        {
            public string AvatarBgColor { get; set; }
            public string AvatarBg { get; set; }
            public string AvatarColor { get; set; }
        }

        public static CSSObject GenBaseStyle(AvatarToken token)
        {
            var antCls = token.AntCls;
            var componentCls = token.ComponentCls;
            var iconCls = token.IconCls;
            var avatarBg = token.AvatarBg;
            var avatarColor = token.AvatarColor;
            var containerSize = token.ContainerSize;
            var containerSizeLG = token.ContainerSizeLG;
            var containerSizeSM = token.ContainerSizeSM;
            var textFontSize = token.TextFontSize;
            var textFontSizeLG = token.TextFontSizeLG;
            var textFontSizeSM = token.TextFontSizeSM;
            var borderRadius = token.BorderRadius;
            var borderRadiusLG = token.BorderRadiusLG;
            var borderRadiusSM = token.BorderRadiusSM;
            var lineWidth = token.LineWidth;
            var lineType = token.LineType;
            var avatarSizeStyle = (number size, number fontSize, number radius) =>
            {
                return new CSSObject
                {
                    Width = size,
                    Height = size,
                    BorderRadius = "50%",
                    [$@"{componentCls}-square"] = new CSSObject
                    {
                        BorderRadius = radius,
                    },
                    [$@"{componentCls}-icon"] = new CSSObject
                    {
                        [$@"{iconCls}"] = new CSSObject
                        {
                            Margin = 0,
                        },
                    },
                };
            };
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    Position = "relative",
                    Display = "inline-flex",
                    JustifyContent = "center",
                    AlignItems = "center",
                    Overflow = "hidden",
                    Color = avatarColor,
                    WhiteSpace = "nowrap",
                    TextAlign = "center",
                    VerticalAlign = "middle",
                    Background = avatarBg,
                    Border = $@"{Unit(lineWidth)} {lineType} transparent",
                    ["&-image"] = new CSSObject
                    {
                        Background = "transparent",
                    },
                    [$@"{antCls}-image-img"] = new CSSObject
                    {
                        Display = "block",
                    },
                    ["..."] = AvatarSizeStyle(containerSize, textFontSize, borderRadius),
                    ["&-lg"] = new CSSObject
                    {
                        ["..."] = AvatarSizeStyle(containerSizeLG, textFontSizeLG, borderRadiusLG),
                    },
                    ["&-sm"] = new CSSObject
                    {
                        ["..."] = AvatarSizeStyle(containerSizeSM, textFontSizeSM, borderRadiusSM),
                    },
                    ["> img"] = new CSSObject
                    {
                        Display = "block",
                        Width = "100%",
                        Height = "100%",
                        ObjectFit = "cover",
                    },
                },
            };
        }

        public static CSSObject GenGroupStyle(AvatarToken token)
        {
            var componentCls = token.ComponentCls;
            var groupBorderColor = token.GroupBorderColor;
            var groupOverlapping = token.GroupOverlapping;
            var groupSpace = token.GroupSpace;
            return new CSSObject
            {
                [$@"{componentCls}-group"] = new CSSObject
                {
                    Display = "inline-flex",
                    [componentCls] = new CSSObject
                    {
                        BorderColor = groupBorderColor,
                    },
                    ["> *:not(:first-child)"] = new CSSObject
                    {
                        MarginInlineStart = groupOverlapping,
                    },
                },
                [$@"{componentCls}-group-popover"] = new CSSObject
                {
                    [$@"{componentCls} + {componentCls}"] = new CSSObject
                    {
                        MarginInlineStart = groupSpace,
                    },
                },
            };
        }

        public static AvatarToken PrepareComponentToken(AvatarToken token)
        {
            var controlHeight = token.ControlHeight;
            var controlHeightLG = token.ControlHeightLG;
            var controlHeightSM = token.ControlHeightSM;
            var fontSize = token.FontSize;
            var fontSizeLG = token.FontSizeLG;
            var fontSizeXL = token.FontSizeXL;
            var fontSizeHeading3 = token.FontSizeHeading3;
            var marginXS = token.MarginXS;
            var marginXXS = token.MarginXXS;
            var colorBorderBg = token.ColorBorderBg;
            return new AvatarToken
            {
                ContainerSize = controlHeight,
                ContainerSizeLG = controlHeightLG,
                ContainerSizeSM = controlHeightSM,
                TextFontSize = Math.Round((fontSizeLG + fontSizeXL) / 2),
                TextFontSizeLG = fontSizeHeading3,
                TextFontSizeSM = fontSize,
                GroupSpace = marginXXS,
                GroupOverlapping = -marginXS,
                GroupBorderColor = colorBorderBg,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Avatar", (AvatarToken token) =>
            {
                var colorTextLightSolid = token.ColorTextLightSolid;
                var colorTextPlaceholder = token.ColorTextPlaceholder;
                var avatarToken = MergeToken(token, new object { AvatarBg = colorTextPlaceholder, AvatarColor = colorTextLightSolid, });
                return new object[]
                {
                    GenBaseStyle(avatarToken),
                    GenGroupStyle(avatarToken)
                };
            }, prepareComponentToken);
        }
    }
}