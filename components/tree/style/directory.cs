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
        public static CSSObject GenDirectoryStyle(TreeToken {
  treeCls,
  treeNodeCls,
  directoryNodeSelectedBg,
  directoryNodeSelectedColor,
  motionDurationMid,
  borderRadius,
  controlItemBgHover,
})
        {
            return new CSSObject
            {
                [$@"{treeCls}{treeCls}-directory {treeNodeCls}"] = new CSSObject
                {
                    [$@"{treeCls}-node-content-wrapper"] = new CSSObject
                    {
                        Position = "static",
                        [$@"{treeCls}-drop-indicator)"] = new CSSObject
                        {
                            Position = "relative",
                        },
                        ["&:hover"] = new CSSObject
                        {
                            Background = "transparent",
                        },
                        ["&:before"] = new CSSObject
                        {
                            Position = "absolute",
                            Inset = 0,
                            Transition = $@"{motionDurationMid}",
                            Content = "\"\"",
                        },
                        ["&:hover:before"] = new CSSObject
                        {
                            Background = controlItemBgHover,
                        },
                    },
                    [$@"{treeCls}-switcher, {treeCls}-checkbox, {treeCls}-draggable-icon"] = new CSSObject
                    {
                        ZIndex = 1,
                    },
                    ["&-selected"] = new CSSObject
                    {
                        [$@"{treeCls}-switcher, {treeCls}-draggable-icon"] = new CSSObject
                        {
                            Color = directoryNodeSelectedColor,
                        },
                        [$@"{treeCls}-node-content-wrapper"] = new CSSObject
                        {
                            Color = directoryNodeSelectedColor,
                            Background = "transparent",
                            ["&:before, &:hover:before"] = new CSSObject
                            {
                                Background = directoryNodeSelectedBg,
                            },
                        },
                    },
                },
            };
        }
    }
}