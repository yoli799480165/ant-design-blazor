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
        public static CSSObject GenFixedStyle(TableToken token)
        {
            var componentCls = token.ComponentCls;
            var lineWidth = token.LineWidth;
            var colorSplit = token.ColorSplit;
            var motionDurationSlow = token.MotionDurationSlow;
            var zIndexTableFixed = token.ZIndexTableFixed;
            var tableBg = token.TableBg;
            var zIndexTableSticky = token.ZIndexTableSticky;
            var calc = token.Calc;
            var shadowColor = colorSplit;
            return new CSSObject
            {
                [$@"{componentCls}-wrapper"] = new CSSObject
                {
                    [$@"{componentCls}-cell-fix-left,
        {componentCls}-cell-fix-right
      "] = new CSSObject
                    {
                        Position = "sticky !important" as 'sticky',
                        ZIndex = zIndexTableFixed,
                        Background = tableBg,
                    },
                    [$@"{componentCls}-cell-fix-left-first::after,
        {componentCls}-cell-fix-left-last::after
      "] = new CSSObject
                    {
                        Position = "absolute",
                        Top = 0,
                        Right = new CSSObject
                        {
                            _skip_check_ = true,
                            Value = 0,
                        },
                        Bottom = Calc(lineWidth).Mul(-1).Equal(),
                        Width = 30,
                        Transform = "translateX(100%)",
                        Transition = $@"{motionDurationSlow}",
                        Content = "\"\"",
                        PointerEvents = "none",
                    },
                    [$@"{componentCls}-cell-fix-left-all::after"] = new CSSObject
                    {
                        Display = "none",
                    },
                    [$@"{componentCls}-cell-fix-right-first::after,
        {componentCls}-cell-fix-right-last::after
      "] = new CSSObject
                    {
                        Position = "absolute",
                        Top = 0,
                        Bottom = Calc(lineWidth).Mul(-1).Equal(),
                        Left = new CSSObject
                        {
                            _skip_check_ = true,
                            Value = 0,
                        },
                        Width = 30,
                        Transform = "translateX(-100%)",
                        Transition = $@"{motionDurationSlow}",
                        Content = "\"\"",
                        PointerEvents = "none",
                    },
                    [$@"{componentCls}-container"] = new CSSObject
                    {
                        Position = "relative",
                        ["&::before, &::after"] = new CSSObject
                        {
                            Position = "absolute",
                            Top = 0,
                            Bottom = 0,
                            ZIndex = Calc(zIndexTableSticky).Add(1).Equal(new object { Unit = false, }),
                            Width = 30,
                            Transition = $@"{motionDurationSlow}",
                            Content = "\"\"",
                            PointerEvents = "none",
                        },
                        ["&::before"] = new CSSObject
                        {
                            InsetInlineStart = 0,
                        },
                        ["&::after"] = new CSSObject
                        {
                            InsetInlineEnd = 0,
                        },
                    },
                    [$@"{componentCls}-ping-left"] = new CSSObject
                    {
                        [$@"{componentCls}-has-fix-left) {componentCls}-container::before"] = new CSSObject
                        {
                            BoxShadow = $@"{shadowColor}",
                        },
                        [$@"{componentCls}-cell-fix-left-first::after,
          {componentCls}-cell-fix-left-last::after
        "] = new CSSObject
                        {
                            BoxShadow = $@"{shadowColor}",
                        },
                        [$@"{componentCls}-cell-fix-left-last::before"] = new CSSObject
                        {
                            BackgroundColor = "transparent !important",
                        },
                    },
                    [$@"{componentCls}-ping-right"] = new CSSObject
                    {
                        [$@"{componentCls}-has-fix-right) {componentCls}-container::after"] = new CSSObject
                        {
                            BoxShadow = $@"{shadowColor}",
                        },
                        [$@"{componentCls}-cell-fix-right-first::after,
          {componentCls}-cell-fix-right-last::after
        "] = new CSSObject
                        {
                            BoxShadow = $@"{shadowColor}",
                        },
                    },
                    [$@"{componentCls}-fixed-column-gapped"] = new CSSObject
                    {
                        [$@"{componentCls}-cell-fix-left-first::after,
        {componentCls}-cell-fix-left-last::after,
        {componentCls}-cell-fix-right-first::after,
        {componentCls}-cell-fix-right-last::after
      "] = new CSSObject
                        {
                            BoxShadow = "none",
                        },
                    },
                },
            };
        }

        public static object FixedDefault()
        {
            return GenFixedStyle;
        }
    }
}