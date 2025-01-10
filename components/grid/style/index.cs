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
    public partial class GridStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
        }

        public class GridRowToken : ComponentToken
        {
        }

        public class GridColToken : ComponentToken
        {
            public double GridColumns { get; set; }
        }

        public static CSSObject GenGridRowStyle(GridToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    Display = "flex",
                    FlexFlow = "row wrap",
                    MinWidth = 0,
                    ["&::before, &::after"] = new CSSObject
                    {
                        Display = "flex",
                    },
                    ["&-no-wrap"] = new CSSObject
                    {
                        FlexWrap = "nowrap",
                    },
                    ["&-start"] = new CSSObject
                    {
                        JustifyContent = "flex-start",
                    },
                    ["&-center"] = new CSSObject
                    {
                        JustifyContent = "center",
                    },
                    ["&-end"] = new CSSObject
                    {
                        JustifyContent = "flex-end",
                    },
                    ["&-space-between"] = new CSSObject
                    {
                        JustifyContent = "space-between",
                    },
                    ["&-space-around"] = new CSSObject
                    {
                        JustifyContent = "space-around",
                    },
                    ["&-space-evenly"] = new CSSObject
                    {
                        JustifyContent = "space-evenly",
                    },
                    ["&-top"] = new CSSObject
                    {
                        AlignItems = "flex-start",
                    },
                    ["&-middle"] = new CSSObject
                    {
                        AlignItems = "center",
                    },
                    ["&-bottom"] = new CSSObject
                    {
                        AlignItems = "flex-end",
                    },
                },
            };
        }

        public static CSSObject GenGridColStyle(GridToken token)
        {
            var componentCls = token.ComponentCls;
            return new CSSObject
            {
                [componentCls] = new CSSObject
                {
                    Position = "relative",
                    MaxWidth = "100%",
                    MinHeight = 1,
                },
            };
        }

        public static CSSObject GenLoopGridColumnsStyle(GridColToken token, string sizeCls)
        {
            var prefixCls = token.PrefixCls;
            var componentCls = token.ComponentCls;
            var gridColumns = token.GridColumns;
            var gridColumnsStyle = new CSSObject
            {
            };
            for (var i = gridColumns; i >= 0; i--)
            {
            }

            return gridColumnsStyle;
        }

        public static CSSObject GenGridStyle(GridColToken token, string sizeCls)
        {
            return GenLoopGridColumnsStyle(token, sizeCls);
        }

        public static CSSObject GenGridMediaStyle(GridColToken token, number screenSize, string sizeCls)
        {
            return new CSSObject
            {
                [$@"{Unit(screenSize)})"] = new CSSObject
                {
                    ["..."] = GenGridStyle(token, sizeCls),
                },
            };
        }

        public static GridToken PrepareRowComponentToken()
        {
            return new GridToken
            {
            };
        }

        public static GridToken PrepareColComponentToken()
        {
            return new GridToken
            {
            };
        }

        public object useRowStyle = GenStyleHooks("Grid", GenGridRowStyle, PrepareRowComponentToken);
        public static object GetMediaSize(AliasToken token)
        {
            var mediaSizesMap = new object
            {
                Xs = token.ScreenXSMin,
                Sm = token.ScreenSMMin,
                Md = token.ScreenMDMin,
                Lg = token.ScreenLGMin,
                Xl = token.ScreenXLMin,
                Xxl = token.ScreenXXLMin,
            };
            return mediaSizesMap;
        }

        public object useColStyle = GenStyleHooks("Grid", (GridToken token) =>
        {
            var gridToken = MergeToken(token, new object { GridColumns = 24, });
            var gridMediaSizesMap = GetMediaSize(gridToken);
            return new object[]
            {
                GenGridColStyle(gridToken),
                GenGridStyle(gridToken, ""),
                GenGridStyle(gridToken, "-xs"),
                Object.Keys(gridMediaSizesMap).Map((object key) =>
                {
                    return GenGridMediaStyle(gridToken, gridMediaSizesMap[key], $@"{key}");
                }).Reduce((object pre, object cur) =>
                {
                    return new object
                    {
                        ["..."] = pre,
                        ["..."] = cur,
                    };
                }, new object { })
            };
        }, PrepareColComponentToken);
    }
}