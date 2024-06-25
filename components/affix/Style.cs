using System;
using CssInCSharp;
using static AntDesign.GlobalStyle;
using static AntDesign.Theme;
using static AntDesign.StyleUtil;

namespace AntDesign
{
    public partial class AffixToken : TokenWithCommonCls
    {
        public double ZIndexPopup
        {
            get => (double)_tokens["zIndexPopup"];
            set => _tokens["zIndexPopup"] = value;
        }

    }

    public partial class AffixToken
    {
    }

    public partial class Affix
    {
        public CSSInterpolation GenSharedAffixStyle(AffixToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject()
            {
                [componentCls] = new CSSObject()
                {
                    Position = "fixed",
                    ZIndex = token.ZIndexPopup,
                },
            };
        }

        public AffixToken PrepareComponentToken(GlobalToken token)
        {
            return new AffixToken()
            {
                ZIndexPopup = token.ZIndexBase + 10,
            };
        }

        protected override UseComponentStyleResult UseComponentStyle()
        {
            return GenStyleHooks("Affix", GenSharedAffixStyle, PrepareComponentToken);
        }

    }

}