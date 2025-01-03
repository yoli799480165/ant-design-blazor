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
    public partial class TypographyStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public string TitleMarginTop { get; set; }
            public string TitleMarginBottom { get; set; }
        }

        public class TypographyToken : ComponentToken
        {
        }

        public static CSSObject GenTypographyStyle(TypographyToken token)
        {
            var componentCls = token.ComponentCls;
            var titleMarginTop = token.TitleMarginTop;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    Color = token.ColorText,
                    WordBreak = "break-word",
                    LineHeight = token.LineHeight,
                    [$@"{componentCls}-secondary"] = new CSSObject
                    {
                        Color = token.ColorTextDescription,
                    },
                    [$@"{componentCls}-success"] = new CSSObject
                    {
                        Color = token.ColorSuccess,
                    },
                    [$@"{componentCls}-warning"] = new CSSObject
                    {
                        Color = token.ColorWarning,
                    },
                    [$@"{componentCls}-danger"] = new CSSObject
                    {
                        Color = token.ColorError,
                        ["a&:active, a&:focus"] = new CSSObject
                        {
                            Color = token.ColorErrorActive,
                        },
                        ["a&:hover"] = new CSSObject
                        {
                            Color = token.ColorErrorHover,
                        },
                    },
                    [$@"{componentCls}-disabled"] = new CSSObject
                    {
                        Color = token.ColorTextDisabled,
                        Cursor = "not-allowed",
                        UserSelect = "none",
                    },
                    ["\n        div&,\n        p\n      "] = new CSSObject
                    {
                        MarginBottom = "1em",
                    },
                    ["..."] = GetTitleStyles(token),
                    [$@"{componentCls},
      & + h2{componentCls},
      & + h3{componentCls},
      & + h4{componentCls},
      & + h5{componentCls}
      "] = new CSSObject
                    {
                        MarginTop = titleMarginTop,
                    },
                    ["\n      div,\n      ul,\n      li,\n      p,\n      h1,\n      h2,\n      h3,\n      h4,\n      h5"] = new CSSObject
                    {
                        ["\n        + h1,\n        + h2,\n        + h3,\n        + h4,\n        + h5\n        "] = new CSSObject
                        {
                            MarginTop = titleMarginTop,
                        },
                    },
                    ["..."] = GetResetStyles(token),
                    ["..."] = GetLinkStyles(token),
                    [$@"{componentCls}-expand,
        {componentCls}-collapse,
        {componentCls}-edit,
        {componentCls}-copy
      "] = new CSSObject
                    {
                        ["..."] = OperationUnit(token),
                        MarginInlineStart = token.MarginXXS,
                    },
                    ["..."] = GetEditableStyles(token),
                    ["..."] = GetCopyableStyles(token),
                    ["..."] = GetEllipsisStyles(),
                    ["&-rtl"] = new CSSObject
                    {
                        Direction = "rtl",
                    },
                },
            };
        }

        public static TypographyToken PrepareComponentToken()
        {
            return new TypographyToken
            {
                TitleMarginTop = "1.2em",
                TitleMarginBottom = "0.5em",
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Typography", (TypographyToken token) =>
            {
                return new object[]
                {
                    GenTypographyStyle(token)
                };
            }, PrepareComponentToken);
        }
    }
}