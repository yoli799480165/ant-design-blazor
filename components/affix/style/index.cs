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
    public partial class AffixStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public double ZIndexPopup { get; set; }
        }

        public class AffixToken : ComponentToken
        {
        }

        public static CSSObject GenSharedAffixStyle(AffixToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    Position = "fixed",
                    ZIndex = token.ZIndexPopup,
                },
            };
        }

        public static AffixToken PrepareComponentToken(AffixToken token)
        {
            return new AffixToken
            {
                ZIndexPopup = token.ZIndexBase + 10,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Affix", genSharedAffixStyle, prepareComponentToken);
        }
    }
}