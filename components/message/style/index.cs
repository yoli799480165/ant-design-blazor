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
    public partial class MessageStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public double ZIndexPopup { get; set; }
            public string ContentBg { get; set; }
            public string ContentPadding { get; set; }
        }

        public class MessageToken : ComponentToken
        {
            public double Height { get; set; }
        }

        public static CSSObject GenMessageStyle(MessageToken token)
        {
            var componentCls = token.ComponentCls;
            var iconCls = token.IconCls;
            var boxShadow = token.BoxShadow;
            var colorText = token.ColorText;
            var colorSuccess = token.ColorSuccess;
            var colorError = token.ColorError;
            var colorWarning = token.ColorWarning;
            var colorInfo = token.ColorInfo;
            var fontSizeLG = token.FontSizeLG;
            var motionEaseInOutCirc = token.MotionEaseInOutCirc;
            var motionDurationSlow = token.MotionDurationSlow;
            var marginXS = token.MarginXS;
            var paddingXS = token.PaddingXS;
            var borderRadiusLG = token.BorderRadiusLG;
            var zIndexPopup = token.ZIndexPopup;
            var contentPadding = token.ContentPadding;
            var contentBg = token.ContentBg;
            var noticeCls = $@"{componentCls}-notice";
            var messageMoveIn = new Keyframes("MessageMoveIn", new object { ["0%"] = new object { Padding = 0, Transform = "translateY(-100%)", Opacity = 0, }, ["100%"] = new object { Padding = paddingXS, Transform = "translateY(0)", Opacity = 1, }, });
            var messageMoveOut = new Keyframes("MessageMoveOut", new object { ["0%"] = new object { MaxHeight = token.Height, Padding = paddingXS, Opacity = 1, }, ["100%"] = new object { MaxHeight = 0, Padding = 0, Opacity = 0, }, });
            var noticeStyle = new CSSObject
            {
                Padding = paddingXS,
                TextAlign = "center",
                [$@"{componentCls}-custom-content"] = new CSSObject
                {
                    Display = "flex",
                    AlignItems = "center",
                },
                [$@"{componentCls}-custom-content > {iconCls}"] = new CSSObject
                {
                    MarginInlineEnd = marginXS,
                    FontSize = fontSizeLG,
                },
                [$@"{noticeCls}-content"] = new CSSObject
                {
                    Display = "inline-block",
                    Padding = contentPadding,
                    Background = contentBg,
                    BorderRadius = borderRadiusLG,
                    PointerEvents = "all",
                },
                [$@"{componentCls}-success > {iconCls}"] = new CSSObject
                {
                    Color = colorSuccess,
                },
                [$@"{componentCls}-error > {iconCls}"] = new CSSObject
                {
                    Color = colorError,
                },
                [$@"{componentCls}-warning > {iconCls}"] = new CSSObject
                {
                    Color = colorWarning,
                },
                [$@"{componentCls}-info > {iconCls},
      {componentCls}-loading > {iconCls}"] = new CSSObject
                {
                    Color = colorInfo,
                },
            };
            return new object[]
            {
                new object
                {
                    [componentCls] = new object
                    {
                        ["..."] = ResetComponent(token),
                        Color = colorText,
                        Position = "fixed",
                        Top = marginXS,
                        Width = "100%",
                        PointerEvents = "none",
                        ZIndex = zIndexPopup,
                        [$@"{componentCls}-move-up"] = new object
                        {
                            AnimationFillMode = "forwards",
                        },
                        [$@"{componentCls}-move-up-appear,
        {componentCls}-move-up-enter
      "] = new object
                        {
                            AnimationName = messageMoveIn,
                            AnimationDuration = motionDurationSlow,
                            AnimationPlayState = "paused",
                            AnimationTimingFunction = motionEaseInOutCirc,
                        },
                        [$@"{componentCls}-move-up-appear{componentCls}-move-up-appear-active,
        {componentCls}-move-up-enter{componentCls}-move-up-enter-active
      "] = new object
                        {
                            AnimationPlayState = "running",
                        },
                        [$@"{componentCls}-move-up-leave"] = new object
                        {
                            AnimationName = messageMoveOut,
                            AnimationDuration = motionDurationSlow,
                            AnimationPlayState = "paused",
                            AnimationTimingFunction = motionEaseInOutCirc,
                        },
                        [$@"{componentCls}-move-up-leave{componentCls}-move-up-leave-active"] = new object
                        {
                            AnimationPlayState = "running",
                        },
                        ["&-rtl"] = new object
                        {
                            Direction = "rtl",
                            ["span"] = new object
                            {
                                Direction = "rtl",
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
                            ["..."] = noticeStyle,
                        },
                    },
                },
                new object
                {
                    [$@"{componentCls}-notice-pure-panel"] = new object
                    {
                        ["..."] = noticeStyle,
                        Padding = 0,
                        TextAlign = "start",
                    },
                }
            };
        }

        public static MessageToken PrepareComponentToken(MessageToken token)
        {
            return new MessageToken
            {
                ZIndexPopup = token.ZIndexPopupBase + CONTAINER_MAX_OFFSET + 10,
                ContentBg = token.ColorBgElevated,
                ContentPadding = $@"{(token.ControlHeightLG - token.FontSize * token.LineHeight) / 2}px {token.PaddingSM}px",
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Message", (MessageToken token) =>
            {
                var combinedToken = MergeToken(token, new object { Height = 150, });
                return new object[]
                {
                    GenMessageStyle(combinedToken)
                };
            }, prepareComponentToken);
        }
    }
}