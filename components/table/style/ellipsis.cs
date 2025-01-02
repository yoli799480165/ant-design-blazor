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
    public partial class TableStyle
    {
        public static CSSObject GenEllipsisStyle(TableToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [$@"{componentCls}-wrapper"] = new CSSObject
                {
                    [$@"{componentCls}-cell-ellipsis"] = new CSSObject
                    {
                        ["..."] = textEllipsis,
                        WordBreak = "keep-all",
                        [$@"{componentCls}-cell-fix-left-last,
          &{componentCls}-cell-fix-right-first
        "] = new CSSObject
                        {
                            Overflow = "visible",
                            [$@"{componentCls}-cell-content"] = new CSSObject
                            {
                                Display = "block",
                                Overflow = "hidden",
                                TextOverflow = "ellipsis",
                            },
                        },
                        [$@"{componentCls}-column-title"] = new CSSObject
                        {
                            Overflow = "hidden",
                            TextOverflow = "ellipsis",
                            WordBreak = "keep-all",
                        },
                    },
                },
            };
        }

        public static object EllipsisDefault()
        {
            return genEllipsisStyle;
        }
    }
}