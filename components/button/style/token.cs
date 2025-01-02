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
        public class ComponentToken : TokenWithCommonCls
        {
            public string FontWeight { get; set; }
            public string DefaultShadow { get; set; }
            public string PrimaryShadow { get; set; }
            public string DangerShadow { get; set; }
            public string PrimaryColor { get; set; }
            public string DefaultColor { get; set; }
            public string DefaultBg { get; set; }
            public string DefaultBorderColor { get; set; }
            public string DangerColor { get; set; }
            public string DefaultHoverBg { get; set; }
            public string DefaultHoverColor { get; set; }
            public string DefaultHoverBorderColor { get; set; }
            public string DefaultActiveBg { get; set; }
            public string DefaultActiveColor { get; set; }
            public string DefaultActiveBorderColor { get; set; }
            public string BorderColorDisabled { get; set; }
            public string DefaultGhostColor { get; set; }
            public string GhostBg { get; set; }
            public string DefaultGhostBorderColor { get; set; }
            public string SolidTextColor { get; set; }
            public string TextTextColor { get; set; }
            public string TextTextHoverColor { get; set; }
            public string TextTextActiveColor { get; set; }
            public string PaddingInline { get; set; }
            public string PaddingInlineLG { get; set; }
            public string PaddingInlineSM { get; set; }
            public string PaddingBlock { get; set; }
            public string PaddingBlockLG { get; set; }
            public string PaddingBlockSM { get; set; }
            public double OnlyIconSize { get; set; }
            public double OnlyIconSizeLG { get; set; }
            public double OnlyIconSizeSM { get; set; }
            public string GroupBorderColor { get; set; }
            public string LinkHoverBg { get; set; }
            public string TextHoverBg { get; set; }
            public double ContentFontSize { get; set; }
            public double ContentFontSizeLG { get; set; }
            public double ContentFontSizeSM { get; set; }
            public double ContentLineHeight { get; set; }
            public double ContentLineHeightLG { get; set; }
            public double ContentLineHeightSM { get; set; }
        }

        public class ButtonToken : ComponentToken
        {
            public string ButtonPaddingHorizontal { get; set; }
            public string ButtonPaddingVertical { get; set; }
            public double ButtonIconOnlyFontSize { get; set; }
        }

        public static object PrepareToken(ButtonToken token)
        {
            var paddingInline = token.PaddingInline;
            var onlyIconSize = token.OnlyIconSize;
            var buttonToken = MergeToken(token, new object { ButtonPaddingHorizontal = paddingInline, ButtonPaddingVertical = 0, ButtonIconOnlyFontSize = onlyIconSize, });
            return buttonToken;
        }

        public static ButtonToken PrepareComponentToken(ButtonToken token)
        {
            var contentFontSize = token.FontSize;
            var contentFontSizeSM = token.FontSize;
            var contentFontSizeLG = token.FontSizeLG;
            var contentLineHeight = GetLineHeight(contentFontSize);
            var contentLineHeightSM = GetLineHeight(contentFontSizeSM);
            var contentLineHeightLG = GetLineHeight(contentFontSizeLG);
            var solidTextColor = IsBright(new AggregationColor(token.ColorBgSolid), "#fff") ? "#000" : "#fff";
            return new ButtonToken
            {
                FontWeight = 400,
                DefaultShadow = $@"{token.ControlOutlineWidth}px 0 {token.ControlTmpOutline}",
                PrimaryShadow = $@"{token.ControlOutlineWidth}px 0 {token.ControlOutline}",
                DangerShadow = $@"{token.ControlOutlineWidth}px 0 {token.ColorErrorOutline}",
                PrimaryColor = token.ColorTextLightSolid,
                DangerColor = token.ColorTextLightSolid,
                BorderColorDisabled = token.ColorBorder,
                DefaultGhostColor = token.ColorBgContainer,
                GhostBg = "transparent",
                DefaultGhostBorderColor = token.ColorBgContainer,
                PaddingInline = token.PaddingContentHorizontal - token.LineWidth,
                PaddingInlineLG = token.PaddingContentHorizontal - token.LineWidth,
                PaddingInlineSM = 8 - token.LineWidth,
                OnlyIconSize = token.FontSizeLG,
                OnlyIconSizeSM = token.FontSizeLG - 2,
                OnlyIconSizeLG = token.FontSizeLG + 2,
                GroupBorderColor = token.ColorPrimaryHover,
                LinkHoverBg = "transparent",
                TextTextColor = token.ColorText,
                TextTextHoverColor = token.ColorText,
                TextTextActiveColor = token.ColorText,
                TextHoverBg = token.ColorFillTertiary,
                DefaultColor = token.ColorText,
                DefaultBg = token.ColorBgContainer,
                DefaultBorderColor = token.ColorBorder,
                DefaultBorderColorDisabled = token.ColorBorder,
                DefaultHoverBg = token.ColorBgContainer,
                DefaultHoverColor = token.ColorPrimaryHover,
                DefaultHoverBorderColor = token.ColorPrimaryHover,
                DefaultActiveBg = token.ColorBgContainer,
                DefaultActiveColor = token.ColorPrimaryActive,
                DefaultActiveBorderColor = token.ColorPrimaryActive,
                PaddingBlock = Math.Max((token.ControlHeight - contentFontSize * contentLineHeight) / 2 - token.LineWidth, 0),
                PaddingBlockSM = Math.Max((token.ControlHeightSM - contentFontSizeSM * contentLineHeightSM) / 2 - token.LineWidth, 0),
                PaddingBlockLG = Math.Max((token.ControlHeightLG - contentFontSizeLG * contentLineHeightLG) / 2 - token.LineWidth, 0),
            };
        }
    }
}