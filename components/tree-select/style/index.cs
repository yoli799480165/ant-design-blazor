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
    public partial class TreeSelectStyle
    {
        public class ComponentToken : TokenWithCommonCls : TreeSharedToken
        {
        }

        public class TreeSelectToken : ComponentToken
        {
            public string TreePrefixCls { get; set; }
        }

        public static CSSObject GenBaseStyle(TreeSelectToken token)
        {
            var componentCls = token.ComponentCls;
            var treePrefixCls = token.TreePrefixCls;
            var colorBgElevated = token.ColorBgElevated;
            var treeCls = $@"{treePrefixCls}";
            return new object[]
            {
                new object
                {
                    [$@"{componentCls}-dropdown"] = new object[]
                    {
                        new object
                        {
                            Padding = $@"{Unit(token.PaddingXS)} {Unit(token.Calc(token.PaddingXS).Div(2).Equal())}",
                        },
                        GenTreeStyle(treePrefixCls, MergeToken(token, new object { ColorBgContainer = colorBgElevated, })),
                        new object
                        {
                            [treeCls] = new object
                            {
                                BorderRadius = 0,
                                [$@"{treeCls}-list-holder-inner"] = new object
                                {
                                    AlignItems = "stretch",
                                    [$@"{treeCls}-treenode"] = new object
                                    {
                                        [$@"{treeCls}-node-content-wrapper"] = new object
                                        {
                                            Flex = "auto",
                                        },
                                    },
                                },
                            },
                        },
                        GetCheckboxStyle($@"{treePrefixCls}-checkbox", token),
                        new object
                        {
                            ["&-rtl"] = new object
                            {
                                Direction = "rtl",
                                [$@"{treeCls}-switcher{treeCls}-switcher_close"] = new object
                                {
                                    [$@"{treeCls}-switcher-icon svg"] = new object
                                    {
                                        Transform = "rotate(90deg)",
                                    },
                                },
                            },
                        }
                    },
                }
            };
        }

        public object PrepareComponentToken = initComponentToken;
    }
}