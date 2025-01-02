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
    public partial class TransferStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public string ListWidth { get; set; }
            public string ListWidthLG { get; set; }
            public string ListHeight { get; set; }
            public string ItemHeight { get; set; }
            public string ItemPaddingBlock { get; set; }
            public string HeaderHeight { get; set; }
        }

        public class TransferToken : ComponentToken
        {
            public double TransferHeaderVerticalPadding { get; set; }
        }

        public static CSSObject GenTransferCustomizeStyle(TransferToken token)
        {
            var antCls = token.AntCls;
            var componentCls = token.ComponentCls;
            var listHeight = token.ListHeight;
            var controlHeightLG = token.ControlHeightLG;
            var tableCls = $@"{antCls}-table";
            var inputCls = $@"{antCls}-input";
            return new CSSObject
            {
                [$@"{componentCls}-customize-list"] = new CSSObject
                {
                    [$@"{componentCls}-list"] = new CSSObject
                    {
                        Flex = "1 1 50%",
                        Width = "auto",
                        Height = "auto",
                        MinHeight = listHeight,
                        MinWidth = 0,
                    },
                    [$@"{tableCls}-wrapper"] = new CSSObject
                    {
                        [$@"{tableCls}-small"] = new CSSObject
                        {
                            Border = 0,
                            BorderRadius = 0,
                            [$@"{tableCls}-selection-column"] = new CSSObject
                            {
                                Width = controlHeightLG,
                                MinWidth = controlHeightLG,
                            },
                        },
                        [$@"{tableCls}-pagination{tableCls}-pagination"] = new CSSObject
                        {
                            Margin = 0,
                            Padding = token.PaddingXS,
                        },
                    },
                    [$@"{inputCls}[disabled]"] = new CSSObject
                    {
                        BackgroundColor = "transparent",
                    },
                },
            };
        }

        public static CSSObject GenTransferStatusColor(TransferToken token, string color)
        {
            var componentCls = token.ComponentCls;
            var colorBorder = token.ColorBorder;
            return new CSSObject
            {
                [$@"{componentCls}-list"] = new CSSObject
                {
                    BorderColor = color,
                    ["&-search:not([disabled])"] = new CSSObject
                    {
                        BorderColor = colorBorder,
                    },
                },
            };
        }

        public static CSSObject GenTransferStatusStyle(TransferToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [$@"{componentCls}-status-error"] = new CSSObject
                {
                    ["..."] = GenTransferStatusColor(token, token.ColorError),
                },
                [$@"{componentCls}-status-warning"] = new CSSObject
                {
                    ["..."] = GenTransferStatusColor(token, token.ColorWarning),
                },
            };
        }

        public static CSSObject GenTransferListStyle(TransferToken token)
        {
            var componentCls = token.ComponentCls;
            var colorBorder = token.ColorBorder;
            var colorSplit = token.ColorSplit;
            var lineWidth = token.LineWidth;
            var itemHeight = token.ItemHeight;
            var headerHeight = token.HeaderHeight;
            var transferHeaderVerticalPadding = token.TransferHeaderVerticalPadding;
            var itemPaddingBlock = token.ItemPaddingBlock;
            var controlItemBgActive = token.ControlItemBgActive;
            var colorTextDisabled = token.ColorTextDisabled;
            var colorTextSecondary = token.ColorTextSecondary;
            var listHeight = token.ListHeight;
            var listWidth = token.ListWidth;
            var listWidthLG = token.ListWidthLG;
            var fontSizeIcon = token.FontSizeIcon;
            var marginXS = token.MarginXS;
            var paddingSM = token.PaddingSM;
            var lineType = token.LineType;
            var antCls = token.AntCls;
            var iconCls = token.IconCls;
            var motionDurationSlow = token.MotionDurationSlow;
            var controlItemBgHover = token.ControlItemBgHover;
            var borderRadiusLG = token.BorderRadiusLG;
            var colorBgContainer = token.ColorBgContainer;
            var colorText = token.ColorText;
            var controlItemBgActiveHover = token.ControlItemBgActiveHover;
            var contentBorderRadius = Unit(token.calc(borderRadiusLG).sub(lineWidth).Equal());
            return new CSSObject
            {
                Display = "flex",
                FlexDirection = "column",
                Width = listWidth,
                Height = listHeight,
                Border = $@"{Unit(lineWidth)} {lineType} {colorBorder}",
                BorderRadius = token.BorderRadiusLG,
                ["&-with-pagination"] = new CSSObject
                {
                    Width = listWidthLG,
                    Height = "auto",
                },
                ["&-search"] = new CSSObject
                {
                    [$@"{iconCls}-search"] = new CSSObject
                    {
                        Color = colorTextDisabled,
                    },
                },
                ["&-header"] = new CSSObject
                {
                    Display = "flex",
                    Flex = "none",
                    AlignItems = "center",
                    Height = headerHeight,
                    Padding = $@"{Unit(token.calc(transferHeaderVerticalPadding).sub(lineWidth).Equal())} {Unit(paddingSM)} {Unit(transferHeaderVerticalPadding)}",
                    Color = colorText,
                    Background = colorBgContainer,
                    BorderBottom = $@"{Unit(lineWidth)} {lineType} {colorSplit}",
                    BorderRadius = $@"{Unit(borderRadiusLG)} {Unit(borderRadiusLG)} 0 0",
                    ["> *:not(:last-child)"] = new CSSObject
                    {
                        MarginInlineEnd = 4,
                    },
                    ["> *"] = new CSSObject
                    {
                        Flex = "none",
                    },
                    ["&-title"] = new CSSObject
                    {
                        ["..."] = textEllipsis,
                        Flex = "auto",
                        TextAlign = "end",
                    },
                    ["&-dropdown"] = new CSSObject
                    {
                        ["..."] = ResetIcon(),
                        FontSize = fontSizeIcon,
                        Transform = "translateY(10%)",
                        Cursor = "pointer",
                        ["&[disabled]"] = new CSSObject
                        {
                            Cursor = "not-allowed",
                        },
                    },
                },
                ["&-body"] = new CSSObject
                {
                    Display = "flex",
                    Flex = "auto",
                    FlexDirection = "column",
                    FontSize = token.FontSize,
                    MinHeight = 0,
                    ["&-search-wrapper"] = new CSSObject
                    {
                        Position = "relative",
                        Flex = "none",
                        Padding = paddingSM,
                    },
                },
                ["&-content"] = new CSSObject
                {
                    Flex = "auto",
                    Margin = 0,
                    Padding = 0,
                    Overflow = "auto",
                    ListStyle = "none",
                    BorderRadius = $@"{contentBorderRadius} {contentBorderRadius}",
                    ["&-item"] = new CSSObject
                    {
                        Display = "flex",
                        AlignItems = "center",
                        MinHeight = itemHeight,
                        Padding = $@"{Unit(itemPaddingBlock)} {Unit(paddingSM)}",
                        Transition = $@"{motionDurationSlow}",
                        ["> *:not(:last-child)"] = new CSSObject
                        {
                            MarginInlineEnd = marginXS,
                        },
                        ["> *"] = new CSSObject
                        {
                            Flex = "none",
                        },
                        ["&-text"] = new CSSObject
                        {
                            ["..."] = textEllipsis,
                            Flex = "auto",
                        },
                        ["&-remove"] = new CSSObject
                        {
                            ["..."] = OperationUnit(token),
                            Color = colorBorder,
                            ["&:hover, &:focus"] = new CSSObject
                            {
                                Color = colorTextSecondary,
                            },
                        },
                        [$@"{componentCls}-list-content-item-disabled)"] = new CSSObject
                        {
                            ["&:hover"] = new CSSObject
                            {
                                BackgroundColor = controlItemBgHover,
                                Cursor = "pointer",
                            },
                            [$@"{componentCls}-list-content-item-checked:hover"] = new CSSObject
                            {
                                BackgroundColor = controlItemBgActiveHover,
                            },
                        },
                        ["&-checked"] = new CSSObject
                        {
                            BackgroundColor = controlItemBgActive,
                        },
                        ["&-disabled"] = new CSSObject
                        {
                            Color = colorTextDisabled,
                            Cursor = "not-allowed",
                        },
                    },
                    [$@"{componentCls}-list-content-item:not({componentCls}-list-content-item-disabled):hover"] = new CSSObject
                    {
                        Background = "transparent",
                        Cursor = "default",
                    },
                },
                ["&-pagination"] = new CSSObject
                {
                    Padding = token.PaddingXS,
                    TextAlign = "end",
                    BorderTop = $@"{Unit(lineWidth)} {lineType} {colorSplit}",
                    [$@"{antCls}-pagination-options"] = new CSSObject
                    {
                        PaddingInlineEnd = token.PaddingXS,
                    },
                },
                ["&-body-not-found"] = new CSSObject
                {
                    Flex = "none",
                    Width = "100%",
                    Margin = "auto 0",
                    Color = colorTextDisabled,
                    TextAlign = "center",
                },
                ["&-footer"] = new CSSObject
                {
                    BorderTop = $@"{Unit(lineWidth)} {lineType} {colorSplit}",
                },
                ["&-checkbox"] = new CSSObject
                {
                    LineHeight = 1,
                },
            };
        }

        public static CSSObject GenTransferStyle(TransferToken token)
        {
            var antCls = token.AntCls;
            var iconCls = token.IconCls;
            var componentCls = token.ComponentCls;
            var marginXS = token.MarginXS;
            var marginXXS = token.MarginXXS;
            var fontSizeIcon = token.FontSizeIcon;
            var colorBgContainerDisabled = token.ColorBgContainerDisabled;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    Position = "relative",
                    Display = "flex",
                    AlignItems = "stretch",
                    [$@"{componentCls}-disabled"] = new CSSObject
                    {
                        [$@"{componentCls}-list"] = new CSSObject
                        {
                            Background = colorBgContainerDisabled,
                        },
                    },
                    [$@"{componentCls}-list"] = GenTransferListStyle(token),
                    [$@"{componentCls}-operation"] = new CSSObject
                    {
                        Display = "flex",
                        Flex = "none",
                        FlexDirection = "column",
                        AlignSelf = "center",
                        Margin = $@"{Unit(marginXS)}",
                        VerticalAlign = "middle",
                        Gap = marginXXS,
                        [$@"{antCls}-btn {iconCls}"] = new CSSObject
                        {
                            FontSize = fontSizeIcon,
                        },
                    },
                },
            };
        }

        public static CSSObject GenTransferRTLStyle(TransferToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [$@"{componentCls}-rtl"] = new CSSObject
                {
                    Direction = "rtl",
                },
            };
        }

        public static TransferToken PrepareComponentToken(TransferToken token)
        {
            var fontSize = token.FontSize;
            var lineHeight = token.LineHeight;
            var controlHeight = token.ControlHeight;
            var controlHeightLG = token.ControlHeightLG;
            var lineWidth = token.LineWidth;
            var fontHeight = Math.Round(fontSize * lineHeight);
            return new TransferToken
            {
                ListWidth = 180,
                ListHeight = 200,
                ListWidthLG = 250,
                HeaderHeight = controlHeightLG,
                ItemHeight = controlHeight,
                ItemPaddingBlock = (controlHeight - fontHeight) / 2,
                TransferHeaderVerticalPadding = Math.Ceil((controlHeightLG - lineWidth - fontHeight) / 2),
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Transfer", (TransferToken token) =>
            {
                var transferToken = MergeToken(token);
                return new object[]
                {
                    GenTransferStyle(transferToken),
                    GenTransferCustomizeStyle(transferToken),
                    GenTransferStatusStyle(transferToken),
                    GenTransferRTLStyle(transferToken)
                };
            }, prepareComponentToken);
        }
    }
}