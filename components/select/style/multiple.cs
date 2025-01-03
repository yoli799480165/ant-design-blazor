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
    public partial class SelectStyle
    {
        public class SelectItemToken : Pick<SelectToken, multipleSelectItemHeight'
  | 'multipleSelectorBgDisabled'
  | 'multipleItemColorDisabled'
  | 'multipleItemBorderColorDisabled'
  | 'selectHeight'
  | 'lineWidth'
  | 'calc'
  | 'inputPaddingHorizontalBase'
  | 'INTERNAL_FIXED_ITEM_MARGIN'
  | 'selectAffixPadding>
        {
        }

        public static object GetMultipleSelectorUnit(Pick<SelectToken,  | 'max' | 'calc' | 'multipleSelectItemHeight' | 'paddingXXS' | 'lineWidth' | 'INTERNAL_FIXED_ITEM_MARGIN'> token)
        {
            var multipleSelectItemHeight = token.MultipleSelectItemHeight;
            var paddingXXS = token.PaddingXXS;
            var lineWidth = token.LineWidth;
            var INTERNAL_FIXED_ITEM_MARGIN = token.INTERNAL_FIXED_ITEM_MARGIN;
            var basePadding = token.Max(token.Calc(paddingXXS).Sub(lineWidth).Equal(), 0);
            var containerPadding = token.Max(token.Calc(basePadding).Sub(INTERNAL_FIXED_ITEM_MARGIN).Equal(), 0);
            return new object
            {
                ItemHeight = Unit(multipleSelectItemHeight),
                ItemLineHeight = Unit(token.Calc(multipleSelectItemHeight).Sub(token.Calc(token.LineWidth).Mul(2)).Equal()),
            };
        }

        public static number | string GetSelectItemStyle(SelectItemToken token)
        {
            var multipleSelectItemHeight = token.MultipleSelectItemHeight;
            var selectHeight = token.SelectHeight;
            var lineWidth = token.LineWidth;
            var selectItemDist = token.Calc(selectHeight).Sub(multipleSelectItemHeight).Div(2).Sub(lineWidth).Equal();
            return selectItemDist;
        }

        public static CSSObject GenOverflowStyle(Pick<SelectToken,  | 'calc' | 'componentCls' | 'iconCls' | 'borderRadiusSM' | 'motionDurationSlow' | 'paddingXS' | 'multipleItemColorDisabled' | 'multipleItemBorderColorDisabled' | 'colorIcon' | 'colorIconHover' | 'INTERNAL_FIXED_ITEM_MARGIN'> token)
        {
            var componentCls = token.ComponentCls;
            var iconCls = token.IconCls;
            var borderRadiusSM = token.BorderRadiusSM;
            var motionDurationSlow = token.MotionDurationSlow;
            var paddingXS = token.PaddingXS;
            var multipleItemColorDisabled = token.MultipleItemColorDisabled;
            var multipleItemBorderColorDisabled = token.MultipleItemBorderColorDisabled;
            var colorIcon = token.ColorIcon;
            var colorIconHover = token.ColorIconHover;
            var INTERNAL_FIXED_ITEM_MARGIN = token.INTERNAL_FIXED_ITEM_MARGIN;
            var selectOverflowPrefixCls = $@"{componentCls}-selection-overflow";
            return new CSSObject
            {
                [selectOverflowPrefixCls] = new CSSObject
                {
                    Position = "relative",
                    Display = "flex",
                    Flex = "auto",
                    FlexWrap = "wrap",
                    MaxWidth = "100%",
                    ["&-item"] = new CSSObject
                    {
                        Flex = "none",
                        AlignSelf = "center",
                        MaxWidth = "100%",
                        Display = "inline-flex",
                    },
                    [$@"{componentCls}-selection-item"] = new CSSObject
                    {
                        Display = "flex",
                        AlignSelf = "center",
                        Flex = "none",
                        BoxSizing = "border-box",
                        MaxWidth = "100%",
                        MarginBlock = INTERNAL_FIXED_ITEM_MARGIN,
                        BorderRadius = borderRadiusSM,
                        Cursor = "default",
                        Transition = $@"{motionDurationSlow}, line-height {motionDurationSlow}, height {motionDurationSlow}",
                        MarginInlineEnd = token.Calc(INTERNAL_FIXED_ITEM_MARGIN).Mul(2).Equal(),
                        PaddingInlineStart = paddingXS,
                        PaddingInlineEnd = token.Calc(paddingXS).Div(2).Equal(),
                        [$@"{componentCls}-disabled&"] = new CSSObject
                        {
                            Color = multipleItemColorDisabled,
                            BorderColor = multipleItemBorderColorDisabled,
                            Cursor = "not-allowed",
                        },
                        ["&-content"] = new CSSObject
                        {
                            Display = "inline-block",
                            MarginInlineEnd = token.Calc(paddingXS).Div(2).Equal(),
                            Overflow = "hidden",
                            WhiteSpace = "pre",
                            TextOverflow = "ellipsis",
                        },
                        ["&-remove"] = new CSSObject
                        {
                            ["..."] = ResetIcon(),
                            Display = "inline-flex",
                            AlignItems = "center",
                            Color = colorIcon,
                            FontWeight = "bold",
                            FontSize = 10,
                            LineHeight = "inherit",
                            Cursor = "pointer",
                            [$@"{iconCls}"] = new CSSObject
                            {
                                VerticalAlign = "-0.2em",
                            },
                            ["&:hover"] = new CSSObject
                            {
                                Color = colorIconHover,
                            },
                        },
                    },
                },
            };
        }

        public static CSSObject GenSelectionStyle(TokenWithCommonCls<AliasToken> & SelectItemToken token, string suffix)
        {
            var componentCls = token.ComponentCls;
            var INTERNAL_FIXED_ITEM_MARGIN = token.INTERNAL_FIXED_ITEM_MARGIN;
            var selectOverflowPrefixCls = $@"{componentCls}-selection-overflow";
            var selectItemHeight = token.MultipleSelectItemHeight;
            var selectItemDist = GetSelectItemStyle(token);
            var suffixCls = suffix ? $@"{componentCls}-{suffix}" : "";
            var multipleSelectorUnit = GetMultipleSelectorUnit(token);
            return new CSSObject
            {
                [$@"{componentCls}-multiple{suffixCls}"] = new CSSObject
                {
                    ["..."] = GenOverflowStyle(token),
                    [$@"{componentCls}-selector"] = new CSSObject
                    {
                        Display = "flex",
                        AlignItems = "center",
                        Width = "100%",
                        Height = "100%",
                        PaddingInline = multipleSelectorUnit.BasePadding,
                        PaddingBlock = multipleSelectorUnit.ContainerPadding,
                        BorderRadius = token.BorderRadius,
                        [$@"{componentCls}-disabled&"] = new CSSObject
                        {
                            Background = token.MultipleSelectorBgDisabled,
                            Cursor = "not-allowed",
                        },
                        ["&:after"] = new CSSObject
                        {
                            Display = "inline-block",
                            Width = 0,
                            Margin = $@"{Unit(INTERNAL_FIXED_ITEM_MARGIN)} 0",
                            LineHeight = Unit(selectItemHeight),
                            Visibility = "hidden",
                            Content = "\"\\a0\"",
                        },
                    },
                    [$@"{componentCls}-selection-item"] = new CSSObject
                    {
                        Height = multipleSelectorUnit.ItemHeight,
                        LineHeight = Unit(multipleSelectorUnit.ItemLineHeight),
                    },
                    [$@"{componentCls}-selection-wrap"] = new CSSObject
                    {
                        AlignSelf = "flex-start",
                        ["&:after"] = new CSSObject
                        {
                            LineHeight = Unit(selectItemHeight),
                            MarginBlock = INTERNAL_FIXED_ITEM_MARGIN,
                        },
                    },
                    [$@"{componentCls}-prefix"] = new CSSObject
                    {
                        MarginInlineStart = token.Calc(token.InputPaddingHorizontalBase).Sub(multipleSelectorUnit.BasePadding).Equal(),
                    },
                    [$@"{selectOverflowPrefixCls}-item + {selectOverflowPrefixCls}-item,
        {componentCls}-prefix + {componentCls}-selection-wrap
      "] = new CSSObject
                    {
                        [$@"{componentCls}-selection-search"] = new CSSObject
                        {
                            MarginInlineStart = 0,
                        },
                        [$@"{componentCls}-selection-placeholder"] = new CSSObject
                        {
                            InsetInlineStart = 0,
                        },
                    },
                    [$@"{selectOverflowPrefixCls}-item-suffix"] = new CSSObject
                    {
                        MinHeight = multipleSelectorUnit.ItemHeight,
                        MarginBlock = INTERNAL_FIXED_ITEM_MARGIN,
                    },
                    [$@"{componentCls}-selection-search"] = new CSSObject
                    {
                        Display = "inline-flex",
                        Position = "relative",
                        MaxWidth = "100%",
                        MarginInlineStart = token.Calc(token.InputPaddingHorizontalBase).Sub(selectItemDist).Equal(),
                        ["\n          &-input,\n          &-mirror\n        "] = new CSSObject
                        {
                            Height = selectItemHeight,
                            FontFamily = token.FontFamily,
                            LineHeight = Unit(selectItemHeight),
                            Transition = $@"{token.MotionDurationSlow}",
                        },
                        ["&-input"] = new CSSObject
                        {
                            Width = "100%",
                            MinWidth = 4.1,
                        },
                        ["&-mirror"] = new CSSObject
                        {
                            Position = "absolute",
                            Top = 0,
                            InsetInlineStart = 0,
                            InsetInlineEnd = "auto",
                            ZIndex = 999,
                            WhiteSpace = "pre",
                            Visibility = "hidden",
                        },
                    },
                    [$@"{componentCls}-selection-placeholder"] = new CSSObject
                    {
                        Position = "absolute",
                        Top = "50%",
                        InsetInlineStart = token.Calc(token.InputPaddingHorizontalBase).Sub(multipleSelectorUnit.BasePadding).Equal(),
                        InsetInlineEnd = token.InputPaddingHorizontalBase,
                        Transform = "translateY(-50%)",
                        Transition = $@"{token.MotionDurationSlow}",
                    },
                },
            };
        }

        public static CSSInterpolation GenMultipleStyle(SelectToken token)
        {
            var componentCls = token.ComponentCls;
            var smallToken = MergeToken(token, new object { SelectHeight = token.ControlHeightSM, MultipleSelectItemHeight = token.MultipleItemHeightSM, BorderRadius = token.BorderRadiusSM, BorderRadiusSM = token.BorderRadiusXS, });
            var largeToken = MergeToken(token, new object { FontSize = token.FontSizeLG, SelectHeight = token.ControlHeightLG, MultipleSelectItemHeight = token.MultipleItemHeightLG, BorderRadius = token.BorderRadiusLG, BorderRadiusSM = token.BorderRadius, });
            return new object[]
            {
                GenSizeStyle(token),
                GenSizeStyle(smallToken, "sm"),
                new object
                {
                    [$@"{componentCls}-multiple{componentCls}-sm"] = new object
                    {
                        [$@"{componentCls}-selection-placeholder"] = new object
                        {
                            InsetInline = token.Calc(token.ControlPaddingHorizontalSM).Sub(token.LineWidth).Equal(),
                        },
                        [$@"{componentCls}-selection-search"] = new object
                        {
                            MarginInlineStart = 2,
                        },
                    },
                },
                GenSizeStyle(largeToken, "lg")
            };
        }

        public static object MultipleDefault()
        {
            return GenMultipleStyle;
        }
    }
}