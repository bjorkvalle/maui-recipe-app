module.exports = {
    content: [
        './**/*.{razor,razor.css,html,cshtml}',
        '../bjorkvalle.UI/**/*.{razor,razor.css,html,cshtml}'
    ],
    theme: {
        container: {
            center: true,
        },
        extend: {
            keyframes: {
                'fade-in': {
                    '0%': {
                        opacity: '0',
                    },
                    '100%': {
                        opacity: '1',
                    },
                },
                'fade-out': {
                    '0%': {
                        opacity: '1',
                    },
                    '100%': {
                        opacity: '0',
                    },
                },
                'slide-in-bottom': {
                    '0%': {
                        transform: 'translateY(1000px)',
                        opacity: '0',
                    },
                    '100%': {
                        transform: 'translateY(0)',
                        opacity: '1'
                    }
                }
            },
            animation: {
                'fade-in': 'fade-in 0.5s ease-out',
                'fade-out': 'fade-out 0.5s ease-out',
                'quick-fade-in': 'fade-in 0.2s ease-out',
                'slide-in-bottom': 'slide-in-bottom 0.2s cubic-bezier(0.250, 0.460, 0.450, 0.940) both'
            },
            maxWidth: {
                'xxs': '10rem',
            },
            backdropBrightness: {
                25: '.25',
            },
            zIndex: {
                '10000': '10000'
            }
        },
    },
    plugins: [require("daisyui")],
    // daisyUI config (optional - here are the default values)
    daisyui: {
        themes: true, // true: all themes | false: only light + dark | array: specific themes like this ["light", "dark", "cupcake"]
        darkTheme: "dark", // name of one of the included themes for dark mode
        base: true, // applies background color and foreground color for root element by default
        styled: true, // include daisyUI colors and design decisions for all components
        utils: true, // adds responsive and modifier utility classes
        rtl: false, // rotate style direction from left-to-right to right-to-left. You also need to add dir="rtl" to your html tag and install `tailwindcss-flip` plugin for Tailwind CSS.
        prefix: "", // prefix for daisyUI classnames (components, modifiers and responsive class names. Not colors)
        logs: true, // Shows info about daisyUI version and used config in the console when building your CSS
    },
}
