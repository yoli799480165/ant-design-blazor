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
    public partial class ImageStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public double ZIndexPopup { get; set; }
            public double PreviewOperationSize { get; set; }
            public string PreviewOperationColor { get; set; }
            public string PreviewOperationHoverColor { get; set; }
            public string PreviewOperationColorDisabled { get; set; }
        }

        public class ImageToken : ComponentToken
        {
            public string PreviewCls { get; set; }
            public string ModalMaskBg { get; set; }
            public double ImagePreviewSwitchSize { get; set; }
        }

        public static CSSObject GenBoxStyle(PositionType position)
        {
            return new CSSObject
            {
                Position = position ?? "absolute",
                Inset = 0,
            };
        }

        public static CSSObject GenImageMaskStyle(ImageToken token)
        {
            var iconCls = token.IconCls;
            var motionDurationSlow = token.MotionDurationSlow;
            var paddingXXS = token.PaddingXXS;
            var marginXXS = token.MarginXXS;
            var prefixCls = token.PrefixCls;
            var colorTextLightSolid = token.ColorTextLightSolid;
            return new CSSObject
            {
                Position = "absolute",
                Inset = 0,
                Display = "flex",
                AlignItems = "center",
                JustifyContent = "center",
                Color = colorTextLightSolid,
                Background = new FastColor("#000").SetA(0.5).ToRgbString(),
                Cursor = "pointer",
                Opacity = 0,
                Transition = $@"{motionDurationSlow}",
                [$@"{prefixCls}-mask-info"] = new CSSObject
                {
                    ["..."] = textEllipsis,
                    Padding = $@"{Unit(paddingXXS)}",
                    [iconCls] = new CSSObject
                    {
                        MarginInlineEnd = marginXXS,
                        ["svg"] = new CSSObject
                        {
                            VerticalAlign = "baseline",
                        },
                    },
                },
            };
        }

        public static CSSObject GenPreviewOperationsStyle(ImageToken token)
        {
            var previewCls = token.PreviewCls;
            var modalMaskBg = token.ModalMaskBg;
            var paddingSM = token.PaddingSM;
            var marginXL = token.MarginXL;
            var margin = token.Margin;
            var paddingLG = token.PaddingLG;
            var previewOperationColorDisabled = token.PreviewOperationColorDisabled;
            var previewOperationHoverColor = token.PreviewOperationHoverColor;
            var motionDurationSlow = token.MotionDurationSlow;
            var iconCls = token.IconCls;
            var colorTextLightSolid = token.ColorTextLightSolid;
            var operationBg = new FastColor(modalMaskBg).SetA(0.1);
            var operationBgHover = operationBg.Clone().SetA(0.2);
            return new CSSObject
            {
                [$@"{previewCls}-footer"] = new CSSObject
                {
                    Position = "fixed",
                    Bottom = marginXL,
                    Left = new CSSObject
                    {
                        _skip_check_ = true,
                        Value = "50%",
                    },
                    Display = "flex",
                    FlexDirection = "column",
                    AlignItems = "center",
                    Color = token.PreviewOperationColor,
                    Transform = "translateX(-50%)",
                },
                [$@"{previewCls}-progress"] = new CSSObject
                {
                    MarginBottom = margin,
                },
                [$@"{previewCls}-close"] = new CSSObject
                {
                    Position = "fixed",
                    Top = marginXL,
                    Right = new CSSObject
                    {
                        _skip_check_ = true,
                        Value = marginXL,
                    },
                    Display = "flex",
                    Color = colorTextLightSolid,
                    BackgroundColor = operationBg.ToRgbString(),
                    BorderRadius = "50%",
                    Padding = paddingSM,
                    Outline = 0,
                    Border = 0,
                    Cursor = "pointer",
                    Transition = $@"{motionDurationSlow}",
                    ["&:hover"] = new CSSObject
                    {
                        BackgroundColor = operationBgHover.ToRgbString(),
                    },
                    [$@"{iconCls}"] = new CSSObject
                    {
                        FontSize = token.PreviewOperationSize,
                    },
                },
                [$@"{previewCls}-operations"] = new CSSObject
                {
                    Display = "flex",
                    AlignItems = "center",
                    Padding = $@"{Unit(paddingLG)}",
                    BackgroundColor = operationBg.ToRgbString(),
                    BorderRadius = 100,
                    ["&-operation"] = new CSSObject
                    {
                        MarginInlineStart = paddingSM,
                        Padding = paddingSM,
                        Cursor = "pointer",
                        Transition = $@"{motionDurationSlow}",
                        UserSelect = "none",
                        [$@"{previewCls}-operations-operation-disabled):hover > {iconCls}"] = new CSSObject
                        {
                            Color = previewOperationHoverColor,
                        },
                        ["&-disabled"] = new CSSObject
                        {
                            Color = previewOperationColorDisabled,
                            Cursor = "not-allowed",
                        },
                        ["&:first-of-type"] = new CSSObject
                        {
                            MarginInlineStart = 0,
                        },
                        [$@"{iconCls}"] = new CSSObject
                        {
                            FontSize = token.PreviewOperationSize,
                        },
                    },
                },
            };
        }

        public static CSSObject GenPreviewSwitchStyle(ImageToken token)
        {
            var modalMaskBg = token.ModalMaskBg;
            var iconCls = token.IconCls;
            var previewOperationColorDisabled = token.PreviewOperationColorDisabled;
            var previewCls = token.PreviewCls;
            var zIndexPopup = token.ZIndexPopup;
            var motionDurationSlow = token.MotionDurationSlow;
            var operationBg = new FastColor(modalMaskBg).SetA(0.1);
            var operationBgHover = operationBg.Clone().SetA(0.2);
            return new CSSObject
            {
                [$@"{previewCls}-switch-left, {previewCls}-switch-right"] = new CSSObject
                {
                    Position = "fixed",
                    InsetBlockStart = "50%",
                    ZIndex = token.Calc(zIndexPopup).Add(1).Equal(),
                    Display = "flex",
                    AlignItems = "center",
                    JustifyContent = "center",
                    Width = token.ImagePreviewSwitchSize,
                    Height = token.ImagePreviewSwitchSize,
                    MarginTop = token.Calc(token.ImagePreviewSwitchSize).Mul(-1).Div(2).Equal(),
                    Color = token.PreviewOperationColor,
                    Background = operationBg.ToRgbString(),
                    BorderRadius = "50%",
                    Transform = "translateY(-50%)",
                    Cursor = "pointer",
                    Transition = $@"{motionDurationSlow}",
                    UserSelect = "none",
                    ["&:hover"] = new CSSObject
                    {
                        Background = operationBgHover.ToRgbString(),
                    },
                    ["&-disabled"] = new CSSObject
                    {
                        ["&, &:hover"] = new CSSObject
                        {
                            Color = previewOperationColorDisabled,
                            Background = "transparent",
                            Cursor = "not-allowed",
                            [$@"{iconCls}"] = new CSSObject
                            {
                                Cursor = "not-allowed",
                            },
                        },
                    },
                    [$@"{iconCls}"] = new CSSObject
                    {
                        FontSize = token.PreviewOperationSize,
                    },
                },
                [$@"{previewCls}-switch-left"] = new CSSObject
                {
                    InsetInlineStart = token.MarginSM,
                },
                [$@"{previewCls}-switch-right"] = new CSSObject
                {
                    InsetInlineEnd = token.MarginSM,
                },
            };
        }

        public static CSSObject GenImagePreviewStyle(ImageToken token)
        {
            var motionEaseOut = token.MotionEaseOut;
            var previewCls = token.PreviewCls;
            var motionDurationSlow = token.MotionDurationSlow;
            var componentCls = token.ComponentCls;
            return new object[]
            {
                new object
                {
                    [$@"{componentCls}-preview-root"] = new object
                    {
                        [previewCls] = new object
                        {
                            Height = "100%",
                            TextAlign = "center",
                            PointerEvents = "none",
                        },
                        [$@"{previewCls}-body"] = new object
                        {
                            ["..."] = GenBoxStyle(),
                            Overflow = "hidden",
                        },
                        [$@"{previewCls}-img"] = new object
                        {
                            MaxWidth = "100%",
                            MaxHeight = "70%",
                            VerticalAlign = "middle",
                            Transform = "scale3d(1, 1, 1)",
                            Cursor = "grab",
                            Transition = $@"{motionDurationSlow} {motionEaseOut} 0s",
                            UserSelect = "none",
                            ["&-wrapper"] = new object
                            {
                                ["..."] = GenBoxStyle(),
                                Transition = $@"{motionDurationSlow} {motionEaseOut} 0s",
                                Display = "flex",
                                JustifyContent = "center",
                                AlignItems = "center",
                                ["& > *"] = new object
                                {
                                    PointerEvents = "auto",
                                },
                                ["&::before"] = new object
                                {
                                    Display = "inline-block",
                                    Width = 1,
                                    Height = "50%",
                                    MarginInlineEnd = -1,
                                    Content = "\"\"",
                                },
                            },
                        },
                        [$@"{previewCls}-moving"] = new object
                        {
                            [$@"{previewCls}-preview-img"] = new object
                            {
                                Cursor = "grabbing",
                                ["&-wrapper"] = new object
                                {
                                    TransitionDuration = "0s",
                                },
                            },
                        },
                    },
                },
                new object
                {
                    [$@"{componentCls}-preview-root"] = new object
                    {
                        [$@"{previewCls}-wrap"] = new object
                        {
                            ZIndex = token.ZIndexPopup,
                        },
                    },
                },
                new object
                {
                    [$@"{componentCls}-preview-operations-wrapper"] = new object
                    {
                        Position = "fixed",
                        ZIndex = token.Calc(token.ZIndexPopup).Add(1).Equal(),
                    },
                    ["&"] = new object[]
                    {
                        GenPreviewOperationsStyle(token),
                        GenPreviewSwitchStyle(token)
                    },
                }
            };
        }

        public static CSSObject GenImageStyle(ImageToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    Position = "relative",
                    Display = "inline-block",
                    [$@"{componentCls}-img"] = new CSSObject
                    {
                        Width = "100%",
                        Height = "auto",
                        VerticalAlign = "middle",
                    },
                    [$@"{componentCls}-img-placeholder"] = new CSSObject
                    {
                        BackgroundColor = token.ColorBgContainerDisabled,
                        BackgroundImage = "url('data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMTYiIGhlaWdodD0iMTYiIHZpZXdCb3g9IjAgMCAxNiAxNiIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj48cGF0aCBkPSJNMTQuNSAyLjVoLTEzQS41LjUgMCAwIDAgMSAzdjEwYS41LjUgMCAwIDAgLjUuNWgxM2EuNS41IDAgMCAwIC41LS41VjNhLjUuNSAwIDAgMC0uNS0uNXpNNS4yODEgNC43NWExIDEgMCAwIDEgMCAyIDEgMSAwIDAgMSAwLTJ6bTguMDMgNi44M2EuMTI3LjEyNyAwIDAgMS0uMDgxLjAzSDIuNzY5YS4xMjUuMTI1IDAgMCAxLS4wOTYtLjIwN2wyLjY2MS0zLjE1NmEuMTI2LjEyNiAwIDAgMSAuMTc3LS4wMTZsLjAxNi4wMTZMNy4wOCAxMC4wOWwyLjQ3LTIuOTNhLjEyNi4xMjYgMCAwIDEgLjE3Ny0uMDE2bC4wMTUuMDE2IDMuNTg4IDQuMjQ0YS4xMjcuMTI3IDAgMCAxLS4wMi4xNzV6IiBmaWxsPSIjOEM4QzhDIiBmaWxsLXJ1bGU9Im5vbnplcm8iLz48L3N2Zz4=')",
                        BackgroundRepeat = "no-repeat",
                        BackgroundPosition = "center center",
                        BackgroundSize = "30%",
                    },
                    [$@"{componentCls}-mask"] = new CSSObject
                    {
                        ["..."] = GenImageMaskStyle(token),
                    },
                    [$@"{componentCls}-mask:hover"] = new CSSObject
                    {
                        Opacity = 1,
                    },
                    [$@"{componentCls}-placeholder"] = new CSSObject
                    {
                        ["..."] = GenBoxStyle(),
                    },
                },
            };
        }

        public static object GenPreviewMotion(ImageToken token)
        {
            var previewCls = token.PreviewCls;
            return new object
            {
                [$@"{previewCls}-root"] = InitZoomMotion(token, "zoom"),
                ["&"] = InitFadeMotion(token, true),
            };
        }

        public static ImageToken PrepareComponentToken(ImageToken token)
        {
            return new ImageToken
            {
                ZIndexPopup = token.ZIndexPopupBase + 80,
                PreviewOperationColor = new FastColor(token.ColorTextLightSolid).SetA(0.65).ToRgbString(),
                PreviewOperationHoverColor = new FastColor(token.ColorTextLightSolid).SetA(0.85).ToRgbString(),
                PreviewOperationColorDisabled = new FastColor(token.ColorTextLightSolid).SetA(0.25).ToRgbString(),
                PreviewOperationSize = token.FontSizeIcon * 1.5,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Image", (ImageToken token) =>
            {
                var previewCls = $@"{token.ComponentCls}-preview";
                var imageToken = MergeToken(token, new object { ModalMaskBg = new FastColor("#000").SetA(0.45).ToRgbString(), ImagePreviewSwitchSize = token.ControlHeightLG, });
                return new object[]
                {
                    GenImageStyle(imageToken),
                    GenImagePreviewStyle(imageToken),
                    GenModalMaskStyle(MergeToken(imageToken, new object { ComponentCls = previewCls, })),
                    GenPreviewMotion(imageToken)
                };
            }, PrepareComponentToken);
        }
    }
}