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
    public partial class SelectStyle
    {
        public class MultipleSelectorToken
        {
            public string MultipleItemBg { get; set; }
            public string MultipleItemBorderColor { get; set; }
            public double MultipleItemHeight { get; set; }
            public double MultipleItemHeightSM { get; set; }
            public double MultipleItemHeightLG { get; set; }
            public string MultipleSelectorBgDisabled { get; set; }
            public string MultipleItemColorDisabled { get; set; }
            public string MultipleItemBorderColorDisabled { get; set; }
        }

        public class ComponentToken : TokenWithCommonCls : MultipleSelectorToken
        {
            public double ZIndexPopup { get; set; }
            public string OptionSelectedColor { get; set; }
            public string OptionSelectedFontWeight { get; set; }
            public string OptionSelectedBg { get; set; }
            public string OptionActiveBg { get; set; }
            public string OptionPadding { get; set; }
            public double OptionFontSize { get; set; }
            public string OptionLineHeight { get; set; }
            public double OptionHeight { get; set; }
            public string SelectorBg { get; set; }
            public string ClearBg { get; set; }
            public double SingleItemHeightLG { get; set; }
            public double ShowArrowPaddingInlineEnd { get; set; }
            public string HoverBorderColor { get; set; }
            public string ActiveBorderColor { get; set; }
            public string ActiveOutlineColor { get; set; }
        }

        public class SelectorToken
        {
            public string SelectAffixPadding { get; set; }
            public string InputPaddingHorizontalBase { get; set; }
            public double MultipleSelectItemHeight { get; set; }
            public double SelectHeight { get; set; }
        }

        public class SelectToken : ComponentToken, SelectorToken
        {
            public string RootPrefixCls { get; set; }
            public double INTERNAL_FIXED_ITEM_MARGIN { get; set; }
        }

        public static SelectToken PrepareComponentToken(SelectToken token)
        {
            var fontSize = token.FontSize;
            var lineHeight = token.LineHeight;
            var lineWidth = token.LineWidth;
            var controlHeight = token.ControlHeight;
            var controlHeightSM = token.ControlHeightSM;
            var controlHeightLG = token.ControlHeightLG;
            var paddingXXS = token.PaddingXXS;
            var controlPaddingHorizontal = token.ControlPaddingHorizontal;
            var zIndexPopupBase = token.ZIndexPopupBase;
            var colorText = token.ColorText;
            var fontWeightStrong = token.FontWeightStrong;
            var controlItemBgActive = token.ControlItemBgActive;
            var controlItemBgHover = token.ControlItemBgHover;
            var colorBgContainer = token.ColorBgContainer;
            var colorFillSecondary = token.ColorFillSecondary;
            var colorBgContainerDisabled = token.ColorBgContainerDisabled;
            var colorTextDisabled = token.ColorTextDisabled;
            var colorPrimaryHover = token.ColorPrimaryHover;
            var colorPrimary = token.ColorPrimary;
            var controlOutline = token.ControlOutline;
            var dblPaddingXXS = paddingXXS * 2;
            var dblLineWidth = lineWidth * 2;
            var multipleItemHeight = Math.Min(controlHeight - dblPaddingXXS, controlHeight - dblLineWidth);
            var multipleItemHeightSM = Math.Min(controlHeightSM - dblPaddingXXS, controlHeightSM - dblLineWidth);
            var multipleItemHeightLG = Math.Min(controlHeightLG - dblPaddingXXS, controlHeightLG - dblLineWidth);
            var INTERNAL_FIXED_ITEM_MARGIN = Math.Floor(paddingXXS / 2);
            return new SelectToken
            {
                ZIndexPopup = zIndexPopupBase + 50,
                OptionSelectedColor = colorText,
                OptionSelectedFontWeight = fontWeightStrong,
                OptionSelectedBg = controlItemBgActive,
                OptionActiveBg = controlItemBgHover,
                OptionPadding = $@"{(controlHeight - fontSize * lineHeight) / 2}px {controlPaddingHorizontal}px",
                OptionFontSize = fontSize,
                OptionLineHeight = lineHeight,
                OptionHeight = controlHeight,
                SelectorBg = colorBgContainer,
                ClearBg = colorBgContainer,
                SingleItemHeightLG = controlHeightLG,
                MultipleItemBg = colorFillSecondary,
                MultipleItemBorderColor = "transparent",
                MultipleSelectorBgDisabled = colorBgContainerDisabled,
                MultipleItemColorDisabled = colorTextDisabled,
                MultipleItemBorderColorDisabled = "transparent",
                ShowArrowPaddingInlineEnd = Math.Ceil(token.FontSize * 1.25),
                HoverBorderColor = colorPrimaryHover,
                ActiveBorderColor = colorPrimary,
                ActiveOutlineColor = controlOutline,
                SelectAffixPadding = paddingXXS,
            };
        }
    }
}