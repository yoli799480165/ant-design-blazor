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
    public partial class TagStyle
    {
        public static CSSObject GenPresetStyle(TagToken token)
        {
            return GenPresetColor(token, (object colorKey, object { textColor, lightBorderColor, lightColor, darkColor }) =>
            {
                return new object
                {
                    [$@"{token.ComponentCls}{token.ComponentCls}-{colorKey}"] = new object
                    {
                        Color = textColor,
                        Background = lightColor,
                        BorderColor = lightBorderColor,
                        ["&-inverse"] = new object
                        {
                            Color = token.ColorTextLightSolid,
                            Background = darkColor,
                            BorderColor = darkColor,
                        },
                        [$@"{token.ComponentCls}-borderless"] = new object
                        {
                            BorderColor = "transparent",
                        },
                    },
                };
            });
        }

        public static object PresetCmpDefault()
        {
            return GenSubStyleComponent(new object[] { "Tag", "preset" }, (TagToken token) =>
            {
                var tagToken = PrepareToken(token);
                return GenPresetStyle(tagToken);
            }, PrepareComponentToken);
        }
    }
}