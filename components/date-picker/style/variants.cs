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
    public partial class DatePickerStyle
    {
        public static CSSObject GenVariantsStyle(PickerToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [componentCls] = new object[]
                {
                    new object
                    {
                        ["..."] = GenOutlinedStyle(token),
                        ["..."] = GenFilledStyle(token),
                        ["..."] = GenBorderlessStyle(token),
                    },
                    new object
                    {
                        ["&-outlined"] = new object
                        {
                            [$@"{componentCls}-multiple {componentCls}-selection-item"] = new object
                            {
                                Background = token.MultipleItemBg,
                                Border = $@"{Unit(token.LineWidth)} {token.LineType} {token.MultipleItemBorderColor}",
                            },
                        },
                        ["&-filled"] = new object
                        {
                            [$@"{componentCls}-multiple {componentCls}-selection-item"] = new object
                            {
                                Background = token.ColorBgContainer,
                                Border = $@"{Unit(token.LineWidth)} {token.LineType} {token.ColorSplit}",
                            },
                        },
                        ["&-borderless"] = new object
                        {
                            [$@"{componentCls}-multiple {componentCls}-selection-item"] = new object
                            {
                                Background = token.MultipleItemBg,
                                Border = $@"{Unit(token.LineWidth)} {token.LineType} {token.MultipleItemBorderColor}",
                            },
                        },
                    }
                },
            };
        }

        public static object VariantsDefault()
        {
            return genVariantsStyle;
        }
    }
}