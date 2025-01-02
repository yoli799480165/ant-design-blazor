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
    public partial class InputStyle
    {
        public class SharedComponentToken
        {
            public double PaddingInline { get; set; }
            public double PaddingInlineSM { get; set; }
            public double PaddingInlineLG { get; set; }
            public double PaddingBlock { get; set; }
            public double PaddingBlockSM { get; set; }
            public double PaddingBlockLG { get; set; }
            public string AddonBg { get; set; }
            public string HoverBorderColor { get; set; }
            public string ActiveBorderColor { get; set; }
            public string ActiveShadow { get; set; }
            public string ErrorActiveShadow { get; set; }
            public string WarningActiveShadow { get; set; }
            public string HoverBg { get; set; }
            public string ActiveBg { get; set; }
            public double InputFontSize { get; set; }
            public double InputFontSizeLG { get; set; }
            public double InputFontSizeSM { get; set; }
        }

        public class ComponentToken : TokenWithCommonCls : SharedComponentToken
        {
        }

        public class SharedInputToken
        {
            public double InputAffixPadding { get; set; }
        }

        public class InputToken : ComponentToken, SharedInputToken
        {
        }

        public static SharedComponentToken InitComponentToken(AliasToken token)
        {
            var controlHeight = token.ControlHeight;
            var fontSize = token.FontSize;
            var lineHeight = token.LineHeight;
            var lineWidth = token.LineWidth;
            var controlHeightSM = token.ControlHeightSM;
            var controlHeightLG = token.ControlHeightLG;
            var fontSizeLG = token.FontSizeLG;
            var lineHeightLG = token.LineHeightLG;
            var paddingSM = token.PaddingSM;
            var controlPaddingHorizontalSM = token.ControlPaddingHorizontalSM;
            var controlPaddingHorizontal = token.ControlPaddingHorizontal;
            var colorFillAlter = token.ColorFillAlter;
            var colorPrimaryHover = token.ColorPrimaryHover;
            var colorPrimary = token.ColorPrimary;
            var controlOutlineWidth = token.ControlOutlineWidth;
            var controlOutline = token.ControlOutline;
            var colorErrorOutline = token.ColorErrorOutline;
            var colorWarningOutline = token.ColorWarningOutline;
            var colorBgContainer = token.ColorBgContainer;
            return new SharedComponentToken
            {
                PaddingBlock = Math.Max(Math.Round(((controlHeight - fontSize * lineHeight) / 2) * 10) / 10 - lineWidth, 0),
                PaddingBlockSM = Math.Max(Math.Round(((controlHeightSM - fontSize * lineHeight) / 2) * 10) / 10 - lineWidth, 0),
                PaddingBlockLG = Math.Ceil(((controlHeightLG - fontSizeLG * lineHeightLG) / 2) * 10) / 10 - lineWidth,
                PaddingInline = paddingSM - lineWidth,
                PaddingInlineSM = controlPaddingHorizontalSM - lineWidth,
                PaddingInlineLG = controlPaddingHorizontal - lineWidth,
                AddonBg = colorFillAlter,
                ActiveBorderColor = colorPrimary,
                HoverBorderColor = colorPrimaryHover,
                ActiveShadow = $@"{controlOutlineWidth}px {controlOutline}",
                ErrorActiveShadow = $@"{controlOutlineWidth}px {colorErrorOutline}",
                WarningActiveShadow = $@"{controlOutlineWidth}px {colorWarningOutline}",
                HoverBg = colorBgContainer,
                ActiveBg = colorBgContainer,
                InputFontSize = fontSize,
                InputFontSizeLG = fontSizeLG,
                InputFontSizeSM = fontSize,
            };
        }
    }
}