
// https://lodash.com/docs/4.17.15#throttle
// also known as debounce
function throttle(func, wait) {
    let timeout = null;
    let previous = 0;

    return function () {
        const now = Date.now();
        const remaining = wait - (now - previous);

        if (remaining <= 0 || remaining > wait) {
            if (timeout) {
                clearTimeout(timeout);
                timeout = null;
            }
            previous = now;
            func.apply(this, arguments);
        } else if (!timeout) {
            timeout = setTimeout(() => {
                previous = Date.now();
                timeout = null;
                func.apply(this, arguments);
            }, remaining);
        }
    };
}

function scrollTo(elementId) {
    var element = document.getElementById(elementId);

    if (element)
        element.scrollIntoView({ behavior: "smooth", block: "start", inline: "nearest" });
}

function copyToClipboard(value) {
    if (navigator.clipboard) {
        navigator.clipboard.writeText(value);
    } else {
        fallbackCopyTextToClipboard(value);
    }
}
function disableScroll(disable) {
    if (disable) {
        document.body.style.overflow = 'hidden';
    } else {
        document.body.style.overflow = '';
    }
}