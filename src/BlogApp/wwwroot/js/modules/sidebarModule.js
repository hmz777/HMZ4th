var sidebar = document.querySelector(".sidebar");
var sidebarBtn = document.querySelector(".sidebar-toggle");

export function InitHandler(componentRef) {
    if (window.matchMedia("(max-width: 991px)").matches) {
        document.onclick = function (e) {
            if (e.target.className.indexOf("side-link") != -1 || e.target.parentElement.parentElement.className.indexOf("side-link") != -1) {
                componentRef.invokeMethodAsync("HideSidebar");
            }
        }
    }
}

export function InitAnimation() {
    anime({
        targets: '.sidebar .links .side-link',
        translateX: [-10, 0],
        opacity: [0, 1],
        easing: "easeOutQuint",
        duration: GlobalOptions.HeaderAnimationDuration,
        delay: anime.stagger(100, { start: 200 }),
        autoPlay: true,
        loop: false
    });

    anime({
        targets: '.sidebar .sidebar-social li',
        translateY: [10, 0],
        opacity: [0, 1],
        easing: "easeOutQuint",
        duration: GlobalOptions.HeaderAnimationDuration,
        delay: anime.stagger(100, { start: 200 }),
        autoPlay: true,
        loop: false
    });
}

export function Dispose() {

}