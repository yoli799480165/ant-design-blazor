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
    public partial class NotificationStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public double ZIndexPopup { get; set; }
            public string Width { get; set; }
        }

        public class NotificationToken : ComponentToken
        {
            public string AnimationMaxHeight { get; set; }
            public string NotificationBg { get; set; }
            public string NotificationPadding { get; set; }
            public double NotificationPaddingVertical { get; set; }
            public double NotificationPaddingHorizontal { get; set; }
            public string NotificationIconSize { get; set; }
            public string NotificationCloseButtonSize { get; set; }
            public double NotificationMarginBottom { get; set; }
            public double NotificationMarginEdge { get; set; }
            public double NotificationStackLayer { get; set; }
            public string NotificationProgressBg { get; set; }
            public double NotificationProgressHeight { get; set; }
        }

        public static CSSObject GenNoticeStyle(NotificationToken token)
        {
            var iconCls = token.IconCls;
            var componentCls = token.ComponentCls;
            var boxShadow = token.BoxShadow;
            var fontSizeLG = token.FontSizeLG;
            var notificationMarginBottom = token.NotificationMarginBottom;
            var borderRadiusLG = token.BorderRadiusLG;
            var colorSuccess = token.ColorSuccess;
            var colorInfo = token.ColorInfo;
            var colorWarning = token.ColorWarning;
            var colorError = token.ColorError;
            var colorTextHeading = token.ColorTextHeading;
            var notificationBg = token.NotificationBg;
            var notificationPadding = token.NotificationPadding;
            var notificationMarginEdge = token.NotificationMarginEdge;
            var notificationProgressBg = token.NotificationProgressBg;
            var notificationProgressHeight = token.NotificationProgressHeight;
            var fontSize = token.FontSize;
            var lineHeight = token.LineHeight;
            var width = token.Width;
            var notificationIconSize = token.NotificationIconSize;
            var colorText = token.ColorText;
            var noticeCls = $@"{componentCls}-notice";
            return new CSSObject
            {
                Position = "relative",
                MarginBottom = notificationMarginBottom,
                MarginInlineStart = "auto",
                Background = notificationBg,
                BorderRadius = borderRadiusLG,
                [noticeCls] = new CSSObject
                {
                    Padding = notificationPadding,
                    MaxWidth = $@"{Unit(token.Calc(notificationMarginEdge).Mul(2).Equal())})",
                    Overflow = "hidden",
                    WordWrap = "break-word",
                },
                [$@"{noticeCls}-message"] = new CSSObject
                {
                    MarginBottom = token.MarginXS,
                    Color = colorTextHeading,
                    FontSize = fontSizeLG,
                    LineHeight = token.LineHeightLG,
                },
                [$@"{noticeCls}-description"] = new CSSObject
                {
                    Color = colorText,
                },
                [$@"{noticeCls}-closable {noticeCls}-message"] = new CSSObject
                {
                    PaddingInlineEnd = token.PaddingLG,
                },
                [$@"{noticeCls}-with-icon {noticeCls}-message"] = new CSSObject
                {
                    MarginBottom = token.MarginXS,
                    MarginInlineStart = token.Calc(token.MarginSM).Add(notificationIconSize).Equal(),
                    FontSize = fontSizeLG,
                },
                [$@"{noticeCls}-with-icon {noticeCls}-description"] = new CSSObject
                {
                    MarginInlineStart = token.Calc(token.MarginSM).Add(notificationIconSize).Equal(),
                },
                [$@"{noticeCls}-icon"] = new CSSObject
                {
                    Position = "absolute",
                    FontSize = notificationIconSize,
                    LineHeight = 1,
                    [$@"{iconCls}"] = new CSSObject
                    {
                        Color = colorSuccess,
                    },
                    [$@"{iconCls}"] = new CSSObject
                    {
                        Color = colorInfo,
                    },
                    [$@"{iconCls}"] = new CSSObject
                    {
                        Color = colorWarning,
                    },
                    [$@"{iconCls}"] = new CSSObject
                    {
                        Color = colorError,
                    },
                },
                [$@"{noticeCls}-close"] = new CSSObject
                {
                    Position = "absolute",
                    Top = token.NotificationPaddingVertical,
                    InsetInlineEnd = token.NotificationPaddingHorizontal,
                    Color = token.ColorIcon,
                    Outline = "none",
                    Width = token.NotificationCloseButtonSize,
                    Height = token.NotificationCloseButtonSize,
                    BorderRadius = token.BorderRadiusSM,
                    Transition = $@"{token.MotionDurationMid}, color {token.MotionDurationMid}",
                    Display = "flex",
                    AlignItems = "center",
                    JustifyContent = "center",
                    ["&:hover"] = new CSSObject
                    {
                        Color = token.ColorIconHover,
                        BackgroundColor = token.ColorBgTextHover,
                    },
                    ["&:active"] = new CSSObject
                    {
                        BackgroundColor = token.ColorBgTextActive,
                    },
                    ["..."] = GenFocusStyle(token),
                },
                [$@"{noticeCls}-progress"] = new CSSObject
                {
                    Position = "absolute",
                    Display = "block",
                    Appearance = "none",
                    WebkitAppearance = "none",
                    InlineSize = $@"{Unit(borderRadiusLG)} * 2)",
                    Left = new CSSObject
                    {
                        _skip_check_ = true,
                        Value = borderRadiusLG,
                    },
                    Right = new CSSObject
                    {
                        _skip_check_ = true,
                        Value = borderRadiusLG,
                    },
                    Bottom = 0,
                    BlockSize = notificationProgressHeight,
                    Border = 0,
                    ["&, &::-webkit-progress-bar"] = new CSSObject
                    {
                        BorderRadius = borderRadiusLG,
                        BackgroundColor = "rgba(0, 0, 0, 0.04)",
                    },
                    ["&::-moz-progress-bar"] = new CSSObject
                    {
                        Background = notificationProgressBg,
                    },
                    ["&::-webkit-progress-value"] = new CSSObject
                    {
                        BorderRadius = borderRadiusLG,
                        Background = notificationProgressBg,
                    },
                },
                [$@"{noticeCls}-btn"] = new CSSObject
                {
                    Float = "right",
                    MarginTop = token.MarginSM,
                },
            };
        }

        public static CSSObject GenNotificationStyle(NotificationToken token)
        {
            var componentCls = token.ComponentCls;
            var notificationMarginBottom = token.NotificationMarginBottom;
            var notificationMarginEdge = token.NotificationMarginEdge;
            var motionDurationMid = token.MotionDurationMid;
            var motionEaseInOut = token.MotionEaseInOut;
            var noticeCls = $@"{componentCls}-notice";
            var fadeOut = new Keyframes("antNotificationFadeOut", new object { ["0%"] = new object { MaxHeight = token.AnimationMaxHeight, MarginBottom = notificationMarginBottom, }, ["100%"] = new object { MaxHeight = 0, MarginBottom = 0, PaddingTop = 0, PaddingBottom = 0, Opacity = 0, }, });
            return new object[]
            {
                new object
                {
                    [componentCls] = new object
                    {
                        ["..."] = ResetComponent(token),
                        Position = "fixed",
                        ZIndex = token.ZIndexPopup,
                        MarginRight = new object
                        {
                            Value = notificationMarginEdge,
                            _skip_check_ = true,
                        },
                        [$@"{componentCls}-hook-holder"] = new object
                        {
                            Position = "relative",
                        },
                        [$@"{componentCls}-fade-appear-prepare"] = new object
                        {
                            Opacity = "0 !important",
                        },
                        [$@"{componentCls}-fade-enter, {componentCls}-fade-appear"] = new object
                        {
                            AnimationDuration = token.MotionDurationMid,
                            AnimationTimingFunction = motionEaseInOut,
                            AnimationFillMode = "both",
                            Opacity = 0,
                            AnimationPlayState = "paused",
                        },
                        [$@"{componentCls}-fade-leave"] = new object
                        {
                            AnimationTimingFunction = motionEaseInOut,
                            AnimationFillMode = "both",
                            AnimationDuration = motionDurationMid,
                            AnimationPlayState = "paused",
                        },
                        [$@"{componentCls}-fade-enter{componentCls}-fade-enter-active, {componentCls}-fade-appear{componentCls}-fade-appear-active"] = new object
                        {
                            AnimationPlayState = "running",
                        },
                        [$@"{componentCls}-fade-leave{componentCls}-fade-leave-active"] = new object
                        {
                            AnimationName = fadeOut,
                            AnimationPlayState = "running",
                        },
                        ["&-rtl"] = new object
                        {
                            Direction = "rtl",
                            [$@"{noticeCls}-btn"] = new object
                            {
                                Float = "left",
                            },
                        },
                    },
                },
                new object
                {
                    [componentCls] = new object
                    {
                        [$@"{noticeCls}-wrapper"] = new object
                        {
                            ["..."] = GenNoticeStyle(token),
                        },
                    },
                }
            };
        }

        public static NotificationToken PrepareComponentToken(AliasToken token)
        {
            return new NotificationToken
            {
                ZIndexPopup = token.ZIndexPopupBase + CONTAINER_MAX_OFFSET + 50,
                Width = 384,
            };
        }

        public static object PrepareNotificationToken(NotificationToken token)
        {
            var notificationPaddingVertical = token.PaddingMD;
            var notificationPaddingHorizontal = token.PaddingLG;
            var notificationToken = MergeToken(token, new object { NotificationBg = token.ColorBgElevated, NotificationIconSize = token.Calc(token.FontSizeLG).Mul(token.LineHeightLG).Equal(), NotificationCloseButtonSize = token.Calc(token.ControlHeightLG).Mul(0.55).Equal(), NotificationMarginBottom = token.Margin, NotificationPadding = $@"{Unit(token.PaddingMD)} {Unit(token.PaddingContentHorizontalLG)}", NotificationMarginEdge = token.MarginLG, AnimationMaxHeight = 150, NotificationStackLayer = 3, NotificationProgressHeight = 2, NotificationProgressBg = $@"{token.ColorPrimaryBorderHover}, {token.ColorPrimary})", });
            return notificationToken;
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Notification", (NotificationToken token) =>
            {
                var notificationToken = PrepareNotificationToken(token);
                return new object[]
                {
                    GenNotificationStyle(notificationToken),
                    GenNotificationPlacementStyle(notificationToken),
                    GenStackStyle(notificationToken)
                };
            }, PrepareComponentToken);
        }
    }
}