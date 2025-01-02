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
    public partial class DropdownStyle
    {
        public static CSSObject GenStatusStyle(DropdownToken token)
        {
            var componentCls = token.ComponentCls;
            var menuCls = token.MenuCls;
            var colorError = token.ColorError;
            var colorTextLightSolid = token.ColorTextLightSolid;
            var itemCls = $@"{menuCls}-item";
            return new CSSObject
            {
                [$@"{componentCls}, {componentCls}-menu-submenu"] = new CSSObject
                {
                    [$@"{menuCls} {itemCls}"] = new CSSObject
                    {
                        [$@"{itemCls}-danger:not({itemCls}-disabled)"] = new CSSObject
                        {
                            Color = colorError,
                            ["&:hover"] = new CSSObject
                            {
                                Color = colorTextLightSolid,
                                BackgroundColor = colorError,
                            },
                        },
                    },
                },
            };
        }

        public static object StatusDefault()
        {
            return genStatusStyle;
        }
    }
}