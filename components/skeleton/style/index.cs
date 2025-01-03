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
    public partial class SkeletonStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public string Color { get; set; }
            public string ColorGradientEnd { get; set; }
            public string GradientFromColor { get; set; }
            public string GradientToColor { get; set; }
            public string TitleHeight { get; set; }
            public double BlockRadius { get; set; }
            public double ParagraphMarginTop { get; set; }
            public double ParagraphLiHeight { get; set; }
        }

        public object skeletonClsLoading = new Keyframes("ant-skeleton-loading", new object { ["0%"] = new object { BackgroundPosition = "100% 50%", }, ["100%"] = new object { BackgroundPosition = "0 50%", }, });
        public class SkeletonToken : ComponentToken
        {
            public string SkeletonAvatarCls { get; set; }
            public string SkeletonTitleCls { get; set; }
            public string SkeletonParagraphCls { get; set; }
            public string SkeletonButtonCls { get; set; }
            public string SkeletonInputCls { get; set; }
            public string SkeletonImageCls { get; set; }
            public string ImageSizeBase { get; set; }
            public string SkeletonLoadingBackground { get; set; }
            public string SkeletonLoadingMotionDuration { get; set; }
            public double BorderRadius { get; set; }
        }

        public static CSSObject GenSkeletonElementCommonSize(number | string size)
        {
            return new CSSObject
            {
                Height = size,
                LineHeight = Unit(size),
            };
        }

        public static CSSObject GenSkeletonElementAvatarSize(number | string size)
        {
            return new CSSObject
            {
                Width = size,
                ["..."] = GenSkeletonElementCommonSize(size),
            };
        }

        public static CSSObject GenSkeletonColor(SkeletonToken token)
        {
            return new CSSObject
            {
                Background = token.SkeletonLoadingBackground,
                BackgroundSize = "400% 100%",
                AnimationName = skeletonClsLoading,
                AnimationDuration = token.SkeletonLoadingMotionDuration,
                AnimationTimingFunction = "ease",
                AnimationIterationCount = "infinite",
            };
        }

        public static CSSObject GenSkeletonElementInputSize(number size, CSSUtil['calc'] calc)
        {
            return new CSSObject
            {
                Width = Calc(size).Mul(5).Equal(),
                MinWidth = Calc(size).Mul(5).Equal(),
                ["..."] = GenSkeletonElementCommonSize(size),
            };
        }

        public static CSSObject GenSkeletonElementAvatar(SkeletonToken token)
        {
            var skeletonAvatarCls = token.SkeletonAvatarCls;
            var gradientFromColor = token.GradientFromColor;
            var controlHeight = token.ControlHeight;
            var controlHeightLG = token.ControlHeightLG;
            var controlHeightSM = token.ControlHeightSM;
            return new CSSObject
            {
                [skeletonAvatarCls] = new CSSObject
                {
                    Display = "inline-block",
                    VerticalAlign = "top",
                    Background = gradientFromColor,
                    ["..."] = GenSkeletonElementAvatarSize(controlHeight),
                },
                [$@"{skeletonAvatarCls}{skeletonAvatarCls}-circle"] = new CSSObject
                {
                    BorderRadius = "50%",
                },
                [$@"{skeletonAvatarCls}{skeletonAvatarCls}-lg"] = new CSSObject
                {
                    ["..."] = GenSkeletonElementAvatarSize(controlHeightLG),
                },
                [$@"{skeletonAvatarCls}{skeletonAvatarCls}-sm"] = new CSSObject
                {
                    ["..."] = GenSkeletonElementAvatarSize(controlHeightSM),
                },
            };
        }

        public static CSSObject GenSkeletonElementInput(SkeletonToken token)
        {
            var controlHeight = token.ControlHeight;
            var borderRadiusSM = token.BorderRadiusSM;
            var skeletonInputCls = token.SkeletonInputCls;
            var controlHeightLG = token.ControlHeightLG;
            var controlHeightSM = token.ControlHeightSM;
            var gradientFromColor = token.GradientFromColor;
            var calc = token.Calc;
            return new CSSObject
            {
                [skeletonInputCls] = new CSSObject
                {
                    Display = "inline-block",
                    VerticalAlign = "top",
                    Background = gradientFromColor,
                    BorderRadius = borderRadiusSM,
                    ["..."] = GenSkeletonElementInputSize(controlHeight, calc),
                },
                [$@"{skeletonInputCls}-lg"] = new CSSObject
                {
                    ["..."] = GenSkeletonElementInputSize(controlHeightLG, calc),
                },
                [$@"{skeletonInputCls}-sm"] = new CSSObject
                {
                    ["..."] = GenSkeletonElementInputSize(controlHeightSM, calc),
                },
            };
        }

        public static CSSObject GenSkeletonElementImageSize(number | string size)
        {
            return new CSSObject
            {
                Width = size,
                ["..."] = GenSkeletonElementCommonSize(size),
            };
        }

        public static CSSObject GenSkeletonElementImage(SkeletonToken token)
        {
            var skeletonImageCls = token.SkeletonImageCls;
            var imageSizeBase = token.ImageSizeBase;
            var gradientFromColor = token.GradientFromColor;
            var borderRadiusSM = token.BorderRadiusSM;
            var calc = token.Calc;
            return new CSSObject
            {
                [skeletonImageCls] = new CSSObject
                {
                    Display = "inline-flex",
                    AlignItems = "center",
                    JustifyContent = "center",
                    VerticalAlign = "middle",
                    Background = gradientFromColor,
                    BorderRadius = borderRadiusSM,
                    ["..."] = GenSkeletonElementImageSize(Calc(imageSizeBase).Mul(2).Equal()),
                    [$@"{skeletonImageCls}-path"] = new CSSObject
                    {
                        ["fill"] = "#bfbfbf",
                    },
                    [$@"{skeletonImageCls}-svg"] = new CSSObject
                    {
                        ["..."] = GenSkeletonElementImageSize(imageSizeBase),
                        MaxWidth = Calc(imageSizeBase).Mul(4).Equal(),
                        MaxHeight = Calc(imageSizeBase).Mul(4).Equal(),
                    },
                    [$@"{skeletonImageCls}-svg{skeletonImageCls}-svg-circle"] = new CSSObject
                    {
                        BorderRadius = "50%",
                    },
                },
                [$@"{skeletonImageCls}{skeletonImageCls}-circle"] = new CSSObject
                {
                    BorderRadius = "50%",
                },
            };
        }

        public static CSSObject GenSkeletonElementButtonShape(SkeletonToken token, number size, string buttonCls)
        {
            var skeletonButtonCls = token.SkeletonButtonCls;
            return new CSSObject
            {
                [$@"{buttonCls}{skeletonButtonCls}-circle"] = new CSSObject
                {
                    Width = size,
                    MinWidth = size,
                    BorderRadius = "50%",
                },
                [$@"{buttonCls}{skeletonButtonCls}-round"] = new CSSObject
                {
                    BorderRadius = size,
                },
            };
        }

        public static CSSObject GenSkeletonElementButtonSize(number size, CSSUtil['calc'] calc)
        {
            return new CSSObject
            {
                Width = Calc(size).Mul(2).Equal(),
                MinWidth = Calc(size).Mul(2).Equal(),
                ["..."] = GenSkeletonElementCommonSize(size),
            };
        }

        public static CSSObject GenSkeletonElementButton(SkeletonToken token)
        {
            var borderRadiusSM = token.BorderRadiusSM;
            var skeletonButtonCls = token.SkeletonButtonCls;
            var controlHeight = token.ControlHeight;
            var controlHeightLG = token.ControlHeightLG;
            var controlHeightSM = token.ControlHeightSM;
            var gradientFromColor = token.GradientFromColor;
            var calc = token.Calc;
            return new CSSObject
            {
                [skeletonButtonCls] = new CSSObject
                {
                    Display = "inline-block",
                    VerticalAlign = "top",
                    Background = gradientFromColor,
                    BorderRadius = borderRadiusSM,
                    Width = Calc(controlHeight).Mul(2).Equal(),
                    MinWidth = Calc(controlHeight).Mul(2).Equal(),
                    ["..."] = GenSkeletonElementButtonSize(controlHeight, calc),
                },
                ["..."] = GenSkeletonElementButtonShape(token, controlHeight, skeletonButtonCls),
                [$@"{skeletonButtonCls}-lg"] = new CSSObject
                {
                    ["..."] = GenSkeletonElementButtonSize(controlHeightLG, calc),
                },
                ["..."] = GenSkeletonElementButtonShape(token, controlHeightLG, $@"{skeletonButtonCls}-lg"),
                [$@"{skeletonButtonCls}-sm"] = new CSSObject
                {
                    ["..."] = GenSkeletonElementButtonSize(controlHeightSM, calc),
                },
                ["..."] = GenSkeletonElementButtonShape(token, controlHeightSM, $@"{skeletonButtonCls}-sm"),
            };
        }

        public static CSSObject GenBaseStyle(SkeletonToken token)
        {
            var componentCls = token.ComponentCls;
            var skeletonAvatarCls = token.SkeletonAvatarCls;
            var skeletonTitleCls = token.SkeletonTitleCls;
            var skeletonParagraphCls = token.SkeletonParagraphCls;
            var skeletonButtonCls = token.SkeletonButtonCls;
            var skeletonInputCls = token.SkeletonInputCls;
            var skeletonImageCls = token.SkeletonImageCls;
            var controlHeight = token.ControlHeight;
            var controlHeightLG = token.ControlHeightLG;
            var controlHeightSM = token.ControlHeightSM;
            var gradientFromColor = token.GradientFromColor;
            var padding = token.Padding;
            var marginSM = token.MarginSM;
            var borderRadius = token.BorderRadius;
            var titleHeight = token.TitleHeight;
            var blockRadius = token.BlockRadius;
            var paragraphLiHeight = token.ParagraphLiHeight;
            var controlHeightXS = token.ControlHeightXS;
            var paragraphMarginTop = token.ParagraphMarginTop;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    Display = "table",
                    Width = "100%",
                    [$@"{componentCls}-header"] = new CSSObject
                    {
                        Display = "table-cell",
                        PaddingInlineEnd = padding,
                        VerticalAlign = "top",
                        [skeletonAvatarCls] = new CSSObject
                        {
                            Display = "inline-block",
                            VerticalAlign = "top",
                            Background = gradientFromColor,
                            ["..."] = GenSkeletonElementAvatarSize(controlHeight),
                        },
                        [$@"{skeletonAvatarCls}-circle"] = new CSSObject
                        {
                            BorderRadius = "50%",
                        },
                        [$@"{skeletonAvatarCls}-lg"] = new CSSObject
                        {
                            ["..."] = GenSkeletonElementAvatarSize(controlHeightLG),
                        },
                        [$@"{skeletonAvatarCls}-sm"] = new CSSObject
                        {
                            ["..."] = GenSkeletonElementAvatarSize(controlHeightSM),
                        },
                    },
                    [$@"{componentCls}-content"] = new CSSObject
                    {
                        Display = "table-cell",
                        Width = "100%",
                        VerticalAlign = "top",
                        [skeletonTitleCls] = new CSSObject
                        {
                            Width = "100%",
                            Height = titleHeight,
                            Background = gradientFromColor,
                            BorderRadius = blockRadius,
                            [$@"{skeletonParagraphCls}"] = new CSSObject
                            {
                                MarginBlockStart = controlHeightSM,
                            },
                        },
                        [skeletonParagraphCls] = new CSSObject
                        {
                            Padding = 0,
                            ["> li"] = new CSSObject
                            {
                                Width = "100%",
                                Height = paragraphLiHeight,
                                ListStyle = "none",
                                Background = gradientFromColor,
                                BorderRadius = blockRadius,
                                ["+ li"] = new CSSObject
                                {
                                    MarginBlockStart = controlHeightXS,
                                },
                            },
                        },
                        [$@"{skeletonParagraphCls}> li:last-child:not(:first-child):not(:nth-child(2))"] = new CSSObject
                        {
                            Width = "61%",
                        },
                    },
                    [$@"{componentCls}-content"] = new CSSObject
                    {
                        [$@"{skeletonTitleCls}, {skeletonParagraphCls} > li"] = new CSSObject
                        {
                        },
                    },
                },
                [$@"{componentCls}-with-avatar {componentCls}-content"] = new CSSObject
                {
                    [skeletonTitleCls] = new CSSObject
                    {
                        MarginBlockStart = marginSM,
                        [$@"{skeletonParagraphCls}"] = new CSSObject
                        {
                            MarginBlockStart = paragraphMarginTop,
                        },
                    },
                },
                [$@"{componentCls}{componentCls}-element"] = new CSSObject
                {
                    Display = "inline-block",
                    Width = "auto",
                    ["..."] = GenSkeletonElementButton(token),
                    ["..."] = GenSkeletonElementAvatar(token),
                    ["..."] = GenSkeletonElementInput(token),
                    ["..."] = GenSkeletonElementImage(token),
                },
                [$@"{componentCls}{componentCls}-block"] = new CSSObject
                {
                    Width = "100%",
                    [skeletonButtonCls] = new CSSObject
                    {
                        Width = "100%",
                    },
                    [skeletonInputCls] = new CSSObject
                    {
                        Width = "100%",
                    },
                },
                [$@"{componentCls}{componentCls}-active"] = new CSSObject
                {
                    [$@"{skeletonTitleCls},
        {skeletonParagraphCls} > li,
        {skeletonAvatarCls},
        {skeletonButtonCls},
        {skeletonInputCls},
        {skeletonImageCls}
      "] = new CSSObject
                    {
                        ["..."] = GenSkeletonColor(token),
                    },
                },
            };
        }

        public static SkeletonToken PrepareComponentToken(SkeletonToken token)
        {
            var colorFillContent = token.ColorFillContent;
            var colorFill = token.ColorFill;
            var gradientFromColor = colorFillContent;
            var gradientToColor = colorFill;
            return new SkeletonToken
            {
                Color = gradientFromColor,
                ColorGradientEnd = gradientToColor,
                TitleHeight = token.ControlHeight / 2,
                BlockRadius = token.BorderRadiusSM,
                ParagraphMarginTop = token.MarginLG + token.MarginXXS,
                ParagraphLiHeight = token.ControlHeight / 2,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Skeleton", (SkeletonToken token) =>
            {
                var componentCls = token.ComponentCls;
                var calc = token.Calc;
                var skeletonToken = MergeToken(token, new object { SkeletonAvatarCls = $@"{componentCls}-avatar", SkeletonTitleCls = $@"{componentCls}-title", SkeletonParagraphCls = $@"{componentCls}-paragraph", SkeletonButtonCls = $@"{componentCls}-button", SkeletonInputCls = $@"{componentCls}-input", SkeletonImageCls = $@"{componentCls}-image", ImageSizeBase = Calc(token.ControlHeight).Mul(1.5).Equal(), BorderRadius = 100, SkeletonLoadingBackground = $@"{token.GradientFromColor} 25%, {token.GradientToColor} 37%, {token.GradientFromColor} 63%)", SkeletonLoadingMotionDuration = "1.4s", });
                return new object[]
                {
                    GenBaseStyle(skeletonToken)
                };
            }, PrepareComponentToken, new object { DeprecatedTokens = new object[] { new object[] { "color", "gradientFromColor" }, new object[] { "colorGradientEnd", "gradientToColor" } }, });
        }
    }
}