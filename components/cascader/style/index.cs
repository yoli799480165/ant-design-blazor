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
    public partial class CascaderStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public string ControlWidth { get; set; }
            public string ControlItemWidth { get; set; }
            public string DropdownHeight { get; set; }
            public string OptionSelectedBg { get; set; }
            public string OptionSelectedFontWeight { get; set; }
            public string OptionPadding { get; set; }
            public string MenuPadding { get; set; }
        }

        public class CascaderToken : ComponentToken
        {
        }

        public static CSSObject GenBaseStyle(CascaderToken token)
        {
            var componentCls = token.ComponentCls;
            var antCls = token.AntCls;
            return new object[]
            {
                new object
                {
                    [componentCls] = new object
                    {
                        Width = token.ControlWidth,
                    },
                },
                new object
                {
                    [$@"{componentCls}-dropdown"] = new object[]
                    {
                        new object
                        {
                            [$@"{antCls}-select-dropdown"] = new object
                            {
                                Padding = 0,
                            },
                        },
                        GetColumnsStyle(token)
                    },
                },
                new object
                {
                    [$@"{componentCls}-dropdown-rtl"] = new object
                    {
                        Direction = "rtl",
                    },
                },
                GenCompactItemStyle(token)
            };
        }

        public static CascaderToken PrepareComponentToken(GlobalToken token)
        {
            var itemPaddingVertical = Math.Round((token.ControlHeight - token.FontSize * token.LineHeight) / 2);
            return new CascaderToken
            {
                ControlWidth = 184,
                ControlItemWidth = 111,
                DropdownHeight = 180,
                OptionSelectedBg = token.ControlItemBgActive,
                OptionSelectedFontWeight = token.FontWeightStrong,
                OptionPadding = $@"{itemPaddingVertical}px {token.PaddingSM}px",
                MenuPadding = token.PaddingXXS,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Cascader", (CascaderToken token) =>
            {
                return new object[]
                {
                    GenBaseStyle(token)
                };
            }, PrepareComponentToken);
        }
    }
}