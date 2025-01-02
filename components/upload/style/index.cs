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
    public partial class UploadStyle
    {
        public class ComponentToken : TokenWithCommonCls
        {
            public string ActionsColor { get; set; }
        }

        public class UploadToken : ComponentToken
        {
            public string UploadThumbnailSize { get; set; }
            public string UploadProgressOffset { get; set; }
            public string UploadPicCardSize { get; set; }
        }

        public static CSSObject GenBaseStyle(UploadToken token)
        {
            var componentCls = token.ComponentCls;
            var colorTextDisabled = token.ColorTextDisabled;
            return new CSSObject
            {
                [$@"{componentCls}-wrapper"] = new CSSObject
                {
                    ["..."] = ResetComponent(token),
                    [componentCls] = new CSSObject
                    {
                        Outline = 0,
                        ["input[type='file']"] = new CSSObject
                        {
                            Cursor = "pointer",
                        },
                    },
                    [$@"{componentCls}-select"] = new CSSObject
                    {
                        Display = "inline-block",
                    },
                    [$@"{componentCls}-hidden"] = new CSSObject
                    {
                        Display = "none",
                    },
                    [$@"{componentCls}-disabled"] = new CSSObject
                    {
                        Color = colorTextDisabled,
                        Cursor = "not-allowed",
                    },
                },
            };
        }

        public static UploadToken PrepareComponentToken(UploadToken token)
        {
            return new UploadToken
            {
                ActionsColor = token.ColorTextDescription,
            };
        }

        public static UseComponentStyleResult IndexDefault()
        {
            return GenStyleHooks("Upload", (UploadToken token) =>
            {
                var fontSizeHeading3 = token.FontSizeHeading3;
                var fontHeight = token.FontHeight;
                var lineWidth = token.LineWidth;
                var controlHeightLG = token.ControlHeightLG;
                var calc = token.Calc;
                var uploadToken = MergeToken(token, new object { UploadThumbnailSize = calc(fontSizeHeading3).mul(2).Equal(), UploadProgressOffset = calc(calc(fontHeight).div(2)).add(lineWidth).Equal(), UploadPicCardSize = calc(controlHeightLG).mul(2.55).Equal(), });
                return new object[]
                {
                    GenBaseStyle(uploadToken),
                    GenDraggerStyle(uploadToken),
                    GenPictureStyle(uploadToken),
                    GenPictureCardStyle(uploadToken),
                    GenListStyle(uploadToken),
                    GenMotionStyle(uploadToken),
                    GenRtlStyle(uploadToken),
                    GenCollapseMotion(uploadToken)
                };
            }, prepareComponentToken);
        }
    }
}