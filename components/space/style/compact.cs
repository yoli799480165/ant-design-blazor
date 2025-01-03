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
    public partial class SpaceStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
        }

        public class SpaceToken : ComponentToken
        {
        }

        public static CSSObject GenSpaceCompactStyle(SpaceToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    ["&-block"] = new CSSObject
                    {
                        Display = "flex",
                        Width = "100%",
                    },
                    ["&-vertical"] = new CSSObject
                    {
                        FlexDirection = "column",
                    },
                },
            };
        }

        public static object CompactDefault()
        {
            return GenSpaceCompactStyle;
        }
    }
}