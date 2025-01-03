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
    public partial class InputNumberStyle
    {
        public class ComponentToken : TokenWithCommonCls : SharedComponentToken
        {
            public double ControlWidth { get; set; }
            public double HandleWidth { get; set; }
            public double HandleFontSize { get; set; }
            public string HandleVisible { get; set; }
            public string HandleBg { get; set; }
            public string HandleActiveBg { get; set; }
            public string HandleHoverColor { get; set; }
            public string HandleBorderColor { get; set; }
            public string FilledHandleBg { get; set; }
            public double HandleOpacity { get; set; }
            public double HandleVisibleWidth { get; set; }
        }

        public class InputNumberToken : ComponentToken, SharedInputToken
        {
        }

        public static InputNumberToken PrepareComponentToken(InputNumberToken token)
        {
            var handleVisible = "auto";
            var handleWidth = token.ControlHeightSM - token.LineWidth * 2;
            return new InputNumberToken
            {
                ["..."] = InitComponentToken(token),
                ControlWidth = 90,
                HandleFontSize = token.FontSize / 2,
                HandleActiveBg = token.ColorFillAlter,
                HandleBg = token.ColorBgContainer,
                FilledHandleBg = new TinyColor(token.ColorFillSecondary).OnBackground(token.ColorBgContainer).ToHexString(),
                HandleHoverColor = token.ColorPrimary,
                HandleBorderColor = token.ColorBorder,
                HandleOpacity = handleVisible == true ? 1 : 0,
                HandleVisibleWidth = handleVisible == true ? handleWidth : 0,
            };
        }
    }
}