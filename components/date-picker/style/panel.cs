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
        public static CSSObject GenPickerCellInnerStyle(SharedPickerToken token)
        {
            var pickerCellCls = token.PickerCellCls;
            var pickerCellInnerCls = token.PickerCellInnerCls;
            var cellHeight = token.CellHeight;
            var borderRadiusSM = token.BorderRadiusSM;
            var motionDurationMid = token.MotionDurationMid;
            var cellHoverBg = token.CellHoverBg;
            var lineWidth = token.LineWidth;
            var lineType = token.LineType;
            var colorPrimary = token.ColorPrimary;
            var cellActiveWithRangeBg = token.CellActiveWithRangeBg;
            var colorTextLightSolid = token.ColorTextLightSolid;
            var colorTextDisabled = token.ColorTextDisabled;
            var cellBgDisabled = token.CellBgDisabled;
            var colorFillSecondary = token.ColorFillSecondary;
            return new CSSObject
            {
                ["&::before"] = new CSSObject
                {
                    Position = "absolute",
                    Top = "50%",
                    InsetInlineStart = 0,
                    InsetInlineEnd = 0,
                    ZIndex = 1,
                    Height = cellHeight,
                    Transform = "translateY(-50%)",
                    Content = "\"\"",
                    PointerEvents = "none",
                },
                [pickerCellInnerCls] = new CSSObject
                {
                    Position = "relative",
                    ZIndex = 2,
                    Display = "inline-block",
                    MinWidth = cellHeight,
                    Height = cellHeight,
                    LineHeight = Unit(cellHeight),
                    BorderRadius = borderRadiusSM,
                    Transition = $@"{motionDurationMid}",
                },
                [$@"{pickerCellCls}-in-view):not({pickerCellCls}-disabled),
    &:hover:not({pickerCellCls}-selected):not({pickerCellCls}-range-start):not({pickerCellCls}-range-end):not({pickerCellCls}-disabled)"] = new CSSObject
                {
                    [pickerCellInnerCls] = new CSSObject
                    {
                        Background = cellHoverBg,
                    },
                },
                [$@"{pickerCellCls}-today {pickerCellInnerCls}"] = new CSSObject
                {
                    ["&::before"] = new CSSObject
                    {
                        Position = "absolute",
                        Top = 0,
                        InsetInlineEnd = 0,
                        Bottom = 0,
                        InsetInlineStart = 0,
                        ZIndex = 1,
                        Border = $@"{Unit(lineWidth)} {lineType} {colorPrimary}",
                        BorderRadius = borderRadiusSM,
                        Content = "\"\"",
                    },
                },
                [$@"{pickerCellCls}-in-range,
      &-in-view{pickerCellCls}-range-start,
      &-in-view{pickerCellCls}-range-end"] = new CSSObject
                {
                    Position = "relative",
                    [$@"{pickerCellCls}-disabled):before"] = new CSSObject
                    {
                        Background = cellActiveWithRangeBg,
                    },
                },
                [$@"{pickerCellCls}-selected,
      &-in-view{pickerCellCls}-range-start,
      &-in-view{pickerCellCls}-range-end"] = new CSSObject
                {
                    [$@"{pickerCellCls}-disabled) {pickerCellInnerCls}"] = new CSSObject
                    {
                        Color = colorTextLightSolid,
                        Background = colorPrimary,
                    },
                    [$@"{pickerCellCls}-disabled {pickerCellInnerCls}"] = new CSSObject
                    {
                        Background = colorFillSecondary,
                    },
                },
                [$@"{pickerCellCls}-range-start:not({pickerCellCls}-disabled):before"] = new CSSObject
                {
                    InsetInlineStart = "50%",
                },
                [$@"{pickerCellCls}-range-end:not({pickerCellCls}-disabled):before"] = new CSSObject
                {
                    InsetInlineEnd = "50%",
                },
                [$@"{pickerCellCls}-range-start:not({pickerCellCls}-range-end) {pickerCellInnerCls}"] = new CSSObject
                {
                    BorderStartStartRadius = borderRadiusSM,
                    BorderEndStartRadius = borderRadiusSM,
                    BorderStartEndRadius = 0,
                    BorderEndEndRadius = 0,
                },
                [$@"{pickerCellCls}-range-end:not({pickerCellCls}-range-start) {pickerCellInnerCls}"] = new CSSObject
                {
                    BorderStartStartRadius = 0,
                    BorderEndStartRadius = 0,
                    BorderStartEndRadius = borderRadiusSM,
                    BorderEndEndRadius = borderRadiusSM,
                },
                ["&-disabled"] = new CSSObject
                {
                    Color = colorTextDisabled,
                    Cursor = "not-allowed",
                    [pickerCellInnerCls] = new CSSObject
                    {
                        Background = "transparent",
                    },
                    ["&::before"] = new CSSObject
                    {
                        Background = cellBgDisabled,
                    },
                },
                [$@"{pickerCellCls}-today {pickerCellInnerCls}::before"] = new CSSObject
                {
                    BorderColor = colorTextDisabled,
                },
            };
        }

        public static CSSObject GenPanelStyle(SharedPickerToken token)
        {
            var componentCls = token.ComponentCls;
            var pickerCellCls = token.PickerCellCls;
            var pickerCellInnerCls = token.PickerCellInnerCls;
            var pickerYearMonthCellWidth = token.PickerYearMonthCellWidth;
            var pickerControlIconSize = token.PickerControlIconSize;
            var cellWidth = token.CellWidth;
            var paddingSM = token.PaddingSM;
            var paddingXS = token.PaddingXS;
            var paddingXXS = token.PaddingXXS;
            var colorBgContainer = token.ColorBgContainer;
            var lineWidth = token.LineWidth;
            var lineType = token.LineType;
            var borderRadiusLG = token.BorderRadiusLG;
            var colorPrimary = token.ColorPrimary;
            var colorTextHeading = token.ColorTextHeading;
            var colorSplit = token.ColorSplit;
            var pickerControlIconBorderWidth = token.PickerControlIconBorderWidth;
            var colorIcon = token.ColorIcon;
            var textHeight = token.TextHeight;
            var motionDurationMid = token.MotionDurationMid;
            var colorIconHover = token.ColorIconHover;
            var fontWeightStrong = token.FontWeightStrong;
            var cellHeight = token.CellHeight;
            var pickerCellPaddingVertical = token.PickerCellPaddingVertical;
            var colorTextDisabled = token.ColorTextDisabled;
            var colorText = token.ColorText;
            var fontSize = token.FontSize;
            var motionDurationSlow = token.MotionDurationSlow;
            var withoutTimeCellHeight = token.WithoutTimeCellHeight;
            var pickerQuarterPanelContentHeight = token.PickerQuarterPanelContentHeight;
            var borderRadiusSM = token.BorderRadiusSM;
            var colorTextLightSolid = token.ColorTextLightSolid;
            var cellHoverBg = token.CellHoverBg;
            var timeColumnHeight = token.TimeColumnHeight;
            var timeColumnWidth = token.TimeColumnWidth;
            var timeCellHeight = token.TimeCellHeight;
            var controlItemBgActive = token.ControlItemBgActive;
            var marginXXS = token.MarginXXS;
            var pickerDatePanelPaddingHorizontal = token.PickerDatePanelPaddingHorizontal;
            var pickerControlIconMargin = token.PickerControlIconMargin;
            var pickerPanelWidth = token
    .calc(cellWidth)
    .mul(7)
    .add(token.calc(pickerDatePanelPaddingHorizontal).mul(2)).Equal();
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["&-panel"] = new CSSObject
                    {
                        Display = "inline-flex",
                        FlexDirection = "column",
                        TextAlign = "center",
                        Background = colorBgContainer,
                        BorderRadius = borderRadiusLG,
                        Outline = "none",
                        ["&-focused"] = new CSSObject
                        {
                            BorderColor = colorPrimary,
                        },
                        ["&-rtl"] = new CSSObject
                        {
                            [$@"{componentCls}-prev-icon,
              {componentCls}-super-prev-icon"] = new CSSObject
                            {
                                Transform = "rotate(45deg)",
                            },
                            [$@"{componentCls}-next-icon,
              {componentCls}-super-next-icon"] = new CSSObject
                            {
                                Transform = "rotate(-135deg)",
                            },
                            [$@"{componentCls}-time-panel"] = new CSSObject
                            {
                                [$@"{componentCls}-content"] = new CSSObject
                                {
                                    Direction = "ltr",
                                    ["> *"] = new CSSObject
                                    {
                                        Direction = "rtl",
                                    },
                                },
                            },
                        },
                    },
                    ["&-decade-panel,\n        &-year-panel,\n        &-quarter-panel,\n        &-month-panel,\n        &-week-panel,\n        &-date-panel,\n        &-time-panel"] = new CSSObject
                    {
                        Display = "flex",
                        FlexDirection = "column",
                        Width = pickerPanelWidth,
                    },
                    ["&-header"] = new CSSObject
                    {
                        Display = "flex",
                        Padding = $@"{Unit(paddingXS)}",
                        Color = colorTextHeading,
                        BorderBottom = $@"{Unit(lineWidth)} {lineType} {colorSplit}",
                        ["> *"] = new CSSObject
                        {
                            Flex = "none",
                        },
                        ["button"] = new CSSObject
                        {
                            Padding = 0,
                            Color = colorIcon,
                            LineHeight = Unit(textHeight),
                            Background = "transparent",
                            Border = 0,
                            Cursor = "pointer",
                            Transition = $@"{motionDurationMid}",
                            FontSize = "inherit",
                            Display = "inline-flex",
                            AlignItems = "center",
                            JustifyContent = "center",
                        },
                        ["> button"] = new CSSObject
                        {
                            MinWidth = "1.6em",
                            ["&:hover"] = new CSSObject
                            {
                                Color = colorIconHover,
                            },
                            ["&:disabled"] = new CSSObject
                            {
                                Opacity = 0.25,
                                PointerEvents = "none",
                            },
                        },
                        ["&-view"] = new CSSObject
                        {
                            Flex = "auto",
                            FontWeight = fontWeightStrong,
                            LineHeight = Unit(textHeight),
                            ["> button"] = new CSSObject
                            {
                                Color = "inherit",
                                FontWeight = "inherit",
                                ["&:not(:first-child)"] = new CSSObject
                                {
                                    MarginInlineStart = paddingXS,
                                },
                                ["&:hover"] = new CSSObject
                                {
                                    Color = colorPrimary,
                                },
                            },
                        },
                    },
                    ["&-prev-icon,\n        &-next-icon,\n        &-super-prev-icon,\n        &-super-next-icon"] = new CSSObject
                    {
                        Position = "relative",
                        Width = pickerControlIconSize,
                        Height = pickerControlIconSize,
                        ["&::before"] = new CSSObject
                        {
                            Position = "absolute",
                            Top = 0,
                            InsetInlineStart = 0,
                            Width = pickerControlIconSize,
                            Height = pickerControlIconSize,
                            Border = "0 solid currentcolor",
                            BorderBlockWidth = $@"{Unit(pickerControlIconBorderWidth)} 0",
                            BorderInlineWidth = $@"{Unit(pickerControlIconBorderWidth)} 0",
                            Content = "\"\"",
                        },
                    },
                    ["&-super-prev-icon,\n        &-super-next-icon"] = new CSSObject
                    {
                        ["&::after"] = new CSSObject
                        {
                            Position = "absolute",
                            Top = pickerControlIconMargin,
                            InsetInlineStart = pickerControlIconMargin,
                            Display = "inline-block",
                            Width = pickerControlIconSize,
                            Height = pickerControlIconSize,
                            Border = "0 solid currentcolor",
                            BorderBlockWidth = $@"{Unit(pickerControlIconBorderWidth)} 0",
                            BorderInlineWidth = $@"{Unit(pickerControlIconBorderWidth)} 0",
                            Content = "\"\"",
                        },
                    },
                    ["&-prev-icon, &-super-prev-icon"] = new CSSObject
                    {
                        Transform = "rotate(-45deg)",
                    },
                    ["&-next-icon, &-super-next-icon"] = new CSSObject
                    {
                        Transform = "rotate(135deg)",
                    },
                    ["&-content"] = new CSSObject
                    {
                        Width = "100%",
                        TableLayout = "fixed",
                        BorderCollapse = "collapse",
                        ["th, td"] = new CSSObject
                        {
                            Position = "relative",
                            MinWidth = cellHeight,
                            FontWeight = "normal",
                        },
                        ["th"] = new CSSObject
                        {
                            Height = token.calc(cellHeight).add(token.calc(pickerCellPaddingVertical).mul(2)).Equal(),
                            Color = colorText,
                            VerticalAlign = "middle",
                        },
                    },
                    ["&-cell"] = new CSSObject
                    {
                        Padding = $@"{Unit(pickerCellPaddingVertical)} 0",
                        Color = colorTextDisabled,
                        Cursor = "pointer",
                        ["&-in-view"] = new CSSObject
                        {
                            Color = colorText,
                        },
                        ["..."] = GenPickerCellInnerStyle(token),
                    },
                    ["&-decade-panel,\n        &-year-panel,\n        &-quarter-panel,\n        &-month-panel"] = new CSSObject
                    {
                        [$@"{componentCls}-content"] = new CSSObject
                        {
                            Height = token.calc(withoutTimeCellHeight).mul(4).Equal(),
                        },
                        [pickerCellInnerCls] = new CSSObject
                        {
                            Padding = $@"{Unit(paddingXS)}",
                        },
                    },
                    ["&-quarter-panel"] = new CSSObject
                    {
                        [$@"{componentCls}-content"] = new CSSObject
                        {
                            Height = pickerQuarterPanelContentHeight,
                        },
                    },
                    ["&-decade-panel"] = new CSSObject
                    {
                        [pickerCellInnerCls] = new CSSObject
                        {
                            Padding = $@"{Unit(token.calc(paddingXS).div(2).Equal())}",
                        },
                        [$@"{componentCls}-cell::before"] = new CSSObject
                        {
                            Display = "none",
                        },
                    },
                    ["&-year-panel,\n        &-quarter-panel,\n        &-month-panel"] = new CSSObject
                    {
                        [$@"{componentCls}-body"] = new CSSObject
                        {
                            Padding = $@"{Unit(paddingXS)}",
                        },
                        [pickerCellInnerCls] = new CSSObject
                        {
                            Width = pickerYearMonthCellWidth,
                        },
                    },
                    ["&-date-panel"] = new CSSObject
                    {
                        [$@"{componentCls}-body"] = new CSSObject
                        {
                            Padding = $@"{Unit(paddingXS)} {Unit(pickerDatePanelPaddingHorizontal)}",
                        },
                        [$@"{componentCls}-content th"] = new CSSObject
                        {
                            BoxSizing = "border-box",
                            Padding = 0,
                        },
                    },
                    ["&-week-panel"] = new CSSObject
                    {
                        [$@"{componentCls}-cell"] = new CSSObject
                        {
                            [$@"{pickerCellInnerCls},
            &-selected {pickerCellInnerCls},
            {pickerCellInnerCls}"] = new CSSObject
                            {
                                Background = "transparent !important",
                            },
                        },
                        ["&-row"] = new CSSObject
                        {
                            ["td"] = new CSSObject
                            {
                                ["&:before"] = new CSSObject
                                {
                                    Transition = $@"{motionDurationMid}",
                                },
                                ["&:first-child:before"] = new CSSObject
                                {
                                    BorderStartStartRadius = borderRadiusSM,
                                    BorderEndStartRadius = borderRadiusSM,
                                },
                                ["&:last-child:before"] = new CSSObject
                                {
                                    BorderStartEndRadius = borderRadiusSM,
                                    BorderEndEndRadius = borderRadiusSM,
                                },
                            },
                            ["&:hover td:before"] = new CSSObject
                            {
                                Background = cellHoverBg,
                            },
                            ["&-range-start td, &-range-end td, &-selected td, &-hover td"] = new CSSObject
                            {
                                [$@"{pickerCellCls}"] = new CSSObject
                                {
                                    ["&:before"] = new CSSObject
                                    {
                                        Background = colorPrimary,
                                    },
                                    [$@"{componentCls}-cell-week"] = new CSSObject
                                    {
                                        Color = new TinyColor(colorTextLightSolid).setAlpha(0.5).ToHexString(),
                                    },
                                    [pickerCellInnerCls] = new CSSObject
                                    {
                                        Color = colorTextLightSolid,
                                    },
                                },
                            },
                            ["&-range-hover td:before"] = new CSSObject
                            {
                                Background = controlItemBgActive,
                            },
                        },
                    },
                    ["&-week-panel, &-date-panel-show-week"] = new CSSObject
                    {
                        [$@"{componentCls}-body"] = new CSSObject
                        {
                            Padding = $@"{Unit(paddingXS)} {Unit(paddingSM)}",
                        },
                        [$@"{componentCls}-content th"] = new CSSObject
                        {
                            Width = "auto",
                        },
                    },
                    ["&-datetime-panel"] = new CSSObject
                    {
                        Display = "flex",
                        [$@"{componentCls}-time-panel"] = new CSSObject
                        {
                            BorderInlineStart = $@"{Unit(lineWidth)} {lineType} {colorSplit}",
                        },
                        [$@"{componentCls}-date-panel,
          {componentCls}-time-panel"] = new CSSObject
                        {
                            Transition = $@"{motionDurationSlow}",
                        },
                        ["&-active"] = new CSSObject
                        {
                            [$@"{componentCls}-date-panel,
            {componentCls}-time-panel"] = new CSSObject
                            {
                                Opacity = 0.3,
                                ["&-active"] = new CSSObject
                                {
                                    Opacity = 1,
                                },
                            },
                        },
                    },
                    ["&-time-panel"] = new CSSObject
                    {
                        Width = "auto",
                        MinWidth = "auto",
                        [$@"{componentCls}-content"] = new CSSObject
                        {
                            Display = "flex",
                            Flex = "auto",
                            Height = timeColumnHeight,
                        },
                        ["&-column"] = new CSSObject
                        {
                            Flex = "1 0 auto",
                            Width = timeColumnWidth,
                            Margin = $@"{Unit(paddingXXS)} 0",
                            Padding = 0,
                            OverflowY = "hidden",
                            TextAlign = "start",
                            ListStyle = "none",
                            Transition = $@"{motionDurationMid}",
                            OverflowX = "hidden",
                            ["&::-webkit-scrollbar"] = new CSSObject
                            {
                                Width = 8,
                                BackgroundColor = "transparent",
                            },
                            ["&::-webkit-scrollbar-thumb"] = new CSSObject
                            {
                                BackgroundColor = token.ColorTextTertiary,
                                BorderRadius = token.BorderRadiusSM,
                            },
                            ["&"] = new CSSObject
                            {
                                ScrollbarWidth = "thin",
                                ScrollbarColor = $@"{token.ColorTextTertiary} transparent",
                            },
                            ["&::after"] = new CSSObject
                            {
                                Display = "block",
                                Height = $@"{Unit(timeCellHeight)})",
                                Content = "\"\"",
                            },
                            ["&:not(:first-child)"] = new CSSObject
                            {
                                BorderInlineStart = $@"{Unit(lineWidth)} {lineType} {colorSplit}",
                            },
                            ["&-active"] = new CSSObject
                            {
                                Background = new TinyColor(controlItemBgActive).setAlpha(0.2).ToHexString(),
                            },
                            ["&:hover"] = new CSSObject
                            {
                                OverflowY = "auto",
                            },
                            ["> li"] = new CSSObject
                            {
                                Margin = 0,
                                Padding = 0,
                                [$@"{componentCls}-time-panel-cell"] = new CSSObject
                                {
                                    MarginInline = marginXXS,
                                    [$@"{componentCls}-time-panel-cell-inner"] = new CSSObject
                                    {
                                        Display = "block",
                                        Width = token.calc(timeColumnWidth).sub(token.calc(marginXXS).mul(2)).Equal(),
                                        Height = timeCellHeight,
                                        Margin = 0,
                                        PaddingBlock = 0,
                                        PaddingInlineEnd = 0,
                                        PaddingInlineStart = token.calc(timeColumnWidth).sub(timeCellHeight).div(2).Equal(),
                                        Color = colorText,
                                        LineHeight = Unit(timeCellHeight),
                                        BorderRadius = borderRadiusSM,
                                        Cursor = "pointer",
                                        Transition = $@"{motionDurationMid}",
                                        ["&:hover"] = new CSSObject
                                        {
                                            Background = cellHoverBg,
                                        },
                                    },
                                    ["&-selected"] = new CSSObject
                                    {
                                        [$@"{componentCls}-time-panel-cell-inner"] = new CSSObject
                                        {
                                            Background = controlItemBgActive,
                                        },
                                    },
                                    ["&-disabled"] = new CSSObject
                                    {
                                        [$@"{componentCls}-time-panel-cell-inner"] = new CSSObject
                                        {
                                            Color = colorTextDisabled,
                                            Background = "transparent",
                                            Cursor = "not-allowed",
                                        },
                                    },
                                },
                            },
                        },
                    },
                },
            };
        }

        public static CSSObject GenPickerPanelStyle(DatePickerToken token)
        {
            var componentCls = token.ComponentCls;
            var textHeight = token.TextHeight;
            var lineWidth = token.LineWidth;
            var paddingSM = token.PaddingSM;
            var antCls = token.AntCls;
            var colorPrimary = token.ColorPrimary;
            var cellActiveWithRangeBg = token.CellActiveWithRangeBg;
            var colorPrimaryBorder = token.ColorPrimaryBorder;
            var lineType = token.LineType;
            var colorSplit = token.ColorSplit;
            return new CSSObject
            {
                [$@"{componentCls}-dropdown"] = new CSSObject
                {
                    [$@"{componentCls}-footer"] = new CSSObject
                    {
                        BorderTop = $@"{Unit(lineWidth)} {lineType} {colorSplit}",
                        ["&-extra"] = new CSSObject
                        {
                            Padding = $@"{Unit(paddingSM)}",
                            LineHeight = Unit(token.calc(textHeight).sub(token.calc(lineWidth).mul(2)).Equal()),
                            TextAlign = "start",
                            ["&:not(:last-child)"] = new CSSObject
                            {
                                BorderBottom = $@"{Unit(lineWidth)} {lineType} {colorSplit}",
                            },
                        },
                    },
                    [$@"{componentCls}-panels + {componentCls}-footer {componentCls}-ranges"] = new CSSObject
                    {
                        JustifyContent = "space-between",
                    },
                    [$@"{componentCls}-ranges"] = new CSSObject
                    {
                        MarginBlock = 0,
                        PaddingInline = Unit(paddingSM),
                        Overflow = "hidden",
                        TextAlign = "start",
                        ListStyle = "none",
                        Display = "flex",
                        JustifyContent = "center",
                        AlignItems = "center",
                        ["> li"] = new CSSObject
                        {
                            LineHeight = Unit(token.calc(textHeight).sub(token.calc(lineWidth).mul(2)).Equal()),
                            Display = "inline-block",
                        },
                        [$@"{componentCls}-now-btn-disabled"] = new CSSObject
                        {
                            PointerEvents = "none",
                            Color = token.ColorTextDisabled,
                        },
                        [$@"{componentCls}-preset > {antCls}-tag-blue"] = new CSSObject
                        {
                            Color = colorPrimary,
                            Background = cellActiveWithRangeBg,
                            BorderColor = colorPrimaryBorder,
                            Cursor = "pointer",
                        },
                        [$@"{componentCls}-ok"] = new CSSObject
                        {
                            PaddingBlock = token.calc(lineWidth).mul(2).Equal(),
                            MarginInlineStart = "auto",
                        },
                    },
                },
            };
        }

        public static object PanelDefault()
        {
            return genPickerPanelStyle;
        }
    }
}