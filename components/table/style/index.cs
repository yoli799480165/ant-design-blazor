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
    public partial class TableStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public string HeaderBg { get; set; }
            public string HeaderColor { get; set; }
            public string HeaderSortActiveBg { get; set; }
            public string HeaderSortHoverBg { get; set; }
            public string BodySortBg { get; set; }
            public string RowHoverBg { get; set; }
            public string RowSelectedBg { get; set; }
            public string RowSelectedHoverBg { get; set; }
            public string RowExpandedBg { get; set; }
            public double CellPaddingBlock { get; set; }
            public double CellPaddingInline { get; set; }
            public double CellPaddingBlockMD { get; set; }
            public double CellPaddingInlineMD { get; set; }
            public double CellPaddingBlockSM { get; set; }
            public double CellPaddingInlineSM { get; set; }
            public string BorderColor { get; set; }
            public double HeaderBorderRadius { get; set; }
            public string FooterBg { get; set; }
            public string FooterColor { get; set; }
            public double CellFontSize { get; set; }
            public double CellFontSizeMD { get; set; }
            public double CellFontSizeSM { get; set; }
            public string HeaderSplitColor { get; set; }
            public string FixedHeaderSortActiveBg { get; set; }
            public string HeaderFilterHoverBg { get; set; }
            public string FilterDropdownMenuBg { get; set; }
            public string FilterDropdownBg { get; set; }
            public string ExpandIconBg { get; set; }
            public string SelectionColumnWidth { get; set; }
            public string StickyScrollBarBg { get; set; }
            public double StickyScrollBarBorderRadius { get; set; }
            public double ExpandIconMarginTop { get; set; }
            public double ExpandIconHalfInner { get; set; }
            public double ExpandIconSize { get; set; }
            public double ExpandIconScale { get; set; }
            public string HeaderIconColor { get; set; }
            public string HeaderIconHoverColor { get; set; }
        }

        public class TableToken : ComponentToken
        {
            public double TableFontSize { get; set; }
            public string TableBg { get; set; }
            public double TableRadius { get; set; }
            public double TablePaddingHorizontal { get; set; }
            public double TablePaddingVertical { get; set; }
            public double TablePaddingHorizontalMiddle { get; set; }
            public double TablePaddingVerticalMiddle { get; set; }
            public double TablePaddingHorizontalSmall { get; set; }
            public double TablePaddingVerticalSmall { get; set; }
            public string TableBorderColor { get; set; }
            public string TableHeaderTextColor { get; set; }
            public string TableHeaderBg { get; set; }
            public string TableFooterTextColor { get; set; }
            public string TableFooterBg { get; set; }
            public string TableHeaderCellSplitColor { get; set; }
            public string TableHeaderSortBg { get; set; }
            public string TableHeaderSortHoverBg { get; set; }
            public string TableBodySortBg { get; set; }
            public string TableFixedHeaderSortActiveBg { get; set; }
            public string TableHeaderFilterActiveBg { get; set; }
            public string TableFilterDropdownBg { get; set; }
            public string TableFilterDropdownHeight { get; set; }
            public string TableRowHoverBg { get; set; }
            public string TableSelectedRowBg { get; set; }
            public string TableSelectedRowHoverBg { get; set; }
            public double TableFontSizeMiddle { get; set; }
            public double TableFontSizeSmall { get; set; }
            public string TableSelectionColumnWidth { get; set; }
            public string TableExpandIconBg { get; set; }
            public string TableExpandColumnWidth { get; set; }
            public string TableExpandedRowBg { get; set; }
            public double TableFilterDropdownWidth { get; set; }
            public double TableFilterDropdownSearchWidth { get; set; }
            public double ZIndexTableFixed { get; set; }
            public string ZIndexTableSticky { get; set; }
            public double TableScrollThumbSize { get; set; }
            public string TableScrollThumbBg { get; set; }
            public string TableScrollThumbBgHover { get; set; }
            public string TableScrollBg { get; set; }
        }

        public static CSSObject GenTableStyle(TableToken token)
        {
            var componentCls = token.ComponentCls;
            var fontWeightStrong = token.FontWeightStrong;
            var tablePaddingVertical = token.TablePaddingVertical;
            var tablePaddingHorizontal = token.TablePaddingHorizontal;
            var tableExpandColumnWidth = token.TableExpandColumnWidth;
            var lineWidth = token.LineWidth;
            var lineType = token.LineType;
            var tableBorderColor = token.TableBorderColor;
            var tableFontSize = token.TableFontSize;
            var tableBg = token.TableBg;
            var tableRadius = token.TableRadius;
            var tableHeaderTextColor = token.TableHeaderTextColor;
            var motionDurationMid = token.MotionDurationMid;
            var tableHeaderBg = token.TableHeaderBg;
            var tableHeaderCellSplitColor = token.TableHeaderCellSplitColor;
            var tableFooterTextColor = token.TableFooterTextColor;
            var tableFooterBg = token.TableFooterBg;
            var calc = token.Calc;
            var tableBorder = $@"{Unit(lineWidth)} {lineType} {tableBorderColor}";
            return new CSSObject
            {
                [$@"{componentCls}-wrapper"] = new CSSObject
                {
                    Clear = "both",
                    MaxWidth = "100%",
                    ["..."] = ClearFix(),
                    [componentCls] = new CSSObject
                    {
                        ["..."] = ResetComponent(token),
                        FontSize = tableFontSize,
                        Background = tableBg,
                        BorderRadius = $@"{Unit(tableRadius)} {Unit(tableRadius)} 0 0",
                        ScrollbarColor = $@"{token.TableScrollThumbBg} {token.TableScrollBg}",
                    },
                    ["table"] = new CSSObject
                    {
                        Width = "100%",
                        TextAlign = "start",
                        BorderRadius = $@"{Unit(tableRadius)} {Unit(tableRadius)} 0 0",
                        BorderCollapse = "separate",
                        BorderSpacing = 0,
                    },
                    [$@"{componentCls}-cell,
          {componentCls}-thead > tr > th,
          {componentCls}-tbody > tr > th,
          {componentCls}-tbody > tr > td,
          tfoot > tr > th,
          tfoot > tr > td
        "] = new CSSObject
                    {
                        Position = "relative",
                        Padding = $@"{Unit(tablePaddingVertical)} {Unit(tablePaddingHorizontal)}",
                        OverflowWrap = "break-word",
                    },
                    [$@"{componentCls}-title"] = new CSSObject
                    {
                        Padding = $@"{Unit(tablePaddingVertical)} {Unit(tablePaddingHorizontal)}",
                    },
                    [$@"{componentCls}-thead"] = new CSSObject
                    {
                        ["\n          > tr > th,\n          > tr > td\n        "] = new CSSObject
                        {
                            Position = "relative",
                            Color = tableHeaderTextColor,
                            FontWeight = fontWeightStrong,
                            TextAlign = "start",
                            Background = tableHeaderBg,
                            BorderBottom = tableBorder,
                            Transition = $@"{motionDurationMid} ease",
                            ["&[colspan]:not([colspan='1'])"] = new CSSObject
                            {
                                TextAlign = "center",
                            },
                            [$@"{componentCls}-selection-column):not({componentCls}-row-expand-icon-cell):not([colspan])::before"] = new CSSObject
                            {
                                Position = "absolute",
                                Top = "50%",
                                InsetInlineEnd = 0,
                                Width = 1,
                                Height = "1.6em",
                                BackgroundColor = tableHeaderCellSplitColor,
                                Transform = "translateY(-50%)",
                                Transition = $@"{motionDurationMid}",
                                Content = "\"\"",
                            },
                        },
                        ["> tr:not(:last-child) > th[colspan]"] = new CSSObject
                        {
                            BorderBottom = 0,
                        },
                    },
                    [$@"{componentCls}-tbody"] = new CSSObject
                    {
                        ["> tr"] = new CSSObject
                        {
                            ["> th, > td"] = new CSSObject
                            {
                                Transition = $@"{motionDurationMid}, border-color {motionDurationMid}",
                                BorderBottom = tableBorder,
                                [$@"{componentCls}-wrapper:only-child,
              > {componentCls}-expanded-row-fixed > {componentCls}-wrapper:only-child
            "] = new CSSObject
                                {
                                    [componentCls] = new CSSObject
                                    {
                                        MarginBlock = Unit(Calc(tablePaddingVertical).Mul(-1).Equal()),
                                        MarginInline = $@"{Unit(Calc(tableExpandColumnWidth).Sub(tablePaddingHorizontal).Equal())}
                {Unit(Calc(tablePaddingHorizontal).Mul(-1).Equal())}",
                                        [$@"{componentCls}-tbody > tr:last-child > td"] = new CSSObject
                                        {
                                            BorderBottom = 0,
                                            ["&:first-child, &:last-child"] = new CSSObject
                                            {
                                                BorderRadius = 0,
                                            },
                                        },
                                    },
                                },
                            },
                            ["> th"] = new CSSObject
                            {
                                Position = "relative",
                                Color = tableHeaderTextColor,
                                FontWeight = fontWeightStrong,
                                TextAlign = "start",
                                Background = tableHeaderBg,
                                BorderBottom = tableBorder,
                                Transition = $@"{motionDurationMid} ease",
                            },
                        },
                    },
                    [$@"{componentCls}-footer"] = new CSSObject
                    {
                        Padding = $@"{Unit(tablePaddingVertical)} {Unit(tablePaddingHorizontal)}",
                        Color = tableFooterTextColor,
                        Background = tableFooterBg,
                    },
                },
            };
        }

        public static TableToken PrepareComponentToken(TableToken token)
        {
            var colorFillAlter = token.ColorFillAlter;
            var colorBgContainer = token.ColorBgContainer;
            var colorTextHeading = token.ColorTextHeading;
            var colorFillSecondary = token.ColorFillSecondary;
            var colorFillContent = token.ColorFillContent;
            var controlItemBgActive = token.ControlItemBgActive;
            var controlItemBgActiveHover = token.ControlItemBgActiveHover;
            var padding = token.Padding;
            var paddingSM = token.PaddingSM;
            var paddingXS = token.PaddingXS;
            var colorBorderSecondary = token.ColorBorderSecondary;
            var borderRadiusLG = token.BorderRadiusLG;
            var controlHeight = token.ControlHeight;
            var colorTextPlaceholder = token.ColorTextPlaceholder;
            var fontSize = token.FontSize;
            var fontSizeSM = token.FontSizeSM;
            var lineHeight = token.LineHeight;
            var lineWidth = token.LineWidth;
            var colorIcon = token.ColorIcon;
            var colorIconHover = token.ColorIconHover;
            var opacityLoading = token.OpacityLoading;
            var controlInteractiveSize = token.ControlInteractiveSize;
            var colorFillSecondarySolid = new TinyColor(colorFillSecondary).OnBackground(colorBgContainer).ToHexShortString();
            var colorFillContentSolid = new TinyColor(colorFillContent).OnBackground(colorBgContainer).ToHexShortString();
            var colorFillAlterSolid = new TinyColor(colorFillAlter).OnBackground(colorBgContainer).ToHexShortString();
            var baseColorAction = new TinyColor(colorIcon);
            var baseColorActionHover = new TinyColor(colorIconHover);
            var expandIconHalfInner = controlInteractiveSize / 2 - lineWidth;
            var expandIconSize = expandIconHalfInner * 2 + lineWidth * 3;
            return new TableToken
            {
                HeaderBg = colorFillAlterSolid,
                HeaderColor = colorTextHeading,
                HeaderSortActiveBg = colorFillSecondarySolid,
                HeaderSortHoverBg = colorFillContentSolid,
                BodySortBg = colorFillAlterSolid,
                RowHoverBg = colorFillAlterSolid,
                RowSelectedBg = controlItemBgActive,
                RowSelectedHoverBg = controlItemBgActiveHover,
                RowExpandedBg = colorFillAlter,
                CellPaddingBlock = padding,
                CellPaddingInline = padding,
                CellPaddingBlockMD = paddingSM,
                CellPaddingInlineMD = paddingXS,
                CellPaddingBlockSM = paddingXS,
                CellPaddingInlineSM = paddingXS,
                BorderColor = colorBorderSecondary,
                HeaderBorderRadius = borderRadiusLG,
                FooterBg = colorFillAlterSolid,
                FooterColor = colorTextHeading,
                CellFontSize = fontSize,
                CellFontSizeMD = fontSize,
                CellFontSizeSM = fontSize,
                HeaderSplitColor = colorBorderSecondary,
                FixedHeaderSortActiveBg = colorFillSecondarySolid,
                HeaderFilterHoverBg = colorFillContent,
                FilterDropdownMenuBg = colorBgContainer,
                FilterDropdownBg = colorBgContainer,
                ExpandIconBg = colorBgContainer,
                SelectionColumnWidth = controlHeight,
                StickyScrollBarBg = colorTextPlaceholder,
                StickyScrollBarBorderRadius = 100,
                ExpandIconMarginTop = (fontSize * lineHeight - lineWidth * 3) / 2 - Math.Ceil((fontSizeSM * 1.4 - lineWidth * 3) / 2),
                HeaderIconColor = baseColorAction.Clone().SetAlpha(baseColorAction.GetAlpha() * opacityLoading).ToRgbString(),
                HeaderIconHoverColor = baseColorActionHover.Clone().SetAlpha(baseColorActionHover.GetAlpha() * opacityLoading).ToRgbString(),
                ExpandIconScale = controlInteractiveSize / expandIconSize,
            };
        }

        public object zIndexTableFixed = 2;
        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Table", (TableToken token) =>
            {
                var colorTextHeading = token.ColorTextHeading;
                var colorSplit = token.ColorSplit;
                var colorBgContainer = token.ColorBgContainer;
                var checkboxSize = token.ControlInteractiveSize;
                var headerBg = token.HeaderBg;
                var headerColor = token.HeaderColor;
                var headerSortActiveBg = token.HeaderSortActiveBg;
                var headerSortHoverBg = token.HeaderSortHoverBg;
                var bodySortBg = token.BodySortBg;
                var rowHoverBg = token.RowHoverBg;
                var rowSelectedBg = token.RowSelectedBg;
                var rowSelectedHoverBg = token.RowSelectedHoverBg;
                var rowExpandedBg = token.RowExpandedBg;
                var cellPaddingBlock = token.CellPaddingBlock;
                var cellPaddingInline = token.CellPaddingInline;
                var cellPaddingBlockMD = token.CellPaddingBlockMD;
                var cellPaddingInlineMD = token.CellPaddingInlineMD;
                var cellPaddingBlockSM = token.CellPaddingBlockSM;
                var cellPaddingInlineSM = token.CellPaddingInlineSM;
                var borderColor = token.BorderColor;
                var footerBg = token.FooterBg;
                var footerColor = token.FooterColor;
                var headerBorderRadius = token.HeaderBorderRadius;
                var cellFontSize = token.CellFontSize;
                var cellFontSizeMD = token.CellFontSizeMD;
                var cellFontSizeSM = token.CellFontSizeSM;
                var headerSplitColor = token.HeaderSplitColor;
                var fixedHeaderSortActiveBg = token.FixedHeaderSortActiveBg;
                var headerFilterHoverBg = token.HeaderFilterHoverBg;
                var filterDropdownBg = token.FilterDropdownBg;
                var expandIconBg = token.ExpandIconBg;
                var selectionColumnWidth = token.SelectionColumnWidth;
                var stickyScrollBarBg = token.StickyScrollBarBg;
                var calc = token.Calc;
                var tableToken = MergeToken(token, new object { TableFontSize = cellFontSize, TableBg = colorBgContainer, TableRadius = headerBorderRadius, TablePaddingVertical = cellPaddingBlock, TablePaddingHorizontal = cellPaddingInline, TablePaddingVerticalMiddle = cellPaddingBlockMD, TablePaddingHorizontalMiddle = cellPaddingInlineMD, TablePaddingVerticalSmall = cellPaddingBlockSM, TablePaddingHorizontalSmall = cellPaddingInlineSM, TableBorderColor = borderColor, TableHeaderTextColor = headerColor, TableHeaderBg = headerBg, TableFooterTextColor = footerColor, TableFooterBg = footerBg, TableHeaderCellSplitColor = headerSplitColor, TableHeaderSortBg = headerSortActiveBg, TableHeaderSortHoverBg = headerSortHoverBg, TableBodySortBg = bodySortBg, TableFixedHeaderSortActiveBg = fixedHeaderSortActiveBg, TableHeaderFilterActiveBg = headerFilterHoverBg, TableFilterDropdownBg = filterDropdownBg, TableRowHoverBg = rowHoverBg, TableSelectedRowBg = rowSelectedBg, TableSelectedRowHoverBg = rowSelectedHoverBg, ZIndexTableSticky = Calc(zIndexTableFixed).Add(1).Equal(new object { Unit = false, }), TableFontSizeMiddle = cellFontSizeMD, TableFontSizeSmall = cellFontSizeSM, TableSelectionColumnWidth = selectionColumnWidth, TableExpandIconBg = expandIconBg, TableExpandColumnWidth = Calc(checkboxSize).Add(Calc(token.Padding).Mul(2)).Equal(), TableExpandedRowBg = rowExpandedBg, TableFilterDropdownWidth = 120, TableFilterDropdownHeight = 264, TableFilterDropdownSearchWidth = 140, TableScrollThumbSize = 8, TableScrollThumbBg = stickyScrollBarBg, TableScrollThumbBgHover = colorTextHeading, TableScrollBg = colorSplit, });
                return new object[]
                {
                    GenTableStyle(tableToken),
                    GenPaginationStyle(tableToken),
                    GenSummaryStyle(tableToken),
                    GenSorterStyle(tableToken),
                    GenFilterStyle(tableToken),
                    GenBorderedStyle(tableToken),
                    GenRadiusStyle(tableToken),
                    GenExpandStyle(tableToken),
                    GenSummaryStyle(tableToken),
                    GenEmptyStyle(tableToken),
                    GenSelectionStyle(tableToken),
                    GenFixedStyle(tableToken),
                    GenStickyStyle(tableToken),
                    GenEllipsisStyle(tableToken),
                    GenSizeStyle(tableToken),
                    GenRtlStyle(tableToken),
                    GenVirtualStyle(tableToken)
                };
            }, PrepareComponentToken, new object { Unitless = new object { ExpandIconScale = true, }, });
        }
    }
}