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
    public partial class TreeStyle
    {
        public class TreeSharedToken
        {
            public double TitleHeight { get; set; }
            public double IndentSize { get; set; }
            public string NodeHoverBg { get; set; }
            public string NodeHoverColor { get; set; }
            public string NodeSelectedBg { get; set; }
            public string NodeSelectedColor { get; set; }
        }

        public class ComponentToken : TokenWithCommonCls : TreeSharedToken
        {
            public string DirectoryNodeSelectedColor { get; set; }
            public string DirectoryNodeSelectedBg { get; set; }
        }

        public object treeNodeFX = new Keyframes("ant-tree-node-fx-do-not-use", new object { ["0%"] = new object { Opacity = 0, }, ["100%"] = new object { Opacity = 1, }, });
        public static CSSObject GetSwitchStyle(string prefixCls, AliasToken token)
        {
            return new CSSObject
            {
                [$@"{prefixCls}-switcher-icon"] = new CSSObject
                {
                    Display = "inline-block",
                    FontSize = 10,
                    VerticalAlign = "baseline",
                    ["svg"] = new CSSObject
                    {
                        Transition = $@"{token.MotionDurationSlow}",
                    },
                },
            };
        }

        public static CSSObject GetDropIndicatorStyle(string prefixCls, AliasToken token)
        {
            return new CSSObject
            {
                [$@"{prefixCls}-drop-indicator"] = new CSSObject
                {
                    Position = "absolute",
                    ZIndex = 1,
                    Height = 2,
                    BackgroundColor = token.ColorPrimary,
                    BorderRadius = 1,
                    PointerEvents = "none",
                    ["&:after"] = new CSSObject
                    {
                        Position = "absolute",
                        Top = -3,
                        InsetInlineStart = -6,
                        Width = 8,
                        Height = 8,
                        BackgroundColor = "transparent",
                        Border = $@"{Unit(token.LineWidthBold)} solid {token.ColorPrimary}",
                        BorderRadius = "50%",
                        Content = "\"\"",
                    },
                },
            };
        }

        public class TreeToken : ComponentToken
        {
            public string TreeCls { get; set; }
            public string TreeNodeCls { get; set; }
            public string TreeNodePadding { get; set; }
        }

        public static CSSObject GenBaseStyle(string prefixCls, TreeToken token)
        {
            var treeCls = token.TreeCls;
            var treeNodeCls = token.TreeNodeCls;
            var treeNodePadding = token.TreeNodePadding;
            var titleHeight = token.TitleHeight;
            var indentSize = token.IndentSize;
            var nodeSelectedBg = token.NodeSelectedBg;
            var nodeHoverBg = token.NodeHoverBg;
            var colorTextQuaternary = token.ColorTextQuaternary;
            var controlItemBgActiveDisabled = token.ControlItemBgActiveDisabled;
            return new CSSObject
            {
                [treeCls] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    Background = token.ColorBgContainer,
                    BorderRadius = token.BorderRadius,
                    Transition = $@"{token.MotionDurationSlow}",
                    ["&-rtl"] = new CSSObject
                    {
                        Direction = "rtl",
                    },
                    [$@"{treeCls}-rtl {treeCls}-switcher_close {treeCls}-switcher-icon svg"] = new CSSObject
                    {
                        Transform = "rotate(90deg)",
                    },
                    [$@"{treeCls}-active-focused)"] = new CSSObject
                    {
                        ["..."] = GenFocusOutline(token),
                    },
                    [$@"{treeCls}-list-holder-inner"] = new CSSObject
                    {
                        AlignItems = "flex-start",
                    },
                    [$@"{treeCls}-block-node"] = new CSSObject
                    {
                        [$@"{treeCls}-list-holder-inner"] = new CSSObject
                        {
                            AlignItems = "stretch",
                            [$@"{treeCls}-node-content-wrapper"] = new CSSObject
                            {
                                Flex = "auto",
                            },
                            [$@"{treeNodeCls}.dragging:after"] = new CSSObject
                            {
                                Position = "absolute",
                                Inset = 0,
                                Border = $@"{token.ColorPrimary}",
                                Opacity = 0,
                                AnimationName = treeNodeFX,
                                AnimationDuration = token.MotionDurationSlow,
                                AnimationPlayState = "running",
                                AnimationFillMode = "forwards",
                                Content = "\"\"",
                                PointerEvents = "none",
                                BorderRadius = token.BorderRadius,
                            },
                        },
                    },
                    [treeNodeCls] = new CSSObject
                    {
                        Display = "flex",
                        AlignItems = "flex-start",
                        MarginBottom = treeNodePadding,
                        LineHeight = Unit(titleHeight),
                        Position = "relative",
                        ["&:before"] = new CSSObject
                        {
                            Content = "\"\"",
                            Position = "absolute",
                            ZIndex = 1,
                            InsetInlineStart = 0,
                            Width = "100%",
                            Top = "100%",
                            Height = treeNodePadding,
                        },
                        [$@"{treeCls}-node-content-wrapper"] = new CSSObject
                        {
                            Color = token.ColorTextDisabled,
                            Cursor = "not-allowed",
                            ["&:hover"] = new CSSObject
                            {
                                Background = "transparent",
                            },
                        },
                        [$@"{treeCls}-checkbox-disabled + {treeCls}-node-selected,&{treeNodeCls}-disabled{treeNodeCls}-selected {treeCls}-node-content-wrapper"] = new CSSObject
                        {
                            BackgroundColor = controlItemBgActiveDisabled,
                        },
                        [$@"{treeNodeCls}-disabled)"] = new CSSObject
                        {
                            [$@"{treeCls}-node-content-wrapper"] = new CSSObject
                            {
                                ["&:hover"] = new CSSObject
                                {
                                    Color = token.NodeHoverColor,
                                },
                            },
                        },
                        [$@"{treeCls}-node-content-wrapper"] = new CSSObject
                        {
                            Background = token.ControlItemBgHover,
                        },
                        [$@"{treeNodeCls}-disabled).filter-node {treeCls}-title"] = new CSSObject
                        {
                            Color = token.ColorPrimary,
                            FontWeight = 500,
                        },
                        ["&-draggable"] = new CSSObject
                        {
                            Cursor = "grab",
                            [$@"{treeCls}-draggable-icon"] = new CSSObject
                            {
                                FlexShrink = 0,
                                Width = titleHeight,
                                TextAlign = "center",
                                Visibility = "visible",
                                Color = colorTextQuaternary,
                            },
                            [$@"{treeNodeCls}-disabled {treeCls}-draggable-icon"] = new CSSObject
                            {
                                Visibility = "hidden",
                            },
                        },
                    },
                    [$@"{treeCls}-indent"] = new CSSObject
                    {
                        AlignSelf = "stretch",
                        WhiteSpace = "nowrap",
                        UserSelect = "none",
                        ["&-unit"] = new CSSObject
                        {
                            Display = "inline-block",
                            Width = indentSize,
                        },
                    },
                    [$@"{treeCls}-draggable-icon"] = new CSSObject
                    {
                        Visibility = "hidden",
                    },
                    [$@"{treeCls}-switcher, {treeCls}-checkbox"] = new CSSObject
                    {
                        MarginInlineEnd = token.Calc(token.Calc(titleHeight).Sub(token.ControlInteractiveSize)).Div(2).Equal(),
                    },
                    [$@"{treeCls}-switcher"] = new CSSObject
                    {
                        ["..."] = GetSwitchStyle(prefixCls, token),
                        Position = "relative",
                        Flex = "none",
                        AlignSelf = "stretch",
                        Width = titleHeight,
                        TextAlign = "center",
                        Cursor = "pointer",
                        UserSelect = "none",
                        Transition = $@"{token.MotionDurationSlow}",
                        ["&-noop"] = new CSSObject
                        {
                            Cursor = "unset",
                        },
                        ["&:before"] = new CSSObject
                        {
                            PointerEvents = "none",
                            Content = "\"\"",
                            Width = titleHeight,
                            Height = titleHeight,
                            Position = "absolute",
                            Left = new CSSObject
                            {
                                _skip_check_ = true,
                                Value = 0,
                            },
                            Top = 0,
                            BorderRadius = token.BorderRadius,
                            Transition = $@"{token.MotionDurationSlow}",
                        },
                        [$@"{treeCls}-switcher-noop):hover:before"] = new CSSObject
                        {
                            BackgroundColor = token.ColorBgTextHover,
                        },
                        [$@"{treeCls}-switcher-icon svg"] = new CSSObject
                        {
                            Transform = "rotate(-90deg)",
                        },
                        ["&-loading-icon"] = new CSSObject
                        {
                            Color = token.ColorPrimary,
                        },
                        ["&-leaf-line"] = new CSSObject
                        {
                            Position = "relative",
                            ZIndex = 1,
                            Display = "inline-block",
                            Width = "100%",
                            Height = "100%",
                            ["&:before"] = new CSSObject
                            {
                                Position = "absolute",
                                Top = 0,
                                InsetInlineEnd = token.Calc(titleHeight).Div(2).Equal(),
                                Bottom = token.Calc(treeNodePadding).Mul(-1).Equal(),
                                MarginInlineStart = -1,
                                BorderInlineEnd = $@"{token.ColorBorder}",
                                Content = "\"\"",
                            },
                            ["&:after"] = new CSSObject
                            {
                                Position = "absolute",
                                Width = token.Calc(token.Calc(titleHeight).Div(2).Equal()).Mul(0.8).Equal(),
                                Height = token.Calc(titleHeight).Div(2).Equal(),
                                BorderBottom = $@"{token.ColorBorder}",
                                Content = "\"\"",
                            },
                        },
                    },
                    [$@"{treeCls}-node-content-wrapper"] = new CSSObject
                    {
                        Position = "relative",
                        MinHeight = titleHeight,
                        PaddingBlock = 0,
                        PaddingInline = token.PaddingXS,
                        Background = "transparent",
                        BorderRadius = token.BorderRadius,
                        Cursor = "pointer",
                        Transition = $@"{token.MotionDurationMid}, border 0s, line-height 0s, box-shadow 0s",
                        ["..."] = GetDropIndicatorStyle(prefixCls, token),
                        ["&:hover"] = new CSSObject
                        {
                            BackgroundColor = nodeHoverBg,
                        },
                        [$@"{treeCls}-node-selected"] = new CSSObject
                        {
                            Color = token.NodeSelectedColor,
                            BackgroundColor = nodeSelectedBg,
                        },
                        [$@"{treeCls}-iconEle"] = new CSSObject
                        {
                            Display = "inline-block",
                            Width = titleHeight,
                            Height = titleHeight,
                            TextAlign = "center",
                            VerticalAlign = "top",
                            ["&:empty"] = new CSSObject
                            {
                                Display = "none",
                            },
                        },
                    },
                    [$@"{treeCls}-unselectable {treeCls}-node-content-wrapper:hover"] = new CSSObject
                    {
                        BackgroundColor = "transparent",
                    },
                    [$@"{treeNodeCls}.drop-container > [draggable]"] = new CSSObject
                    {
                        BoxShadow = $@"{token.ColorPrimary}",
                    },
                    ["&-show-line"] = new CSSObject
                    {
                        [$@"{treeCls}-indent-unit"] = new CSSObject
                        {
                            Position = "relative",
                            Height = "100%",
                            ["&:before"] = new CSSObject
                            {
                                Position = "absolute",
                                Top = 0,
                                InsetInlineEnd = token.Calc(titleHeight).Div(2).Equal(),
                                Bottom = token.Calc(treeNodePadding).Mul(-1).Equal(),
                                BorderInlineEnd = $@"{token.ColorBorder}",
                                Content = "\"\"",
                            },
                            ["&-end:before"] = new CSSObject
                            {
                                Display = "none",
                            },
                        },
                        [$@"{treeCls}-switcher"] = new CSSObject
                        {
                            Background = "transparent",
                            ["&-line-icon"] = new CSSObject
                            {
                                VerticalAlign = "-0.15em",
                            },
                        },
                    },
                    [$@"{treeNodeCls}-leaf-last {treeCls}-switcher-leaf-line:before"] = new CSSObject
                    {
                        Top = "auto !important",
                        Bottom = "auto !important",
                        Height = $@"{Unit(token.Calc(titleHeight).Div(2).Equal())} !important",
                    },
                },
            };
        }

        public static CSSInterpolation GenTreeStyle(string prefixCls, AliasToken & TreeSharedToken & CSSUtil token)
        {
            var treeCls = $@"{prefixCls}";
            var treeNodeCls = $@"{treeCls}-treenode";
            var treeNodePadding = token.Calc(token.PaddingXS).Div(2).Equal();
            var treeToken = MergeToken(token, new object { });
            return new object[]
            {
                GenBaseStyle(prefixCls, treeToken),
                GenDirectoryStyle(treeToken)
            };
        }

        public static TreeSharedToken InitComponentToken(AliasToken token)
        {
            var controlHeightSM = token.ControlHeightSM;
            var controlItemBgHover = token.ControlItemBgHover;
            var controlItemBgActive = token.ControlItemBgActive;
            var titleHeight = controlHeightSM;
            return new TreeSharedToken
            {
                IndentSize = titleHeight,
                NodeHoverBg = controlItemBgHover,
                NodeHoverColor = token.ColorText,
                NodeSelectedBg = controlItemBgActive,
                NodeSelectedColor = token.ColorText,
            };
        }

        public static TreeToken PrepareComponentToken(TreeToken token)
        {
            var colorTextLightSolid = token.ColorTextLightSolid;
            var colorPrimary = token.ColorPrimary;
            return new TreeToken
            {
                ["..."] = InitComponentToken(token),
                DirectoryNodeSelectedColor = colorTextLightSolid,
                DirectoryNodeSelectedBg = colorPrimary,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Tree", (TreeToken token, object { prefixCls }) =>
            {
                return new object[]
                {
                    new object
                    {
                        [token.ComponentCls] = GetCheckboxStyle($@"{prefixCls}-checkbox", token),
                    },
                    GenTreeStyle(prefixCls, token),
                    GenCollapseMotion(token)
                };
            }, PrepareComponentToken);
        }
    }
}