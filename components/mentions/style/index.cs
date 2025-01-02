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
    public partial class MentionsStyle
    {
        public class ComponentToken : TokenWithCommonCls : SharedComponentToken
        {
            public double ZIndexPopup { get; set; }
            public string DropdownHeight { get; set; }
            public string ControlItemWidth { get; set; }
        }

        public class MentionsToken : ComponentToken, SharedInputToken
        {
            public string ItemPaddingVertical { get; set; }
        }

        public static CSSObject GenMentionsStyle(MentionsToken token)
        {
            var componentCls = token.ComponentCls;
            var colorTextDisabled = token.ColorTextDisabled;
            var controlItemBgHover = token.ControlItemBgHover;
            var controlPaddingHorizontal = token.ControlPaddingHorizontal;
            var colorText = token.ColorText;
            var motionDurationSlow = token.MotionDurationSlow;
            var lineHeight = token.LineHeight;
            var controlHeight = token.ControlHeight;
            var paddingInline = token.PaddingInline;
            var paddingBlock = token.PaddingBlock;
            var fontSize = token.FontSize;
            var fontSizeIcon = token.FontSizeIcon;
            var colorTextTertiary = token.ColorTextTertiary;
            var colorTextQuaternary = token.ColorTextQuaternary;
            var colorBgElevated = token.ColorBgElevated;
            var paddingXXS = token.PaddingXXS;
            var paddingLG = token.PaddingLG;
            var borderRadius = token.BorderRadius;
            var borderRadiusLG = token.BorderRadiusLG;
            var boxShadowSecondary = token.BoxShadowSecondary;
            var itemPaddingVertical = token.ItemPaddingVertical;
            var calc = token.Calc;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    ["..."] = GenBasicInputStyle(token),
                    Position = "relative",
                    Display = "inline-block",
                    Height = "auto",
                    Padding = 0,
                    Overflow = "hidden",
                    WhiteSpace = "pre-wrap",
                    VerticalAlign = "bottom",
                    ["..."] = GenOutlinedStyle(token),
                    ["..."] = GenFilledStyle(token),
                    ["..."] = GenBorderlessStyle(token),
                    ["&-affix-wrapper"] = new CSSObject
                    {
                        ["..."] = GenBasicInputStyle(token),
                        Display = "inline-flex",
                        Padding = 0,
                        ["&::before"] = new CSSObject
                        {
                            Display = "inline-block",
                            Width = 0,
                            Visibility = "hidden",
                            Content = "\"\\a0\"",
                        },
                        [$@"{componentCls}-suffix"] = new CSSObject
                        {
                            Position = "absolute",
                            Top = 0,
                            InsetInlineEnd = paddingInline,
                            Bottom = 0,
                            ZIndex = 1,
                            Display = "inline-flex",
                            AlignItems = "center",
                            Margin = "auto",
                        },
                        [$@"{componentCls}-suffix) > {componentCls} > textarea"] = new CSSObject
                        {
                            PaddingInlineEnd = paddingLG,
                        },
                        [$@"{componentCls}-clear-icon"] = new CSSObject
                        {
                            Position = "absolute",
                            InsetInlineEnd = 0,
                            InsetBlockStart = calc(fontSize).mul(lineHeight).mul(0.5).add(paddingBlock).Equal(),
                            Transform = "translateY(-50%)",
                            Margin = 0,
                            Color = colorTextQuaternary,
                            FontSize = fontSizeIcon,
                            VerticalAlign = -1,
                            Cursor = "pointer",
                            Transition = $@"{motionDurationSlow}",
                            ["&:hover"] = new CSSObject
                            {
                                Color = colorTextTertiary,
                            },
                            ["&:active"] = new CSSObject
                            {
                                Color = colorText,
                            },
                            ["&-hidden"] = new CSSObject
                            {
                                Visibility = "hidden",
                            },
                        },
                    },
                    ["&-disabled"] = new CSSObject
                    {
                        ["> textarea"] = new CSSObject
                        {
                            ["..."] = GenDisabledStyle(token),
                        },
                    },
                    [$@"{componentCls}"] = new CSSObject
                    {
                        [$@"{componentCls}-measure"] = new CSSObject
                        {
                            Color = colorText,
                            BoxSizing = "border-box",
                            MinHeight = token.calc(controlHeight).Sub(2),
                            Margin = 0,
                            Padding = $@"{Unit(paddingBlock)} {Unit(paddingInline)}",
                            Overflow = "inherit",
                            OverflowX = "hidden",
                            OverflowY = "auto",
                            FontWeight = "inherit",
                            FontSize = "inherit",
                            FontFamily = "inherit",
                            FontStyle = "inherit",
                            FontVariant = "inherit",
                            FontSizeAdjust = "inherit",
                            FontStretch = "inherit",
                            LineHeight = "inherit",
                            Direction = "inherit",
                            LetterSpacing = "inherit",
                            WhiteSpace = "inherit",
                            TextAlign = "inherit",
                            VerticalAlign = "top",
                            WordWrap = "break-word",
                            WordBreak = "inherit",
                            TabSize = "inherit",
                        },
                        ["> textarea"] = new CSSObject
                        {
                            Width = "100%",
                            Border = "none",
                            Outline = "none",
                            Resize = "none",
                            BackgroundColor = "transparent",
                            ["..."] = GenPlaceholderStyle(token.ColorTextPlaceholder),
                        },
                        [$@"{componentCls}-measure"] = new CSSObject
                        {
                            Position = "absolute",
                            Top = 0,
                            InsetInlineEnd = 0,
                            Bottom = 0,
                            InsetInlineStart = 0,
                            ZIndex = -1,
                            Color = "transparent",
                            PointerEvents = "none",
                            ["> span"] = new CSSObject
                            {
                                Display = "inline-block",
                                MinHeight = "1em",
                            },
                        },
                    },
                    ["&-dropdown"] = new CSSObject
                    {
                        ["..."] = ResetComponent(token),
                        Position = "absolute",
                        Top = -9999,
                        InsetInlineStart = -9999,
                        ZIndex = token.ZIndexPopup,
                        BoxSizing = "border-box",
                        FontVariant = "initial",
                        Padding = paddingXXS,
                        BackgroundColor = colorBgElevated,
                        BorderRadius = borderRadiusLG,
                        Outline = "none",
                        BoxShadow = boxShadowSecondary,
                        ["&-hidden"] = new CSSObject
                        {
                            Display = "none",
                        },
                        [$@"{componentCls}-dropdown-menu"] = new CSSObject
                        {
                            MaxHeight = token.DropdownHeight,
                            Margin = 0,
                            PaddingInlineStart = 0,
                            Overflow = "auto",
                            ListStyle = "none",
                            Outline = "none",
                            ["&-item"] = new CSSObject
                            {
                                ["..."] = textEllipsis,
                                Position = "relative",
                                Display = "block",
                                MinWidth = token.ControlItemWidth,
                                Padding = $@"{Unit(itemPaddingVertical)} {Unit(controlPaddingHorizontal)}",
                                Color = colorText,
                                FontWeight = "normal",
                                Cursor = "pointer",
                                Transition = $@"{motionDurationSlow} ease",
                                ["&:hover"] = new CSSObject
                                {
                                    BackgroundColor = controlItemBgHover,
                                },
                                ["&-disabled"] = new CSSObject
                                {
                                    Color = colorTextDisabled,
                                    Cursor = "not-allowed",
                                    ["&:hover"] = new CSSObject
                                    {
                                        Color = colorTextDisabled,
                                        BackgroundColor = controlItemBgHover,
                                        Cursor = "not-allowed",
                                    },
                                },
                                ["&-selected"] = new CSSObject
                                {
                                    Color = colorText,
                                    FontWeight = token.FontWeightStrong,
                                    BackgroundColor = controlItemBgHover,
                                },
                                ["&-active"] = new CSSObject
                                {
                                    BackgroundColor = controlItemBgHover,
                                },
                            },
                        },
                    },
                },
            };
        }

        public static MentionsToken PrepareComponentToken(MentionsToken token)
        {
            return new MentionsToken
            {
                ["..."] = InitComponentToken(token),
                DropdownHeight = 250,
                ControlItemWidth = 100,
                ZIndexPopup = token.ZIndexPopupBase + 50,
                ItemPaddingVertical = (token.ControlHeight - token.FontHeight) / 2,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Mentions", (MentionsToken token) =>
            {
                var mentionsToken = MergeToken(token, InitInputToken(token));
                return new object[]
                {
                    GenMentionsStyle(mentionsToken)
                };
            }, prepareComponentToken);
        }
    }
}