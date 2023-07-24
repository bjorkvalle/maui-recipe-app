using bjorkvalle.UI.Enums;

namespace bjorkvalle.UI.Utilities
{
    public static class ClassProvider
    {
        public static string ModalSize(ModalSize size) => size switch
        {
            bjorkvalle.UI.Enums.ModalSize.Larger => "max-w-screen-md",
            bjorkvalle.UI.Enums.ModalSize.Large => "max-w-screen-sm",
            _ => null
        };

        public static string ListStyleTypeClass(ListStyleTypes type) => type switch
        {
            ListStyleTypes.Bullets => "list-disc",
            ListStyleTypes.Numbered => "list-decimal",
            _ => null
        };

        public static string JustifyClass(Justify justify) => justify switch
        {
            Justify.Start => "justify-start",
            Justify.Center => "justify-center",
            Justify.End => "justify-end",
            Justify.Between => "justify-between",
            Justify.Around => "justify-around",
            Justify.Evenly => "justify-evenly",
            _ => null
        };

        public static string PositionClass(Position position) => position switch
        {
            Position.Bottom => "bottom",
            Position.Left => "left",
            Position.Right => "right",
            _ => null
        };

        public static string ColorClass(Color color) => color switch
        {
            Color.Primary => "primary",
            Color.Neutral => "neutral",
            Color.Secondary => "secondary",
            Color.Accent => "accent",
            Color.Ghost => "ghost",
            Color.Info => "info",
            Color.Success => "success",
            Color.Warning => "warning",
            Color.Error => "error",
            _ => null
        };

        public static string ColorClass(BadgeColor color) => color switch
        {
            BadgeColor.Primary => "primary",
            BadgeColor.Secondary => "secondary",
            BadgeColor.Accent => "accent",
            BadgeColor.Ghost => "ghost",
            BadgeColor.Info => "info",
            BadgeColor.Success => "success",
            BadgeColor.Warning => "warning",
            BadgeColor.Error => "error",
            _ => null
        };

        public static string ColorClass(LinkColor color) => color switch
        {
            LinkColor.Primary => "primary",
            LinkColor.Secondary => "secondary",
            LinkColor.Accent => "accent",
            LinkColor.Neutral => "neutral",
            _ => null
        };

        public static string ColorClass(CheckboxColor color) => color switch
        {
            CheckboxColor.Primary => "primary",
            CheckboxColor.Secondary => "secondary",
            CheckboxColor.Accent => "accent",
            _ => null
        };

        public static string AlignClass(Align align) => align switch
        {
            Align.Left => "left",
            Align.Right => "right",
            Align.Center => "center",
            _ => null
        };

        public static string SizeClass(Size size) => size switch
        {
            Size.Tiny => "xs",
            Size.Small => "sm",
            Size.Large => "lg",
            _ => null
        };

        public static string TabType(TabTypes type) => type switch
        {
            TabTypes.Bordered => "bordered",
            TabTypes.Lifted => "lifted",
            _ => null
        };

        public static string AlertClass(AlertTypes alert) => alert switch
        {
            AlertTypes.Info => "info",
            AlertTypes.Success => "success",
            AlertTypes.Warning => "warning",
            AlertTypes.Error => "error",
            _ => null
        };

        public static string ButtonColorClass(Color color) => color switch
        {
            Color.Neutral => "neutral",
            Color.Primary => "primary",
            Color.Secondary => "secondary",
            Color.Accent => "accent",
            Color.Ghost => "ghost",
            Color.Link => "link",
            Color.Info => "info",
            Color.Success => "success",
            Color.Warning => "warning",
            Color.Error => "error",
            _ => null
        };

        public static string ButtonShapeClass(ButtonShape shape) => shape switch
        {
            ButtonShape.Square => "square",
            ButtonShape.Circle => "circle",
            _ => null
        };

        public static string WidthClass(Size size) => size switch
        {
            Size.Tiny => "1/4",
            Size.Small => "2/4",
            Size.Default => "3/4",
            Size.Large => "full",
            _ => null
        };
    }
}
