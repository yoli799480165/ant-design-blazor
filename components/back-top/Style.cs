using System;
using CssInCSharp;
using static AntDesign.GlobalStyle;
using static AntDesign.Theme;
using static AntDesign.StyleUtil;

namespace AntDesign
{
    public partial class BackTopToken : TokenWithCommonCls
    {
        public double ZIndexPopup
        {
            get => (double)_tokens["zIndexPopup"];
            set => _tokens["zIndexPopup"] = value;
        }

    }

    public partial class BackTopToken
    {
        public string BackTopBackground
        {
            get => (string)_tokens["backTopBackground"];
            set => _tokens["backTopBackground"] = value;
        }

        public string BackTopColor
        {
            get => (string)_tokens["backTopColor"];
            set => _tokens["backTopColor"] = value;
        }

        public string BackTopHoverBackground
        {
            get => (string)_tokens["backTopHoverBackground"];
            set => _tokens["backTopHoverBackground"] = value;
        }

        public double BackTopFontSize
        {
            get => (double)_tokens["backTopFontSize"];
            set => _tokens["backTopFontSize"] = value;
        }

        public double BackTopSize
        {
            get => (double)_tokens["backTopSize"];
            set => _tokens["backTopSize"] = value;
        }

        public string BackTopBlockEnd
        {
            get => (string)_tokens["backTopBlockEnd"];
            set => _tokens["backTopBlockEnd"] = value;
        }

        public string BackTopInlineEnd
        {
            get => (string)_tokens["backTopInlineEnd"];
            set => _tokens["backTopInlineEnd"] = value;
        }

        public string BackTopInlineEndMD
        {
            get => (string)_tokens["backTopInlineEndMD"];
            set => _tokens["backTopInlineEndMD"] = value;
        }

        public string BackTopInlineEndXS
        {
            get => (string)_tokens["backTopInlineEndXS"];
            set => _tokens["backTopInlineEndXS"] = value;
        }

    }

    public partial class BackTop
    {
        public CSSObject GenSharedBackTopStyle(BackTopToken token)
        {
            var componentCls = token.ComponentCls;
            var backTopFontSize = token.BackTopFontSize;
            var backTopSize = token.BackTopSize;
            var zIndexPopup = token.ZIndexPopup;
            return new CSSObject()
            {
                [componentCls] = new CSSObject()
                {
                    ["..."] = ResetComponent(token),
                    Position = "fixed",
                    InsetInlineEnd = token.BackTopInlineEnd,
                    InsetBlockEnd = token.BackTopBlockEnd,
                    ZIndex = zIndexPopup,
                    Width = 40,
                    Height = 40,
                    Cursor = "pointer",
                    ["&:empty"] = new CSSObject()
                    {
                        Display = "none",
                    },
                    [$"{componentCls}-content"] = new CSSObject()
                    {
                        Width = backTopSize,
                        Height = backTopSize,
                        Overflow = "hidden",
                        Color = token.BackTopColor,
                        TextAlign = "center",
                        BackgroundColor = token.BackTopBackground,
                        BorderRadius = backTopSize,
                        Transition = @$"all {token.MotionDurationMid}",
                        ["&:hover"] = new CSSObject()
                        {
                            BackgroundColor = token.BackTopHoverBackground,
                            Transition = @$"all {token.MotionDurationMid}",
                        },
                    },
                    [$"{componentCls}-icon"] = new CSSObject()
                    {
                        FontSize = backTopFontSize,
                        LineHeight = Unit(backTopSize)
                    },
                },
            };
        }

        public CSSObject GenMediaBackTopStyle(BackTopToken token)
        {
            var componentCls = token.ComponentCls;
            var screenMD = token.ScreenMD;
            var screenXS = token.ScreenXS;
            var backTopInlineEndMD = token.BackTopInlineEndMD;
            var backTopInlineEndXS = token.BackTopInlineEndXS;
            return new CSSObject()
            {
                [$"@media (max-width: {Unit(screenMD)})"] = new CSSObject()
                {
                    [componentCls] = new CSSObject()
                    {
                        InsetInlineEnd = backTopInlineEndMD,
                    },
                },
                [$"@media (max-width: {Unit(screenXS)})"] = new CSSObject()
                {
                    [componentCls] = new CSSObject()
                    {
                        InsetInlineEnd = backTopInlineEndXS,
                    },
                },
            };
        }

        public BackTopToken PrepareComponentToken(GlobalToken token)
        {
            return new BackTopToken()
            {
                ZIndexPopup = token.ZIndexBase + 10,
            };
        }

        protected override UseComponentStyleResult UseComponentStyle()
        {
            return GenStyleHooks(
                "BackTop",
                (token) =>
                {
                    var fontSizeHeading3 = token.FontSizeHeading3;
                    var colorTextDescription = token.ColorTextDescription;
                    var colorTextLightSolid = token.ColorTextLightSolid;
                    var colorText = token.ColorText;
                    var controlHeightLG = token.ControlHeightLG;
                    var calc = token.Calc;
                    var backTopToken = MergeToken(
                        token,
                        new BackTopToken()
                        {
                            BackTopBackground = colorTextDescription,
                            BackTopColor = colorTextLightSolid,
                            BackTopHoverBackground = colorText,
                            BackTopFontSize = fontSizeHeading3,
                            BackTopSize = controlHeightLG,
                            BackTopBlockEnd = token.Calc(controlHeightLG).Mul(1.25).Equal(),
                            BackTopInlineEnd = token.Calc(controlHeightLG).Mul(2.5).Equal(),
                            BackTopInlineEndMD = token.Calc(controlHeightLG).Mul(1.5).Equal(),
                            BackTopInlineEndXS = token.Calc(controlHeightLG).Mul(0.5).Equal()
                        });
                    return new CSSInterpolation[]
                    {
                        GenSharedBackTopStyle(backTopToken),
                        GenMediaBackTopStyle(backTopToken),
                    };
                },
                PrepareComponentToken);
        }

    }

}
