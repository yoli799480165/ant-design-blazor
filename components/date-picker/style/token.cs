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
    public partial class DatePickerStyle
    {
        public class PanelComponentToken : MultipleSelectorToken
        {
            public string CellHoverBg { get; set; }
            public string CellActiveWithRangeBg { get; set; }
            public string CellHoverWithRangeBg { get; set; }
            public string CellBgDisabled { get; set; }
            public string CellRangeBorderColor { get; set; }
            public double TimeColumnWidth { get; set; }
            public double TimeColumnHeight { get; set; }
            public double TimeCellHeight { get; set; }
            public double CellHeight { get; set; }
            public double CellWidth { get; set; }
            public double TextHeight { get; set; }
            public double WithoutTimeCellHeight { get; set; }
        }

        public class ComponentToken : TokenWithCommonCls : Exclude<SharedComponentToken, addonBg>, PanelComponentToken, ArrowToken
        {
            public double PresetsWidth { get; set; }
            public double PresetsMaxWidth { get; set; }
            public double ZIndexPopup { get; set; }
        }

        public class PickerPanelToken
        {
            public string PickerCellCls { get; set; }
            public string PickerCellInnerCls { get; set; }
            public string PickerDatePanelPaddingHorizontal { get; set; }
            public string PickerYearMonthCellWidth { get; set; }
            public string PickerCellPaddingVertical { get; set; }
            public string PickerQuarterPanelContentHeight { get; set; }
            public double PickerCellBorderGap { get; set; }
            public double PickerControlIconSize { get; set; }
            public double PickerControlIconMargin { get; set; }
            public double PickerControlIconBorderWidth { get; set; }
        }

        public class PickerToken : ComponentToken, PickerPanelToken, SharedInputToken, SelectorToken
        {
            public double INTERNAL_FIXED_ITEM_MARGIN { get; set; }
        }

        public class SharedPickerToken : TokenWithCommonCls<GlobalToken>, PickerPanelToken, PanelComponentToken
        {
        }

        public static PickerPanelToken InitPickerPanelToken(TokenWithCommonCls<GlobalToken> token)
        {
            var componentCls = token.ComponentCls;
            var controlHeightLG = token.ControlHeightLG;
            var paddingXXS = token.PaddingXXS;
            var padding = token.Padding;
            return new PickerPanelToken
            {
                PickerCellCls = $@"{componentCls}-cell",
                PickerCellInnerCls = $@"{componentCls}-cell-inner",
                PickerYearMonthCellWidth = token.calc(controlHeightLG).mul(1.5).Equal(),
                PickerQuarterPanelContentHeight = token.calc(controlHeightLG).mul(1.4).Equal(),
                PickerCellPaddingVertical = token.calc(paddingXXS).add(token.calc(paddingXXS).div(2)).Equal(),
                PickerCellBorderGap = 2,
                PickerControlIconSize = 7,
                PickerControlIconMargin = 4,
                PickerControlIconBorderWidth = 1.5,
                PickerDatePanelPaddingHorizontal = token
      .calc(padding)
      .add(token.calc(paddingXXS).div(2)).Equal(),
            };
        }

        public static PanelComponentToken InitPanelComponentToken(GlobalToken token)
        {
            var colorBgContainerDisabled = token.ColorBgContainerDisabled;
            var controlHeight = token.ControlHeight;
            var controlHeightSM = token.ControlHeightSM;
            var controlHeightLG = token.ControlHeightLG;
            var paddingXXS = token.PaddingXXS;
            var lineWidth = token.LineWidth;
            var dblPaddingXXS = paddingXXS * 2;
            var dblLineWidth = lineWidth * 2;
            var multipleItemHeight = Math.Min(controlHeight - dblPaddingXXS, controlHeight - dblLineWidth);
            var multipleItemHeightSM = Math.Min(controlHeightSM - dblPaddingXXS, controlHeightSM - dblLineWidth);
            var multipleItemHeightLG = Math.Min(controlHeightLG - dblPaddingXXS, controlHeightLG - dblLineWidth);
            var INTERNAL_FIXED_ITEM_MARGIN = Math.Floor(paddingXXS / 2);
            var filledToken = new object
            {
                CellHoverBg = token.ControlItemBgHover,
                CellActiveWithRangeBg = token.ControlItemBgActive,
                CellHoverWithRangeBg = new TinyColor(token.colorPrimary).lighten(35).ToHexString(),
                CellRangeBorderColor = new TinyColor(token.colorPrimary).lighten(20).ToHexString(),
                CellBgDisabled = colorBgContainerDisabled,
                TimeColumnWidth = controlHeightLG * 1.4,
                TimeColumnHeight = 28 * 8,
                TimeCellHeight = 28,
                CellWidth = controlHeightSM * 1.5,
                CellHeight = controlHeightSM,
                TextHeight = controlHeightLG,
                WithoutTimeCellHeight = controlHeightLG * 1.65,
                MultipleItemBg = token.ColorFillSecondary,
                MultipleItemBorderColor = "transparent",
                MultipleSelectorBgDisabled = colorBgContainerDisabled,
                MultipleItemColorDisabled = token.ColorTextDisabled,
                MultipleItemBorderColorDisabled = "transparent",
            };
            return filledToken;
        }

        public static DatePickerToken PrepareComponentToken(DatePickerToken token)
        {
            return new DatePickerToken
            {
                ["..."] = InitComponentToken(token),
                ["..."] = InitPanelComponentToken(token),
                ["..."] = GetArrowToken(token),
                PresetsWidth = 120,
                PresetsMaxWidth = 200,
                ZIndexPopup = token.ZIndexPopupBase + 50,
            };
        }
    }
}