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
    public partial class StepsStyle
    {
        public static CSSObject GenStepsCustomIconStyle(StepsToken token)
        {
            var componentCls = token.ComponentCls;
            var customIconTop = token.CustomIconTop;
            var customIconSize = token.CustomIconSize;
            var customIconFontSize = token.CustomIconFontSize;
            return new CSSObject
            {
                [$@"{componentCls}-item-custom"] = new CSSObject
                {
                    [$@"{componentCls}-item-container > {componentCls}-item-icon"] = new CSSObject
                    {
                        Height = "auto",
                        Background = "none",
                        Border = 0,
                        [$@"{componentCls}-icon"] = new CSSObject
                        {
                            Top = customIconTop,
                            Width = customIconSize,
                            Height = customIconSize,
                            FontSize = customIconFontSize,
                            LineHeight = Unit(customIconSize),
                        },
                    },
                },
                [$@"{componentCls}-vertical)"] = new CSSObject
                {
                    [$@"{componentCls}-item-custom"] = new CSSObject
                    {
                        [$@"{componentCls}-item-icon"] = new CSSObject
                        {
                            Width = "auto",
                            Background = "none",
                        },
                    },
                },
            };
        }

        public static object CustomIconDefault()
        {
            return genStepsCustomIconStyle;
        }
    }
}