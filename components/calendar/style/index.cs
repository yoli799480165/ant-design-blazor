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
    public partial class CalendarStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public string YearControlWidth { get; set; }
            public string MonthControlWidth { get; set; }
            public string MiniContentHeight { get; set; }
            public string FullBg { get; set; }
            public string FullPanelBg { get; set; }
            public string ItemActiveBg { get; set; }
        }

        public class CalendarToken : ComponentToken, PickerPanelToken, PanelComponentToken
        {
            public string CalendarCls { get; set; }
            public string DateValueHeight { get; set; }
            public string WeekHeight { get; set; }
            public string DateContentHeight { get; set; }
        }

        public static CSSObject GenCalendarStyles(CalendarToken token)
        {
            var calendarCls = token.CalendarCls;
            var componentCls = token.ComponentCls;
            var fullBg = token.FullBg;
            var fullPanelBg = token.FullPanelBg;
            var itemActiveBg = token.ItemActiveBg;
            return new CSSObject
            {
                [calendarCls] = new CSSObject
                {
                    ["..."] = GenPanelStyle(token),
                    ["..."] = ResetComponent(token),
                    Background = fullBg,
                    ["&-rtl"] = new CSSObject
                    {
                        Direction = "rtl",
                    },
                    [$@"{calendarCls}-header"] = new CSSObject
                    {
                        Display = "flex",
                        JustifyContent = "flex-end",
                        Padding = $@"{Unit(token.PaddingSM)} 0",
                        [$@"{calendarCls}-year-select"] = new CSSObject
                        {
                            MinWidth = token.YearControlWidth,
                        },
                        [$@"{calendarCls}-month-select"] = new CSSObject
                        {
                            MinWidth = token.MonthControlWidth,
                            MarginInlineStart = token.MarginXS,
                        },
                        [$@"{calendarCls}-mode-switch"] = new CSSObject
                        {
                            MarginInlineStart = token.MarginXS,
                        },
                    },
                },
                [$@"{calendarCls} {componentCls}-panel"] = new CSSObject
                {
                    Background = fullPanelBg,
                    Border = 0,
                    BorderTop = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorSplit}",
                    BorderRadius = 0,
                    [$@"{componentCls}-month-panel, {componentCls}-date-panel"] = new CSSObject
                    {
                        Width = "auto",
                    },
                    [$@"{componentCls}-body"] = new CSSObject
                    {
                        Padding = $@"{Unit(token.PaddingXS)} 0",
                    },
                    [$@"{componentCls}-content"] = new CSSObject
                    {
                        Width = "100%",
                    },
                },
                [$@"{calendarCls}-mini"] = new CSSObject
                {
                    BorderRadius = token.BorderRadiusLG,
                    [$@"{calendarCls}-header"] = new CSSObject
                    {
                        PaddingInlineEnd = token.PaddingXS,
                        PaddingInlineStart = token.PaddingXS,
                    },
                    [$@"{componentCls}-panel"] = new CSSObject
                    {
                        BorderRadius = $@"{Unit(token.BorderRadiusLG)} {Unit(token.BorderRadiusLG)}",
                    },
                    [$@"{componentCls}-content"] = new CSSObject
                    {
                        Height = token.MiniContentHeight,
                        ["th"] = new CSSObject
                        {
                            Height = "auto",
                            Padding = 0,
                            LineHeight = Unit(token.WeekHeight),
                        },
                    },
                    [$@"{componentCls}-cell::before"] = new CSSObject
                    {
                        PointerEvents = "none",
                    },
                },
                [$@"{calendarCls}{calendarCls}-full"] = new CSSObject
                {
                    [$@"{componentCls}-panel"] = new CSSObject
                    {
                        Display = "block",
                        Width = "100%",
                        TextAlign = "end",
                        Background = fullBg,
                        Border = 0,
                        [$@"{componentCls}-body"] = new CSSObject
                        {
                            ["th, td"] = new CSSObject
                            {
                                Padding = 0,
                            },
                            ["th"] = new CSSObject
                            {
                                Height = "auto",
                                PaddingInlineEnd = token.PaddingSM,
                                PaddingBottom = token.PaddingXXS,
                                LineHeight = Unit(token.WeekHeight),
                            },
                        },
                    },
                    [$@"{componentCls}-cell"] = new CSSObject
                    {
                        ["&::before"] = new CSSObject
                        {
                            Display = "none",
                        },
                        ["&:hover"] = new CSSObject
                        {
                            [$@"{calendarCls}-date"] = new CSSObject
                            {
                                Background = token.ControlItemBgHover,
                            },
                        },
                        [$@"{calendarCls}-date-today::before"] = new CSSObject
                        {
                            Display = "none",
                        },
                        [$@"{componentCls}-cell-selected"] = new CSSObject
                        {
                            [$@"{calendarCls}-date, {calendarCls}-date-today"] = new CSSObject
                            {
                                Background = itemActiveBg,
                            },
                        },
                        ["&-selected, &-selected:hover"] = new CSSObject
                        {
                            [$@"{calendarCls}-date, {calendarCls}-date-today"] = new CSSObject
                            {
                                [$@"{calendarCls}-date-value"] = new CSSObject
                                {
                                    Color = token.ColorPrimary,
                                },
                            },
                        },
                    },
                    [$@"{calendarCls}-date"] = new CSSObject
                    {
                        Display = "block",
                        Width = "auto",
                        Height = "auto",
                        Margin = $@"{Unit(token.calc(token.marginXS).div(2).Equal())}",
                        Padding = $@"{Unit(token.calc(token.paddingXS).div(2).Equal())} {Unit(token.PaddingXS)} 0",
                        Border = 0,
                        BorderTop = $@"{Unit(token.LineWidthBold)} {token.LineType} {token.ColorSplit}",
                        BorderRadius = 0,
                        Transition = $@"{token.MotionDurationSlow}",
                        ["&-value"] = new CSSObject
                        {
                            LineHeight = Unit(token.DateValueHeight),
                            Transition = $@"{token.MotionDurationSlow}",
                        },
                        ["&-content"] = new CSSObject
                        {
                            Position = "static",
                            Width = "auto",
                            Height = token.DateContentHeight,
                            OverflowY = "auto",
                            Color = token.ColorText,
                            LineHeight = token.LineHeight,
                            TextAlign = "start",
                        },
                        ["&-today"] = new CSSObject
                        {
                            BorderColor = token.ColorPrimary,
                            [$@"{calendarCls}-date-value"] = new CSSObject
                            {
                                Color = token.ColorText,
                            },
                        },
                    },
                },
                [$@"{Unit(token.ScreenXS)}) "] = new CSSObject
                {
                    [calendarCls] = new CSSObject
                    {
                        [$@"{calendarCls}-header"] = new CSSObject
                        {
                            Display = "block",
                            [$@"{calendarCls}-year-select"] = new CSSObject
                            {
                                Width = "50%",
                            },
                            [$@"{calendarCls}-month-select"] = new CSSObject
                            {
                                Width = $@"{Unit(token.PaddingXS)})",
                            },
                            [$@"{calendarCls}-mode-switch"] = new CSSObject
                            {
                                Width = "100%",
                                MarginTop = token.MarginXS,
                                MarginInlineStart = 0,
                                ["> label"] = new CSSObject
                                {
                                    Width = "50%",
                                    TextAlign = "center",
                                },
                            },
                        },
                    },
                },
            };
        }

        public static CalendarToken PrepareComponentToken(CalendarToken token)
        {
            return new CalendarToken
            {
                FullBg = token.ColorBgContainer,
                FullPanelBg = token.ColorBgContainer,
                ItemActiveBg = token.ControlItemBgActive,
                YearControlWidth = 80,
                MonthControlWidth = 70,
                MiniContentHeight = 256,
                ["..."] = InitPanelComponentToken(token),
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Calendar", (CalendarToken token) =>
            {
                var calendarCls = $@"{token.ComponentCls}-calendar";
                var calendarToken = MergeToken(token, InitPickerPanelToken(token), new object { PickerCellInnerCls = $@"{token.ComponentCls}-cell-inner", DateValueHeight = token.ControlHeightSM, WeekHeight = token.calc(token.controlHeightSM).mul(0.75).Equal() as number, DateContentHeight = token
        .calc(token.calc(token.fontHeightSM).add(token.marginXS))
        .mul(3)
        .add(token.calc(token.lineWidth).mul(2)).Equal() as number, });
                return new object[]
                {
                    GenCalendarStyles(calendarToken)
                };
            }, prepareComponentToken);
        }
    }
}