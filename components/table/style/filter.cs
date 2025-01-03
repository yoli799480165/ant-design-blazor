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
        public static CSSObject GenFilterStyle(TableToken token)
        {
            var componentCls = token.ComponentCls;
            var antCls = token.AntCls;
            var iconCls = token.IconCls;
            var tableFilterDropdownWidth = token.TableFilterDropdownWidth;
            var tableFilterDropdownSearchWidth = token.TableFilterDropdownSearchWidth;
            var paddingXXS = token.PaddingXXS;
            var paddingXS = token.PaddingXS;
            var colorText = token.ColorText;
            var lineWidth = token.LineWidth;
            var lineType = token.LineType;
            var tableBorderColor = token.TableBorderColor;
            var headerIconColor = token.HeaderIconColor;
            var fontSizeSM = token.FontSizeSM;
            var tablePaddingHorizontal = token.TablePaddingHorizontal;
            var borderRadius = token.BorderRadius;
            var motionDurationSlow = token.MotionDurationSlow;
            var colorTextDescription = token.ColorTextDescription;
            var colorPrimary = token.ColorPrimary;
            var tableHeaderFilterActiveBg = token.TableHeaderFilterActiveBg;
            var colorTextDisabled = token.ColorTextDisabled;
            var tableFilterDropdownBg = token.TableFilterDropdownBg;
            var tableFilterDropdownHeight = token.TableFilterDropdownHeight;
            var controlItemBgHover = token.ControlItemBgHover;
            var controlItemBgActive = token.ControlItemBgActive;
            var boxShadowSecondary = token.BoxShadowSecondary;
            var filterDropdownMenuBg = token.FilterDropdownMenuBg;
            var calc = token.Calc;
            var dropdownPrefixCls = $@"{antCls}-dropdown";
            var tableFilterDropdownPrefixCls = $@"{componentCls}-filter-dropdown";
            var treePrefixCls = $@"{antCls}-tree";
            var tableBorder = $@"{Unit(lineWidth)} {lineType} {tableBorderColor}";
            return new object[]
            {
                new object
                {
                    [$@"{componentCls}-wrapper"] = new object
                    {
                        [$@"{componentCls}-filter-column"] = new object
                        {
                            Display = "flex",
                            JustifyContent = "space-between",
                        },
                        [$@"{componentCls}-filter-trigger"] = new object
                        {
                            Position = "relative",
                            Display = "flex",
                            AlignItems = "center",
                            MarginBlock = Calc(paddingXXS).Mul(-1).Equal(),
                            MarginInline = $@"{Unit(paddingXXS)} {Unit(Calc(tablePaddingHorizontal).Div(2).Mul(-1).Equal())}",
                            Padding = $@"{Unit(paddingXXS)}",
                            Color = headerIconColor,
                            FontSize = fontSizeSM,
                            Cursor = "pointer",
                            Transition = $@"{motionDurationSlow}",
                            ["&:hover"] = new object
                            {
                                Color = colorTextDescription,
                                Background = tableHeaderFilterActiveBg,
                            },
                            ["&.active"] = new object
                            {
                                Color = colorPrimary,
                            },
                        },
                    },
                },
                new object
                {
                    [$@"{antCls}-dropdown"] = new object
                    {
                        [tableFilterDropdownPrefixCls] = new object
                        {
                            ["..."] = ResetComponent(token),
                            MinWidth = tableFilterDropdownWidth,
                            BackgroundColor = tableFilterDropdownBg,
                            BoxShadow = boxShadowSecondary,
                            Overflow = "hidden",
                            [$@"{dropdownPrefixCls}-menu"] = new object
                            {
                                MaxHeight = tableFilterDropdownHeight,
                                OverflowX = "hidden",
                                Border = 0,
                                BoxShadow = "none",
                                BorderRadius = "unset",
                                BackgroundColor = filterDropdownMenuBg,
                                ["&:empty::after"] = new object
                                {
                                    Display = "block",
                                    Padding = $@"{Unit(paddingXS)} 0",
                                    Color = colorTextDisabled,
                                    FontSize = fontSizeSM,
                                    TextAlign = "center",
                                    Content = "\"Not Found\"",
                                },
                            },
                            [$@"{tableFilterDropdownPrefixCls}-tree"] = new object
                            {
                                PaddingBlock = $@"{Unit(paddingXS)} 0",
                                PaddingInline = paddingXS,
                                [treePrefixCls] = new object
                                {
                                    Padding = 0,
                                },
                                [$@"{treePrefixCls}-treenode {treePrefixCls}-node-content-wrapper:hover"] = new object
                                {
                                    BackgroundColor = controlItemBgHover,
                                },
                                [$@"{treePrefixCls}-treenode-checkbox-checked {treePrefixCls}-node-content-wrapper"] = new object
                                {
                                    ["&, &:hover"] = new object
                                    {
                                        BackgroundColor = controlItemBgActive,
                                    },
                                },
                            },
                            [$@"{tableFilterDropdownPrefixCls}-search"] = new object
                            {
                                Padding = paddingXS,
                                BorderBottom = tableBorder,
                                ["&-input"] = new object
                                {
                                    ["input"] = new object
                                    {
                                        MinWidth = tableFilterDropdownSearchWidth,
                                    },
                                    [iconCls] = new object
                                    {
                                        Color = colorTextDisabled,
                                    },
                                },
                            },
                            [$@"{tableFilterDropdownPrefixCls}-checkall"] = new object
                            {
                                Width = "100%",
                                MarginBottom = paddingXXS,
                                MarginInlineStart = paddingXXS,
                            },
                            [$@"{tableFilterDropdownPrefixCls}-btns"] = new object
                            {
                                Display = "flex",
                                JustifyContent = "space-between",
                                Padding = $@"{Unit(Calc(paddingXS).Sub(lineWidth).Equal())} {Unit(paddingXS)}",
                                Overflow = "hidden",
                                BorderTop = tableBorder,
                            },
                        },
                    },
                },
                new object
                {
                    [$@"{antCls}-dropdown {tableFilterDropdownPrefixCls}, {tableFilterDropdownPrefixCls}-submenu"] = new object
                    {
                        [$@"{antCls}-checkbox-wrapper + span"] = new object
                        {
                            PaddingInlineStart = paddingXS,
                            Color = colorText,
                        },
                        ["> ul"] = new object
                        {
                            MaxHeight = "calc(100vh - 130px)",
                            OverflowX = "hidden",
                            OverflowY = "auto",
                        },
                    },
                }
            };
        }

        public static object FilterDefault()
        {
            return GenFilterStyle;
        }
    }
}